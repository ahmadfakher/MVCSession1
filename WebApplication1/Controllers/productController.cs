using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //BaserUrl/Products/Index
    [Route("Test/[action]")]
    public class productController : Controller
    {
        #region Action & ActionResult
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetProduct()
        {
            var products = new List<product>
            {
                new product { Id = 1, Name = "Product 1" },
                new product { Id = 2, Name = "Product 2" },
                new product { Id = 3, Name = "Product 3" }
            };
            return Json(products);
        }
        [HttpGet]
        public IActionResult GetProductById(int id)
        {
            if (id < 0)
                return BadRequest();
            else if (id == 0)
                return RedirectToAction(nameof(Index));
            else if (id < 10)
                return NotFound();
            else
                return Json(new product { Id = id, Name = "Laptop" });
        }
        [HttpGet]
        public IActionResult RedirectAction()
        {
            return Redirect("https://www.youtube.com");
        }
        public IActionResult FileAction()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes("C:\\Users\\Admin\\Downloads\\hello.pdf");
            return File(fileBytes, "application/pdf", "sample.pdf");
        }
        #endregion
        [HttpGet("json")]
        public IActionResult JsonAction()
        {
            return Json("Hello from json action");
        }
        [HttpGet("ProductCode/{code:int}")]
        public IActionResult GetProductByCode(int code)
        {
            return Json(new product { Id = code, Name = "Product01"});
        }
        //
        public IActionResult Search(/**/productFilters filter)
        {
            return View();
        }
    }
}
