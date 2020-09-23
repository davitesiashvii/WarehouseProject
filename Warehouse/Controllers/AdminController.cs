using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO.Admin;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<AppUser> userManager;
        private RoleManager<IdentityRole> roleManager;

        public AdminController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Users()
        {
            return View(userManager.Users);
        }

        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>CreateUser(CreateUserDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    
                    UserName = model.Name,
                    Email = model.Email
                };
                

                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Users));
                }
                else
                {
                    AddErrorsFromResult(result); 
                }
            }
            return View(model);

        }
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> EditUser(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                EditUserDTO model = new EditUserDTO();
                model.Id = user.Id;
                model.Email = user.Email;
                model.Roles = roleManager.Roles.Select(x => x.Name).ToList();
                model.UserRoles = (List<string>)await userManager.GetRolesAsync(user);
                return View(model);
            }
            else
            {
                return RedirectToAction("Users");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserDTO model)
        {
            AppUser user = await userManager.FindByIdAsync(model.Id);
            if (user != null)
            {
                user.Email = model.Email;
                IdentityResult result = await userManager.UpdateAsync(user);
                var roles = await userManager.GetRolesAsync(user);
                foreach (var role in roles)
                {
                    if (model.UserRoles == null ||
                        (model.UserRoles != null && !model.UserRoles.Contains(role)))
                    {
                        await userManager.RemoveFromRoleAsync(user, role);
                    }
                }
                if (model.UserRoles != null)
                {
                    foreach (var role in model.UserRoles)
                    {
                        if (!roles.Contains(role))
                        {
                            await userManager.AddToRoleAsync(user, role);
                        }
                    }
                }
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Users));
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "User not found");
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Users));
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View("Users", userManager.Users);
        }

        public IActionResult Roles()
        {
            return View(roleManager.Roles);
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Roles));
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(name);
        }



    }
}