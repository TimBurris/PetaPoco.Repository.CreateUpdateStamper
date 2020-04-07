using System;

namespace PetaPoco.Repository.CreateUpdateStamper.Options
{
    public class CreateUpdateByUserStamperOptions
    {
        public CreateUpdateByUserStamperOptions(Func<object> getUserIdCallback)
        {
            this.GetUserId = getUserIdCallback;
        }
        public string UpdateByPropertyName { get; set; }
        public string CreatedByPropertyName { get; set; }

        public bool StampWithUpdatedBy { get; set; } = true;
        public bool StampWithCreatedBy { get; set; } = true;

        public Func<object> GetUserId { get; }

    }
}

