using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectAuth.ViewModels;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Http.Internal;
using ProjectAuth.Models;
using System.Security.Claims;

namespace ProjectAuth.Controllers
{
    public class RolesController : Controller
    {
        //private ApplicationDbContext context = new ApplicationDbContext();

        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RolesController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            context = db;
        }



        public ActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        public IActionResult Create(string RoleName)
        {
            try
            {
                    context.Roles.Add(new IdentityRole()
                    {
                        Name = RoleName
                    });
                    context.SaveChanges();
                    ViewBag.ResultMessage = "Role created successfully !";
                    return RedirectToAction("Create");
             }
            catch
            {
                return View();
    }
}
    }
}
