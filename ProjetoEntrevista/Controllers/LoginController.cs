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

        public LoginController(IUsuarioRepositorio iUsuarioRepositorio, ISessao sessao)
        {
            _iUsuarioRepositorio = iUsuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home"); // Verifica se houver sessão ativa do usuário, não retornar a view index de login e sim da home
            return View();
        }

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
    }
}
