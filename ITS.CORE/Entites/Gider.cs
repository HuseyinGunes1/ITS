using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.CORE.Entites
{
    public class Gider
    {
        public int GiderId { get; set; }
        public decimal GiderTutar { get; set; }
        public string GiderAciklama { get; set; }
        public DateTime GiderTarih { get; set; }
        public string GiderKisi { get; set; }
        public int IsciId { get; set; }
        public virtual Isci Isci { get; set; }
    }
}
