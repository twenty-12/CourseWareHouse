using CourseWarehouse.Data;
using CourseWarehouse.Data.Repositories;
using CourseWarehouse.Services;
using CourseWarehouse.Services.HostedService;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace CourseWareHouse.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<InMemoryContext>(options => 
                options.UseInMemoryDatabase("CourseWarehouse"),
                ServiceLifetime.Singleton);
            
            builder.Services.AddScoped<ICourseRepository, InMemoryCourseRepository>();
            builder.Services.AddScoped<ITagRepository, InMemoryTagRepository>();
            builder.Services.AddScoped<IUserRepository, InMemoryUserRepository>();
            
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<ITagService, TagService>();
            builder.Services.AddScoped<IRecommendationService, RecommendationService>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddHostedService<InMemoryDataFillHostedService>();
            
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.WriteIndented = true;
                });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapControllers();

            app.Run();
        }
    }
}
