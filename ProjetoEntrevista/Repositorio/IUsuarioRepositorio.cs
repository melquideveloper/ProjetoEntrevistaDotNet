using ProjetoEntrevista.Models;
namespace ProjetoEntrevista.Repositorio
{
    public interface IUsuarioRepositorio
    {
        ModelUsuario Adicionar(ModelUsuario usuer);

        ModelUsuario Remover(int id);

        ModelUsuario BuscarUsuario(int id);

        ModelUsuario LoginUsuario(string login);

        List<ModelUsuario> BuscarUsers();

        ModelUsuario Editar(ModelUsuario usuario);
    }
}
