using System.ComponentModel.DataAnnotations;

namespace KMSUI.ViewModels.Organization
{
#nullable disable

    public class OrganizationAddViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری می باشد")]
        [MaxLength(250, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        public string PersianTitle { get; set; }
        public Guid? ParentId { get; set; }
        [Required]
        public int SortingNumber { get; set; } 
    }
}
