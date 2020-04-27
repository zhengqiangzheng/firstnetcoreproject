using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication1.Services;

namespace WebApplication1
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();//基本功能
            //services.AddMvc();//功能都有
            //services.AddControllers();//五页面,做api
            services.AddSingleton<IClock, ChinaClock>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.Configure<ThreeOptions>(configuration.GetSection("Three"));
        }
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
            //var three = configuration["Three:BlodDepartmentEmployeeCountThreshold"];
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            //app.UseMvc();
            app.UseHttpsRedirection();
            app.UseRouting();
            //app.Run(async context =>
            //{
            //    context.Response.ContentType = "text/plain;charset=utf-8";
            //    await context.Response.WriteAsync("你好啊黑黑黑");
            //});
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapGet("/hello/{name:alpha}", async context =>
                {
                    var name = context.Request.RouteValues["name"];
                    await context.Response.WriteAsync($"Hello World!{name}");
                });
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Department}/{action=Index}/{id?}");

            });
        }
    }
}
