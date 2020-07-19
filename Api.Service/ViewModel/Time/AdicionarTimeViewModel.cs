using System.ComponentModel.DataAnnotations;

namespace Service.ViewModel.Time
{
    public class AdicionarTimeViewModel
    {
        [Required]
        [StringLength(100)]
        public string nome { get; set; }
        [Required]
        [StringLength(10)]
        public string sigla { get; set; }
    }
}