using Cinema.Models;
using Cinema.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager; 
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterVM account)
        {
            if (ModelState.IsValid)
            {
                
                var userIdentity = new User { Email = account.Email, UserName = account.Username, Name = account.Name, Lastname = account.Lastname };
                var result = await _userManager.CreateAsync(userIdentity, account.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(userIdentity, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);

                }
            }
            return View(account);

        }

        public  IActionResult Login()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, true, false);

                if (result.Succeeded) return RedirectToAction("index", "home");

                else ModelState.AddModelError("", " invalid login info");
            }
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        public IActionResult CreateRole()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleVM role)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole() { Name = role.Name};
                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded) return RedirectToAction("index", "home");
                foreach (var error in result.Errors) ModelState.AddModelError("", error.Description);
            }

            return View(role);
        }

        public IActionResult ListRoles()
        {
            var listofviews = _roleManager.Roles.ToList();
            return View(listofviews);
        }
        [HttpGet]
        public async Task<IActionResult> Inrole(string role)
        {
            var roleobj = await _roleManager.FindByIdAsync(role);

            if (roleobj == null)
            {
                // Handle the case where the role doesn't exist
                return NotFound();
            }

            var usersInRole = await _userManager.GetUsersInRoleAsync(roleobj.Name);

            var rolevm = new RoleVM()
            {
                id = roleobj.Id,
                Name = roleobj.Name,
                users = usersInRole.ToList() // Assuming RoleVM.users is a List<User> property
            };

            return View(rolevm);
        }

        [HttpGet]
        public async  Task<IActionResult> addtorole(string id)
        {

            var role = await _roleManager.FindByIdAsync(id);
            var userlist = _userManager.Users.ToList();
            var availableusers = new List<IdentityUser>();

            foreach(var user in userlist)
            {
                if (!( await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    availableusers.Add(user);
                } 
            }
            ViewBag.role = role.Name;
            return View(userlist);

        }

        [HttpPost]
        public async Task<IActionResult> addtorole(addtoroleVM addtoroleVM)
        {
            foreach(var user in addtoroleVM.usernames)
            {
                var userobj = await _userManager.FindByEmailAsync(user);
                await _userManager.AddToRoleAsync(userobj, addtoroleVM.Role);

            }
            return Content("Done");
        }

    }
}
