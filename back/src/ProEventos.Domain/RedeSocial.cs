using ProEventos.Domain;

namespace ProEventos.Domain
{
    public class RedeSocial
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string url { get; set; }
        public int? EventoId { get; set; }
        public Evento evento { get; set; }
        public int? palestranteId { get; set; }
        public Palestrante palestrante { get; set; }
    }

}