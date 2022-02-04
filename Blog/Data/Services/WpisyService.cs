using Blog.Data.Base;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Blog.Data.Services
{
    public class WpisyService:EntityBaseRepository<Wpis>, IWpisyService
    {
        private readonly AppDbContext _context;

        public WpisyService(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<Wpis> GetWpisByIdAsync(int id)
        {
            var wpisyDetails = _context.Wpisy
                .Include(k => k.Komentarze)
                .Include(tw => tw.TagiWpisy).ThenInclude(t => t.Tag)
                .Include(o => o.Oceny)
                .FirstOrDefaultAsync(n => n.Id == id);

            return await wpisyDetails;
        }
    }
}
