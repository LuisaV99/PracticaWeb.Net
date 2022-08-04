using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPractica.Models;

namespace WebPractica.Controllers
{
    public class CuentasController : Controller
    {

        //Variable apara crear el password
        private readonly UserManager<IdentityUser> _userMananger;
        //Variable para autenticarse
        private readonly SignInManager<IdentityUser> _signInManager;

        //Creamos el constructor de esta clse con ctor

        public CuentasController (UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userMananger = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Retorma la vista Registro usuario
        [HttpGet]

        public async Task <IActionResult> Registro()
        {
            RegistroUsuarios RuVista = new RegistroUsuarios();
            return View(RuVista);
        }

        //Guarda el registro en la base de datos 
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Registro (RegistroUsuarios ru)
        {
            //Verifico si el modelo es valido
            if(ModelState.IsValid)
            {
                //Creo una variable
                var usuario = new AppUsuario
                {
                    UserName = ru.Email,
                    Email = ru.Email,
                    Documento = ru.Documento,
                    Nombre = ru.Nombre

                };
                //Recibe dos parametros, la variable usuario y el password
                var resultado = await _userMananger.CreateAsync(usuario, ru.Password);
                //Verifica que todo salio bien
                if (resultado.Succeeded)
                {
                    //Se autenticarse
                    await _signInManager.SignInAsync(usuario, isPersistent: false);
                    //Vuelve a la pagina inicio
                    return RedirectToAction("Index", "Home");
                }
                ValidarErrores(resultado);

            }
            //Si el modelo no es valido retorna a la vista donde estaba
            return View(ru);
        }
        //Manejador de errores
        private void ValidarErrores(IdentityResult resultado)
        {
            foreach (var error in resultado.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        //Metodo mostrar formulario de acceso
        [HttpGet]
        public IActionResult Acceso()
        {
            return View();
        }

           [HttpPost]
    public async Task<IActionResult> Acceso (LoginUsuarios lu) 
        { 
            if (ModelState.IsValid)
            {
                //Recibe dos parametros, la variable dusuario y el password
                var resultado = await _signInManager.PasswordSignInAsync(lu.Email, lu.Password, lu.Rememberme, lockoutOnFailure: false);
                //Verifica aque todo salió bien
                if (resultado.Succeeded)
                {
                    //Vuelve a la pagina inicio
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Ingreso inválido");
                    return View(lu);
                }
            }
            return View(lu);
        }
        //Cerrar sesion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>SalirAplicacion()
        {
            //Cierra la sesion (logout)
            await _signInManager.SignOutAsync();
            //Vuelve a la paagina Inicio
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
