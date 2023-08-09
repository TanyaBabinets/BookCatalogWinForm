using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogWinForm.Model
{
    public class PressName
    {
        public int Id { get; set; }

        [Required] // NOT NULL
        [StringLength(50)]
        public string Name { get; set; }
       
        [StringLength(5)]
        public string Year { get; set; }
        public virtual ICollection<Author> authors { get; set; }
        public virtual ICollection<Book> books { get; set; }

        public PressName()
        {
            authors = new List<Author>();
            books = new List<Book>();
        }


    }
}
