using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FoodSharing.Domain.Entities;
using FoodSharing.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IESE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager; 
        private readonly SignInManager<ApplicationUser> signInManager;
        public AccountController(UserManager<ApplicationUser> userMgr, SignInManager<ApplicationUser> signinMgr)
        {
            userManager = userMgr;
            signInManager = signinMgr;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                ApplicationUser user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync(); 
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, true/*model.RememberMe*/, false); //TODO: кнопка запомнить меня //Проверям пароль и нужно ли запоминать аккаунт и входим в аккаунт(но запоминание еще не работает)
                    if (result.Succeeded) 
                    {
                        await Authenticate(user); 

                        return Ok(model); 
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.Email), "Неверный email или пароль");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return NotFound(model);
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser userName = await userManager.FindByNameAsync(model.UserName);
                IdentityUser userMail = await userManager.FindByEmailAsync(model.EMail);
                if (userName == null && userMail == null)
                {
                    await userManager.CreateAsync(new ApplicationUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = model.EMail,
                        UserName = model.UserName,
                        PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, model.Password)
                    });
                    return Ok(model);
                }
                ModelState.AddModelError(nameof(LoginViewModel.Email), "Аккаунт с такими данными существет");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return NotFound(model);
        }

        [Authorize]
        [HttpGet("Logout")] 
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }

        [HttpGet("Authorize")] 
        public async Task<IActionResult> Authorize()
        {
            if (User.Identity.IsAuthenticated)
                return Ok(); 
            return NotFound(); 
        }

        [HttpGet("AuthorizeRole")] 
        public async Task<IEnumerable<TypeUser>> AuthorizeRole()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = userManager.FindByIdAsync(User.FindFirst(x => x.Type == "id").Value).Result;
                if (user != null)
                    return user.TypeUsers;
            }
            return null; 
        }

        private async Task Authenticate(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim("id", user.Id)
            };


            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookies", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync("Identity.Application", new ClaimsPrincipal(id));
        }
    }
}