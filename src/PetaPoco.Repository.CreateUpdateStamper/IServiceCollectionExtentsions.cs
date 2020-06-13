using PetaPoco.Repository.CreateUpdateStamper;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace PetaPoco.Repository
{
    public static class IServiceCollectionExtentsions
    {

        public static Abstractions.ICrudRepositoryServiceCollection AddCreateUpdateByUserStamper(this Abstractions.ICrudRepositoryServiceCollection services, CreateUpdateStamper.Options.CreateUpdateByUserStamperOptions options)
        {
            services.Add(new CreateUpdateStamper.CreateUpdateByUserStamper(options));

            return services;
        }


        public static Abstractions.ICrudRepositoryServiceCollection AddCreateUpdateDateStamper(this Abstractions.ICrudRepositoryServiceCollection services, CreateUpdateStamper.Options.CreateUpdateDateStamperOptions options)
        {
            services.Add(new CreateUpdateStamper.CreateUpdateDateStamper(options));

            return services;
        }

        public static void UseCreateUpdateDateStamper(this IApplicationBuilder app)
        {
            CreateUpdateStamper.Options.CreateUpdateByUserStamperOptions.ServiceProvider = app.ApplicationServices;
        }
    }
}
