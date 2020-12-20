using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO.Core.Application.Util
{
    public class Email
    {
        public static void EnviarEmail(string remetente, string destinatario, string assunto, string txt_mensagem)
        {            
            string txt_servidor_smtp = "smtp.gmail.com";
            string txt_servidor_smtp_usuario = "webcaldasti@gmail.com";
            string txt_servidor_smtp_senha = "&Web!_2016";            
            bool cod_ssl = true;
            int cod_porta = 587;

            //Cria objeto com dados do e-mail.
            System.Net.Mail.MailMessage objEmail = new System.Net.Mail.MailMessage();

            //Define o remetente do e-mail.
            objEmail.From = new System.Net.Mail.MailAddress(txt_servidor_smtp_usuario, remetente, System.Text.Encoding.UTF8);

            //Define os destinatários do e-mail.
            objEmail.To.Add(destinatario);

            //Define a prioridade do e-mail.
            objEmail.Priority = System.Net.Mail.MailPriority.Normal;

            //Define o formato do e-mail HTML (caso não queira HTML alocar valor false)
            objEmail.IsBodyHtml = true;

            //Define o título do e-mail.
            objEmail.Subject = assunto;

            //Define o corpo do e-mail.        
            objEmail.Body = txt_mensagem;

            //Para evitar problemas com caracteres "estranhos", configuramos o Charset para "ISO-8859-1"
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

            //Cria objeto com os dados do SMTP
            System.Net.Mail.SmtpClient objSmtp = new System.Net.Mail.SmtpClient();

            //Alocamos o endereço do host para enviar os e-mails:
            objSmtp.Host = txt_servidor_smtp;

            objSmtp.Credentials = new System.Net.NetworkCredential(txt_servidor_smtp_usuario, txt_servidor_smtp_senha);

            objSmtp.Port = cod_porta;

            objSmtp.EnableSsl = cod_ssl;

            try
            {
                //Enviamos o e-mail através do método .Send()
                objSmtp.Send(objEmail);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Source + " - " + ex.Message + " - " + ex.StackTrace);             
            }
            finally
            {
                objEmail.Dispose();
            }            
        }
    }
}
