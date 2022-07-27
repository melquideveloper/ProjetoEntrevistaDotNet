using ProjetoEntrevista.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEntrevista.Data
{
    //Criando a conexão com banco herdando ou extend de DbContext, que já foi baixado pelo gerenciado de pacotes o Microsoft.EntityFrameworkCore
    public class BancoDeDados : DbContext 
    {


        /**
         O construtor da classe 
         Recebe como parâmetro DbContextOptions que extendeu do DbContext pelo método DbContextOptions e recebe o alias de 'options'
         */
        public BancoDeDados(DbContextOptions<BancoDeDados> options) : base(options)
        {

        }


        /**
         * Fazendo inclusão do ModelContato que esta na pasta Models, 
         * dessa forma será acessado os atributos e métodos de ModelContato, nescessário para ser criado a tabela no banco de dados pela migration 
         * e realizar manipulação no banco
         */
        public DbSet<ModelCliente> Contatos { get; set; } //Tabela no banco de dados terá o nome de Contatos... e tabém essa variável contato será carregar no projeto métodos como INSERT, UPDATE, DELETE quando insânciada aqui no projeto
        public DbSet<ModelUsuario> Usuarios { get; set; } //Tabela no banco de dados terá o nome de Usuarios... e tabém essa variável usuarios será carregar no projeto para invocar os métodos como INSERT, UPDATE, DELETE quando insânciada aqui no projeto
    }
}
