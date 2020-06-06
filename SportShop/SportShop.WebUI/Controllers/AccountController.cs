using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Security.Claims;
using SportShop.DLL.Interfaces;
using SportShop.DLL.DTO;
using SportShop.DLL.Infrastructure;
using SportShop.WebUI.Models;
using SportShop.DLL.Services;

namespace SportShop.WebUI.Controllers
{

    /// <summary>
    /// This is where you log in, register and log out.
    /// </summary>
    [Authorize]
    public class AccountController : Controller
    {
        private IServiceCart serviceCart;
        public AccountController(IServiceCart serviceCart)
        {
            this.serviceCart = serviceCart;
        }

        private void MigrateShoppingCart(string  Email) 
        {
            var cart = serviceCart.GetCart(this.HttpContext);
            ///cart.GetMigrateCart(Email);
            Session[serviceCart.CartSessionKey] = Email;
        }

        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await UserService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    if (model.Email == "manager@gmail.com")
                    {
                        return RedirectToAction("Index", "Manager");
                    }
                    MigrateShoppingCart(model.Email);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    Address = model.Address,
                    Name = model.Name,
                    Role = "user"
                };
                OperationDetails operationDetails = await UserService.Create(userDto);
                if (operationDetails.Succedeed)
                    return RedirectToAction("Index", "Home");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }

        
        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new UserDTO
            {
                Email = "manager@gmail.com",
                UserName = "manager@gmail.com",
                Password = "Manager_123",
                Name = "Traviss",
                Address = "not matter",
                Role = "admin",
            }, new List<string> { "user", "admin" });
        }
        protected override void Dispose(bool disposing)
        {
            serviceCart.Dispose();
            base.Dispose(disposing);
        }
    }
}