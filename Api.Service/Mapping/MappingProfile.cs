using System.Collections.Generic;
using Application.ViewModel;
using Application.ViewModel.Partida;
using Application.ViewModel.Time;
using AutoMapper;
using Domain.Entities;
using Domain.PageList;
using Service.ViewModel.Campeonato;
using Service.ViewModel.Time;

namespace Service.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<PartidaEntity, PartidaViewModel>()
                .ForMember(x => x.timeA, opt => opt.MapFrom(s => s.timeA.nome))
                .ForMember(x => x.timeB, opt => opt.MapFrom(s => s.timeB.nome));
            
            CreateMap<CampeonatoEntity, CampeonatoViewModel>()
                .ForMember(x=>x.campeao,y=>y.MapFrom(z=>z.campeao.nome))
                .ForMember(x=>x.vici,y=>y.MapFrom(z=>z.vici.nome))
                .ForMember(x=>x.terceiro,y=>y.MapFrom(z=>z.terceiro.nome))
                .ForMember(x=>x.partidas,y=>y.MapFrom(
                    z=>z.partidas));
            CreateMap<AdicionarCampeonatoViewModel, CampeonatoEntity>();
            CreateMap< AdicionarTimeViewModel,TimeEntity >();
            CreateMap< AdicionarTimeViewModel,TimeEntity >();
            CreateMap<TimeEntity,TimeViewModel>();
            CreateMap<AdicionarPartidaViewModel, PartidaEntity>();
            CreateMap<AlterarTimeViewModel, TimeEntity>();
           }
    }
}