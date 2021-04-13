
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.CORE.Entites
{
   public class Cavus:IdentityUser
    {
        public int GrupId { get; set; }
        public virtual Grup Grup { get; set; }
    }
}
