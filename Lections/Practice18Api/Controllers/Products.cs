using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Practice18Api.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Practice18Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Products:ControllerBase
	{
        [HttpPost(template: "addgroup")]
        public ActionResult AddGroup(string name, string description)
        {
            try
            {
                using (var ctx = new ProductsContext())
                {
                    if (ctx.ProductGroups.Count(x => x.Name.ToLower() == x.Name.ToLower()) > 0)
                    {
                        return StatusCode(409);
                    }
                    else
                    {
                        ctx.ProductGroups.Add(new ProcuctGroup { Name = name, Description = description });
                        ctx.SaveChanges();
                    }
                }

                    return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet(template: "getgroups")]
        public ActionResult<IEnumerable<ProductGroupModel>> GetGroups()
        {
            try
            {
                using (var ctx = new ProductsContext())
                {
                    var list = ctx.ProductGroups.Select(x => new ProductGroupModel { Id = x.Id, Name = x.Name, Description = x.Description }).ToList();
                    return list;
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }


        [HttpPost(template: "addproduct")]
        public ActionResult AddProduct(string name, string description, int groupId)
        {
            try
            {
                using (var ctx = new ProductsContext())
                {
                    if (ctx.Procucts.Count(x => x.Name.ToLower() == name.ToLower()) > 0)
                    {
                        return StatusCode(409);
                    }
                    else
                    {
                        ctx.Procucts.Add(new Product { Name = name, Description = description, ProductGroupId = groupId });
                        ctx.SaveChanges();
                    }
                }

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }


        [HttpGet(template: "getproducts")]
        public ActionResult<IEnumerable<ProductModel>> GetProducts()
        {
            try
            {
                using (var ctx = new ProductsContext())
                {
                    var list = ctx.Procucts.Select(x => new ProductModel {Name = x.Name, Description = x.Description, GroupName = x.ProductGroup.Name }).ToList();
                    return list;
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}

