using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Models.DB
{
    public class WorkInfo
    {
        [Key]
        public int WorkInfoId { get; set; }
        [ForeignKey("Contact")]
        public int ContactId { get; set; }
        public string Title { get; set; }
        public string Post { get; set; }
        public int Address { get; set; }
        public string Phone { get; set; }
        public string InternalPhone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }

    }
}