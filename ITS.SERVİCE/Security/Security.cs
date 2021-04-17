using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.SERVİCE.Security
{
   internal static class Security
    {
        public static SecurityKey GetSymetricSecurityKey(string key)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }
    }
}
