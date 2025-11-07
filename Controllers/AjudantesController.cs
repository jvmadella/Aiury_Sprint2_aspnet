using Microsoft.AspNetCore.Mvc;
using Aiury.Services;
using Aiury.ViewModels;
using Aiury.Models;

namespace Aiury.Controllers
{
    [Route("ajudantes")]
    public class AjudantesController : Controller
    {
        private readonly IAjudanteRepository _repo;
        public AjudantesController(IAjudanteRepository repo) => _repo = repo;

        [HttpGet("")]
        public IActionResult Index(string? busca, string? ordenarPor, string? ordem, int page=1, int pageSize=10)
        {
            var q = _repo.Query();
            if (!string.IsNullOrWhiteSpace(busca))
                q = q.Where(x => x.NomeReal.Contains(busca, StringComparison.OrdinalIgnoreCase) || x.AreaAtuacao.Contains(busca, StringComparison.OrdinalIgnoreCase));

            bool asc = (ordem ?? "asc").Equals("asc", StringComparison.OrdinalIgnoreCase);
            q = (ordenarPor ?? "id").ToLowerInvariant() switch
            {
                "nome" => asc ? q.OrderBy(x => x.NomeReal) : q.OrderByDescending(x => x.NomeReal),
                "area" => asc ? q.OrderBy(x => x.AreaAtuacao) : q.OrderByDescending(x => x.AreaAtuacao),
                _ => asc ? q.OrderBy(x => x.IdAjudante) : q.OrderByDescending(x => x.IdAjudante)
            };

            var items = q.Skip((page-1)*pageSize).Take(pageSize).ToList();
            return View(items);
        }

        [HttpGet("novo")]
        public IActionResult Create() => View(new AjudanteViewModel());

        [HttpPost("novo")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AjudanteViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);
            _repo.Add(new Ajudantes{
                NomeReal = vm.NomeReal,
                AreaAtuacao = vm.AreaAtuacao,
                Motivacao = vm.Motivacao,
                DataNascimento = vm.DataNascimento,
                IdCidade = vm.IdCidade,
                DataCadastro = DateTime.UtcNow
            });
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar/{id:int}")]
        public IActionResult Edit(int id)
        {
            var m = _repo.Get(id);
            if (m == null) return NotFound();
            var vm = new AjudanteViewModel{
                IdAjudante = m.IdAjudante,
                NomeReal = m.NomeReal,
                AreaAtuacao = m.AreaAtuacao,
                Motivacao = m.Motivacao,
                DataNascimento = m.DataNascimento,
                IdCidade = m.IdCidade
            };
            return View(vm);
        }

        [HttpPost("editar/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, AjudanteViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);
            var m = _repo.Get(id);
            if (m == null) return NotFound();
            m.NomeReal = vm.NomeReal;
            m.AreaAtuacao = vm.AreaAtuacao;
            m.Motivacao = vm.Motivacao;
            m.DataNascimento = vm.DataNascimento;
            m.IdCidade = vm.IdCidade;
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

        [HttpGet("detalhes/{id:int}/{slug?}")]
        public IActionResult Details(int id)
        {
            var m = _repo.Get(id);
            if (m == null) return NotFound();
            return View(m);
        }
    }
}
