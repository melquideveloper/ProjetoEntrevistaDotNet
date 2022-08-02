using ProjetoEntrevista.Models;
namespace ProjetoEntrevista.helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(ModelUsuario Usuario);

        void RemoverSessaoDousuario();

        ModelUsuario BuscarSessaoDoUsuario();
    }
}
