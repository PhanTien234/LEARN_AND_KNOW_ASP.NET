using System;
// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();

// app.MapGet("/", () => "Hello ASP.NET Core 23! jsjskj");

// app.Run();
namespace hello_app{
    public class Program{
        /*
            To setup and run application for ASP.NET: Basic,
            + Create Host object (implement IHost):
                - Inside it will contain Dependence Injection (ID): IServiceProvider (ServiceCollection) to take out service
                - Logging (ILogging)
                - Configuration of Application
                - contain class implement from interface IHostedService => have StartAsync method: Run HTTP Server (built-in dotnet(known as Kestrel Http))
            + For setup and run Host, we will implement all step following here:
                - Step 1: Create IHostBuilder
                - Step 2: Configuration, sign up services
                - Step 3: call IHostBuilder.Build() => to create Host (IHost)
                - Step 4: To run it, just call Host.Run() method
            In ASP.NET, When receive request => all request go through codes and handle return respond corresponding response. (the component that request go through called ((pipeline) => It is a string Middleware)
        */
        public static void Main(string[] args){
            Console.WriteLine("Start App");
            IHostBuilder builder = Host.CreateDefaultBuilder(args);
            // Configuration default for HOST create
            builder.ConfigureWebHostDefaults((IWebHostBuilder webBuilder) =>{
                // Tuy bien them ve Host
                //webBuilder
                // if you want to change folder default is wwwroot, we can configure host like bellow 
                //webBuilder.UseWebRoot("publish");
                webBuilder.UseStartup<MyStartup>();
                //right now, it just knows which class to use to build Pipeline
            });
            IHost host = builder.Build();
            host.Run();
        }
    }

}

