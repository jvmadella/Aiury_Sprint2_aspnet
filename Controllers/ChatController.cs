using System.Threading.Tasks;
using Aiury.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Aiury.Data;

namespace Aiury.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly MeuDbContext _context;

        public ChatController(MeuDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Iniciar()
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdString))
            {
                return Unauthorized();
            }

            var idUsuarioLogado = int.Parse(userIdString);

            var novoChat = new Chat
            {
                IdUsuario = idUsuarioLogado,
                DataInicio = DateTime.UtcNow,
                Ativo = true,
                IdAjudante = null,
                DataFim = null
            };

            _context.Chats.Add(novoChat);

            await _context.SaveChangesAsync();

            int novoChatId = novoChat.IdChat;


            return RedirectToAction("Chat", new { id = novoChatId });
        }

        [HttpPost]
        public IActionResult Atender(int id)
        {
            return RedirectToAction("Chat", new { id = id });
        }

        public IActionResult Chat(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
