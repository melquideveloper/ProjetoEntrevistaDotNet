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

        public ModelUsuario Editar(ModelUsuario usuario)
        {
            ModelUsuario usuariodb= BuscarUsuario(usuario.Id);
            usuariodb.Name = usuario.Name;
            usuariodb.Email = usuario.Email;
            usuariodb.Login = usuario.Login;
            usuariodb.Perfil = usuario.Perfil;
            usuariodb.Senha = usuario.Senha;
            usuariodb.DataAtualizacao = DateTime.Now;

            _bancodedados.Usuarios.Update(usuariodb);
            _bancodedados.SaveChanges();
            return usuariodb;
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
