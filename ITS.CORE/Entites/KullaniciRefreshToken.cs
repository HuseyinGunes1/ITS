using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.CORE.Entites
{
   public class KullaniciRefreshToken
    {
        public string CavusId { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenOmru { get; set; }
    }
}
