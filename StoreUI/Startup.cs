using Blazored.LocalStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoreUI.Data;
using StoreUI.Domain;
using StoreUI.Handlers;
using StoreUI.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            var appSettingSection = Configuration.GetSection("EmailConfigs");
            services.Configure<EmailConfigs>(appSettingSection);
            var address = Configuration.GetSection("EndPointsConfig");
            services.Configure<EndPointsConfig>(address);
            services.AddScoped<Cart>();
            services.AddTransient<ValidateHeaderHandler>();
            services.AddHttpClient<IUserAuthenticationService, UserAuthenticationService>();
            services.AddHttpClient<IAppProductService, AppProductService>()
                 .AddHttpMessageHandler<ValidateHeaderHandler>();
            services.AddHttpClient<IDigiShopService<ProductModel>, DigiShopService<ProductModel>>()
                .AddHttpMessageHandler<ValidateHeaderHandler>();
            services.AddHttpClient<IDigiShopService<OrderModel>, DigiShopService<OrderModel>>()
                 .AddHttpMessageHandler<ValidateHeaderHandler>();
            services.AddBlazoredLocalStorage();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
