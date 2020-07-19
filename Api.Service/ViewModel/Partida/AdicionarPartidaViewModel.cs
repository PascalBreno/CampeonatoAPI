using System;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Partida
{
    public class AdicionarPartidaViewModel
    {
        [Required]
        public string siglaTimeA { get; set; }
        [Required]
        public string siglaTimeB { get; set; }
        [Required]
        public int golsA { get; set; }
        [Required]
        public int golsB { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime data { get; set; }
        [Required]
        public string codigoCampeonato { get; set; }
    }
}