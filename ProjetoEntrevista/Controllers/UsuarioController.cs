using Microsoft.AspNetCore.Mvc;
using ProjetoEntrevista.Models;
using ProjetoEntrevista.Repositorio;

namespace ProjetoEntrevista.Controllers
{
    public class UsuarioController : Controller
    {
        public readonly IUsuarioRepositorio _iusuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio iusuarioRepositorio)
        {
            _iusuarioRepositorio = iusuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<ModelUsuario> todosUsers= _iusuarioRepositorio.BuscarUsers();
            return View(todosUsers);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(ModelUsuario user)
        {
            try
            {
                user.DataCadastro = DateTime.Now; //Incluo aqui a data de catras do usuário uma vez que não vem do form 'cadastrar'
                _iusuarioRepositorio.Adicionar(user);
                return View("Index");
            }
            catch(System.Exception erro)
            {
                throw new NotImplementedException();
            }
        }

     
    }
}
