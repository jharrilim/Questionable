using Microsoft.AspNetCore.Mvc;

namespace Questionable.ViewComponents
{
	public class LoginLogoutViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
