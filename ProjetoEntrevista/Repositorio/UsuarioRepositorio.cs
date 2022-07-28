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

        public ModelUsuario BuscarUsuario(int id)
        {
            return _bancodedados.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public ModelUsuario Remover(int id)
        {
            ModelUsuario user = BuscarUsuario(id);
            if (user == null) throw new System.Exception("Erro em remover o registro. Usuário não encontrado");

            _bancodedados.Usuarios.Remove(user);
            _bancodedados.SaveChanges();
            return (user);
        }
    }
}
