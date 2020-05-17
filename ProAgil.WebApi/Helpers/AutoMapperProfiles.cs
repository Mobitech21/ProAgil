using AutoMapper;
using ProAgil.Domain;
using ProAgil.Domain.Entidades;
using ProAgil.WebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ProAgil.WebApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
       
        //     CreateMap<Evento,EventoDto>()
        //    .ForMember(dest => dest.Palestrante, opt => {
        //     opt.MapFrom(src => src.PalestrantesEventos.Select(x=> x.Palestrante).ToList());
        //      });
            

        //     CreateMap<Palestrante,PalestranteDto>()
        //     .ForMember(dest => dest.Eventos, opt => {
        //     opt.MapFrom(src => src.PalestrantesEventos.Select(x=> x.Evento).ToList());
        //     });
            
            CreateMap<Evento,EventoDto>().ReverseMap();
            CreateMap<Palestrante,PalestranteDto>().ReverseMap();;
            CreateMap<Lote,LoteDto>().ReverseMap();
            CreateMap<RedeSocial,RedeSocialDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();







        }

        
    }
}