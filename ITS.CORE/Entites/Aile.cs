using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.CORE.Entites
{
   public class Aile
    {
        public int AileId { get; set; }
        public string AileAdi { get; set; }

        public int GrupId { get; set; }

        public virtual Grup Grup { get; set; }
        public virtual ICollection<Isci> Isci { get; set; }
    }
}
