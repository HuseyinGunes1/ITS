using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsciTakipSistemi.UI.Areas.AdminPaneli.Controllers
{
	[Area("AdminPaneli")]
	public class GrupController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult GrupEkle()
		{
			return View();
		}
	}
}
