using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.CORE.Dto
{
	public class CreateGiderDto
	{
		public CreateGiderDto()
		{
            GiderTarih = DateTime.Now;
		}
        public int GiderId { get; set; }
        public decimal GiderTutar { get; set; }
        public string GiderAciklama { get; set; }
        public DateTime GiderTarih { get; set; }
        public string GiderKisi { get; set; }
        public int IsciId { get; set; }
    }
}
