using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ProjetoEntrevista.Models;
using Newtonsoft.Json;
namespace ProjetoEntrevista.Filters
{
    public class PaginaParaUsuárioLogado : ActionFilterAttribute  // Nossa classe PaginaParaUsuárioLogado extend da ActionFilterAttribute e nela tem um atributo public virtual void OnActionExecuted(ActionExecutedContext context), que simplimentes antes que controler ser chamada será passado por esse filtro antes
    {
        public override void OnActionExecuted(ActionExecutedContext context) // override é expressão de reescrever nesse caso o método OnActionExecuted já existente na nossa classe que foi extendida ActionFilterAttribute
        {

            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado"); //o método context.HttpContext.Session.GetString busca a sessão conforme o valor da sua chave entre ("sessaoUsuarioLogado")

            if (string.IsNullOrEmpty(sessaoUsuario)) //Verifico se existe sessão do usuário, caso não exita ele vai sempre ir para rota de Login, caso o usuário force pela URL tentar acessar rotas do projetos sem logim
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } }); // método RedirectToRouteResult como váriavel global acessa as rotas definidas no projeto e pelo índice {"",""} diz qual controller quer e qual action também
            }
            else
            {
                ModelUsuario user=JsonConvert.DeserializeObject<ModelUsuario>(sessaoUsuario);

                if (user == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }

            }

            base.OnActionExecuted(context); //aqui busco todo contexo do método OnActionExecuted que esta na classe ActionFilterAttribute
        }
    }
}
