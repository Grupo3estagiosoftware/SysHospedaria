using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNugets.Models
{
    public class Hospede
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        public string Nome { get; set; }
        public string BI { get; set; }

        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Enderco { get; set; }
    }
}
