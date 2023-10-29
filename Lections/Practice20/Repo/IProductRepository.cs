using System;

public interface IProductRepository
{
    public ProductGroupModel AddGroup(ProductGroupModel group);

    public IEnumerable<ProductGroupModel> GetGroups();

    public ProductModel AddProduct(ProductModel product);

    public IEnumerable<ProductModel> GetProducts();

}


