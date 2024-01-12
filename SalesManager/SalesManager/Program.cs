using Microsoft.EntityFrameworkCore;
using SalesManager.BLL.Base;
using SalesManager.BLL.Interfaces;
using SalesManager.BLL.Services;
using SalesManager.Common;
using SalesManager.Components;
using SalesManager.DAL.DatabaseContext;

namespace SalesManager
{
    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Mains the.
        /// </summary>
        /// <param name="args">The args.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveWebAssemblyComponents();
            builder.Services.AddBlazorBootstrap();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSignalR();
            builder.Services.AddControllers();

            builder.Services.AddDbContext<SalesManagerContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));
            builder.Services.AddScoped<IBaseService, BaseService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IWindowService, WindowService>();
            builder.Services.AddScoped<ISubElementService, SubElementService>();
            builder.Services.AddScoped<ISalesManagerContext, SalesManagerContext>();

            builder.Services.AddSingleton(AutoMapperConfiguration.Configure());

            //builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.MapRazorComponents<App>()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.UseRouting();

            app.UseAntiforgery();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });

            using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<SalesManagerContext>();
                context.Database.Migrate();
            }

            app.Run();
        }
    }
}
