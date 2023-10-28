using System;
namespace Lection20Program3.Client
{
	public class LibraryBooksClient:ILibraryBooksClient
	{   
        readonly HttpClient client = new HttpClient();

        public async Task<bool> Exists(Guid id)
        {
            using HttpResponseMessage response = await client.GetAsync($"https://localhost:7050/Library/CheckBook?bookId={id.ToString()}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            if (responseBody == "true")
            {
                return true;
            }

            if (responseBody == "false")
            {
                return false;
            }

            throw new Exception("Unknow response");
        }
    }
    
}

