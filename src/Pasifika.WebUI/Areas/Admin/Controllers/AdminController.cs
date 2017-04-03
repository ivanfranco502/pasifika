using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pasifika.Model;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Pasifika.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAuthenticationManager _authenticationManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<AppUser> userManager, IAuthenticationManager AuthenticationManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _authenticationManager = AuthenticationManager;
            _roleManager = roleManager;
        }

        public ActionResult Index()
        {
            return View(_userManager.Users);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error", result.Errors);
                }
            }
            else
            {
                return View("Error", new string[] { "User Not Found" });
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ViewModels.CreateModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { UserName = model.Name, Email = model.Email };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(model);
        }

        public async Task<ActionResult> Edit(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            //bool isAdmin = await _userManager.IsInRoleAsync(id, "Admin");

            if (user != null)
            {
                return View(new ViewModels.EditModel
                {
                    Usuario = user,
                    //IsAdmin = isAdmin
                });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        //public async Task<ActionResult> Edit(string id, string email, string password, bool IsAdmin)
        public async Task<ActionResult> Edit(string id, string email, string password)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = email;
                IdentityResult validEmail = await _userManager.UserValidator.ValidateAsync(user);
                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }
                IdentityResult validPass = null;
                if (password != string.Empty)
                {
                    validPass = await _userManager.PasswordValidator.ValidateAsync(password);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = _userManager.PasswordHasher.HashPassword(password);
                    }
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }
                if ((validEmail.Succeeded && validPass == null) || (validEmail.Succeeded && password != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        /*
                        if (!_roleManager.RoleExists("Admin"))
                            _roleManager.Create(new IdentityRole("Admin"));

                        if (IsAdmin)
                        {
                            if (!_userManager.IsInRole(id, "Admin"))
                                _userManager.AddToRole(user.Id, "Admin");

                            return RedirectToAction("Index");
                        }
                        else
                        {
                            if (_userManager.IsInRole(id, "Admin"))
                                _userManager.RemoveFromRole(user.Id, "Admin");

                            return RedirectToAction("Index");
                        }*/

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View(user);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}