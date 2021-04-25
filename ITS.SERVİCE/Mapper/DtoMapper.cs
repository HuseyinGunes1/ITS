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
            CreateMap<CreateIsciDto, Isci>().ReverseMap();
            CreateMap<CreateIsverenDto, Isveren>().ReverseMap();
            CreateMap<CreateIsDto, Is>().ReverseMap();
        }
    }
}
