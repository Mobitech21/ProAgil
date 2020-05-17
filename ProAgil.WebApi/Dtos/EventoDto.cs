using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ProAgil.WebApi.Dtos
{
    public class EventoDto 
    {
        public int id { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }

        [Required(ErrorMessage= "O Tema deve ser informado")]
        public string Tema { get; set; }
        
        [Required(ErrorMessage="O Campo eh requerido")]
        [Range(1,200, ErrorMessage="Quantidade Invalida")]
        public int QtdPessoas { get; set; }
        public string  Lote { get; set; }

        [Phone]
        public string Telefone { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string ImagemUrl { get; set; }
        public List<LoteDto> Lotes {get;set;}
        public List<RedeSocialDto> RedesSociais { get; set; }
        public List<PalestranteDto> PalestranteEventos { get; set; }    



     }
}
