using ITS.CORE.Entites;
using ITS.CORE.Token;
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
