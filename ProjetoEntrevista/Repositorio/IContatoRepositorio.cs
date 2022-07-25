using ProjetoEntrevista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEntrevista.Repositorio
{

    public interface IContatoRepositorio
    {
        ModelContato Adicionar(ModelContato contato);  //Método responsável por adicionar um contato

        List<ModelContato> BuscarTodos(); //Método responsável por buscar todos os contatos.

        ModelContato BuscarContato(int id); //Método responsável por buscar um contato segundo seu ID.

        ModelContato Alterar(ModelContato contato); //Método responsável por buscar um contato segundo seu ID.

        bool Apagar(int id);

    }
}
