using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using log4net;
using System.Reflection;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoTrainingService;

namespace MongoTraining
{
    class ServiceHost
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private MongoConnection mongoConnection;

        public ServiceHost()
        {
        
        }

        public void Start()
        {
            _log.Info("The service has started");
            mongoConnection = new MongoConnection();

            BsonDocument doc = new BsonDocument
            {
                {"name","tom"}
            };

            mongoConnection.Insert(doc);
        }

        public void Stop()
        {

        }
    }
}
