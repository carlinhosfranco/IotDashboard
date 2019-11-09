using System.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MQTTnet.AspNetCore;
using MQTTnet;
using MQTTnet.Server;

namespace IoT.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            // var mqttServer = new MqttFactory().CreateMqttServer();
            // await mqttServer.StartAsync(new MqttServerOptions());
            // Console.WriteLine("Press any key to exit.");
            // Console.ReadLine();
            // await mqttServer.StopAsync();
            
        }

        // private static IWebHost BuildWebHost(string[] args) =>
        //                 WebHost.CreateDefaultBuilder(args)
        //                         .UseKestrel(o => {
        //                                         o.ListenAnyIP(1883, l => l.UseMqtt()); // mqtt pipeline
        //                                         o.ListenAnyIP(5000); // default http pipeline
        //                                     })
        //                         .UseStartup<Startup>()
        //                         .Build();
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            
            WebHost.CreateDefaultBuilder(args)
                // .UseKestrel(o => {
                //                 o.ListenAnyIP(1883, l => l.UseMqtt()); // mqtt pipeline
                //                 o.ListenAnyIP(5001); // default http pipeline
                //                 //o.ListenLocalhost(1883, l => l.UseMqtt());
                //                 //o.ListenLocalhost(5001);
                //             }
                //             )
                // // .UseContentRoot(Directory.GetCurrentDirectory())
                // // .UseUrls("http://localhost:5000", "https://localhost:5001")
                // .UseIISIntegration()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>();
                //.Build();
    }
}
