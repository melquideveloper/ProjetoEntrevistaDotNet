using Microsoft.AspNetCore.Mvc;
using ProjetoEntrevista.Models;
using ProjetoEntrevista.Repositorio;

namespace ProjetoEntrevista.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        /**
         * Construto da classe recebe a instância de IContatoRepositorio
         * que é responsável por acessar o Model e realizar as transações no banco;
         */
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        /***
         * Os metódos que são construido, e não informardos se são 'GET' ou 'POST'... 
         * por padrão ele assume ação de "GET", por isso abaixo existe outro Método também 'Cadastrar'
         * porém que recebe um atributo e configurado como "POST" [HttpPost]
         */
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


        /**
         * Método responsável por adicionar um contato ao banco.
         * A constante _contatoRepositorio que é alimentado pelo construtor aqui na linha 11
         * recebe a instância da classe 'IContatoRepositorio'.
         * E acessa o método para executar as ações.
         */
        [HttpPost]
        public IActionResult Cadastrar(ModelContato contato)
        {
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index"); //RedirectToAction método para retornar para rota Index definida em View contato
        }
    }
}
