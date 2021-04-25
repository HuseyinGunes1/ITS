using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.CORE.Dto
{
	public class CreateIsciDto
	{
		public int IsciId { get; set; }
		public string IsciAdi { get; set; }
		public string IsciSoyadi { get; set; }
		public int AileId { get; set; }
		public int GrupId { get; set; }
	}
}
