using ProjetoEntrevista.Repositorio;
using ProjetoEntrevista.Models;
using ProjetoEntrevista.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEntrevista.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoDeDados _bancoDeDados;
        public ContatoRepositorio(BancoDeDados bancoDeDados)
        {
            _bancoDeDados = bancoDeDados;
        }

        public ModelContato Adicionar(ModelContato contato)
        {
            //Gravar no banco de dados
            //throw new NotImplementedException();
            _bancoDeDados.Contatos.Add(contato);
            _bancoDeDados.SaveChanges();
            return contato;
        }
    }
}
