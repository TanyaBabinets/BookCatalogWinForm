using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookCatalogWinForm.Model
{
    public class BookContext:DbContext
    {

     
        public DbSet<Book> books { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<PressName> pressNames { get; set; }
        public DbSet<Category> categorys { get; set; }

        public BookContext() : base("DbBook")
        {
        }
        public List<Book> GetBook()
        {
            List <Book> books2 = new List<Book>();
            foreach (var b in books.ToList()) 
            {
                Entry(b).Reference("author1").Load();
                Entry(b).Reference("category1").Load();
                books2.Add(b);   
            
            }
            return books2;
        }
        
        public Author GetAuthor(string a)
        {
            foreach (var item in authors) {
            if (item.Name.ToLower() == a.ToLower() || item.LastName.ToLower() ==a.ToLower() || item.FullName.ToLower()==a.ToLower()) 
                    return item;    
            }
            
            return null;
        }

        public Category GetCategory(string a)
        {
            foreach (var item in categorys)
            {
                if (item.NameC.ToLower() == a.ToLower())
                    return item;
            }
            

            return null;
        }
        public void AddBook(Book temp)
        {
            
            books.Add(temp);
            
            SaveChanges();  
        }
        

        public void DeleteBook(Book temp)
        {

            if (temp != null)
            {
                temp = books.Find(temp.Id);
                books.Remove(temp);
                
                SaveChanges();
            }

        }



    }
}
