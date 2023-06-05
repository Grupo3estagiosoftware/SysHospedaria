using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNugets.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public int NumPessoas { get; set; }
        public bool Estado { get; set; }

        [Required(ErrorMessage = "Selecione o hospede")]
        public int HospedeId { get; set; }

        public Hospede Hospede { get; set; }

        [Required(ErrorMessage = "Selecione o quarto")]
        public int QuartoId { get; set; }

        public Quarto Quarto { get; set; }
    }
}
