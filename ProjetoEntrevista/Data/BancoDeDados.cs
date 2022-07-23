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
         * Fazendo inclusão do ModelContato que esta na pasta Models aqui nessa classe, 
         * dessa forma será acessado os atributos e métodos de ModelContato, nescessário para ser criado a tabela no banco de dados pela migration 
         */
        public DbSet<ModelContato> Contatos { get; set; } //Tabela terá o nome de Contatos, conforme setado ao lado
    }
}
