using Microsoft.Extensions.Configuration;

namespace cat.itb.M6UF3EA1.Helpers
{
    public static class ConfigurationHelper
    {
        const string ConfPath = "appsettings.json";
        const string URLDataName = "MongoURL";
        const string DBDataName = "DB";
        const string CollectionDataName = "Collection";
        public static string GetDBUrl()
        {
            try
            {
                IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(ConfPath, optional: false, reloadOnChange: true)
                .Build();

                return config.GetConnectionString(URLDataName);
            }
            catch(FileNotFoundException)
            {
                throw new FileNotFoundException("The appsettings.json has not been added to the folder of the program, please add it to "+Directory.GetCurrentDirectory()+", you can find it at the root of the proyect folder.");
            }
            
        }
        public static string GetDB()
        {
            try
            {
                IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(ConfPath, optional: false, reloadOnChange: true)
                .Build();

                return config.GetConnectionString(DBDataName);
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("The appsettings.json has not been added to the folder of the program, please add it to " + Directory.GetCurrentDirectory() + ", you can find it at the root of the proyect folder.");
            }
            
        }
        public static string GetCollection()
        {
            try
            {
                IConfiguration config = new ConfigurationBuilder()
                                .AddJsonFile(ConfPath, optional: false, reloadOnChange: true)
                                .Build();

                return config.GetConnectionString(CollectionDataName);
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("The appsettings.json has not been added to the folder of the program, please add it to " + Directory.GetCurrentDirectory() + ", you can find it at the root of the proyect folder.");
            }
            
        }
    }
}
