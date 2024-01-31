using Library.Api.Entities;
using Library.Api.EntityMaps;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("Api/Books")]

    public class BooksEntityController : ControllerBase
    {
        private readonly EFLibrary Library;
        public BooksEntityController()
        {
             Library = new EFLibrary();
        }
        [HttpPost("add-Book")]
        public void AddBook([FromQuery]bookDto dto)
        {
            
            Book book = new Book() 
            {
                Name = dto.Name,
                Category = dto.Category,
                YearOfPublication = dto.YearOfPublication,
                Author=dto.Author,
                Price = dto.Price,


            };
           Library.Books.Add(book);
            Library.SaveChanges();
          
            
        }

        [HttpGet("Get-allBook")]
        public DbSet<Book> Getall()
        {

            return Library.Books;
        }
        [HttpPost("Search-Book")]
        public List<Book> Serch([FromQuery] string item)
        {

            var search = Library.Books.Where(_ => _.Name.Contains (item) || _.Category.Contains(item));
           return search.ToList();
        }
        [HttpPatch("Upadte-Book/{id}")]
        public void UpdateBook([FromRoute] int id,[FromBody] bookDto Dto)
        {
           // Library = new EFLibrary();
            var Update = Library.Books.Where(_ => _.Id == id).FirstOrDefault();
            Update.Name = Dto.Name;
            Update.Category = Dto.Category;
            Update.YearOfPublication = Dto.YearOfPublication;
            Update.Author = Dto.Author;
            Update.Price = Dto.Price;
            Library.SaveChanges();
        }
        [HttpDelete("Delete-Book/{id}")]

        public void DeleteBook([FromRoute] int id)
        {
            
            var delete = Library.Books.Where(_ => _.Id == id).FirstOrDefault();
            Library.Books.Remove(delete);   
            Library.SaveChanges();
        }


    }
    public class bookDto
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]

        public string Category { get; set; }
        [MaxLength(50)]

        public string YearOfPublication { get; set; }
        [MaxLength(50)]

        public string Author { get; set; }
        public double Price { get; set; }
    }
}
