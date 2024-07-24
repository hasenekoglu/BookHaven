using LibraryManagementSystem.WebUI.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace LibraryManagementSystem.WebUI.Controllers
{
    public class MailController : Controller
    {
        
        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new("Book Haven","hasenek2000@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new("User",mailRequest.RecieverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.MessageContent;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = mailRequest.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com",587,false);
            client.Authenticate("hasenek2000@gmail.com","xlmhuhrenoowyeza");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}
