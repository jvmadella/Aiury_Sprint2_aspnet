using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aiury.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        public IActionResult MeuPerfil()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AlterarNome(string novoNomeAnonimo)
        {
            return RedirectToAction("MeuPerfil");
        }
    }
}
