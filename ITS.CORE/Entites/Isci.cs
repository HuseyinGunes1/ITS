using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.CORE.Entites
{
   public class Isci
    {
        public int IsciId { get; set; }

        public string IsciAdi { get; set; }
        public string IsciSoyadi { get; set; }

        public int AileId { get; set; }
        public int GrupId { get; set; }

        public virtual Aile Aile { get; set; }
        public virtual Grup Grup { get; set; }
        public virtual ICollection<Gider> Gider { get; set; }
        public virtual ICollection<IsIsci> IsIsci { get; set; }
    }
}
