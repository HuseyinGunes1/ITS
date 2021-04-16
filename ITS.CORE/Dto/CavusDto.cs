using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.CORE.Dto
{
   public  class CavusDto //Cliente dönecek olan kullanıcı bilgilerini içiren sınıftır
    {
        public string CavusId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int GrupId { get; set; }
    }
}
