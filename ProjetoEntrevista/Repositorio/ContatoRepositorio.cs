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
        private readonly BancoDeDados _bancoDeDados;  //Declaro uma constante nessa classe para receber a instância da conxeão ja instânciada na inicialização do projeto, que estsa na pasta Data 

        /**
         Construtro da classe que...
         Recebe atribuo do tipo BancoDeDados, que é nossa classe já instâciada na inicialização do projeto em startup.cs no método 'ConfigureServices'. 
         , e  e seta na constante _bancoDeDados desse classe ContatoRepositório
         Classe BancoDeDados se encontra na pasta DATA.
         */
        public ContatoRepositorio(BancoDeDados bancoDeDados)
        {
            _bancoDeDados = bancoDeDados;
        }

        public ModelContato Adicionar(ModelContato contato)
        {
            //Gravar no banco de dados
            //throw new NotImplementedException();
            _bancoDeDados.Contatos.Add(contato);  //nossa constante _bancoDeDados pelo método .Add "prepara" o INSERT NO BANCO DE DADOS com atributo recebido contato da calsse ModelContato
            _bancoDeDados.SaveChanges(); //nossa constante _bancoDeDados pelo método .SaveChanges da o COMMIT  equivalente ao 'pgquery' no POSTGREE, para de fato grava no banco de dados
            return contato;
        }
    }
}
