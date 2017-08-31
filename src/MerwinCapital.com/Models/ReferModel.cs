namespace MerwinCapital.com.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ReferModel
    {
        private string _bodyTemplate;

        public ReferModel()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<p>Hello {0}.</p>");
            sb.AppendLine("<p>{1} thought you might be interested in hearing from us.  Merwin Capital Management LLC provides many products and services that may be of interest to you, including:");
            sb.AppendLine();
            sb.Append("<ul>");
            sb.Append("<li>Stocks, bonds, ETFs, and mutual funds in an advisory account - fee only</li>");
            sb.Append("<li>401k Rollovers</li>");
            sb.Append("<li>Tax minimization strategies</li>");
            sb.Append("<li>Retirement Planning</li>");
            sb.Append("<li>Tactical Money Management</li>");
            sb.Append("<li>Fixed and indexed annuities</li>");
            sb.Append("<li>Life, disability, and long-term care insurance</li>");
            sb.Append("</ul></p>");
            sb.AppendLine("<p>For more information, visit our website at <a href='http://www.merwincapital.com'>www.merwincapital.com</a>, or call our office at (602) 765-8887 or toll free at (800) 290-4900.</p>");

            _bodyTemplate = sb.ToString();
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "'Friend's Email' is required.")]
        [RegularExpression(@"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$", ErrorMessage = "Please enter a valid email address for Your Email.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Friend's Email:")]
        public string ToEmail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "'Friend's Name' is required.")]
        [Display(Name = "Friend's Name:")]
        public string ToName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "'Your Name' is required.")]
        [Display(Name = "Your Name:")]
        public string FromName { get; set; }

        public string Body
        {
            get
            {
                return string.Format(_bodyTemplate, "(friend's name)", "(your name)");
            }
        }

        public string BodyTemplate
        {
            get
            {
                return _bodyTemplate;
            }
        }
    }
}