using ProjetoEntrevista.Enum;

namespace ProjetoEntrevista.Models
{
    public class ModelUsuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public Perfil Perfil { get; set; }
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha) //retorna valor booleando se a comparação da senha ...
        {
            return Senha == senha; 
        }
    }
}
