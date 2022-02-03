using Blog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Data.Services
{
    public interface ITagiService
    {

        Task<IEnumerable<Tag>> GetAllAsync();

        Task <Tag> GetByIdAsync(int id);

        Task AddAsync(Tag tag);

        Task<Tag> UpdateAsync(int id, Tag newTag);


        Task DeleteAsync(int id);



    }
}
