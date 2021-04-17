using ITS.CORE.Dto;
using ITS.CORE.Entites;

using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.CORE.Services
{
   public interface ITokenService
    {
        TokenEntity CreateToken(Cavus cavus);
    }
}
