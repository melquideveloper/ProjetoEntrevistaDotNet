using Microsoft.AspNetCore.Mvc;
using ProjetoEntrevista.Filters;

namespace ProjetoEntrevista.Controllers
{
    [PaginaParaUsuárioLogado] // Essa invocação da classe que esta na pasta Filters, é para controlar o filtro de rota, para checar antes de acessar os método da home, verificar se existe usuário logado, e então poder acessar as rotas
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
