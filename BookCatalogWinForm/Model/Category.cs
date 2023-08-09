using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogWinForm.Model
{
    public class Category
    {
        public int Id { get; set; }

        [Required] // NOT NULL
        [StringLength(50)]
        public string NameC { get; set; }


        public virtual ICollection<Book> books { get; set; }

        public Category()
        {
            books = new List<Book>();
        }

    }
}
