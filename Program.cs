
using Microsoft.EntityFrameworkCore;
using StoreBackendQL.Essentials;
using StoreBackendQL.GraphQL.Mutations;
using StoreBackendQL.GraphQL.Queries;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StoreBackendQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreDevConnection")));


            builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<ProductMutation>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.UseRouting();

            app.MapGraphQL();
            app.Run();
        }
    }
}
