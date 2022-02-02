using Blog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Data.Services
{
    public interface ITagiService
    {

        Task<IEnumerable<Tag>> GetAll();

        Tag GetById(int id);

        void Add(Tag tag);

        Tag Update(int id, Tag newTag);


        void Delete(int id);



    }
}
