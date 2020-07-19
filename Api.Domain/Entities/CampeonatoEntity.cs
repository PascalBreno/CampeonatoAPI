using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class CampeonatoEntity : BaseEntity
    {
        public string nome { get; set; }
        public string codigoCampeonato { get; set; }
        public virtual List<PartidaEntity> partidas { get; set; }
        public DateTime dataInicio { get; set; }
        public virtual DateTime? dataFinal { get; set; }
        public virtual TimeEntity campeao { get; set; }
        public virtual TimeEntity vici { get; set; }
        public virtual TimeEntity terceiro { get; set; }
    }
}