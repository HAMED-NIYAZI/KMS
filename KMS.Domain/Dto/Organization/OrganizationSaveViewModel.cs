namespace KMS.Domain.Dto.Organization
{
    public class OrganizationSaveViewModel
    {
        public int SortingNumber { get; set; }
        public string PersianTitle { get; set; }
        public Guid? ParentId { get; set; }


    }
}
