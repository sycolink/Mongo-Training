using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using log4net;
using System.Reflection;

namespace MongoTraining
{
    class ServiceHost
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public ServiceHost()
        {
          
        }

        public void Start()
        {
            _log.Info("The service has started");
        }

        public void Stop()
        {

        }
    }
}
