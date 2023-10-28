using System;
namespace Lection20Program3.Client
{
	public interface ILibraryClient
	{
        public Task<bool> Exists(Guid id);
    }
}

