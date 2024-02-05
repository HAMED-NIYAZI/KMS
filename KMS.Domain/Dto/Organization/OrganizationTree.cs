namespace KMS.Domain.Dto.Organization
{
    public class OrganizationTree
    {
        public Guid Id { get; set; }
        public int SortingNumber { get; set; }
        public string PersianTitle { get; set; }
        public bool IsSelected { get; set; }
        public Guid? ParentId { get; set; }

        public ICollection<OrganizationTree> Children { get; set; } = new List<OrganizationTree>();


    }
}
