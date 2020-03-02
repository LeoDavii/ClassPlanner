using System.Net.Mail;

namespace ClassPlanner.Application.Utils
{
    public class Emails
    {
        public void SendEmailNewUser(string email, string password)
        {
            MailMessage message = new MailMessage(
                "l.davi.t@outlook.com", email, "Meu ClassPlanner",
                $"Bem-vindo, Professor!\n\n\nO seu classPlanner já está disponível! Acesse através dos dados abaixo: \n\nEmail: {email}\nSenha: {password}\n\nLink");

            SmtpClient client = new SmtpClient("smtp.office365.com")
            {
            Port = 587,
            UseDefaultCredentials = false,
            EnableSsl = true,
            Credentials = new System.Net.NetworkCredential("l.davi.t@outlook.com", "L33tSupaH4X0r")
            };

            client.Send(message);
        }
    }
}
