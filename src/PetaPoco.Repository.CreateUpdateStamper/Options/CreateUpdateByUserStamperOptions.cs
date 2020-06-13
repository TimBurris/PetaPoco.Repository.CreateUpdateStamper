using System;

namespace PetaPoco.Repository.CreateUpdateStamper.Options
{
    public class CreateUpdateByUserStamperOptions
    {
        private readonly Func<IServiceProvider, object> _userIdProvider;

        public CreateUpdateByUserStamperOptions(Func<IServiceProvider, object> userIdProvider)
        {
            _userIdProvider = userIdProvider;
        }
        public string UpdateByPropertyName { get; set; }
        public string CreatedByPropertyName { get; set; }

        public bool StampWithUpdatedBy { get; set; } = true;
        public bool StampWithCreatedBy { get; set; } = true;

        public object GetUserId()
        {
            return _userIdProvider.Invoke(ServiceProvider);
        }

        internal static IServiceProvider ServiceProvider { get; set; }

    }
}

