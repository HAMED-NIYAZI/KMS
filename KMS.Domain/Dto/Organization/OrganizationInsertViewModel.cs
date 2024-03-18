namespace KMS.Domain.Dto.Organization
{
    public class OrganizationInsertViewModel
    {
        public int SortingNumber { get; set; }
        public string PersianTitle { get; set; }
        public Guid? ParentId { get; set; }


    }
}
