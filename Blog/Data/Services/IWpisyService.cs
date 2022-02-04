using Blog.Data.Base;
using Blog.Models;
using System.Threading.Tasks;

namespace Blog.Data.Services
{
    public interface IWpisyService: IEntityBaseRepository<Wpis>
    {
        Task<Wpis> GetWpisByIdAsync(int id);
    }
}
