using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using CarRental.Service;

namespace CarRental.HostService
{
    class Program
    {
        static void Main()
        {
            using (ServiceHost wcfHost = new ServiceHost(typeof(CarRentalService)))
            {
                wcfHost.Open();
                Console.WriteLine("WCF service started  @ " + DateTime.Now.ToString());

                using (WebServiceHost restHost = new WebServiceHost(typeof(RestService), new Uri("http://localhost:8080/Api/")))
                {
                    ServiceEndpoint ep = restHost.AddServiceEndpoint(typeof(IRestService), new WebHttpBinding(), "");

                    restHost.Description.Endpoints[0].Behaviors.Add(new WebHttpBehavior { HelpEnabled = true });

                    ServiceDebugBehavior sdb = restHost.Description.Behaviors.Find<ServiceDebugBehavior>();

                    sdb.IncludeExceptionDetailInFaults = true;
                    //sdb.HttpsHelpPageEnabled = true;

                    restHost.Open();
                    Console.WriteLine("Rest service started  @ " + DateTime.Now.ToString());

                    Console.ReadLine();
                }
            }
        }
    }
}
