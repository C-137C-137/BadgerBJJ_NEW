using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.DisplayManagement.Notify;
using OrchardCore.DisplayManagement;
using OrchardCore.Modules;
using BadgerBJJ.Module.Models;
using OrchardCore.Data.Migration;
using OrchardCore.Data;
using OrchardCore.DisplayManagement.Handlers;
using BadgerBJJ.Module.Migrations;
using BadgerBJJ.Module.Indexes;
using BadgerBJJ.Module.Drivers;

namespace BadgerBJJ.Module
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<INotifier, Notifier>();

            //enables  MVC controllers and Razor views
            services.AddControllersWithViews();

            //notifier service registration
            services.AddScoped<INotifier, Notifier>();

            //OrchardCore ContMgmtSys configuration
            services.AddOrchardCore().AddMvc().AddTheming();

            //Appointment~Schedule related services
            services.AddScoped<IDisplayManager<ScheduleModel>, DisplayManager<ScheduleModel>>();
            services.AddScoped<IDisplayDriver<ScheduleModel>, ScheduleDisplayDriver>();
            services.AddDataMigration<ScheduleMigrations>();
            services.AddIndexProvider<ScheduleIndexProvider>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            // Default route to main Page
            routes.MapAreaControllerRoute(
                name: "Index",
                areaName: "BadgerBJJ.Module",
                pattern: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );

            // Specific routes for each page
            routes.MapAreaControllerRoute(
                name: "Schedule",
                areaName: "BadgerBJJ.Module",
                pattern: "Schedule/Schedule",
                defaults: new { controller = "Schedule", action = "Schedule" }
            );

            routes.MapAreaControllerRoute(
                name: "About",
                areaName: "BadgerBJJ.Module",
                pattern: "About/About",
                defaults: new { controller = "About", action = "About" }
            );

            routes.MapAreaControllerRoute(
                name: "Contact",
                areaName: "BadgerBJJ.Module",
                pattern: "Contact/Contact",
                defaults: new { controller = "Contact", action = "Contact" }
            );

            //routes.MapAreaControllerRoute(
            //name: "BadgerBJJ.Module.Default",
            //areaName: "BadgerBJJ.Module",
            //pattern: "{controller=Home}/{action=Index}/{id?}"
            //);
        }
    }
}
