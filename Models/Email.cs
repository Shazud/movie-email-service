using System.ComponentModel.DataAnnotations;

namespace MovieEmailService.Models
{
    public class Email
    {
        [Required]
        [DataType(DataType.Text)]
        public string subject { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string body { get; set; }

        public string email { get; set; }
    }
}