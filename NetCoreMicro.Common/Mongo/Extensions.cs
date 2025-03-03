﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreMicro.Common.Mongo
{
    public static class Extensions
    {
        public static void AddMongoDB(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<MongoOptions>(configuration.GetSection("mongo"));
            service.AddSingleton<MongoClient>(c =>
            {
                var optionsMongo = c.GetService<IOptions<MongoOptions>>();

                return new MongoClient(optionsMongo.Value.ConnectionString);
            });
            service.AddScoped<IMongoDatabase>(c =>
            {
                var optionsMongo = c.GetService<IOptions<MongoOptions>>();
                var clientMongo = c.GetService<MongoClient>();

                return clientMongo.GetDatabase(optionsMongo.Value.Database);
            });

            service.AddScoped<IDatabaseInitializer, MongoInitializer>();
            service.AddScoped<IDatabaseSeeder, MongoSeeder>();
        }
    }
}
