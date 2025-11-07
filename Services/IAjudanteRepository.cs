using Aiury.Models;
namespace Aiury.Services
{
    public interface IAjudanteRepository
    {
        IQueryable<Ajudantes> Query();
        Ajudantes? Get(int id);
        void Add(Ajudantes item);
        void Update(Ajudantes item);
        void Delete(int id);
    }
}
