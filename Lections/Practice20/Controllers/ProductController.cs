using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductController:ControllerBase
{
    private IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpPost(template: "addgroup")]
    public ActionResult AddGroup(ProductGroupModel productGroup)
    {
        _repository.AddGroup(productGroup);
        return Ok();
    }

    [HttpGet(template: "getgroups")]
    public ActionResult<IEnumerable<ProductGroupModel>> GetGroups()
    {
        return Ok(_repository.GetGroups());
    }


    [HttpPost(template: "addproduct")]
    public ActionResult AddProduct(ProductModel product)
    {
        _repository.AddProduct(product);
        return Ok();
    }


    [HttpGet(template: "getproducts")]
    public ActionResult<IEnumerable<ProductModel>> GetProducts()
    {
        return Ok(_repository.GetProducts());
    }

}


