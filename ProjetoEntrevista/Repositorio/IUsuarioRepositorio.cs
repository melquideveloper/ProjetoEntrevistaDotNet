using ProjetoEntrevista.Models;
namespace ProjetoEntrevista.Repositorio
{
    public interface IUsuarioRepositorio
    {
        ModelUsuario Adicionar(ModelUsuario usuer);

        ModelUsuario Remover(int id);

        ModelUsuario BuscarUsuario(int id);

        ModelUsuario LoginUsuario(string login);

        ModelUsuario BuscarEmailLogin(string login, string email);

        List<ModelUsuario> BuscarUsers();

        ModelUsuario Editar(ModelUsuario usuario);
    }
}
