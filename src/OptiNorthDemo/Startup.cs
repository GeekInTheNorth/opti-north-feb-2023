namespace OptiNorthDemo;

using Cms.Web.Infrastructure.ServiceExtensions;

using EPiServer.Cms.Shell;
using EPiServer.Cms.Shell.UI;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Scheduler;
using EPiServer.Web.Routing;

using Geta.Optimizely.Categories.Configuration;
using Geta.Optimizely.Categories.Find.Infrastructure.Initialization;
using Geta.Optimizely.Categories.Infrastructure.Initialization;

using OptiNorthDemo.ServiceExtensions;

public class Startup
{
    private readonly IWebHostEnvironment _webHostingEnvironment;

    public Startup(IWebHostEnvironment webHostingEnvironment)
    {
        _webHostingEnvironment = webHostingEnvironment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        if (_webHostingEnvironment.IsDevelopment())
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(_webHostingEnvironment.ContentRootPath, "App_Data"));

            services.Configure<SchedulerOptions>(options => options.Enabled = false);
        }

        services.AddCmsAspNetIdentity<ApplicationUser>()
                .AddCms()
                .AddAdminUserRegistration(x => x.Behavior = RegisterAdminUserBehaviors.Enabled | RegisterAdminUserBehaviors.SingleUserOnly)
                .AddEmbeddedLocalization<Startup>()
                .AddFind();

        services.AddCustomDependencies()
                .AddGetaCategories()
                .AddGetaContentTypeIcons(_webHostingEnvironment)
                .AddRobotsTextHandler()
                .AddSecurityAdmin();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/server-error.html");
        }

        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseSecurityAdmin();

        app.UseGetaCategories();
        app.UseGetaCategoriesFind();
        app.UseGetaContentTypeIcons(env);

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapContent();
            // endpoints.MapRazorPages();
        });
    }
}