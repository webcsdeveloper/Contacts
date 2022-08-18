using System.ComponentModel.DataAnnotations;

namespace Contacts.Models.DB
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "تکمیل این فیلد الزامی است")]
        public string Firstname { get; set; }
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "تکمیل این فیلد الزامی است")]
        public string Lastname { get; set; }
        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "تکمیل این فیلد الزامی است")]
        public string Phone { get; set; }
        [Display(Name = "داخلی")]
        public string? InternalPhone { get; set; }
        [Display(Name = "شماره فکس")]
        public string? Fax { get; set; }
        [Display(Name = "سمت")]
        public string? Post { get; set; }
        [Display(Name = "شماره پرسنلی")]
        public string? PersonnelId { get; set; }
        [Display(Name = "محل کار")]
        public string? WorkPlace { get; set; }
        
        //public ICollection<WorkInfo> WorkInfos { get; set; }
        //public ICollection<HomeInfo> HomeInfos { get; set; }

    }
}
