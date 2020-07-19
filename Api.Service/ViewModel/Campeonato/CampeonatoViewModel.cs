using System;
using System.Collections.Generic;
using Application.ViewModel.Partida;
using Domain.Entities;

namespace Service.ViewModel.Campeonato
{
    public class CampeonatoViewModel
    {
        public string nome { get; set; }
        public string codigoCampeonato { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime? dataFinal { get; set; }
        public string campeao { get; set; }
        public string vici { get; set; }
        public string terceiro { get; set; }
        
        public List<PartidaViewModel> partidas { get; set; }
    }
}