using Microsoft.AspNetCore.Mvc;
using Aiury.Services;
using Aiury.ViewModels;
using Aiury.Models;

namespace Aiury.Controllers
{
    [Route("cidades")]
    public class CidadesController : Controller
    {
        private readonly ICidadeRepository _repo;
        public CidadesController(ICidadeRepository repo) => _repo = repo;

        [HttpGet("")]
        public IActionResult Index(string? busca)
        {
            var q = _repo.Query();
            if (!string.IsNullOrWhiteSpace(busca))
                q = q.Where(x => x.NomeCidade.Contains(busca, StringComparison.OrdinalIgnoreCase));
            return View(q.ToList());
        }

        [HttpGet("nova")]
        public IActionResult Create() => View(new CidadeViewModel());

        [HttpPost("nova")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CidadeViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);
            _repo.Add(new Cidades{ NomeCidade = vm.NomeCidade, IdEstado = vm.IdEstado });
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar/{id:int}")]
        public IActionResult Edit(int id)
        {
            var m = _repo.Get(id);
            if (m == null) return NotFound();
            return View(new CidadeViewModel{ IdCidade = m.IdCidade, NomeCidade = m.NomeCidade, IdEstado = m.IdEstado });
        }

        [HttpPost("editar/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CidadeViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);
            var m = _repo.Get(id);
            if (m == null) return NotFound();
            m.NomeCidade = vm.NomeCidade; m.IdEstado = vm.IdEstado;
            _repo.Update(m);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("remover/{id:int}")]
        public IActionResult Delete(int id)
        {
            var m = _repo.Get(id);
            if (m == null) return NotFound();
            return View(m);
        }

        [HttpPost("remover/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("detalhes/{id:int}")]
        public IActionResult Details(int id)
        {
            var m = _repo.Get(id);
            if (m == null) return NotFound();
            return View(m);
        }
    }
}
