using System;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace Automatic_Email_Sender
{
    class Program
    {
        static void Main()
        {
            var email = "angry.bring.customer@gmail.com";
            var password = "Unit1234";
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(email, password),
                EnableSsl = true,
            };
            var mail = new MailMessage
            {
                From = new MailAddress(email),
                Subject = "oppdrag ikke fullført",
                Body = @"hei, jeg bestilte en levering gjennom komplett, den leveringen skulle være med en hjemlevering med innbæring<br>
                        og henting av e-avfall (i dette tilfellet en oppvaskmaskin) og at de skulle ta med seg emballasjen fra leveringen,<br>
                        da de ankom så leverte de den nye oppvaskmaskinen, men tok ikke med seg embalasjen fra den nye maskinen og tok heller ikke med seg den gamle maskinen.<br>
                        <b>jeg ønsker å motta tjenesten jeg har betalt for.</b><br><br>
                        <b>Sendingsnummer:</b> <h5>70702051086799528</h5>",
                IsBodyHtml = true
            };
            mail.To.Add("homedelivery.norge@bring.com");
            var startTime = 3600000;
            var minTime = 60000;
            var currentTime = startTime;
            while (true)
            {
                smtpClient.Send(mail);
                Console.WriteLine($"Email sent at {DateTime.Now}");
                Thread.Sleep(currentTime);
                if (currentTime - 60000 >= minTime) currentTime -= 60000;
            }
        }
    }
}
