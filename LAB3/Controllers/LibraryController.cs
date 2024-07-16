using Microsoft.AspNetCore.Mvc;

namespace LAB3.Controllers;


[ApiController]
[Microsoft.AspNetCore.Components.Route("Library")]

public class LibraryController : ControllerBase
{
    private List<Book> _books = new List<Book>()
    {
        new Book { book_Id = 1, title = "title1", published_year = 2000, author_id = 3 },
        new Book { book_Id = 2, title = "title2", published_year = 1995, author_id = 2 },
        new Book { book_Id = 3, title = "title3", published_year = 2008, author_id = 1 },
        new Book { book_Id = 4, title = "title4", published_year = 2003, author_id = 3 }
    };

    private List<Author> _authors = new List<Author>()
    {
        new Author { author_Id =1, name = "author1", birth_date = new DateTime(1988, 6, 8),country = "US"},
        new Author { author_Id =2, name = "author2", birth_date = new DateTime(1988, 7, 15),country = "UK"},
        new Author { author_Id =3, name = "author3", birth_date = new DateTime(1975, 3, 30),country = "Russia"},
        
    };


    [HttpGet("GetBooks")]

    public List<Book> GetBookByYear(int year)
    {
        var book = _books
            .Where(b => b.published_year == year)
            .OrderBy(b => b.book_Id)
            .ToList();
        
        return book;
    }

    [HttpGet("GetAuthor")]

    public IActionResult GetAuthorByYear()
    {
        var authorByYear = _authors
            .GroupBy(a => a.birth_date.Year)
            .Select(g => new
            {
                Year = g.Key,
                Authors = g.ToList()
            }).ToList();

        return Ok(authorByYear);
    }

    [HttpGet("GetAuthor/Year&Country")]

    public IActionResult GetAuthorByYearAndCountry()
    {
        var authorByYearCountry = _authors
            .GroupBy(a => new { a.birth_date.Year, a.country })
            .Select(g => new
            {
                Year = g.Key,
                Country = g.Key,
                Authors = g.ToList()
            }).ToList();

        return Ok(authorByYearCountry);
    }

    [HttpGet("TotalBooks")]

    public int TotalNumberOfBooks()
    {
        var nbBooks = _books
            .Count;
        
        return nbBooks;
    }
    
    [HttpGet("BookByPage")]
    
    public IEnumerable<Book> GetBooksByPage(int pageSize, int pageNumber)
    {
        var booksperpage= _books
            .Skip((pageNumber - 1) * pageSize).Take(pageSize);

        return booksperpage;
    }
}