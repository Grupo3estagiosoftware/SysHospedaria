using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNugets.Models
{
    public class Preco
    {
        [Key]
        public int Id { get; set; }
        public decimal ValorPreco { get; set; }

        [DataType(DataType.Date)]
        public DateTime Inicio { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fim { get; set; }

    }
}
