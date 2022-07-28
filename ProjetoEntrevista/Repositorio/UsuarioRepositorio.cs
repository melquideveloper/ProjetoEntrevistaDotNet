using ProjetoEntrevista.Models;
using ProjetoEntrevista.Repositorio;
using ProjetoEntrevista.Data;

namespace ProjetoEntrevista.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        public readonly BancoDeDados _bancodedados;

        public UsuarioRepositorio(BancoDeDados bancoDeDados)
        {
            _bancodedados = bancoDeDados;
        }

        public ModelUsuario Adicionar(ModelUsuario user)
        {
            _bancodedados.Usuarios.Add(user);
            _bancodedados.SaveChanges();
            return user;
        }

        public List<ModelUsuario> BuscarUsers()
        {
            return _bancodedados.Usuarios.ToList();
        }
    }
}
