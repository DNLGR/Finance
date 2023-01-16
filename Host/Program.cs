using System;
using System.ServiceModel;

namespace Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(FinanceServices.DatabaseService)))
            {
                host.Open();

                Console.WriteLine("Host is now ready!");

                //Console.WriteLine(host.);

                Console.ReadKey();
            }
        }
    }
}
