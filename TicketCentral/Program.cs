using TicketCentral.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace TicketCentral
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var customerContext = services.GetRequiredService<CustomerContext>();
                    customerContext.Database.EnsureCreated();

                    var eventContext = services.GetRequiredService<EventContext>();
                    eventContext.Database.EnsureCreated();

                    var ticketContext = services.GetRequiredService<TicketContext>();
                    ticketContext.Database.EnsureCreated();

                    var venueContext = services.GetRequiredService<VenueContext>();
                    venueContext.Database.EnsureCreated();

                    var context = services.GetRequiredService<BookingContext>();
                    context.Database.EnsureCreated();
                    DbInitializer.Initialize(context);
                }
                catch(Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured creating the DB.");
                }
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

    }
}
