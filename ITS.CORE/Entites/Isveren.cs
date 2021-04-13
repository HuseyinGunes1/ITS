using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.CORE.Entites
{
   public class Isveren
    {
        public int IsverenId { get; set; }
        public string IsverenAdi { get; set; }
        public string IsverenSoyadi { get; set; }
        public virtual ICollection<Is> Is { get; set; }
    }
}
