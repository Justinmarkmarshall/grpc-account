using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace AccountService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // try adding this to allow BLOOM RPC to hit - it works but means that the client test project will throw an "The SSL connection could not be established" error.
                    // when trying to hit the service (https://localhost:5001) however works when hitting http://0.0.0.0:5001 from BloomRPC
                    //webBuilder.ConfigureKestrel(options =>
                    //{
                    //    // This endpoint will use HTTP/2 and HTTPS on port 5001.
                    //    options.Listen(IPAddress.Any, 5001, listenOptions =>
                    //    {
                    //        listenOptions.Protocols = HttpProtocols.Http2;
                    //    });
                    //});

                    webBuilder.UseStartup<Startup>();
                });
                
    }
}
