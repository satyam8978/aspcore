using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using AspCorePractie.Model;
using System.ComponentModel.DataAnnotations;

namespace AspCorePractie.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Services.Depend _myDependency;
        public IndexModel(ILogger<IndexModel> logger, Services.Depend myDependency)
        {
            _logger = logger;
            _myDependency = myDependency;

            _logger.LogInformation("The main page has been accessed");
        }
        public string Phone()
        {
            return "+49-333-3333333";
        }
        public void OnGet()
        {

             _myDependency.WriteMessage("hai");
           
                }
      
        public async Task<IActionResult> OnPostAsync(string username, string password)
        {

            if (!string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Login");
            }
          

            bool isAuthenticate = false;
            if (username == "admin" && password == "a")
            {
                var  claims = new List<Claim>
                {
                    new Claim("User",username),
                    new Claim("Role","Admin"),
                };
                var login = HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies", "User", "Role")));
                isAuthenticate = true;
            }
            if (username == "demo" && password == "c")
            {
                var claims = new List<Claim>
                {
                    new Claim("User",username),
                    new Claim("Role","Admin"),
                };
                var login = HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies", "User", "Role")));
                isAuthenticate = true;
            }
            if (isAuthenticate)
            {
               
               
                return RedirectToPage("./Emp/Index");
            }
            return RedirectToPage("./Index");
        }
    }
}
