using AutoMapper;
using ITS.CORE.Dto;
using ITS.CORE.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.SERVİCE.Mapper
{
   internal class DtoMapper:Profile
    {
        public DtoMapper()
        {
            CreateMap<CavusDto, Cavus>().ReverseMap();
            CreateMap<CreateUserDto, Cavus>().ReverseMap();
            CreateMap<CreateIsciDto, Isci>().ReverseMap();
            CreateMap<CreateIsverenDto, Isveren>().ReverseMap();
            CreateMap<CreateIsDto, Is>().ReverseMap();
            CreateMap<CreateIsIsciDto, IsIsci>().ReverseMap();
            CreateMap<CreateGiderDto, Gider>().ReverseMap();
            CreateMap<CreateAileDto, Aile>().ReverseMap();
            CreateMap<CreateUcretDto, Ücret>().ReverseMap();
            CreateMap<CreateGrupDto, Grup>().ReverseMap();

        }
    }
}
