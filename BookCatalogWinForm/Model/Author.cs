using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogWinForm.Model
{
    public class Author
    {
        public int Id { get; set; }

        [Required] // NOT NULL
        [StringLength(50)]
        public string Name { get; set; }

        [Required] // NOT NULL
        [StringLength(50)]
        public string LastName { get; set; }

        public string FullName => $"{Name} {LastName}";
        public virtual ICollection<Book> books { get; set; }
        public virtual PressName pressName { get; set; }

        public Author()
        {
            books = new List<Book>();
           
        }

    }
}
