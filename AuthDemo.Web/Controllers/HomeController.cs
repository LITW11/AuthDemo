using AuthDemo.Data;
using AuthDemo.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AuthDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress; Initial Catalog=AuthDemo; Integrated Security=true;";

        public IActionResult Index()
        {
            var vm = new HomeViewModel();
            if (User.Identity.IsAuthenticated)
            {
                vm.Message = "Welcome Logged in user!!";
                var repo = new UserRepository(_connectionString);
                var user = repo.GetByEmail(User.Identity.Name);
                vm.User = user;
            }
            else
            {
                vm.Message = "Welcome guest :)";
            }
            return View(vm);
        }

        [Authorize]
        public IActionResult Secret()
        {
            var email = User.Identity.Name;
            var repo = new UserRepository(_connectionString);
            var user = repo.GetByEmail(email);

            return View(new SecretPageViewModel
            {
                User = user
            });
        }
    }
}