using System;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel
{
    public class AdicionarCampeonatoViewModel
    {
        [Required]
        [StringLength(100)]
        public string nome { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? dataInicio { get; set; }
    }
}