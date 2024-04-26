using System;
using cat.itb.M6UF3EA1.Helpers;
using MongoDB.Bson;
using MongoDB.Driver;

namespace UF3_test.connections
{
    public class MongoConnection
    {
        private static String URL = ConfigurationHelper.GetDBUrl();

        public static IMongoDatabase GetDatabase(String database)
        {

            MongoClient dbClient = new MongoClient(URL);
            return dbClient.GetDatabase(database);
        }
        public static MongoClient GetMongoClient()
        {
            return new MongoClient(URL);
        }
    }
}
