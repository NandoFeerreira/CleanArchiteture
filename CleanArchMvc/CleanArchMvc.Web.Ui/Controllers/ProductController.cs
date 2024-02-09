using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.Web.Ui.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService  productService)
        {
            _productService = productService;  
        }

        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View(products);  
        }
    }
}
