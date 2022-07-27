﻿using ProjetoEntrevista.Enum;

namespace ProjetoEntrevista.Models
{
    public class ModelUsuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public Perfil Perfil { get; set; }
        public string senha { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
