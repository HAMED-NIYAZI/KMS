namespace KMS.Domain
{
    public class Chart : BaseEntity
    {
        public int? SortingNumber { get; set; }
        public string? PersianTitle { get; set; }
        public string? EnglishTitle { get; set; }
        public string? Description { get; set; }
        public Guid? OrganizationId { get; set; }
        public Guid? ParentId { get; set; }

    }
}
