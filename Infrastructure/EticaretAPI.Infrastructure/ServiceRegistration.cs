﻿
using EticaretAPI.Application.Abstractions.Storage;
using EticaretAPI.Infrastructure.Enums;
using EticaretAPI.Infrastructure.services;
using EticaretAPI.Infrastructure.services.Storage;
using EticaretAPI.Infrastructure.services.Storage.Local;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
        }
        //public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : class, IStorage
        //{
        //    serviceCollection.AddScoped<IStorage,T>();
        //}
        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType  )
        {
            switch (storageType) 
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }
    }
}
