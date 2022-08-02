using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProjetoEntrevista.Models;

namespace ProjetoEntrevista.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() // esse método configura a chamada do componente '@await Component.InvokeAsync("Menu")' dentro de _Layout.cshtml
        {
            string sessionUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado"); // aqui carrego a session no projeto de forma direta pela 'HttpContext.Session.GetString' sem precisar instanciar a interface ISessao aqui na classe 

            if (string.IsNullOrEmpty(sessionUsuario)) return null; //caso não haja sessão retornar null e não segue pra linha abaixo

            ModelUsuario usuario = JsonConvert.DeserializeObject<ModelUsuario>(sessionUsuario); // se sessionUsuario existe uso JsonConvert.DeserializeObject<ModelUsuario> para converte-lo de Json para objeto e mando n view abaixo

            return View(usuario); //Retorno para minha view que esta em /Shared/componentes/Menu/Default.cshtml
        }
    }
}
