using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NIS.ViewModel;
using System.Threading.Tasks;

namespace NIS.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        public RoleManager<IdentityRole> RoleManager { get; }

        public RoleController(RoleManager<IdentityRole> _RoleManager)
        {
            RoleManager = _RoleManager;
        }


        //add role
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleVM newRole)
        {
            if (ModelState.IsValid == true)
            {
                IdentityRole role = new IdentityRole() { Name = newRole.RoleName };

                IdentityResult result =  await RoleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return View();
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description); 
                    }
                }
            }
            return View(newRole);
        }

    }
}
