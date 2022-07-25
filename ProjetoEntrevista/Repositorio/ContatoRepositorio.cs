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

        public ModelContato Alterar(ModelContato contato)
        {
            ModelContato contatoBanco = BuscarContato(contato.Id); //Primeiro busco contato no banco 

            if (contatoBanco == null) throw new System.Exception("Registro não localizado. Erro ao atualiar!");

            /**
             * Depois realizo a preparação substituindo o valor dos dados no banco pelo valor vindo do usuário.
             */
            contatoBanco.Nome = contato.Nome;
            contatoBanco.Email = contato.Email;
            contatoBanco.Celular = contato.Celular;

            //Rodo no comando update as informações prontas
            _bancoDeDados.Contatos.Update(contatoBanco);
            //Depois confirmo o commit
            _bancoDeDados.SaveChanges();

            return contatoBanco;

        }

        public List<ModelContato> BuscarTodos() //Método responsável por buscar todos os contatos no banco 
        {
           return _bancoDeDados.Contatos.ToList(); // a constante _bancoDeDados é instacia criada aqui no contrutor que acessa o atributo Contatos já carregado pela migrations
        }

        public ModelContato BuscarContato(int id)
        {           
            return _bancoDeDados.Contatos.FirstOrDefault(x => x.Id == id);  // Busca primeira ou única ocorrência (FirstOrDefault) com ID informado, no banco de dados. onde x =>   x.Id (banco) seja igual ao id vindo do atributo (int id)
        }

        public bool Apagar(int id)
        {
            ModelContato contatoBanco = BuscarContato(id);
            if (contatoBanco == null) throw new System.Exception("Erro em remover o registro. Contato não encontrado");

            _bancoDeDados.Contatos.Remove(contatoBanco);
            _bancoDeDados.SaveChanges();

            return true;
            
        }
   
    }
}
