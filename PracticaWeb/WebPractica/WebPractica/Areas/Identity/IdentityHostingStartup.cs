using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebPractica.Data;

[assembly: HostingStartup(typeof(WebPractica.Areas.Identity.IdentityHostingStartup))]
namespace WebPractica.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                //services.AddDbContext<WebPracticaContext>(options =>
                //    options.UseSqlServer(
                //        context.Configuration.GetConnectionString("WebPracticaContextConnection")));

                //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //    .AddEntityFrameworkStores<WebPracticaContext>();
            });
        }
    }
}