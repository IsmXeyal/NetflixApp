using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace NetflixAppBusinessLogicLayer.Network;

public class NetWork
{
    public static void SendNotification(string receiveMail, string messageSubject, string messageBody)
    {
        ConfigurationBuilder confB = new ConfigurationBuilder();
        confB.AddJsonFile("AppSettingsMail.json");
        var con = confB.Build();

        SmtpClient smtp = new SmtpClient
        {
            Host = con.GetSection("SmtpSettings")["Host"],
            Port = Convert.ToInt32(con.GetSection("SmtpSettings")["Port"]),
            UseDefaultCredentials = Convert.ToBoolean(con.GetSection("SmtpSettings")["UseDefaultCredentials"]),
            Credentials = new NetworkCredential(
                con.GetSection("SmtpSettings")["Credentials:UserName"],
                con.GetSection("SmtpSettings")["Credentials:Password"]
            ),
            DeliveryMethod = (SmtpDeliveryMethod)Enum.Parse(
                typeof(SmtpDeliveryMethod),
                con.GetSection("SmtpSettings")["DeliveryMethod"]
            ),
            EnableSsl = Convert.ToBoolean(con.GetSection("SmtpSettings")["EnableSsl"])
        };

        var fromEmailSettings = con.GetSection("SmtpSettings:FromEmail");

        MailAddress FromEmail = new MailAddress(
            fromEmailSettings["Address"],
            fromEmailSettings["DisplayName"]
        );

        MailAddress ToEmail = new MailAddress(receiveMail);

        MailMessage mailMessage = new MailMessage
        {
            From = FromEmail,
            Subject = messageSubject,
            Body = messageBody
        };

        mailMessage.To.Add(ToEmail);

        smtp.Send(mailMessage);
    }
}
