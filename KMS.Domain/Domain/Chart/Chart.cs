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


        //#region Navigation Properties
        //public ICollection<User> Users { get; set; }
        //public Organization Organization { get; set; }
        //public Chart Parent { get; set; }
        //public ICollection<Chart> Children { get; set; }
        //#endregion

    }
}
