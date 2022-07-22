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
        public BancoDeDados(DbContextOptions<BancoDeDados> options) : base(options)
        {

        }

        public DbSet<ModelContato> Contatos { get; set; }
    }
}
