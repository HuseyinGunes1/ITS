using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.CORE.Entites
{
   public class Grup
    {
        public int GrupId { get; set; }
        public string GrupAdi { get; set; }

        public virtual Cavus Cavus { get; set; }
        public virtual ICollection<Aile> Aile { get; set; }
        public virtual ICollection<Isci> Isci { get; set; }
        public virtual ICollection<Is> Is { get; set; }
    }
}
