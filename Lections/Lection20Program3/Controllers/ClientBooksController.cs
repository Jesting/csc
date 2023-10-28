using System;
using Lection20Program3.Client;
using Lection20Program3.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

[ApiController]
[Route("[controller]")]
public class ClientBooksController : ControllerBase
{
    private IClientBookRepo _repo;
    public ClientBooksController(IClientBookRepo repo)
	{
        _repo = repo;
    }

    [HttpPost(template: "TakeBook")]
    public async Task<TakeBookResultDto> TakeBookAsync(ClientBookDto record)
    {

        var userExistsTask = new LibraryUsersClient().Exists(record.ClientId);
        var bookExistsTask = new LibraryBooksClient().Exists(record.BookId);

        var userExists = await userExistsTask;
        var bookExists = await bookExistsTask;

        if (userExists && bookExists)
        {
            try
            {
                _repo.TakeBook(record);
                return new TakeBookResultDto { Success = true };
            }
            catch (Exception e)
            {
                if (e is DbUpdateException && e.InnerException is PostgresException && e?.InnerException?.Message?.Contains("duplicate")==true)
                {
                    return new TakeBookResultDto { Error = "Такую книну уже взяли" };
                }
                throw;
            }
            
        }
        else
        {

            if(!userExists)
                return new TakeBookResultDto { Error = "Пользователь не найден!" };
            else
                return new TakeBookResultDto { Error = "Книга не найдена!" };

        }
    }

    [HttpPost(template: "ReturnBook")]
    public ActionResult ReurnBook(Guid bookId)
    {
        _repo.ReturnBook(bookId);
        return Ok();
    }

    [HttpGet(template: "ListBooks")]
    public ActionResult<IEnumerable<Guid>> ListBooks(Guid clientId)
    {
        return Ok(_repo.ListBooks(clientId));
    }
}


