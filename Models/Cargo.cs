using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNugets.Models
{
    public class Cargo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo descriçao")]
        public string Descricao { get; set; }
    }
}
