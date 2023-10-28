using System;
using System.Text;
using System.Text.Json;
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
    public class DLibraryController : ControllerBase
    {
        private AppDbContext _context;
        private IDistributedCache _cache;
        public DLibraryController(AppDbContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public T GetData<T>(string key)
        {
            var value = _cache.GetString(key);
            if (!string.IsNullOrEmpty(value))
            {
                return JsonSerializer.Deserialize<T>(value);
            }
            return default;
        }

        public void SetData<T>(string key, T value)
        {
            string jsonString = JsonSerializer.Serialize(value);
            _cache.SetString(key, jsonString);
        }

        public bool TryGetValue<T>(string key, out T value)
        {
            var data = GetData<T>(key);
            if (data == null)
            {
                value = default;
                return false;
            }
            else
            {
                value = data;
                return true;
            }
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
            if (TryGetValue("authors", out List<AuthorModel> authors))
            {
                return authors;
            }
            else
            {
                using (_context)
                {
                    authors = _context.Authors.Select(x => new AuthorModel { Name = x.Name, Id = x.Id }).ToList();
                    SetData("authors", authors.Select(x => new AuthorModel { Name = x.Name.ToUpper(), Id = x.Id }).ToList());
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


        [HttpPost(template: "AddBookWithAuthorName")]
        public ActionResult AddBookWithAuthorName(BookModel bm)
        {
            try
            {
                using (_context)
                {
                    var title = bm.Title;
                    var authorId = _context.Authors.FirstOrDefault(x => x.Name == bm.Author)?.Id??-1;

                    if (authorId<0)
                    {
                        var author = new Author { Name = bm.Author };
                        _context.Authors.Add(author);
                        _context.SaveChanges();
                        authorId = author.Id;
                    }

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
            if (TryGetValue("books", out List<BookModel> books))
            {
                return books;
            }
            else
            {
                using (_context)
                {
                    books = _context.Books.Select(x => new BookModel { Author = x.Author.Name, Title = x.Title }).ToList();
                    SetData("books", books.Select(x => new BookModel { Author = x.Author.ToUpper(), Title = x.Title }).ToList());
                    return Ok(books);
                }
            }
        }

        private string GetCsv(IEnumerable<BookModel> books)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var b in books)
            {
                sb.AppendLine(b.Author + ";" + b.Title + "\n");
            }
            return sb.ToString();
        }


        [HttpGet(template: "GetBooksCSV")]
        public FileContentResult GetBooksCsv()
        {
            var content = "";

            if (TryGetValue("books", out List<BookModel> books))
            {
                content = GetCsv(books);
            }
            else
            {
                using (_context)
                {
                    books = _context.Books.Select(x => new BookModel { Author = x.Author.Name, Title = x.Title }).ToList();
                    SetData("books", books.Select(x => new BookModel { Author = x.Author.ToUpper(), Title = x.Title }).ToList());

                    content = GetCsv(books);
                }
            }
            return File(new System.Text.UTF8Encoding().GetBytes(content), "text/csv", "report.csv");

        }


        [HttpGet(template: "GetBooksCSVUrl")]
        public ActionResult<string> GetBooksCsvUrl()
        {
            var content = "";

            if (TryGetValue("books", out List<BookModel> books))
            {
                content = GetCsv(books);
            }
            else
            {
                using (_context)
                {
                    books = _context.Books.Select(x => new BookModel { Author = x.Author.Name, Title = x.Title }).ToList();
                    SetData("books", books.Select(x => new BookModel { Author = x.Author.ToUpper(), Title = x.Title }).ToList());

                    content = GetCsv(books);
                }
            }

            string fileName = null;

            fileName = "books" + DateTime.Now.ToBinary().ToString() + ".csv";

            System.IO.File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles", fileName), content);

            return "https://"+Request.Host.ToString()+ "/static/" + fileName;

        }


    }
}

