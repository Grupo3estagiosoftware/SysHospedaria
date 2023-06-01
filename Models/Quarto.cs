using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNugets.Models
{
    public class Quarto
    {
        [Key]
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Andar { get; set; }

        [Required(ErrorMessage = "Selecione o tipo")]
        public string Tipo { get; set; }
        public bool Ocupado { get; set; }

        [Required(ErrorMessage = "Selecione o preço") ] 
        public int PrecoId { get; set; }

        public Preco Preco { get; set; }
    }
}
