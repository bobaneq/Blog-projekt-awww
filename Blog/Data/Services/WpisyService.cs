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

        public async Task AddNewWpisAsync(NewWpisVM data)
        {
            var newWpis = new Wpis()
            {
                Tytul = data.Tytul,
                Zawartosc = data.Zawartosc,
                KomentarzeZablokowane = data.KomentarzeZablokowane,
                DataDodania = data.DataDodania
            };

            await _context.Wpisy.AddAsync(newWpis);
            await _context.SaveChangesAsync();

            //Dodawanie Tagów
            //foreach (var tagid in data.tagiids)
            //{
            //    var newtagwpis = new tagwpis()
            //    {
            //        wpisid = newwpis.id,
            //        tagid = tagid

            //    };
            //    await _context.tagiwpisy.addasync(newtagwpis);
            //}

            await _context.SaveChangesAsync();
        }

        public async Task<Wpis> GetWpisByIdAsync(int id)
        {
            var wpisyDetails = _context.Wpisy
                .Include(k => k.Komentarze)
                .Include(tw => tw.TagiWpisy).ThenInclude(t=>t.Tag)
                .Include(o => o.Oceny)
                .FirstOrDefaultAsync(n => n.Id == id);

            return await wpisyDetails;
        }
    }
}
