namespace TabelaTPL.Models
{
    public class Disponibilidade
    {
        public int Id { get; set; }
        public Disponibiilidade Disponibilidades { get; set; }
        public int VoluntariosId { get; set; }
        public virtual Voluntarios? Voluntarios { get; set; }
    }
    public enum Disponibiilidade
    {
        SEG_8h_10h = 1,
        SEG_10h_12h = 2,
        SEG_12h_14h = 3,
        SEG_14h_16h = 4,
        SEG_16h_18h = 5,

        TER_8H_10 = 6,
        TER_10H_12h = 7,
        TER_12h_14h = 8,
        TER_14h_16h = 9,
        TER_16h_18h = 10,
    }

}
