using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.CORE.Entites
{
   public class Is
    {
        public int IsId { get; set; }
        public string IsAdi { get; set; }
        public DateTime Tarih { get; set; }
        public int IsverenId { get; set; }
        public int GrupId { get; set; }
        public virtual Isveren Isveren { get; set; }
        public virtual Grup Grup { get; set; }
        public virtual ICollection<IsIsci> IsIsci { get; set; }
    }
}
