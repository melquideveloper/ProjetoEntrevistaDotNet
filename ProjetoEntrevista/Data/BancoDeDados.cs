using ProjetoEntrevista.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEntrevista.Data
{
    public class BancoDeDados : DbContext 
    {   
        //Criando a conexão com banco após ja ter baixados os pacotes para conexão com SQLserv
        public BancoDeDados(DbContextOptions<BancoDeDados> options) : base(options)
        {

        }
        //Fazendo referência ao ModelContato para ser acessado os atributos e métodos
        public DbSet<ModelContato> Contatos { get; set; }
    }
}
