using System.Threading.Tasks;

namespace API.Arcus.Infrastructure.Repository
{
    public interface IBaseRepository
    {
        Task SaveAsync();    
    }
}