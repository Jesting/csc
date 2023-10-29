using Practice20GrapQL.Model;

namespace Practice20;

public class Program
{
    public class Query
    {
        public IEnumerable<ProductGroupModel> GetGroups([Service] ProductRepository repository) => repository.GetGroups();
        public IEnumerable<ProductModel> GetProducts([Service] ProductRepository repository) => repository.GetProducts();
    }

    public class Mutation
    {
        public ProductGroupModel AddGroup(ProductGroupModel input, [Service] ProductRepository repository)
        {
            return repository.AddGroup(input);
        }

        public ProductModel AddProduct(ProductModel input, [Service] ProductRepository repository)
        {
            return repository.AddProduct(input);
        }

        public bool AddProducts(List<ProductModel> input, [Service] ProductRepository repository)
        {
            foreach(var x in input)
                repository.AddProduct(x);

            return true;
        }

    }

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddMemoryCache();
        builder.Services
            .AddSingleton<ProductRepository>()
            .AddGraphQLServer()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>();

        var app = builder.Build();

        app.MapGraphQL();

        app.Run();
    }
}

