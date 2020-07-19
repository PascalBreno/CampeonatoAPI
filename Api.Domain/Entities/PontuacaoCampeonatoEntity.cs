namespace Domain.Entities
{
    public class PontuacaoCampeonatoEntity : BaseEntity
    {
        public virtual TimeEntity time { get; set; }
        public string codigoCampeonato { get; set; }
        public int pontuacaoTime { get; set; }
    }
}