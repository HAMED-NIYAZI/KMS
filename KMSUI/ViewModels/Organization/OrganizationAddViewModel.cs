using System.ComponentModel.DataAnnotations;

namespace KMSUI.ViewModels.Organization
{
#nullable disable

    public class OrganizationAddViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string PersianTitle { get; set; }
        public Guid ParentId { get; set; }
        public int SortingNumber { get; set; }
    }
}
