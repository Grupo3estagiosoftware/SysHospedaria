using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNugets.Models
{
    public class Check
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public bool Checkin { get; set; }
        public bool Chechout { get; set; }
        [Required]
        public int ReservaId { get; set; }

        [ForeignKey("ReservaId")]
        public Reserva Reserva { get; set; }

        //[Required]
        //public int FuncionarioId { get; set; }

        //[ForeignKey("FuncionarioId")]
        //public Funcionario Funcionario { get; set; }
    }
}
