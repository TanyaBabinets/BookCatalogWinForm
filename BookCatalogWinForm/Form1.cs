using BookCatalogWinForm.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookCatalogWinForm
{
    public partial class Form1 : Form
    {
       BookContext db = null;

        public Form1()
        {
            InitializeComponent();
            using (db = new BookContext())
            { listBox1.DataSource = db.GetBook(); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)///ADD BOOK
        {
            using (db = new BookContext())
            {
                Book books = new Book();
                books.Name = textBox2.Text;

                books.author1 = db.GetAuthor(textBox1.Text);
                if (books.author1 == null)
                {
                    Author author2 = new Author();
                    string[] Fullname = textBox1.Text.Split(' ');
                    author2.Name = Fullname[0];
                    author2.LastName = Fullname[1];
                    db.authors.Add(author2);
                    db.SaveChanges();
                    books.author1 = db.GetAuthor(textBox1.Text);
                }
                books.category1 = db.GetCategory(textBox3.Text);

                if (books.category1 == null)
                {
                    Category category2 = new Category();
                    category2.NameC = textBox3.Text;
                    db.categorys.Add(category2);
                    db.SaveChanges();
                    books.category1 = db.GetCategory(textBox3.Text);
                }
                books.Pages = Convert.ToInt32(textBox4.Text);
  
                db.AddBook(books);

                listBox1.DataSource = db.GetBook();
         
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;   
            }
        }

        private void button2_Click(object sender, EventArgs e)///UPDATE BOOK
        {
            using (db = new BookContext())
            {
                Book book3 = (Book)listBox1.SelectedItem;
                book3 = db.books.Find(book3.Id);
                book3.author1 = db.GetAuthor(textBox1.Text);
                if (book3.author1 == null)
                {
                    Author author2 = new Author();
                    string[] Fullname = textBox1.Text.Split(' ');
                    author2.Name = Fullname[0];
                    author2.LastName = Fullname[1];
                    db.authors.Add(author2);
                    db.SaveChanges();
                    book3.author1 = db.GetAuthor(textBox1.Text);
                }
                book3.Name = textBox2.Text;
                book3.category1 = db.GetCategory(textBox3.Text);

                if (book3.category1 == null)
                {
                    Category category2 = new Category();
                    category2.NameC = textBox3.Text;
                    db.categorys.Add(category2);
                    db.SaveChanges();
                    book3.category1 = db.GetCategory(textBox3.Text);
                }
                book3.Pages = Convert.ToInt32(textBox4.Text);
                db.SaveChanges();
                listBox1.DataSource = db.GetBook();

                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
            }
        }


       
        private void button3_Click(object sender, EventArgs e) //DELETE BOOK
        {
            using (db = new BookContext())
            {
                db.DeleteBook((Book)listBox1.SelectedItem);
                listBox1.DataSource = db.GetBook();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) ///LIST BOX
        {
            Book temp = (Book)listBox1.SelectedItem;
            

            textBox1.Text = temp.author1.FullName;
           textBox2.Text = temp.Name;
            textBox3.Text = temp.category1.NameC;
           textBox4.Text = temp.Pages.ToString();

        }
    }
}
