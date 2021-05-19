using Application;
using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Application.Validators;
using Domain.Interfaces;
using FluentValidation.AspNetCore;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Middlewares;

namespace WebAPI.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddApplication();
            
            services.AddInfrastructure();
            
            services.AddControllers()
                .AddFluentValidation(options => 
                {
                    options.RegisterValidatorsFromAssemblyContaining<PseudoProbableSequenceValidator>();
                })
                .AddXmlSerializerFormatters();

            services.AddAuthentication();

            services.AddScoped<ErrorHandlingMiddleware>();
        }
    }
}
