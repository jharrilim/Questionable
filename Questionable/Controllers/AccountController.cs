using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Questionable.Data.Entities;
using Questionable.ViewModels;

namespace Questionable.Controllers
{
	public class AccountController : Controller
    {
		private UserManager<User> UserManager { get; }
		private SignInManager<User> SignInManager { get; }

		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			UserManager = userManager;
			SignInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var loginResult = await SignInManager
					.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
				if (loginResult.Succeeded)
				{
					if (Url.IsLocalUrl(model.ReturnUrl))
						return Redirect(model.ReturnUrl);
					else
						return RedirectToAction("Index", "Home");
				}
			}
			ModelState.AddModelError("", "Could not login.");
			return View(model);
		}

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Logout()
		{
			await SignInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterUserViewModel model)
		{
			if (!ModelState.IsValid)
				return View();

			var user = new User
			{
				UserName = model.Username
			};

			var createResult = await UserManager.CreateAsync(user, model.Password);
			if (createResult.Succeeded)
			{
				await SignInManager.SignInAsync(user, false);
				return RedirectToAction("Index", "Home");
			}
			else
			{
				foreach (var error in createResult.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
				return View();
			}
		}
    }
}
