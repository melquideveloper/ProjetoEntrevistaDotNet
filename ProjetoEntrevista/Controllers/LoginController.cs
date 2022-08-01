using Microsoft.AspNetCore.Mvc;
using ProjetoEntrevista.Models;
using ProjetoEntrevista.Repositorio;

namespace ProjetoEntrevista.Controllers
{
    public class LoginController:Controller
    {

        public readonly IUsuarioRepositorio _iUsuarioRepositorio;

        public LoginController(IUsuarioRepositorio iUsuarioRepositorio)
        {
            _iUsuarioRepositorio = iUsuarioRepositorio;
        }

        public IActionResult Index()
        {
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
                        return RedirectToAction("Index", "Home", new { id=usuario.Id });
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
    }
}
