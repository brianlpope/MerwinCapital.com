namespace MerwinCapital.com.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mail;
    using System.Web.Mvc;
    using Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ActiveMenu = "HomeMenu";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.ActiveMenu = "AboutMenu";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.ActiveMenu = "ContactMenu";

            ContactModel model = new ContactModel();

            return View(model);
        }

        [HandleError]
        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            string message = "There are a few errors";
            bool isSuccess = false;
            try
            {
                if (ModelState.IsValid)
                {
                    string subject = System.Configuration.ConfigurationManager.AppSettings["ContactSubject"];
                    string fromName = model.FromName;
                    string fromAddress = System.Configuration.ConfigurationManager.AppSettings["EmailFromAddress"];
                    string toAddress = System.Configuration.ConfigurationManager.AppSettings["EmailToAddress"];
                    string toName = System.Configuration.ConfigurationManager.AppSettings["EmailToName"];
                    var emailmessage = new MailMessage(new MailAddress(fromAddress, fromName), new MailAddress(toAddress, toName));
                    emailmessage.Subject = string.Format(subject, fromName);
                    emailmessage.Body = model.Message;

                    var smtpClient = new SmtpClient();
                    smtpClient.Send(emailmessage);

                    message = "Email sent.  Thank you for your comments.";
                    isSuccess = true;
                }
                else
                {
                    IEnumerable<string> errors = GetErrorsFromModelState();
                    message = string.Concat(errors);
                }
            }
            catch (Exception ex)
            {
                ViewBag.IsSuccess = false;
                ViewBag.Message = ex.Message;
            }

            ViewBag.IsSuccess = isSuccess;
            ViewBag.Message = message;

            return View();
        }

        public ActionResult Refer()
        {
            ViewBag.ActiveMenu = "ReferMenu";

            ReferModel model = new ReferModel();

            return View(model);
        }

        [HandleError]
        [HttpPost]
        public ActionResult Refer(ReferModel model)
        {
            string message = "There are a few errors";
            bool isSuccess = false;
            try
            {
                if (ModelState.IsValid)
                {
                    string subject = System.Configuration.ConfigurationManager.AppSettings["ReferralSubject"];
                    string fromAddress = System.Configuration.ConfigurationManager.AppSettings["EmailFromAddress"];
                    string fromName = model.FromName;
                    string toAddress = model.ToEmail;
                    string toName = model.ToName;
                    var emailmessage = new MailMessage(new MailAddress(fromAddress, fromName), new MailAddress(toAddress, toName));
                    emailmessage.Subject = string.Format(subject, fromName);
                    emailmessage.IsBodyHtml = true;
                    emailmessage.Body = string.Format(model.BodyTemplate, toName, fromName);

                    var smtpClient = new SmtpClient();
                    smtpClient.Send(emailmessage);

                    message = "Email sent.  Thank you for your referral.";
                    isSuccess = true;
                }
                else
                {
                    IEnumerable<string> errors = GetErrorsFromModelState();
                    message = string.Concat(errors);
                }
            }
            catch (Exception ex)
            {
                ViewBag.IsSuccess = false;
                ViewBag.Message = ex.Message;
            }

            ViewBag.IsSuccess = isSuccess;
            ViewBag.Message = message;

            return View(model);
        }

        public ActionResult Mission()
        {
            ViewBag.ActiveMenu = "MissionMenu";

            return View();
        }


        public ActionResult Privacy()
        {
            ViewBag.ActiveMenu = "PrivacyMenu";

            return View();
        }

        private IEnumerable<string> GetErrorsFromModelState()
        {
            return ModelState.SelectMany(x => x.Value.Errors
                .Select(error => error.ErrorMessage));
        }
    }
}