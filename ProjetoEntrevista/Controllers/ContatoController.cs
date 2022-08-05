using Microsoft.AspNetCore.Mvc;
using ProjetoEntrevista.Models;
using ProjetoEntrevista.Repositorio;
using ProjetoEntrevista.Filters;

namespace ProjetoEntrevista.Controllers
{
    [PaginaParaUsuárioLogado] // Essa invocação da classe que esta na pasta Filters, é para controlar AS ROTAS E checar antes de acessar TODAS AS ROTAS DO USUÁRIO CONTROLER DIGITANDO NA URL, verificar se o usuário é ADMIN
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
            List<ModelCliente> contatos = _contatoRepositorio.BuscarTodos(); // Declaro a variável 'contatos' do tipo 'List<ModelContato>' que equivale a um array e pela minha constante '_contatoRepositorio' acesso método 'BuscarTodos()' que vai buscar no banco pela Model meus contatos
            return View(contatos); //Mando meus 'cantatos' já carregados acima para minha View 'Index'
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

        public IActionResult Editar(int id)
        {
            ModelCliente contato = _contatoRepositorio.BuscarContato(id);
            return View(contato);
        }

        public IActionResult ApagarConf(int id)
        {
            ModelCliente contato = _contatoRepositorio.BuscarContato(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try //O try, tentativa de execução do bloco abaixo 
            {
                _contatoRepositorio.Apagar(id);
                TempData["MensagemSucesso"] = "Contato apagado com sucesso"; //Essa variável TempData nativa, será acessada na View para que possa exibir a mensagem de sucesso ou de erro.
                return RedirectToAction("Index");
            }
            catch(System.Exception erro)
            {               
                TempData["MensagemErro"] = $"Erro! {erro.InnerException.Message}"; //Essa variável TempData nativa, será acessada na View para que possa exibir a mensagem de sucesso ou de erro.
                return RedirectToAction("Index");
            }
             
        }


        /**
         * Método responsável por adicionar um contato ao banco.
         * A constante _contatoRepositorio que é alimentada no construtor dessa classe
         * recebe a instância da classe 'IContatoRepositorio'.
         * E acessa o método para executar as ações.
         */
        [HttpPost]  //esse método POST esta em link com a view Cadastrar na tag  <form asp-controller="Contato" asp-action="Cadastrar" method="post">
        public IActionResult Cadastrar(ModelCliente contato)
        {
            try //O try, tentativa de execução do bloco abaixo 
            {
                if (ModelState.IsValid)  //Essé método ModelState.IsValid é para confirmar o DATA_annotation iniciado na ModelContato da pasta Model que valida lá o tipo de dados, ex. email, telefone ...
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso"; //Essa variável TempData nativa, será acessada na View para que possa exibir a mensagem de sucesso ou de erro.
                    return RedirectToAction("Index"); //RedirectToAction método para retornar para rota Index definida em View contato
                }

                return View(contato);

            }
            catch (System.Exception erro) //O exception trás os erros da tentativa mal sussedida do try, e então eu coloco a mensagem de erro variável erro
            {
                TempData["MensagemErro"] = $"Erro! {erro.InnerException.Message}"; // o $ no início da string é para possibilitar a concatenação com a variável {erro.Message} 
                return View(contato);

            }
           
        }

        [HttpPost]  
        public IActionResult Alterar(ModelCliente contato)
        {

            try //O try, tentativa de execução do bloco abaixo 
            {
                if (ModelState.IsValid)  //Essé método ModelState.IsValid é para confirmar o DATA_annotation iniciado na ModelContato da pasta Model que valida lá o tipo de dados, ex. email, telefone ...
                {
                    _contatoRepositorio.Alterar(contato);
                    TempData["MensagemSucesso"] = "Contato atualizado com sucesso"; //Essa variável TempData nativa, será acessada na View para que possa exibir a mensagem de sucesso ou de erro.
                    return RedirectToAction("Index"); //RedirectToAction método para retornar para rota Index definida em View contato
                }
                return View("Editar", contato); //nesse caso o nome da View que por padrão seria o mesmo do método nesse bloco (public IActionResult 'Alterar') não existe, po isso apontei qual View View("Editar" ... e o parametro ...  contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro! {erro.InnerException.Message}"; //Essa variável TempData nativa, será acessada na View para que possa exibir a mensagem de sucesso ou de erro.
                return View(contato);
            }


            
        }
    }
}
