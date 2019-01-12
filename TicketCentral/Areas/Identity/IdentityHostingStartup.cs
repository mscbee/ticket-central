using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketCentral.Areas.Identity.Data;
using TicketCentral.Models;

[assembly: HostingStartup(typeof(TicketCentral.Areas.Identity.IdentityHostingStartup))]
namespace TicketCentral.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AdminContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AdminContextConnection")));

                services.AddDefaultIdentity<AdminUser>()
                    .AddEntityFrameworkStores<AdminContext>();
            });
        }
    }
}