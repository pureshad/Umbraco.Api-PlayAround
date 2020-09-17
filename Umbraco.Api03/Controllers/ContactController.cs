using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Api03.Models;
using Umbraco.Core.Media;
using Umbraco.Web.Mvc;

namespace Umbraco.Api03.Controllers
{
    public class ContactController : SurfaceController
    {
        public ActionResult RenderContact()
        {
            return PartialView("~/Views/Partials/Contact/Contact.cshtml");
        }

        public ActionResult SubmitForm(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                var massage = Services.ContentService.CreateContent($"{model.Name} - {DateTime.Now}", CurrentPage.Id, "contactContent");

                massage.SetValue("userName", model.Name);
                massage.SetValue("email", model.Email);
                massage.SetValue("message", model.Message);
                massage.SetValue("phone", model.Phone);
                massage.SetValue("umbracoNaviHide", true);

                TempData["SuccessMassage"] = true;

                Services.ContentService.SaveAndPublishWithStatus(massage);

                SendMail(model);

                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }

        /// <summary>
        /// Before sending a message, you must enable the "Less secure app access" in the google acount security tab
        /// and also change your credentials in the web.config file on the "mailSettings" tag
        /// </summary>
        /// <param name="model">The form request model</param>
        private void SendMail(ContactModel model)
        {
            /*
                FIRST WAY TO SEND EMAIL              
             
                var fromEmail = new MailAddress(ConfigurationManager.AppSettings["SendEmailFrom"]);
                var fromPassword = ConfigurationManager.AppSettings["EmailPassword"];
                var toAddress = new MailAddress(model.Email);
                string subject = "Some email subject";
                string body = model.Message;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromEmail.Address, fromPassword)
                };

                var message = new MailMessage(fromEmail, toAddress)
                {
                    Subject = subject,
                    Body = body
                };

                smtp.Send(message);
            */

            var fromEmail = new MailAddress(ConfigurationManager.AppSettings["SendEmailFrom"]);
            const string subject = "Some email subject";
            var toAddress = new MailAddress(model.Email);
            string body = model.Message;

            var message = new MailMessage(fromEmail, toAddress)
            {
                Subject = subject,
                Body = body
            };

            try
            {
                var smtp = new SmtpClient();
                smtp.Send(message);

            }
            catch (Exception e)
            {
                HttpNotFound(HttpContext.Response.StatusCode + e.ToString());
            }
        }

    }
}