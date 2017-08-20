using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using log4net;
using System.Reflection;
using MongoDB.Bson;

namespace MongoTrainingService
{
    class MongoConnection
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private IMongoClient client = new MongoClient();
        private IMongoDatabase database;
        private IMongoCollection<BsonDocument> collection;
      

        public MongoConnection()
        {
            try
            {
                IMongoClient client = new MongoClient(Settings.Default.MongoConnectionString);
                database = client.GetDatabase(Settings.Default.MongoDatabase);
                collection = database.GetCollection<BsonDocument>(Settings.Default.MongoCollection);

                _log.InfoFormat("Succesfully connected to Mongo at {0}", Settings.Default.MongoConnectionString);
            }
            catch(Exception e)
            {
                _log.Error("Exception caught while connection to Mongo: ", e);
            }
        }

        public void Insert(BsonDocument doc)
        {
            try
            {
                collection.InsertOne(doc);
                _log.Info("Document inserted into Mongo");
            }
            catch (Exception e)
            {
                _log.Error("Error encountered inserting doucment into Mongo: ", e);
            }         
        }
    }
}
