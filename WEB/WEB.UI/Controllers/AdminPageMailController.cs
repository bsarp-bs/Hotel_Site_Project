using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using WEB_UI.Models;

namespace WEB_UI.Controllers
{
    public class AdminPageMailController : Controller
    {
        [HttpGet]
        public IActionResult AdminPageMailIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminPageMailIndex(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelimAdmin", "YOURMAIL");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyB = new BodyBuilder();
            bodyB.TextBody = model.Body;
            mimeMessage.Body = bodyB.ToMessageBody();

            mimeMessage.Subject = model.Subject;

            SmtpClient smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate("YOURMAIL", "YOURMAIL GOOGLE PASSWORD KEY");
            smtp.Send(mimeMessage);
            smtp.Disconnect(true);


            return View();
        }
    }
}
