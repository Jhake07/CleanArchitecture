﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitectureSystem.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            //services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
