using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEntrevista.Models
{
    public class ModelContato
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Nome do contato!")] //"DATA_annotation" tornar o campo obrigatório, e exiber mensagem caso não preenchido
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Digite o email do contato!")]
        [EmailAddress(ErrorMessage = "O email informado não é válido")]  //"DATA_annotation validação" tipo email, caso preechido forma do formato de email exibe a mensgem
        public string? Email { get; set; }
        [Required(ErrorMessage = "Digite o celular do contato!")]
        [Phone(ErrorMessage = "O celular informado não é válido")]
        public string? Celular { get; set; }


       

    }
}
