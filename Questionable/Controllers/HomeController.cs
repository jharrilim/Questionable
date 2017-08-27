using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Questionable.ViewModels;

namespace Questionable.Controllers
{
	public class HomeController : Controller
    {
       public IActionResult Index()
        {
            return View();
        }

		[Route("/about")]
		public IActionResult About()
        {
            return View();
        }

		[Route("/contact")]
        public IActionResult Contact()
        {
            return View();
        }

		[Route("/create")]
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[Route("/create")]
		public IActionResult Create(CreateQuizViewModel model)
		{
//			if (ModelState.IsValid)
//			{
				foreach(var i in Request.Form)
				{
					System.Console.WriteLine(i.Value.ToString());
				}
//			}
			return View();
		}

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
