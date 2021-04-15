using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.CORE.Token
{
   public class Token
    {
        public string AccesToken { get; set; }
        public DateTime AccesTokenLifeTime { get; set; }

        public string RefreshToken { get; set; }
        public DateTime RefreshTokenLifeTime { get; set; }
    }
}
