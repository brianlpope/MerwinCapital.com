namespace MCM.Extensions
{
    using System.Web;

    public static class RequestExtension
    {
        public static bool IsAjaxRequest(this HttpRequestBase request)
        {
            if (request == null)
            {
                return false;
            }

            if (request["X-Requested-With"] == "XMLHttpRequest")
            {
                return true;
            }

            if (request.Headers != null)
            {
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";
            }

            return false;
        }
    }
}