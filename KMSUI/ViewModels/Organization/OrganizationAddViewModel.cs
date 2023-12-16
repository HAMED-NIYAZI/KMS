using System.ComponentModel.DataAnnotations;

namespace KMSUI.ViewModels.Organization
{
 
    public class OrganizationAddViewModel
    {
        public Guid? Id { get; set; }

        [MinLength(3, ErrorMessage = "حداقل کاراکتر 3 کاراکتر مجاز می باشد")]
        [Required(ErrorMessage = "این فیلد اجباری می باشد")]
        [MaxLength(250, ErrorMessage = "حداکثر 100 کاراکتر مجاز می باشد")]
        public string PersianTitle { get; set; }
        public Guid? ParentId { get; set; }
        [Required(ErrorMessage = "این فیلد اجباری می باشد")]
        public int SortingNumber { get; set; } 
    }
}
