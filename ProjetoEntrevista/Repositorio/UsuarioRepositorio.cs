using ProjetoEntrevista.Models;
using ProjetoEntrevista.Repositorio;
using ProjetoEntrevista.Data;
using ProjetoEntrevista.helper;

namespace ProjetoEntrevista.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        public readonly BancoDeDados _bancodedados;

        public UsuarioRepositorio(BancoDeDados bancoDeDados)
        {
            _bancodedados = bancoDeDados;
        }

        public ModelUsuario LoginUsuario(string login)
        {
            return _bancodedados.Usuarios.FirstOrDefault(x => x.Login == login);
        }

        public ModelUsuario Adicionar(ModelUsuario user)
        {
            user.DataCadastro = DateTime.Now; //Incluo aqui a data de catras do usuário uma vez que não vem do form 'cadastrar'                
            user.InsiraSenhaComHash(); //Esse método 'InsiraSenhaComHash()' esta dentro da Model, que fará com que a senha já informada pelo usuário e setada lá no model, seja convertida para modo Hash
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
            usuariodb.Senha = usuario.Senha.GerarHash();
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

        public ModelUsuario BuscarEmailLogin(string login, string email)
        {
            return _bancodedados.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper()==login.ToUpper());  //Essa busca ou 'SELECT' no banco, contempla uma clausula 'WHERE' com dois parâmentros , o LOGIN e o EMAIL (x => x.EMAIL.ToUpper() == EMAIL.ToUpper() && x.LOGIN.ToUpper()==LOGIN.ToUpper())
        }

        public ModelUsuario RedefinicaoDeSenhaSendEmaill(ModelUsuario user)
        {
             
                user.DataAtualizacao = DateTime.Now;
            _bancodedados.Usuarios.Update(user);
            _bancodedados.SaveChanges();
            return user;

        }
    }
}
