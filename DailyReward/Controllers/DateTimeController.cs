using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Acaplay365.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DateTimeController : Controller
	{
		[HttpGet("[action]")]
		public JsonResult GetUtcDateTime()
		{
			var utcTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss,fff");
			return Json(new
			{
				DateTime = utcTime
			});
		}

		[HttpGet("[action]")]
		public JsonResult GetUtcDate()
		{
			var utcDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
			return Json(new
			{
				Date = utcDate
			});
		}

		[HttpGet("[action]")]
		public JsonResult GetUtcTime()
		{
			var utcTime = DateTime.UtcNow.ToString("HH:mm:ss,fff");
			return Json(new
			{
				Time = utcTime
			});
		}
	}
}
