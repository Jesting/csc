using AutoMapper;
using Microsoft.EntityFrameworkCore;


public class ClientBookRepo : IClientBookRepo
{
    private IMapper _mapper;
    private AppDbContext _context;

    public ClientBookRepo(IMapper mapper, AppDbContext context)
	{
        _mapper = mapper;
        _context = context;
    }

    public void ReturnBook(Guid bookId)
    {
        var book = _context.ClientBooks.First(x => x.BookId == bookId);

        _context.ClientBooks.Remove(book);

        _context.SaveChanges();
    }

    public void TakeBook(ClientBookDto record)
    {
        
        _context.Add(_mapper.Map<ClientBook>(record));
        _context.SaveChanges();
    }

    IEnumerable<Guid?> IClientBookRepo.ListBooks(Guid clientId)
    {
        return _context.ClientBooks.Where(x => x.ClientId == clientId).Select(x => x.BookId).ToList();
    }
}

