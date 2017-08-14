using System;
using System.Collections.Generic;
using System.Text;

namespace DataPersistence.Controllers
{
   
    public class MongoDbAccessLayer
    {
        private const string connectionString = "mongodb://mikeDBA:<Password>@cluster0-shard-00-00-jvowz.mongodb.net:27017,cluster0-shard-00-01-jvowz.mongodb.net:27017,cluster0-shard-00-02-jvowz.mongodb.net:27017/<DATABASE>?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin";

        public MongoDbAccessLayer()
        {

        }

        public bool Save()
        {
            return true;
        }
    }
}
