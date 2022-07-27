using ProjetoEntrevista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEntrevista.Repositorio
{

    public interface IContatoRepositorio
    {
        ModelCliente Adicionar(ModelCliente contato);  //Método responsável por adicionar um contato

        List<ModelCliente> BuscarTodos(); //Método responsável por buscar todos os contatos.

        ModelCliente BuscarContato(int id); //Método responsável por buscar um contato segundo seu ID.

        ModelCliente Alterar(ModelCliente contato); //Método responsável por buscar um contato segundo seu ID.

        bool Apagar(int id); //Método responsável por apagar um contato segundo seu ID.

    }
}
