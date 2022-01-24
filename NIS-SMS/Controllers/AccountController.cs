using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NIS.ViewModel;
using System.Threading.Tasks;

namespace NIS.Controllers
{
    public class AccountController : Controller
    {
        //create user manager
        public UserManager<IdentityUser> UserManager { get; }
        public SignInManager<IdentityUser> SignInManager { get; }

        public AccountController(UserManager<IdentityUser> _usermanager, SignInManager<IdentityUser> _signInManager)
        {
            UserManager = _usermanager;
            SignInManager = _signInManager;
        }


        //Registeration
        public IActionResult Registeration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registeration(RegisterAccountVM NewAccount)
        {
            if (ModelState.IsValid)
            {
                //map from identity user -> RegisterAccountVM
                IdentityUser user = new IdentityUser();
                user.UserName = NewAccount.UserName;
                user.Email = NewAccount.Email;


                //save user

               IdentityResult result = await UserManager.CreateAsync(user, NewAccount.Password);

                //if result succeeded 
                if (result.Succeeded)
                {
                    //create cookie
                    await SignInManager.SignInAsync(user, false);

                    //if user is created successfully
                    //redirect to action
                    return RedirectToAction("index", "Department");
                }

                //else if creation is failed
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            //return model & modelstate error
            return View(NewAccount);
        }




        //Login
        //open Login Page
        public IActionResult Login(string RetrunUrl = "/Department/index")
        {
            ViewData["RedirectUrl"] = RetrunUrl;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginUser, string RetrunUrl = "/Department/index")
        {
            if (ModelState.IsValid == true)
            {
                //fined created user
                IdentityUser user = await UserManager.FindByNameAsync(loginUser.UserName);

                if (user != null)
                {
                    //sign in
                    Microsoft.AspNetCore.Identity.SignInResult result =  
                        await SignInManager.PasswordSignInAsync(user, loginUser.Password, loginUser.isPresisite,false);

                    if (result.Succeeded)
                        //return RedirectToAction("index", "Department");
                        return LocalRedirect(RetrunUrl);
                    else
                        ModelState.AddModelError("", "incorrect username or password");
                }
                else
                {
                    ModelState.AddModelError("", "invalid username or Password");
                }
               
            }

            //check and create cookie
            return View(loginUser);
        }

        


        //Logout
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("login", "Account");
        }
    }
}
