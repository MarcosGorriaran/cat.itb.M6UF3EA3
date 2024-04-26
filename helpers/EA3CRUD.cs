using cat.itb.M6UF3EA1.CRUD;
using cat.itb.M6UF3EA1.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using UF3_test.connections;

namespace cat.itb.M6UF3EA3.helpers
{
    public static class EA3CRUD
    {
        public static void ACT1InsertFiles()
        {
            const string DB = "itb";
            CRUDMongoDB<Book> bookCRUD = new CRUDMongoDB<Book>(DB, "book");
            CRUDMongoDB<Product> productCRUD = new CRUDMongoDB<Product>(DB, "product");
            bookCRUD.Insert(Book.ReadJSONArrayFile("FitxersJSON/books2.json"));
            productCRUD.Insert(Product.ReadJSONArray(File.ReadAllText("FitxersJSON/products2.json").Split('\n')));
        }
        public static string dropCollection(string database, string collection)
        {
            IMongoCollection<BsonDocument> conn = MongoConnection.GetDatabase(database).GetCollection<BsonDocument>(collection);
            string resultMsg = conn.CountDocuments(Builders<BsonDocument>.Filter.Empty) + " documents" + Environment.NewLine;
            conn.Database.DropCollection(conn.CollectionNamespace.CollectionName);
            resultMsg += "Remaining Collections: " + Environment.NewLine;
            resultMsg += string.Join(Environment.NewLine, conn.Database.ListCollectionNames().ToList());
            return resultMsg;
        }
        public static string ACT3AShowBookISBN()
        {
            CRUDMongoDB<Book> crud = new CRUDMongoDB<Book>("book");
            string resultMsg = string.Empty;
            IEnumerable<Book> books = crud.Select();
            foreach (Book book in books)
            {
                resultMsg += $"ISBN: {book.isbn}"+Environment.NewLine;
            }
            return resultMsg;
        }
        public static string ACT3BGetOrderedList()
        {
            CRUDMongoDB<Book> crud = new CRUDMongoDB<Book>("book");
            string resultMsg = string.Empty;
            IEnumerable<Book> books = crud.Select().OrderByDescending(element=>element.pageCount);
            foreach (Book book in books)
            {
                resultMsg += $"Títol: {book.title}"+Environment.NewLine+
                    $"Categorias: ("+Environment.NewLine+
                    $"{string.Join(Environment.NewLine,book.categories)}"+Environment.NewLine+
                    $")"+Environment.NewLine;
            }
            return resultMsg;
        }
        public static string ACT3CShowDannoBooks(string searchAuthor)
        {
            CRUDMongoDB<Book> crud = new CRUDMongoDB<Book>("book");
            string resultMsg = string.Empty;
            IEnumerable<Book> books = crud.Select(Builders<Book>.Filter.Eq(element => element.authors, new List<string>() { searchAuthor }));
            foreach (Book book in books)
            {
                resultMsg += $"Títol: {book.title}" + Environment.NewLine +
                    $"Autores: (" + Environment.NewLine +
                    $"{string.Join(Environment.NewLine, book.authors)}" + Environment.NewLine +
                    $")" + Environment.NewLine;
            }
            return resultMsg;
        }
        public static string ACT3DFindSpecificJavaBooks(int minPage, int maxPage)
        {
            CRUDMongoDB<Book> crud = new CRUDMongoDB<Book>("book");
            string resultMsg = string.Empty;
            IEnumerable<Book> books = crud.Select(Builders<Book>.Filter.ElemMatch(element => element.categories,"Java") & 
                Builders<Book>.Filter.Gte(element=>element.pageCount,minPage) &
                Builders<Book>.Filter.Lte(element=>element.pageCount,maxPage));
            foreach (Book book in books)
            {
                resultMsg += $"Títol: {book.title}" + Environment.NewLine +
                    $"Autores: (" + Environment.NewLine +
                    $"{string.Join(Environment.NewLine, book.authors)}" + Environment.NewLine +
                    $")" + Environment.NewLine+
                    $"Paginas: {book.pageCount}"+Environment.NewLine;
            }
            return resultMsg;
        }
        public static string ACT3EShowBooks(params string[] authors)
        {
            CRUDMongoDB<Book> crud = new CRUDMongoDB<Book>("book");
            string resultMsg = string.Empty;
            IEnumerable<Book> books = crud.Select();
            books = books.Where(element =>
            {
                bool result = false;
                foreach (string author in authors)
                {
                    if (element.authors.Contains(author)) return true;
                }
                return false;
            });

            foreach(Book book in books)
            {
                resultMsg += $"Títol: {book.title}" + Environment.NewLine +
                    $"Autores: (" + Environment.NewLine +
                    $"{string.Join(Environment.NewLine, book.authors)}" + Environment.NewLine +
                    $")" + Environment.NewLine;
            }
            return resultMsg;
        }
        public static string ACT3FDiscardBooks(string searchCategory, string discardAuthor)
        {
            CRUDMongoDB<Book> crud = new CRUDMongoDB<Book>("book");
            string resultMsg = string.Empty;
            IEnumerable<Book> books = crud.Select(Builders<Book>.Filter.Not(Builders<Book>.Filter.Eq(element=>element.authors, new List<string>(){discardAuthor})) &
                Builders<Book>.Filter.Eq(element=>element.categories,new List<string>() { searchCategory })).OrderBy(element=>element.title);
            foreach(Book book in books)
            {
                resultMsg += book + Environment.NewLine;
            }
            return resultMsg;
        }
        public static string ACT3GFindLowestPriceProduct()
        {
            CRUDMongoDB<Product> crud = new CRUDMongoDB<Product>("product");
            string resultMsg = string.Empty;
            IEnumerable<Product> products = crud.Select();

            Product product = products.Where(element=>element.price==products.Min(element=>element.price)).First();
            return $"Nom: {product.name}"+Environment.NewLine+
                $"Price: {product.price}"+Environment.NewLine;
        }
        public static string ACT3HFindSumStocks()
        {
            CRUDMongoDB<Product> crud = new CRUDMongoDB<Product>("product");
            return $"sum: "+crud.Select().Sum(element=>element.stock)+Environment.NewLine;
        }
    }
        
}
