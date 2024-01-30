//using MailKit.Net.Smtp;
//using MailKit.Security;
//using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
//using System.Net.Mail;
//using MimeKit;
//using MimeKit.Text;


namespace SimpleEmailSender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost("send")]
        public async Task<IActionResult> SendEmailAsync()
        {
            try
            {
                string body = "Your email body content"; // Define your email body content

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("example@gmail.com");
                    mail.To.Add("phaisall007@gmail.com");
                    mail.Subject = "OTP Registration";
                    mail.Body = body;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com"))
                    {
                        smtp.Port = 587;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("example@gmail.com", "password");
                        smtp.EnableSsl = true;

                        await smtp.SendMailAsync(mail);
                    }

                    return Ok("Email sent successfully");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Failed to send email: {ex.Message}");



                //var email = new MimeMessage();
                //email.From.Add(MailboxAddress.Parse("walker31@ethereal.email"));
                //email.To.Add(MailboxAddress.Parse("parker.swift@ethereal.email"));
                //email.Subject = "Test Email Subject";
                //email.Body = new TextPart(TextFormat.Text) { Text = body };

                //using var smtp = new SmtpClient();
                //smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
                //smtp.Authenticate("walker31@ethereal.email", "yMjMzVBHSJM5Zx1NbD");
                //smtp.Send(email);
                //smtp.Disconnect(true);

                //return Ok("email sent well");
            }
        }

    }
}

