using Aiury.Models;
namespace Aiury.Services
{
    public interface ICidadeRepository
    {
        IQueryable<Cidades> Query();
        Cidades? Get(int id);
        void Add(Cidades item);
        void Update(Cidades item);
        void Delete(int id);
    }
}
