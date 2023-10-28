using System;
using Lection19Program2.Database.Model;
using Lection19Program2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace Lection19Program2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
	{
		private AppDbContext _context;
        private IMemoryCache _cache;
        public LibraryController(AppDbContext context, IMemoryCache cache)
		{
			_context = context;
            _cache = cache;
        }

        [HttpPost(template: "AddAuthor")]
        public ActionResult AddAuthor(string name)
        {
            using (_context)
            {
                if (_context.Authors.FirstOrDefault(x => x.Name == name) != null)
                {
                    return StatusCode(409);
                }
                else
                {
                    _context.Authors.Add(new Author { Name = name });
                    _context.SaveChanges();
                    _cache.Remove("authors");
                    return Ok();
                }
            }
            
        }

        [HttpGet(template: "GetAuthors")]
        public ActionResult<IEnumerable<AuthorModel>> GetAuthors()
        {
            if (_cache.TryGetValue("authors", out List<AuthorModel> authors))
            {
                return authors;
            }
            else
            {
                using (_context)
                {
                    authors = _context.Authors.Select(x => new AuthorModel { Name = x.Name, Id = x.Id }).ToList();
                    _cache.Set("authors", authors.Select(x=>new AuthorModel { Name = x.Name.ToUpper(), Id = x.Id}).ToList(), TimeSpan.FromMinutes(30));
                    return Ok(authors);
                }
            }
        }



        [HttpPost(template: "AddBook")]
        public ActionResult AddBook(string title, int authorId)
        {
            try
            {
                using (_context)
                {
                    if (_context.Books.FirstOrDefault(x => x.Title == title && x.AuthorId == authorId) != null)
                    {
                        return StatusCode(409);
                    }
                    else
                    {
                        _context.Books.Add(new Book { Title = title, AuthorId = authorId });
                        _context.SaveChanges();
                        _cache.Remove("books");
                        return Ok();
                    }
                }
            }
            catch
            {
                return StatusCode(500);
            }

        }

        [HttpGet(template: "GetBooks")]
        public ActionResult<IEnumerable<BookModel>> GetBooks()
        {
            if (_cache.TryGetValue("books", out List<BookModel> books))
            {
                return books;
            }
            else
            {
                using (_context)
                {
                    books = _context.Books.Select(x => new BookModel { Author = x.Author.Name, Title = x.Title }).ToList();
                    _cache.Set("books", books.Select(x => new BookModel { Author = x.Author.ToUpper(), Title = x.Title }).ToList(), TimeSpan.FromMinutes(30));
                    return Ok(books);
                }
            }
        }

        [HttpGet(template: "GetCacheStats")]
        public ActionResult<MemoryCacheStatistics> GetCacheStats()
        {
            
            return _cache.GetCurrentStatistics();
        }

    }
}

