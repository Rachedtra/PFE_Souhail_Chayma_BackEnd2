using AutoMapper;
using Poulina.GestionCommentaire.Domain.DTO;
using Poulina.GestionCommentaire.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poulina.GestionCommentaire.Api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SousCategorie, SousCategorieDTO>()
               .ForMember(d => d.CatLabel, i => i.MapFrom(src => src.Categories.Label))
               .ReverseMap();

            CreateMap<CatDemandeInfo, CatDemandeInfoDTO>()
             .ForMember(d => d.LabelCat, i => i.MapFrom(src => src.categories.Label))
             .ForMember(d => d.DescriptionInfo, i => i.MapFrom(src => src.demandeInformations.Description))
             .ReverseMap();

            CreateMap<CommDemandeInfo, CommDemandeInfoDTO>()
              .ForMember(d => d.DescriptionComm, i => i.MapFrom(src => src.commentaires.Description))
              .ForMember(d => d.DescriptionInfo, i => i.MapFrom(src => src.demandeInformations.Description))
              .ReverseMap();
            
            CreateMap<CommVote, CommVoteDTO>()
              .ForMember(d => d.DescriptionComm, i => i.MapFrom(src => src.commentaires.Description))
              .ForMember(d => d.Note, i => i.MapFrom(src => src.votes.Note))
              .ReverseMap();
        }
    }
}
