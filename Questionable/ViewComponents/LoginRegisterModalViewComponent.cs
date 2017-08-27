using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionable.ViewComponents
{
    public class LoginRegisterModalViewComponent : ViewComponent
    {
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
