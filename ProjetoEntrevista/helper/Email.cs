using ProjetoEntrevista.helper;
using Microsoft.Extensions.Configuration; // Biblioteca de arquivos de configuração .NET
using System.Net.Mail; //Biblioteca de envio de emaio .NET
using System.Net;

namespace ProjetoEntrevista.helper
{
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration; //crio uma constante de tipo configuration, que carregarará os dados e variáveis do "dotenv" ou appssettings que fiva  na raiz do projeto

        public Email(IConfiguration configuration)
        {
            _configuration = configuration; //instacio a configuration e coloco na minha constante
        }

        public bool Enviar(string email, string assunto, string mensagem)
        {
            try
            {
                string host = _configuration.GetValue<string>("SMTP:Host"); //Uso a minha costante configurations e atraves do método, getValue busco minhas Variáveis no arquivo de configuração "appssettings" 
                string nome = _configuration.GetValue<string>("SMTP:Nome");
                string username = _configuration.GetValue<string>("SMTP:UserName");
                string senha = _configuration.GetValue<string>("SMTP:Senha");
                int porta = _configuration.GetValue<int>("SMTP:Porta");

                MailMessage mail = new MailMessage() //instanciando classe de envio de email
                {
                    From = new MailAddress(username, nome) //no momento de instância passa como From ou seja remetente, quem é o Username e o nome
                };

                mail.To.Add(email); //Pra quem vou enviar o email
                mail.Subject = assunto; // assunto do email
                mail.Body = mensagem; //corpo do email
                mail.IsBodyHtml= true; // ativo possibilade de passar código html pelo email
                mail.Priority = MailPriority.High; //email de prioridade, ou seja manda mais rápido

                using (SmtpClient smtp = new SmtpClient(host, porta))  //SmtpClient é a intância para disparo de mail que necessita carregar os parâmentros o host a porta
                {
                    smtp.Credentials = new NetworkCredential(username, senha); // e Username e senha
                    smtp.EnableSsl= true; //habilitando a segurança

                    smtp.Send(mail);//

                    return true;
                }
            }
            catch(System.Exception erro)
            {
                //gravar log de erro

                return false;
            }         
        }
    }
}
