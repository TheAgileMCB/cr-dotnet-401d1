using IdentityDemo.Data;
using IdentityDemo.Models.Interfaces;
using IdentityDemo.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityDemo
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // this will allow us to use the Controllers for our API calls without the req of razor pages or views
            services.AddControllers();

            services.AddDbContext<BlogDbContext>(options =>
            {
                //Install-Package Microsoft.EntityFrameworkCore.SqlServer
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<UsersDbContext>(options =>
            {
                //Install-Package Microsoft.EntityFrameworkCore.SqlServer
                options.UseSqlServer(Configuration.GetConnectionString("UsersConnection"));
            });

            services.AddTransient<IPostManager, PostService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // using the default is fine and a nice shortcut
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
