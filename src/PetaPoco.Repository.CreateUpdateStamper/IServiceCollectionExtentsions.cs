using System;
using System.Collections.Generic;
using System.Text;

namespace PetaPoco.Repository
{
    public static class IServiceCollectionExtentsions
    {

        public static Abstractions.ICrudRepositoryServiceCollection UseCreateUpdateByUserStamper(this Abstractions.ICrudRepositoryServiceCollection services, CreateUpdateStamper.Options.CreateUpdateByUserStamperOptions options)
        {
            services.Add(new CreateUpdateStamper.CreateUpdateByUserStamper(options));

            return services;
        }


        public static Abstractions.ICrudRepositoryServiceCollection UseCreateUpdateDateStamper(this Abstractions.ICrudRepositoryServiceCollection services, CreateUpdateStamper.Options.CreateUpdateDateStamperOptions options)
        {
            services.Add(new CreateUpdateStamper.CreateUpdateDateStamper(options));

            return services;
        }
    }
}
