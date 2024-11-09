using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //IoC Inversion of Control
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService) 
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            if (_productService.GetAll().Success)
            {
                return Ok(_productService.GetAll());
            }
            return BadRequest();
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            if (_productService.GetById(id).Success)
            {
                return Ok(_productService.GetById(id));
            }
            return BadRequest(_productService.GetById(id));
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            if (_productService.Add(product).Success)
            {
                return Ok(_productService.Add(product));
            }
            return BadRequest();
        }


    }
}
