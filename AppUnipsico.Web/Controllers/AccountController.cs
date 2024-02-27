using AppUnipsico.Models;
using AppUnipsico.Models.Models.Usuarios;
using AppUnipsico.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppUnipsico.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<Funcao> _roleManager;
        private readonly SignInManager<Usuario> _signInManager;
        public readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context
          , UserManager<Usuario> userManager
          , RoleManager<Funcao> roleManager
          , SignInManager<Usuario> signInManager) 
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null, string loginName = null)
        {
            ViewBag.Confirm = TempData["Confirm"];
            ViewData["ReturnUrl"] = returnUrl;


            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "home");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = await this._context.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName);
                if (user == default)
                {
                    ModelState.AddModelError(string.Empty, "CPF ou senha inválida.");
                    return View(model);
                }
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {

                    await this._context.SaveChangesAsync();
                    return RedirectToLocal(returnUrl);
                }

                ModelState.AddModelError(string.Empty, "CPF ou senha inválida.");
                return View(model);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> CreateProfessor()
        {
            var existingAdmin = await _userManager.FindByEmailAsync("teste@teste.com.br");
            if (existingAdmin != null)
            {
                return Content("Já existe um administrador.");
            }

            var adminUser = new Usuario
            {
                Id = Guid.NewGuid(),
                UserName = "teste@teste.com.br",
                Nome= "admin",
                Email = "teste@teste.com.br",
                Cpf = "12345678910",
                EmailConfirmed = true,
                TipoUsuario =  AppUnipsico.Models.Enums.TipoUsuario.Professor
            };

            var createResult = await _userManager.CreateAsync(adminUser, "Teste@2024");

            if (createResult.Succeeded)
            {
             
                return Content("Professor criado com sucesso.");
            }

            foreach (var error in createResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Content("Erro ao criar o Professor.");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
