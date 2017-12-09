using System.ServiceModel;
using EasyBusyService;
using System;

namespace EasyBusyHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost service = new ServiceHost(typeof(Service1));
            service.Open();
            Console.ReadLine();
        }
    }
}
