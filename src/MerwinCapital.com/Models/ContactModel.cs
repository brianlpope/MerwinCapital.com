namespace MerwinCapital.com.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ContactModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "'Your Name' is required.")]
        public string FromName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "'Message' is required.")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}