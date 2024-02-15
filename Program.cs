using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using Play.Catalog.Entities;
using Play.Catalog.Repository;
using Play.Catalog.Service.Settings;


public class Program

{
    static void Main() { }

    private ServiceSettings? serviceSettings;

    public Program(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

        serviceSettings = Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

        services.AddMongo(Configuration).AddMongoRepository<Item>("items");


        services.AddControllers(options =>
        {
            // SuppressAsyncSuffixInActionNames is used to prevent removing any suffix from your code
            options.SuppressAsyncSuffixInActionNames = false;
        });

        services.AddSingleton<IRepository<Item>>(serviceProvider =>
        {
            var database = serviceProvider.GetService<IMongoDatabase>();
            return new MongoRepository<Item>(database, "items");
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();


        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

 } 
