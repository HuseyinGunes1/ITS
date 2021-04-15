using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ITS.Shared
{
   public class Response<T> where T:class //client a döneceğimiz hatalar ve dataların tutulduğu sınıf
    {
        public T data { get; private set; }
        public int StatusCode { get; private set; }
        [JsonIgnore]
        public bool IsSuccessfull { get; private set; }//kendi iç yapımda kullanacağım bir property

        public ErrorDto errors { get; private set; }


        public Response<T> Basarili(T data,int statusCode)
        {
            return new Response<T>
            {
                data = data,
                StatusCode = statusCode,
                IsSuccessfull = true
            };
        }

        public Response<T> Basarili( int statusCode)
        {
            return new Response<T>
            {
                data = default, //tipin varsayılan değeri dönecektir yani null dönecektir
                StatusCode = statusCode,
                IsSuccessfull = true
            };
        }

        public Response<T> Basarisiz(string errorMessage,int statusCode)
        {
            var error = new ErrorDto(errorMessage, true);
            return new Response<T>
            {
                errors = error,
                StatusCode = statusCode,
                IsSuccessfull = false
            };
        }
        public Response<T> Basarisiz(ErrorDto errorDto, int statusCode)
        {
          
            return new Response<T>
            {
                errors = errorDto,
                StatusCode = statusCode,
                IsSuccessfull = false
            };
        }
    }
}
