using System;

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

        public static void UseCreateUpdateDateStamper(this IServiceProvider serviceProvider)
        {
            CreateUpdateStamper.Options.CreateUpdateByUserStamperOptions.ServiceProvider = serviceProvider;
        }
    }
}
