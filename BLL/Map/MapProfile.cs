using AutoMapper;
using BLL.DTO.Production;
using BLL.DTO.Shope;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Map
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Production, ProductionDTO>();


            CreateMap<ShopeDTO, Shope>();

            CreateMap<Shope, ShopeDTO>()
                    .ForMember(dest =>
                     dest.Productions,
                     opt => opt.MapFrom(src => src.Productions.Select(src => $"{src.Production.Name} {src.Production.ManufacturerCompany}")));
            
            CreateMap<Shope, ShopeFormDTO>()
                     .ForMember(dest =>
                     dest.ProductionIds,
                     opt => opt.MapFrom(src => src.Productions.Select(x => x.ProductionID).ToList()));

            
            CreateMap<ShopeFormDTO, Shope>()
                .ForMember(dest =>
                     dest.Productions,
                     opt => opt.MapFrom(src => src.ProductionIds.Select(x => new ProductionShope { ProductionID = x })));


           



            CreateMap<Production, CreateProductionDTO>();

            CreateMap<CreateProductionDTO, Production>();
        }

    }
}
