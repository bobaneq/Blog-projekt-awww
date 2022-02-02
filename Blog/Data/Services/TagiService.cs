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





        public void Add(Tag tag)
        {
            _context.Tagi.Add(tag);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Tag>> GetAll()
        {
            var result =await  _context.Tagi.ToListAsync();
            return result;


            
        }

        public Tag GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Tag Update(int id, Tag newTag)
        {
            throw new System.NotImplementedException();
        }
    }
}
