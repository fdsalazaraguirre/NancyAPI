using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using NancyAPI;
using Nancy.Hosting.Self;
using NancyAPI.Services;

namespace NancyAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            HostConfiguration hostConfigs = new HostConfiguration();
            hostConfigs.UrlReservations.CreateAutomatically = true;

            Uri uri = new Uri("http://localhost:1234");
            var host = new NancyHost(hostConfigs, uri);
            host.Start();
            Console.WriteLine("Running on http://localhost:1234");
            
            Console.ReadLine();
            host.Stop();
        }
    }
}
