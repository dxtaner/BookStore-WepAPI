using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private static List<Book> BookList = new List<Book>(){

         new Book()
            {
                Id = 1,
                title = "LOTR",
                genreId = 1,
                pageCount = 320,
                publishDate = new DateTime(2000, 12, 02)
            },
          new Book()
            {
                Id = 2,
                title = "Peri",
                genreId = 2,
                pageCount = 60,
                publishDate = new DateTime(2022, 08, 02)
            },
             new Book()
            {
                Id = 3,
                title = "Yüzüklerin Efendisi: Kralın Dönüşü (2003)",
                genreId = 1,
                pageCount = 201,
                publishDate = new DateTime(2003, 12, 19)
            },
            new Book()
            {
                Id = 4,
                title = "LowHigh",
                genreId = 3,
                pageCount = 550,
                publishDate = new DateTime(2016, 11, 12)
            },
            
        };

        [HttpGet]
        public List<Book> GetBooks()
        {
            var boookList = BookList.OrderBy(b => b.genreId).ToList<Book>();
            return boookList;
        }

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = BookList.Where(book => book.Id == id).SingleOrDefault();
            return book;
        }
        
        // [HttpGet]
        // public Book Get([FromQuery] string id)
        // {
        //     var book = Booklist.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //     return book;
        // }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = BookList.SingleOrDefault(b=> b.title == newBook.title);

            if (book is not null)
                return BadRequest();

            BookList.Add(newBook);
            return Ok();

        }

        [HttpPut]
        public IActionResult UpdateBook(int id,[FromBody] Book updatedBook)
        {
            var book = BookList.SingleOrDefault(b => b.Id == id);

            if (book is null)
                return BadRequest();

            book.genreId = updatedBook.genreId != default ? updatedBook.genreId : book.genreId;
            book.pageCount = updatedBook.pageCount != default ? updatedBook.pageCount : book.pageCount;
            book.publishDate = updatedBook.publishDate != default ? updatedBook.publishDate : book.publishDate;
            book.title = updatedBook.title != default ? updatedBook.title : book.title;

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = BookList.SingleOrDefault(b => b.Id == id);

            if (book is null)
                return BadRequest();

            BookList.Remove(book);
            return Ok();
        } 
    }
}