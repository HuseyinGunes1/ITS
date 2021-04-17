using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.SERVİCE.Mapper
{
   public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(()=>//uygulama ayağa kalktığında memory e eklenmeyecek sadece çağırdığımızda eklenecek
          {
              var config= new MapperConfiguration(x =>
             {
                 x.AddProfile<DtoMapper>();
             });
              return config.CreateMapper();
  
          });
        public static IMapper MapperIslemleri => lazy.Value;
    }
}
