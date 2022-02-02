using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data.Services
{
    public class TagiService : ITagiService
    {
        private readonly AppDbContext _context;

        public TagiService(AppDbContext context)
        {
           _context=context;
        }


        public async Task AddAsync(Tag tag)
        {
            await _context.Tagi.AddAsync(tag);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            var result =await  _context.Tagi.ToListAsync();
            return result;


            
        }

        public async Task<Tag> GetByIdAsync(int id)
        {
            
            var result = await _context.Tagi.FirstOrDefaultAsync(x => x.Id == id);
            return result;


        }

        public async Task<Tag> UpdateAsync(int id, Tag newTag)
        {
            await _context.SaveChangesAsync();
            return newTag;
           
        }
    }
}
