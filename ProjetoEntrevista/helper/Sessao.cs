using ProjetoEntrevista.helper;
using ProjetoEntrevista.Models;
using Microsoft.AspNetCore.Http; //Blibioteca responsável por gerir as sessões
using Newtonsoft.Json; //Biblioteca que carrega as dependecias de manipulação Json, PRECISA SER BAIXADA PELO PACOTE DE NUGET digitando 'Newtonsoft'
namespace ProjetoEntrevista.helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _contextAccessor; //Constate do tipo IHttpContextAccessor que é a tipagem de sessão pela biblioteca Microsoft.AspNetCore.Http

        public Sessao(IHttpContextAccessor contextAccessor) //construtor da classe para ser instânciado a atribuida a  constante o contextAccessor do tipo  IHttpContextAccessor
        {
            _contextAccessor = contextAccessor; //atribuição para constante do gestor de sessão
        }

        ModelUsuario ISessao.BuscarSessaoDoUsuario()
        {
            string sessionUsuario = _contextAccessor.HttpContext.Session.GetString("sessaoUsuarioLogado"); //Aqui estou pelo meu método BuscarSessaoDoUsuario, trazendo minha sessão com a chave "sessaoUsuarioLogado" e atribuindo a minha variavel sessionUsuario
            if (string.IsNullOrEmpty(sessionUsuario)) return null; //verifico pelo string.IsNullOrEmpty se esta vazia a sessionUsuario

            return JsonConvert.DeserializeObject<ModelUsuario>(sessionUsuario); //pelo JsonConvert.DeserializeObject<ModelUsuario> transformo novamente minha sessionUsuario em objeto ModelUsuario e retorno na chamada dessa função
        }

        void ISessao.CriarSessaoDoUsuario(ModelUsuario Usuario)
        {
            string valor = JsonConvert.SerializeObject(Usuario); //Esse comando 'JsonConvert.SerializeObject' tranforma nosso objeto ModelUsuario em uma string Json. nescessário para se colocada na sessão abaixo
            _contextAccessor.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);// Aqui estou criando de fato minha sessão do chave "sessaoUsuarioLogado" e o valor é a o objeto convertido acima pelo jSON
        }

        void ISessao.RemoverSessaoDousuario()
        {
            _contextAccessor.HttpContext.Session.Remove("sessaoUsuarioLogado"); //esse método simplismente remove a sessão da chave indicada no parenteses ("sessaoUsuarioLogado")
        }
    }
}
