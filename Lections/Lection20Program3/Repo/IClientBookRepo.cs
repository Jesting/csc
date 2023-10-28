public interface IClientBookRepo
{
    public void TakeBook(ClientBookDto record);
    public void ReturnBook(Guid bookId);
    public IEnumerable<Guid?> ListBooks(Guid clientId);
}


