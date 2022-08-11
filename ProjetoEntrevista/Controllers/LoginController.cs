using Microsoft.AspNetCore.Mvc;
using ProjetoEntrevista.Models;
using ProjetoEntrevista.Repositorio;
using ProjetoEntrevista.helper;

namespace ProjetoEntrevista.Controllers
{
    public class LoginController:Controller
    {

        public readonly IUsuarioRepositorio _iUsuarioRepositorio; // Responsável pelo CRUD no banco de dados 
        public readonly ISessao _sessao; //resposável por gerir a sessão no projeto
        public readonly IEmail _email;

        public LoginController(IUsuarioRepositorio iUsuarioRepositorio, ISessao sessao, IEmail email)
        {
            _iUsuarioRepositorio = iUsuarioRepositorio;
            _sessao = sessao;
            _email = email;
        }

        public IActionResult Index()
        {
            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home"); // Verifica se houver sessão ativa do usuário, não retornar a view index de login e sim da home
            return View();
        }

        [HttpPost]
        public IActionResult Logar(ModelUsuario user)
        {
            try
            {
                ModelUsuario usuario = _iUsuarioRepositorio.LoginUsuario(user.Login);
                if (usuario != null)
                {                  
                    if (usuario.SenhaValida(user.Senha)) // função SenhaValida esta dentro da ModelUsuario para testar senha
                    {
                        _sessao.CriarSessaoDoUsuario(usuario); //sessão é criada pela inteface _sessao  quando usuário consegue logar
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["MensagemErro"] = "Senha incorreta!";
                        return View("Index");
                    }                       
                }
                else
                {
                    TempData["MensagemErro"] = "Usuario não encontrado!";
                    return View("Index");
                }
            }catch(System.Exception erro)
            {
                TempData["MensagemErro"]=$"Erro! {erro.InnerException.Message}";
                return View("Index");
            }
          
        }
        public IActionResult Logout()
        {
            _sessao.RemoverSessaoDousuario();
            return RedirectToAction("Index", "Login");
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EvianLinkParaRedefinirSenha(ModelUsuario user)
        {
            try
            {
                ModelUsuario usuarioDb = _iUsuarioRepositorio.BuscarEmailLogin(user.Login, user.Email);
                if (usuarioDb.Email == user.Email)
                {   
                    string novasenha=usuarioDb.GerarNovaSenha(); // essa função GerarNovaSenha() foi desenvovlida no ModelUsuario
                    string mensagem = $"Sua nova senha é: {novasenha}";  //mensagem do corpo de email

                    bool emailEnviado=_email.Enviar(usuarioDb.Email, "Redfinição de Senha", mensagem); // a função _email.Enviar esta na calsse Email na pasta /helper 

                    if (emailEnviado)
                    {
                        _iUsuarioRepositorio.RedefinicaoDeSenhaSendEmaill(usuarioDb);
                        TempData["MensagemSucesso"] = "Enviamos para o seu E-mail de cadastro, seu email e senha!";
                        return View("Index");
                    }
                    else
                    { 
                        TempData["MensagemErro"] = "Erro ao enviar email de Redefinição de Senha! Tente novamente!";
                        return View("RedefinirSenha", user);
                    }
                }
                else
                {
                    TempData["MensagemErro"] = "Usuário Não encotrado";
                    return View("RedefinirSenha", user);
                }

            }catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao redifir senha {erro.InnerException.Message}";
                return View("RedefinirSenha", user);
            }
        }

    }
}
