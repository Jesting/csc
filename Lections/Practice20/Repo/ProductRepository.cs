using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

public class ProductRepository: IProductRepository
{
    private readonly IMapper _mapper;
    private IMemoryCache _cache;


    public ProductRepository(IMapper mapper, IMemoryCache cache)
    {
        _mapper = mapper;
        _cache = cache;
    }


    public ProductGroupModel AddGroup(ProductGroupModel group)
    {
        using (var ctx = new ProductsContext())
        {
                
            if (ctx.ProductGroups.Count(x => x.Name.ToLower() == group.Name.ToLower()) > 0)
            {
                throw new Exception("Group was already added");
            }
            else
            {
                var map =_mapper.Map<ProcuctGroup>(group);
                ctx.ProductGroups.Add(map);
                ctx.SaveChanges();
                _cache.Remove("groups");

                return _mapper.Map<ProductGroupModel>(map); ;
            }
        }
    }
        
    public IEnumerable<ProductGroupModel> GetGroups()
    {
        if (_cache.TryGetValue("groups", out List<ProductGroupModel> groups))
        {
            return groups;
        }

        using (var ctx = new ProductsContext())
        {
            var list = ctx.ProductGroups.Select(_mapper.Map<ProductGroupModel>).ToList();

            _cache.Set("groups", list, TimeSpan.FromMinutes(30));

            return list;
        }
    }
        
    public ProductModel AddProduct(ProductModel product)
    {
        using (var ctx = new ProductsContext())
        {
            if (ctx.Procucts.Count(x => x.Name.ToLower() == product.Name.ToLower() && x.ProductGroupId == product.ProductGroupId) > 0)
            {
                throw new Exception("Duplicate product");
            }
            else
            {
                var map = _mapper.Map<Product>(product);
                ctx.Procucts.Add(map);
                ctx.SaveChanges();
                _cache.Remove("products");

                return _mapper.Map<ProductModel>(map);
            }
        }
    }

    public IEnumerable<ProductModel> GetProducts()
    {
        if (_cache.TryGetValue("products", out List<ProductModel> products))
        {
            return products;
        }
        using (var ctx = new ProductsContext())
        {
            var list = ctx.Procucts.Select(_mapper.Map<ProductModel>).ToList();

            _cache.Set("products",list, TimeSpan.FromMinutes(30));

            return list;
        }
    }

}


