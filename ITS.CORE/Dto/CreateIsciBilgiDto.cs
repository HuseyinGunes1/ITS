using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.CORE.Dto
{
	public class CreateIsciBilgiDto
	{
		public string IsAdi { get; set; }
		public DateTime Tarih { get; set; }
		public bool? Durumu { get; set; }
		public string IsverenAdi { get; set; }
		public string IsverenSoyadi { get; set; }
	}
}
