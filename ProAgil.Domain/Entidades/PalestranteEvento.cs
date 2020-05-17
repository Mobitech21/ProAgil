namespace ProAgil.Domain.Entidades
{
    public class PalestranteEvento
    {
        public int PlaestranteId { get; set; }

        public Palestrante Palestrante { get; set; }
        public int EventoId { get; set; }

        public Evento Eventos { get; set; }

        // n pra n

    }
}