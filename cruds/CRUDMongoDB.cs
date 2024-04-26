using System.Collections.Immutable;
using cat.itb.M6UF3EA1.Helpers;
using cat.itb.M6UF3EA1.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using UF3_test.connections;

namespace cat.itb.M6UF3EA1.CRUD
{
    public class CRUDMongoDB<T> where T : Model<T>
    {
        protected IMongoCollection<T> Collection;

        private string GetDatabaseName()
        {
            return Collection.Database.DatabaseNamespace.DatabaseName;
        }
        private string GetCollectionName()
        {
            return Collection.CollectionNamespace.CollectionName;
        }
        private IMongoCollection<BsonDocument> GetBsonCollection()
        {
            return MongoConnection.GetDatabase(GetDatabaseName()).GetCollection<BsonDocument>(GetCollectionName());
        }
        public IMongoDatabase GetDatabase()
        {
            return Collection.Database;
        }
        public CRUDMongoDB(string database, string collection)
        {
            Collection = MongoConnection.GetDatabase(database).GetCollection<T>(collection);
        }
        public CRUDMongoDB(string collection) : this(ConfigurationHelper.GetDB(), collection) { }
        public CRUDMongoDB():this(ConfigurationHelper.GetCollection()) { }

        public void Insert(T element)
        {
            Collection.InsertOne(element);
        }
        public void Insert(params T[] elements)
        {
            Insert(elements.ToImmutableArray());
        }
        public void Insert(IEnumerable<T> elements)
        {
            List<T> list = elements.ToList();
            for (int i = 0; i<list.Count(); i++) 
            {
                Insert(list[i]);
            }
        }
        public long Delete(FilterDefinition<T> target)
        {
            
            return Collection.DeleteMany(target).DeletedCount;
        }
        public long Delete(FilterDefinition<BsonDocument> target)
        {
            IMongoCollection<BsonDocument> bson = GetBsonCollection();
            return bson.DeleteMany(target).DeletedCount;
        }
        public long Update(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            try
            {
                return Collection.UpdateMany(filter, update).MatchedCount;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }
        public long Update(FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update)
        {
            IMongoCollection<BsonDocument> bson = GetBsonCollection();
            try
            {
                return bson.UpdateMany(filter, update).MatchedCount;
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public List<T> Select()
        {   
            return Collection.Find(element => true).ToList();
        }
        public List<BsonDocument> SelectBson()
        {
            IMongoCollection<BsonDocument> bson = GetBsonCollection();

            return bson.Find(Builders<BsonDocument>.Filter.Empty).ToList();
        }
        public List<T> Select(FilterDefinition<T> condition)
        {
            return Collection.Find(condition).ToList();
        }
        public List<BsonDocument> Select(FilterDefinition<BsonDocument> condition)
        {
            IMongoCollection<BsonDocument> bson = GetBsonCollection();

            return bson.Find(condition).ToList();
        }
        public List<BsonDocument> Select(FilterDefinition<T> filter, ProjectionDefinition<T> projection)
        {
            List<BsonDocument> bson = Collection.Find(filter).Project(projection).ToList();
            return bson;
        }
        public List<BsonDocument> Select(FilterDefinition<BsonDocument> filter, ProjectionDefinition<BsonDocument> projection)
        {
            IMongoCollection<BsonDocument> bson = GetBsonCollection();
            List<BsonDocument> result = bson.Find(filter).Project(projection).ToList();
            return result;
        }
        public List<T> Select(SortDefinition<T> sort)
        {
            return Collection.Find(_ => true).Sort(sort).ToList();
        }
        public List<BsonDocument> Select(SortDefinition<BsonDocument> sortDefinition)
        {
            IMongoCollection<BsonDocument> bson = GetBsonCollection();
            return bson.Find(Builders<BsonDocument>.Filter.Empty).Sort(sortDefinition).ToList();
        }
        public List<BsonDocument> Select(SortDefinition<BsonDocument> sortDefinition,ProjectionDefinition<BsonDocument> projection)
        {
            IMongoCollection<BsonDocument> bson = GetBsonCollection();
            return bson.Find(Builders<BsonDocument>.Filter.Empty).Project(projection).Sort(sortDefinition).ToList();
        }
        public void ImportJSONElements(params string[] json)
        {
            
            foreach(string element in json)
            {
                MongoConnection.GetDatabase(ConfigurationHelper.GetDB()).GetCollection<BsonDocument>(Collection.CollectionNamespace.CollectionName).InsertOne(BsonDocument.Parse(element));
            }
        }
    }
}
