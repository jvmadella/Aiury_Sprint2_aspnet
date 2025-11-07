using Aiury.Models;

namespace Aiury.Services
{
    public class AjudanteRepository : IAjudanteRepository
    {
        private static readonly List<Ajudantes> _items = new()
        {
            new Ajudantes { IdAjudante = 1, NomeReal = "Ana Silva", AreaAtuacao = "Psicologia", Motivacao = "Apoiar pessoas em crise emocional", DataNascimento = new DateTime(1990,1,1), DataCadastro = DateTime.UtcNow, IdCidade = 1 },
            new Ajudantes { IdAjudante = 2, NomeReal = "Bruno Souza", AreaAtuacao = "Assistência Social", Motivacao = "Voluntariado e apoio a famílias vulneráveis", DataNascimento = new DateTime(1987,5,10), DataCadastro = DateTime.UtcNow, IdCidade = 2 },
            new Ajudantes { IdAjudante = 3, NomeReal = "Carla Mendes", AreaAtuacao = "Psiquiatria", Motivacao = "Atendimento especializado em crises severas", DataNascimento = new DateTime(1985,4,22), DataCadastro = DateTime.UtcNow, IdCidade = 3 },
            new Ajudantes { IdAjudante = 4, NomeReal = "Lucas Oliveira", AreaAtuacao = "Serviço Social", Motivacao = "Apoiar vítimas de abuso e violência", DataNascimento = new DateTime(1992,11,15), DataCadastro = DateTime.UtcNow, IdCidade = 4 },
            new Ajudantes { IdAjudante = 5, NomeReal = "Marina Torres", AreaAtuacao = "Psicopedagogia", Motivacao = "Auxiliar jovens em sofrimento emocional", DataNascimento = new DateTime(1994,7,9), DataCadastro = DateTime.UtcNow, IdCidade = 5 }
        };

        private static int _nextId = _items.Max(i => i.IdAjudante) + 1;

        public IQueryable<Ajudantes> Query() => _items.AsQueryable();
        public Ajudantes? Get(int id) => _items.FirstOrDefault(x => x.IdAjudante == id);
        public void Add(Ajudantes item) { item.IdAjudante = _nextId++; _items.Add(item); }
        public void Update(Ajudantes item)
        {
            var ex = Get(item.IdAjudante);
            if (ex == null) return;
            ex.NomeReal = item.NomeReal;
            ex.AreaAtuacao = item.AreaAtuacao;
            ex.Motivacao = item.Motivacao;
            ex.DataNascimento = item.DataNascimento;
            ex.IdCidade = item.IdCidade;
        }
        public void Delete(int id)
        {
            var ex = Get(id);
            if (ex != null) _items.Remove(ex);
        }
    }

    public class CidadeRepository : ICidadeRepository
    {
        private static readonly List<Cidades> _items = new()
        {
            new Cidades { IdCidade = 1, NomeCidade = "São Paulo", IdEstado = 1 },
            new Cidades { IdCidade = 2, NomeCidade = "Rio de Janeiro", IdEstado = 2 },
            new Cidades { IdCidade = 3, NomeCidade = "Belo Horizonte", IdEstado = 3 },
            new Cidades { IdCidade = 4, NomeCidade = "Salvador", IdEstado = 4 },
            new Cidades { IdCidade = 5, NomeCidade = "Porto Alegre", IdEstado = 5 }
        };

        private static int _nextId = _items.Max(i => i.IdCidade) + 1;

        public IQueryable<Cidades> Query() => _items.AsQueryable();
        public Cidades? Get(int id) => _items.FirstOrDefault(x => x.IdCidade == id);
        public void Add(Cidades item) { item.IdCidade = _nextId++; _items.Add(item); }
        public void Update(Cidades item)
        {
            var ex = Get(item.IdCidade);
            if (ex == null) return;
            ex.NomeCidade = item.NomeCidade;
            ex.IdEstado = item.IdEstado;
        }
        public void Delete(int id)
        {
            var ex = Get(id);
            if (ex != null) _items.Remove(ex);
        }
    }
}

