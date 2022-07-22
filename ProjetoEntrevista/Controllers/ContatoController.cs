using Microsoft.AspNetCore.Mvc;

namespace ProjetoEntrevista.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult ApagarConf()
        {
            return View();
        }
    }
}
