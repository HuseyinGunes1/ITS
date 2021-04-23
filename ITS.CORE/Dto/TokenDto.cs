using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.CORE.Dto
{
   public class TokenDto
    {
        public string AccessToken { get; set; }
        public DateTime AccesTokenLifeTime { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenLifeTime { get; set; }
    }
}
