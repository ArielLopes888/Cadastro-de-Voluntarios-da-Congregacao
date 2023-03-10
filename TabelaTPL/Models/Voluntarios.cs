using System.ComponentModel;

namespace TabelaTPL.Models
{
    public class Voluntarios
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telefone { get; set; }
        public string Sexo { get; set; }
        public string? Informacoes { get; set; }
        public virtual ICollection<Disponibilidade>? Disponibilidade { get; set; }
    }
}

