using System;
using IoT.Domain.Entities;
using IoT.Domain.Repositories;
using IoT.Infra.Data;
using IoT.Infra.Repositories;
using IoT.Infra.SocketMeddlewares;
using IoT.Infra.SocketsManagers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MQTTnet.AspNetCore;

namespace IoT.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
                    // //this adds a hosted mqtt server to the services
                    // services.AddHostedMqttServer(builder => builder.WithDefaultEndpointPort(1883));
                
                    // //this adds tcp server support based on Microsoft.AspNetCore.Connections.Abstractions
                    // services.AddMqttConnectionHandler();
                
                    // //this adds websocket support
                    // services.AddMqttWebSocketServerAdapter();

            services.AddDbContext<AppDbContext>(options => 
            {
                options.UseSqlite(Configuration.GetConnectionString("SqliteConnectionString"));
            });

            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<ITemperatureRepository, TemperatureRepository>();
            services.AddSingleton<TemperatureSocketManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            
                app.UseHsts();
                app.UseExceptionHandler("Home/Error");
            }
            
            app.UseStaticFiles();
            app.UseWebSockets();
            app.UseMiddleware<TemperatureSocketMiddleware>();
         
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                    
            });
        }
    }
}
