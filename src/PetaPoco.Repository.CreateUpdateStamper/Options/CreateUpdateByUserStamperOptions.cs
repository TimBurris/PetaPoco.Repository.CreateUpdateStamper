using System;

namespace PetaPoco.Repository.CreateUpdateStamper.Options
{
    public class CreateUpdateByUserStamperOptions
    {
        private readonly Func<object> _userIdProvider;
        private readonly Func<IServiceProvider, object> _serviceUserIdProvider;
        public CreateUpdateByUserStamperOptions(Func<object> userIdProvider)
        {
            _userIdProvider = userIdProvider;
        }
        public CreateUpdateByUserStamperOptions(Func<IServiceProvider, object> serviceUserIdProvider)
        {
            _serviceUserIdProvider = serviceUserIdProvider;
        }
        public string UpdateByPropertyName { get; set; }
        public string CreatedByPropertyName { get; set; }

        public bool StampWithUpdatedBy { get; set; } = true;
        public bool StampWithCreatedBy { get; set; } = true;

        public object GetUserId()
        {
            if (_userIdProvider != null)
                return _userIdProvider.Invoke();

            return _serviceUserIdProvider.Invoke(ServiceProvider);
        }

        internal static IServiceProvider ServiceProvider { get; set; }

    }
}

