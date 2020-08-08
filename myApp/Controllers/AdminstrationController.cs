using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using myApp.Models.Claims;
using myApp.Models.ViewModels;

namespace myApp.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminstrationController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AdminstrationController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        // CRUD For Roles
        public ActionResult Index()
        {
            return View(roleManager.Roles);
        }

        [HttpGet]
        [Authorize(Policy = "CUDRole")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Policy = "CUDRole")]
        public async Task<ActionResult> Create(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole()
                {
                    Name = model.Name
                };
                var result= await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, "Can Not Add Role");
                }
            }
            return View(model);
        }

       
        
        [HttpGet]
        [Authorize(Policy = "CUDRole")]
        public async Task<ActionResult> Edit(string RoleID)
        {
            var role = await roleManager.FindByIdAsync(RoleID);
            if(role==null)
            {
                return RedirectToAction(nameof(Index));
            }
            RoleViewModel roleView = new RoleViewModel
            {
                ID=role.Id,
                Name=role.Name,
            };
            var users =new List<UserRoleViewModel>();
            foreach (var user in userManager.Users)
            {
                users.Add(
                    new UserRoleViewModel
                    {
                        UserID = user.Id,
                        Email = user.Email,
                        IsSelected = await userManager.IsInRoleAsync(user, role.Name) ? true : false
                    });
            }
            roleView.Users = users;
            return View(roleView);
        }

        [HttpPost]
        [Authorize(Policy = "CUDRole")]
        public async Task<IActionResult> Edit(RoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(model.ID);
                role.Name = model.Name;
                await roleManager.UpdateAsync(role);
                foreach (var item in model.Users)
                {
                    var user = await userManager.FindByIdAsync(item.UserID);
                    if (item.IsSelected && !await userManager.IsInRoleAsync(user, role.Name))
                    {
                        await userManager.AddToRoleAsync(user, role.Name);
                    }
                    else if (!item.IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                    {
                        await userManager.RemoveFromRoleAsync(user, role.Name);
                    }
                }
                return RedirectToAction(nameof(Index));
            }


            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "CUDRole")]
        public async Task<ActionResult> Delete(string ID)
        {
            var role = await roleManager.FindByIdAsync(ID);
            var result =await roleManager.DeleteAsync(role);
            return RedirectToAction(nameof(Index));
        }



        //CRUD For Users
        [Authorize(Policy = "Users")]
        public ActionResult Users()
        {            
            return View(userManager.Users);
        }

        [Authorize(Policy = "Users")]
        [HttpGet]
        public async Task<ActionResult> ManageClaims(string UserID)
        {
            var user = await userManager.FindByIdAsync(UserID);
            AllClaims allClaims = AllClaims.GetInstance;
            ManageUserClaimsViewModel model = new ManageUserClaimsViewModel
            {
                UserId = UserID
            };

            List<CustomClaim> List = new List<CustomClaim>();
            var userClaims = await userManager.GetClaimsAsync(user);
            foreach (Claim claim in allClaims.Claims)
            {
                CustomClaim customClaim = new CustomClaim { Type = claim.Type, Value = claim.Value ,IsSelected=false};
                if(userClaims.Any(x=>x.Type==claim.Type))
                {
                    customClaim.IsSelected = true;
                }
                List.Add(customClaim);
            }
            model.Claims = List;

            return View(model);
        }

        [Authorize(Policy = "Users")]
        [HttpPost]
        public async Task<ActionResult> ManageClaims(ManageUserClaimsViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);
            await userManager.RemoveClaimsAsync(user, model.Claims.Select(x => new Claim(x.Type, x.Value)));
            await userManager.AddClaimsAsync(user, model.Claims.Where(x => x.IsSelected).Select(x => new Claim(x.Type, x.Value)));
            return RedirectToAction(nameof(Users));
        }



    }
}