using System.Web.Mvc;

namespace MerwinCapital.com.Areas.Preview
{
    public class PreviewAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Preview";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Preview_default",
                "Preview/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}