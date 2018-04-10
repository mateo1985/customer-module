namespace SimpleModularApplication
{
    using Core.Common;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using SimpleModularApplication.Services;

    public class Startup
    {
        private IConfiguration configuration;
        private IHostingEnvironment env;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            this.configuration = configuration;
            this.env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var mvcBuilder = services.AddMvc();
            var modulesBuilder = new ModulesBuilder(mvcBuilder, services, env, configuration);
            var modules = modulesBuilder.LoadModules();
            services.AddSingleton(typeof(IModuleService), new ModuleService(modules));
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc(this.RouteBuilder);
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Not found");
            });
        }

        private void RouteBuilder(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
