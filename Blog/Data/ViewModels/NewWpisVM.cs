using Blog.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class NewWpisVM
    {


        public string ImageURL { get; set; }

        [Display(Name = "Temat")]
        public string Tytul { get; set; }

        [Display(Name = "Treść")]
        public string Zawartosc { get; set; }

        [Display(Name = "Zablokuj komentarz")]
        public bool KomentarzeZablokowane { get; set; }

        // FK jest int bo tylko zalogowani uzytkownicy moga dodawac wpisy
        //public int AutorId { get; set; }
        //public Uzytkownik Autor { get; set; }
        // Sprawdzenie czy zalogowany jest autor wpisu 
        [Display(Name = "Data dodania wpisu")]
        public System.DateTime DataDodania { get; set; }


        //Relacje

        [Display(Name = "Tagi")]
        public virtual List<TagWpis> TagiWpisy { get; set; }


        [Display(Name = "Komentarze")]
        public virtual List<Komentarz> Komentarze { get; set; }

        // EF nie supportuje kolekcji skalarow, wiec trzeba zrobic kolekcje encji
        // ew mozna zrobic przez value converter ale troche bardziej skomplikowane i hakowane
        // ale jak cos to tutaj jest jak to zrobic: https://github.com/dotnet/efcore/issues/4179#issuecomment-447993816
        //public Ocena Ocena { get; set; }

        public virtual List<Ocena> Oceny { get; set; }


    }
}
