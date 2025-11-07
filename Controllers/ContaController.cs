using Aiury.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aiury.Controllers
{
    public class ContaController : Controller
    {
        public IActionResult RegistrarUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarUsuario(Usuarios novoUsuario)
        {
            return RedirectToAction("Index", "Home");
        }

    }
}
