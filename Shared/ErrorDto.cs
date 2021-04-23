using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Shared
{
   public class ErrorDto
    {
        public List<string> Errors { get;  set; } //bir client bir endpointe istek yaptığında birden fazla hata meydana gelebilir bu hataları bu listede tutarız
        //dışardan bu nesne set edilmesin constructor da set edilsin
        public bool IsShow { get; set; } //oluşan hatayı kullanıcıya gösterip göstermememizi sağlar

        public ErrorDto()
        {
            Errors = new List<string>();
        }
        public ErrorDto(string error,bool isShow)
        {
            Errors.Add(error);
            IsShow = isShow;
        }
        public ErrorDto(List<string> error, bool isShow)
        {
            Errors = error;
            IsShow = isShow;
        }
    }
}
