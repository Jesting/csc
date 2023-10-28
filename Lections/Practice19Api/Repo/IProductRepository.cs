using System;

namespace Practice19Api.Repo
{
    public interface IProductRepository
    {
        public void AddGroup(ProductGroupModel group);

        public IEnumerable<ProductGroupModel> GetGroups();

        public void AddProduct(ProductModel product);

        public IEnumerable<ProductModel> GetProducts();

    }
}

