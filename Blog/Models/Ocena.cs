using Blog.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Ocena:IEntityBase
    {

        public int Id { get; set; }

        public int WpisId { get; set; }
        
        [Display(Name="Wpis")]
        [ForeignKey("WpisId")]

        public Wpis Wpis { get; set; }

        //tu ewentualnie zamiast int by mozna dac enum (Jeden, Dwa, Trzy, Cztery, Piec)
        //jesli jesli bedzie int to trzeba dodac walidacje na stronce, zeby dopuscic tylko wartosci 1-5
        // jesli enum to walidacja niepotrzebna,
        // ale ja bym zostawil jako int i dodal walidacje mysle ze bedzie lepiej wygladalo

    
        public enum Wartosc
        {
            [Display(Name = "Jeden")]
            Jeden = 1,
            [Display(Name = "Dwa")]
            Dwa,
            [Display(Name = "Trzy")]
            Trzy,
            [Display(Name = "Cztery")]
            Cztery,
            [Display(Name = "Pięć")]
            Piec
        }


    }
}
