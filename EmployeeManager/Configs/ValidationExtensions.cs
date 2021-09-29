using System;
using EmployeeManager.Services;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManager.Configs
{
    public static class ValidationExtensions
    {

        public static IServiceCollection AddValidation(this IServiceCollection services, Action<FluentValidationMvcConfiguration> configurationExpression = null)
        {
            var cfg = services.BuildServiceProvider().GetService<ValidationConfig>();
            if (cfg.Enabled)
            {
                services.AddFluentValidation(configurationExpression);
            }
            return services;
        }
    }
}
