using Lection20Program3.Client;

namespace Lection20Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        ILibraryClient client = new LibraryUsersClient();


        client.Exists(Guid.NewGuid());

    }
}
