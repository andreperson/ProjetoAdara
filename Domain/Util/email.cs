using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mime;
using System.Net.Configuration;
using System.Net;
using System.Net.Mail;

namespace Domain.Util
{
    public class Email
    {
        public string SendMail(string _emailTo, string _emailCopia, string _assunto, string _texto)
        {

            string retorno = "Email enviado com sucesso!";
            //cria uma mensagem
            MailMessage mail = new MailMessage();

            try
            {
                //define os endereços
                if (string.IsNullOrEmpty(_emailTo))
                {
                    _emailTo = EmailTo;
                }

                mail.From = new MailAddress(EmailFrom);
                mail.To.Add(_emailTo);
                if (!string.IsNullOrEmpty(_emailCopia))
                {
                    mail.To.Add(_emailCopia);
                }

                //define o conteúdo
                mail.Subject = _assunto;
                mail.Body = _texto;
                mail.IsBodyHtml = true;

                //envia a mensagem
                SmtpClient smtp = new SmtpClient(SMTPServer);

                smtp.Credentials = new System.Net.NetworkCredential(EmailFrom, SMTPPwd);
                smtp.Port = 587; // Gmail works on this port<o:p />
                smtp.Host = SMTPServer;
                smtp.EnableSsl = false; //Gmail works on Server Secured Layer

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            return retorno;


        }

        /// <summary>
        /// Configurações do SMTP
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string SMTPServer
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["Configuration.Email.SMTPServer"].ToString();
            }
        }

        public static string SMTPUser
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["Configuration.Email.SMTPUser"].ToString();
            }
        }

        public static string SMTPPwd
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["Configuration.Email.SMTPPwd"].ToString();
            }
        }

        public static string EmailFrom
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["Configuration.Email.EmailFrom"].ToString();
            }
        }

        public static string EmailTo
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["Configuration.Email.EmailTo"].ToString();
            }
        }

    }

}
