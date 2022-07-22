using ProjetoEntrevista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEntrevista.Repositorio
{
    public interface IContatoRepositorio
    {
        ModelContato Adicionar(ModelContato contato);
    }
}
