using LeratoShop.Data;
using LeratoShop.Data.Entities;
using LeratoShop.Helper;
using LeratoShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeratoShop.Controllers
{
    [Authorize(Roles = "User")]
    public class SalesController : Controller
    {

        private readonly ICombosHelper _combosHelper;
        private readonly DataContext _context;

        public SalesController(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        public async Task<IActionResult> Index()
        {
            SalesViewModel model = new()
            {
                ProductTypes = await _combosHelper.GetComboProductTypesAsync(),
                Products = await _combosHelper.GetComboProductsAsync(0),
                ProductDetails = await _combosHelper.GetComboProductDetailsAsync(0),
            };

            return View(model);
        }

        public JsonResult GetProducts(int productTypeId)
        {
            ProductType productType = _context.ProductTypes
                .Include(p => p.Products)
                .FirstOrDefault(pt => pt.Id == productTypeId);
            if (productType == null)
            {
                return null;
            }

            return Json(productType.Products.OrderBy(d => d.Name));
        }

        public JsonResult GetProductDetails(int productId)
        {
            Product product = _context.Products
                .Include(pd => pd.ProductDetails)
                .FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return null;
            }

            return Json(product.ProductDetails.OrderBy(c => c.Color));
        }



    }
}
