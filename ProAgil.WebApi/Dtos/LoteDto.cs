namespace ProAgil.WebApi.Dtos
{
    public class LoteDto
    {
         public int id { get; set; }
         public string Nome { get; set; }
         public int Preco { get; set; }
         public string DataIncio { get; set; }
         public string DataFim { get; set; }
         public int Quantidade { get; set; }
       
    }
}