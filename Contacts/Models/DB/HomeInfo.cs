using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Models.DB
{
    public class HomeInfo
    {
        [Key]
        public int HomeInfoId { get; set; }
        [ForeignKey("Contact")]
        public int ContactId { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
    }
}