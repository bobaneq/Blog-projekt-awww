using Blog.Data.Base;
using Blog.Models;

namespace Blog.Data.Services
{
    public class WpisyService:EntityBaseRepository<Wpis>, IWpisyService
    {
        public WpisyService(AppDbContext context):base(context)
        {

        }
    }
}
