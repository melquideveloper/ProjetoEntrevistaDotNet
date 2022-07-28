using ProjetoEntrevista.Models;
namespace ProjetoEntrevista.Repositorio
{
    public interface IUsuarioRepositorio
    {
        ModelUsuario Adicionar(ModelUsuario usuer);

        List<ModelUsuario> BuscarUsers();
    }
}
