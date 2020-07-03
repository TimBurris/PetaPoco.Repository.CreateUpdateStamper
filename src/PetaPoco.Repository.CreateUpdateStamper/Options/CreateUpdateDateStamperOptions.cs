namespace PetaPoco.Repository.CreateUpdateStamper.Options
{
    public class CreateUpdateDateStamperOptions
    {
        public bool UseUtc { get; set; } = false;
        public bool UseDateTimeOffset { get; set; } = false;
        public bool StampWithUpdatedOn { get; set; } = true;
        public bool StampWithCreatedOn { get; set; } = true;
        public string UpdateOnPropertyName { get; set; }
        public string CreatedOnPropertyName { get; set; }

    }
}

