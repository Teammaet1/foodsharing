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
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager; 
        private readonly SignInManager<ApplicationUser> signInManager;
        public AccountController(UserManager<ApplicationUser> userMgr, SignInManager<ApplicationUser> signinMgr)
        {
            userManager = userMgr;
            signInManager = signinMgr;
        }

        [HttpPost]
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
                       // await Authenticate(user); 

                        return Ok(model); 
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.Email), "Неверный email или пароль");
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
        public async Task<IActionResult> AuthorizeRole()
        {
            if (User.Identity.IsAuthenticated) 
                if (User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value == "admin") 
                    return Ok(); 
            return NotFound(); 
        }

        //private async Task Authenticate(ApplicationUser user) 
        //{
        //    if (userManager.GetRolesAsync(user).Result.FirstOrDefault() == "user") 
        //    {
        //        var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Email, user.Email),
        //        new Claim(ClaimTypes.Name, user.UserName),
        //        new Claim("FIO", user.Surname + " " + user.Firstname + " " + user.Patronymic),
        //        new Claim(ClaimsIdentity.DefaultRoleClaimType, userManager.GetRolesAsync(user).Result.FirstOrDefault()),
        //        new Claim(ClaimTypes.NameIdentifier, user.Id),
        //        new Claim("course", user.Course.ToString()),
        //        new Claim("group", user.Group),
        //        new Claim("faculty", user.Faculty),
        //        new Claim("dateend", user.DateEnd.ToString()),
        //        new Claim("birthdate", user.BirthDate.ToString()),
        //        new Claim("specialization", user.Specialization),
        //        new Claim("formofeducation", user.FormOfEducation),
        //        //new Claim("formofeducation", user.FormOfEducation),
        //        //new Claim("formofeducation", user.FormOfEducation),
        //        //new Claim("formofeducation", user.FormOfEducation),
        //        //new Claim("formofeducation", user.FormOfEducation),
        //    };


        //        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookies", ClaimsIdentity.DefaultNameClaimType,
        //            ClaimsIdentity.DefaultRoleClaimType); // Сами настрой для куки и что в них заносить

        //        await HttpContext.SignInAsync("Identity.Application", new ClaimsPrincipal(id)); //Имя куки в браузере и данные которые занесутся туда
        //                                                                                        //TODO: ПЕРЕДЕЛАТЬ КУКИ МАЙКРОСОФТ ЭДЖ, МАКЕТ ДОЛЖЭЕН БЫТЬ С ДАННЫМИ СРАЗУ


        //    }
        //}
    }
}