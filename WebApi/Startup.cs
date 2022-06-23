using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ApplicationServices.Implementsion;
using ApplicationServices.Implementsion.OrderServices;
using ApplicationServices.Implementsion.ProductServices;
using DataAccess.MsSql;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;
using ApplicationServices.Interfaces.Order;
using ApplicationServices.Interfaces.Product;

namespace WebApi
{
    public class Startup
    {
        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _environment = environment;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebApi", Version = "v1"}); });

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IReadOnlyOrderService, ReadOnlyOrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IReadOnlyProductService, ReadOnlyProductService>();
            services.AddAutoMapper(typeof(MapperProfile));

            if (_environment.IsEnvironment("Testing"))
            {
                services.AddDbContext<IDbContext, AppDbContext>(builder =>
                    builder.UseInMemoryDatabase("Test"));
                services.AddDbContext<IReadOnlyDbContext, AppDbContext>(builder =>
                    builder.UseInMemoryDatabase("Test"));
            }

            services.AddDbContext<IDbContext, AppDbContext>(builder =>
                builder.UseSqlServer(Configuration.GetConnectionString("Database")));
            services.AddDbContext<IReadOnlyDbContext, ReadOnlyAppDbContext>(builder =>
                builder.UseSqlServer(Configuration.GetConnectionString("Database")));
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IStatisticService, StatisticService>();
            // services.Decorate<IReadOnlyOrderService, ReadOnlyOrderServiceDecorator>();
            // services.Decorate<IOrderService, OrderServiceDecorator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}