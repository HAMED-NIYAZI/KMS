namespace KMS.Application.Dtos.OrganizationDto
{
    public class OrganizationDto
    {
        public Guid Id { get; set; }
        //public DateTime CreateDate { get; set; }
        //public DateTime LastUpdateDate { get; set; }
        //public bool IsDeleted { get; set; }
        public int SortingNumber { get; set; }
        public string PersianTitle { get; set; }
       // public string EnglishTitle { get; set; }
      //  public string Description { get; set; }
        public Guid? ParentId { get; set; }

        #region  Navigation Properties
      //  public ICollection<Chart> Charts { get; set; }
        //public OrganizationDto Parent { get; set; }
      //  public ICollection<OrganizationDto> Children { get; set; }
        #endregion
    }
}
