using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.CORE.Entites
{
   public class IsIsci
    {
         public int IsciId { get; set; }
         public int IsId { get; set; }
         public bool? Durumu { get; set; }

         public double Yövmiye { get; set; }
        public virtual Is Is { get; set; }
        public virtual Isci Isci { get; set;} 
    }
}
