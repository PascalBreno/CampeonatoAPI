using System;

namespace Domain.Entities
{
    public class PartidaEntity : BaseEntity
    {
        public virtual TimeEntity timeA { get; set; }
        public virtual TimeEntity timeB { get; set; }
        public int golsA { get; set; }
        public int golsB { get; set; }
        public DateTime data { get; set; }
        
        public string codigoCampeonato { get; set; }
    }
}