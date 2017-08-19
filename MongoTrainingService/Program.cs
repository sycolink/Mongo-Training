using Topshelf;
using log4net.Config;

namespace MongoTraining
{
    public class Program
    {
        public static void Main()
        {
            HostFactory.Run(x =>                                 //1
            {
                XmlConfigurator.Configure();
                x.UseLog4Net();
                x.Service<ServiceHost>(s =>                        //2
                {
                    s.ConstructUsing(name => new ServiceHost());     //3
                    s.WhenStarted(tc => tc.Start());              //4
                    s.WhenStopped(tc => tc.Stop());  
       //5
                });
                x.RunAsLocalSystem();                            //6

                x.SetDescription("A simple service to play around with MongoDB");        //7
                x.SetDisplayName("Mongo Trainings");                       //8
                x.SetServiceName("Mongo.Training");                       //9
            });                                                  //10
        }
    }
}
