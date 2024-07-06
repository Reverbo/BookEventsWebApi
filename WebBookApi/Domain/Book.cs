using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBookApi.Domain
{
    public class Book
    {
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public required string NameBook { get; set; }

        public required string Author { get; set; }

        public required string DescriptionBook { get; set; }

        public int YearCreate { get; set; }

        public bool IsDeleted { get; set; }

        public void Update(Book input) 
        { 
            NameBook = input.NameBook;
            Author = input.Author;
            DescriptionBook = input.DescriptionBook;
            YearCreate = input.YearCreate;
        }

        public void Delete () 
        {
            IsDeleted = true;

        }

        internal void Update(string nameBook, string descriptionBook, bool isDeleted, int yearCreate, string author)
        {
            NameBook = nameBook;
            Author = author;
            DescriptionBook = descriptionBook;
            YearCreate = yearCreate;
            IsDeleted = isDeleted;
        }
    }
}
