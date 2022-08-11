using Microsoft.AspNetCore.Mvc;
using ProjetoEntrevista.Models;
using ProjetoEntrevista.Repositorio;
using ProjetoEntrevista.Enum;
using ProjetoEntrevista.Filters;
using ProjetoEntrevista.helper;

namespace ProjetoEntrevista.Controllers
{
    [PaginaRestritaSomenteAdmin] // Essa invocação da classe que esta na pasta Filters, é para controlar o filtro de rota, para checar antes de acessar os método da home, verificar se existe usuário logado, para poder acessalos
    public class UsuarioController : Controller
    {

        //Declarando a constante para receber a instância do IUsuarioRepositorio
        public readonly IUsuarioRepositorio _iusuarioRepositorio;

        //Construtor da Classe, que instancia o IUsuarioRepositorio e a seta na nossa constate, a interface tem função de CRUD no bando de dados
        public UsuarioController(IUsuarioRepositorio iusuarioRepositorio)
        {
            _iusuarioRepositorio = iusuarioRepositorio;
        }

        //Método que faz link para VIEW de lista de usuário
        public IActionResult Index()
        {           
      
                List<ModelUsuario> todosUsers = _iusuarioRepositorio.BuscarUsers();
                return View(todosUsers);

        }

        //Método que faz link para VIEW de Cadastro de usuário
        public IActionResult Cadastrar()
        {
            return View();
        }

        //Método que recebe o submit da tela de cadastro de usuário para inserir no banco de dados
        [HttpPost]
        public IActionResult Cadastrar(ModelUsuario user)
        {
            try
            {               
                _iusuarioRepositorio.Adicionar(user);
                TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                return RedirectToAction("Index");
            }
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erros! {erro.InnerException.Message}";
                Console.WriteLine(erro.InnerException.Message);
                return View(user);
            }
        }

        //Método que faz link do botão editar da TELA lista de usuário, para moastrar VIEW de CONFIRMAR EXCLUSÃO
        public IActionResult ApagarConf(int id)
        {
            ModelUsuario usuario = _iusuarioRepositorio.BuscarUsuario(id);
            return View(usuario);
        }

        //Método que recebe o submit do botão sim da VIEW de CONFIRMAR EXCLUSÃO, para excluir o usuário
        public IActionResult Apagar(int id)            
        {
            try
            {
                ModelUsuario user = _iusuarioRepositorio.Remover(id);
                TempData["MensagemSucesso"] = "Usuário Removido comsucesso!";
                return RedirectToAction("Index");
            }
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro! Não foi possivel remover o Usuario. Detalhe: {erro.InnerException.Message}";
                return RedirectToAction("Index");
            }
        }

        //Método que faz link para VIEW de Edição de usuário
        public IActionResult Editar(int id)
        {
            ModelUsuario user=_iusuarioRepositorio.BuscarUsuario(id);
            return View(user);
        }

        //Método que recebe o submit da tela de Edição de usuário para inserir no banco de dados
        [HttpPost]
        public IActionResult Editar(ModelUsuario user)
        {
            try
            {
                _iusuarioRepositorio.Editar(user);
                TempData["MensagemSucesso"] = "Atualizado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível alterar usuário. Detalhe {erro.InnerException.Message}";
                return View();
            }

        }


    }
}
