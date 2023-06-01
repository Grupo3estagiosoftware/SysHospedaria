using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNugets.Models
{
    public class Cliente
    {
    
        public int Id { get; set; }
        [Required(ErrorMessage ="Preencha o campo nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencha o campo Email")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        public bool Ativo  { get; set; }
        public bool ClienteEspecial (Cliente cliente) 
        {
            return cliente.Ativo == true && DateTime.Now.Year - cliente.DataCadastro.Year >= 5;
                }
    }
}
