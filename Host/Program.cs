using System;
using System.Linq;
using System.ServiceModel;

namespace Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(FinanceServices.Components.DatabaseService)))
            {
                host.Open();

                Console.WriteLine("Host is starting ...\n");

                Console.WriteLine($"Host name: {host.Description.Name} " +
                                  $"Host configuration name: {host.Description.ConfigurationName} \n" +
                                  $"Host namespave: {host.Description.Namespace} \n\n");

                foreach (var item in host.Description.Endpoints)
                {
                    Console.WriteLine($"Endpoint name: {item.Name}, endpoint adress: {item.Address}, endpoint contract {item.Contract} \n");
                }    

                Console.WriteLine($"\nCurrent state: {host.State}, Time to start: {DateTime.Now}");

                while (true)
                {
                    Execute(Console.ReadLine(), host);
                }
            }
        }

        private static void Execute(string command, ServiceHost host) 
        {
            switch (command.ToLower())
            {
                case "cls": Console.Clear();
                    break;

                case "status":
                    Console.WriteLine($"Current state: {host.State}, Time to start: {DateTime.Now}");
                    break;
            }
        }
    }
}
