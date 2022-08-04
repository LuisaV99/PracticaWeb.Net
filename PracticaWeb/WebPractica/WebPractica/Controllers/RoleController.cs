using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPractica.Models;

namespace WebPractica.Controllers
{
    public class RoleController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(UserManager<IdentityUser> userManager,
       RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //get all users and send to view
            var users = userManager.Users.ToList();
            return View(users);
        }
        [HttpGet]
        public IActionResult Create()
        {
            //return RedirectToAction(nameof(Create));
            return View(new IdentityRole());
        }
        [HttpPost]
        public async Task<IActionResult> Create(string role)
        {
            //crea un nuevo rol
            //Retorna todos los roles
            await roleManager.CreateAsync(new IdentityRole(role));
            return RedirectToAction(nameof(DisplayRoles));
        }
        [HttpGet]
        public IActionResult DisplayRoles()
        {
            //obtener todos los roles a visualiazar
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }
        [HttpGet]
        public IActionResult AddUserToRole()
        {
            //Obtiene todos los usuarios
            //Obtiene todos los roles
            //crear lista de selección y pasar usando viewBag
            var users = userManager.Users.ToList();
            var roles = roleManager.Roles.ToList();
            ViewBag.Users = new SelectList(users, "Id", "UserName");
            ViewBag.Roles = new SelectList(roles, "Name", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUserToRole(UserRole userRole)
        {
            //Busca un usuario por el userRole.UserId
            //verifica que user y user.role.name no esten vacios
            //asigna el rol al usuario
            //redirige al index
            var user = await userManager.FindByIdAsync(userRole.UserId);
            if (!(string.IsNullOrEmpty(userRole.UserId)) &&
           !(string.IsNullOrEmpty(userRole.RoleName)))
            {
                await userManager.AddToRoleAsync(user, userRole.RoleName);
                return RedirectToAction(nameof(Index));
            }
            else
                return RedirectToAction(nameof(AddUserToRole));
        }
        [HttpGet]
        public async Task<IActionResult> Details(string userId)
        {
            //Busca el usuario por userId
            //Agrega el nombre del usuario a ViewBag
            //Obtien el userRole de users y se visualiza
            var user = await userManager.FindByIdAsync(userId);
            ViewBag.UserName = user.UserName;
            var userRoles = await userManager.GetRolesAsync(user);
            return View(userRoles);
        }
        [HttpGet]
        public async Task<IActionResult> RemoveUserRole(string role, string
       userName)
        {
            //get user from userName
            //remove role of user using userManager
            //return to details with parameter userId
            var user = await userManager.FindByNameAsync(userName);
            var result = await userManager.RemoveFromRoleAsync(user, role);
            return RedirectToAction(nameof(Details), new { userId = user.Id });
        }
        [HttpGet]
        public async Task<IActionResult> RemoveRole(string role)
        {
            //get role to delete using role Name
            //delete role using roleManager
            //redirect to displayroles
            var roleToDelete = await roleManager.FindByNameAsync(role);
            var result = await roleManager.DeleteAsync(roleToDelete);
            return RedirectToAction(nameof(DisplayRoles));
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
