using System;

namespace ProAgil.Domain
{
    public class Lote
    {
        public int id { get; set; }
         public string Nome { get; set; }
         public int Preco { get; set; }
         public DateTime? DataIncio { get; set; }
         public DateTime? DataFim { get; set; }
         public DateTime? Quantidade { get; set; }
         public int EventoId  { get; set; }
         public Evento Evento  { get; }
         // 1 pra 1 
    }
}