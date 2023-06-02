
using BlogManagementAPI.Data;
using BlogManagementAPI.Repositories;
using BlogManagementAPI.Repositories.DTO;
using BlogManagementAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using ModelsLibraryBlog;

namespace BlogManagementAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("https://www.alvin-strandberg.se", "http://localhost:5173")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
            });

            builder.Services.AddScoped<IRepository<Post>, PostRepository>();
            builder.Services.AddScoped<IPostRepository<PostGetDTO>, PostRepository>();
            builder.Services.AddScoped<UserRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            // Enable CORS
            app.UseCors();
            //app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}