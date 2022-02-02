using Blog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Data.Services
{
    public interface ITagsService
    {
        // metoda zwracajaca wszystkie tagi
        Task<IEnumerable<Tag>> GetAll();

        // metoda zwracajaca pojedynczy tag po Id
        Tag GetById(int id);

        // metoda dodajaca tag do bazy
        void Add(Tag tag);

        // metoda updatujaca dane w bazie i zwracajaca updatowany tag do uzytkownika
        Tag Update(int id, Tag newTag);


        // metoda usuwajaca tag

        void Delete(int id);

    }
}
