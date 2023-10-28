using System;
namespace Lection20Program3.Client
{
	public interface ILibraryBooksClient
	{
        public Task<bool> Exists(Guid id);
    }
}

