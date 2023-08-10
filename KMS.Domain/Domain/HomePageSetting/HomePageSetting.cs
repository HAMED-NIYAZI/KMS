namespace KMS.Domain
{
#nullable disable

    public class HomePageSetting : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Coulmn1 { get; set; }
        public string Coulmn2 { get; set; }
        public string Coulmn3 { get; set; }
        public string Coulmn4 { get; set; }
        public string Coulmn5 { get; set; }
        public Guid OrganizationId { get; set; }

    }
}
