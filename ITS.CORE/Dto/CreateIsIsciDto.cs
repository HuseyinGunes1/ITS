using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.CORE.Dto
{
	public class CreateIsIsciDto
	{
		public int IsciId { get; set; }
		public int IsId { get; set; }
		public bool Durumu { get; set; }
		public double Yövmiye { get; set; }
	}
}
