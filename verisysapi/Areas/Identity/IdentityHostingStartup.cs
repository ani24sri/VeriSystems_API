using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using verisysapi.Areas.Identity.Data;

[assembly: HostingStartup(typeof(verisysapi.Areas.Identity.IdentityHostingStartup))]
namespace verisysapi.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<verisysapiIdentityDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("verisysapiIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<verisysapiIdentityDbContext>();
            });
        }
    }
}