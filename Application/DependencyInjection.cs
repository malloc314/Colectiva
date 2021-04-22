using Application.Interfaces;
using Application.Mappings;
using Application.Models;
using Application.Services;
using Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IHistoricalSequenceService, HistoricalSequenceService>();
            services.AddScoped<IPseudoProbableSequenceService, PseudoProbableSequenceService>();

            services.AddScoped<IValidator<PseudoProbableSequenceQuantity>, PseudoProbableSequenceValidator>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
