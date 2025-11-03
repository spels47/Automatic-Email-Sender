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
            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.Write("Password: ");
            var password = Console.ReadLine();

            Console.Write("Subject: ");
            var subject = Console.ReadLine();

            Console.Write("Body: ");
            var body = Console.ReadLine();

            Console.Write("Recipient: ");
            var recipient = Console.ReadLine();

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(email, password),
                EnableSsl = true,
            };
            var mail = new MailMessage
            {
                From = new MailAddress(email),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mail.To.Add(recipient);
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
