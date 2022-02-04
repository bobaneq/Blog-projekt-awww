using Blog.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class NewWpisVM
    {


        [Display(Name = "Temat")]
        public string Tytul { get; set; }

        [Display(Name = "Treść")]
        public string Zawartosc { get; set; }

        [Display(Name = "Zablokuj komentarz")]
        public bool KomentarzeZablokowane { get; set; }

        [Display(Name = "Data dodania wpisu")]
        public System.DateTime DataDodania { get; set; }

        [Display(Name = "Tagi")]
        public List<Tag> Tagi { get; set; }

        public List<TagWpis> TagiWpisy { get; set; }


        [Display(Name = "Komentarze")]
        public List<Komentarz> Komentarze { get; set; }



        [Display(Name = "Oceny")]
        public List<Ocena> Oceny { get; set; }






    }
}
