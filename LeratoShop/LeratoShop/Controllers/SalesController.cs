using LeratoShop.Data;
using LeratoShop.Helper;
using LeratoShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeratoShop.Controllers
{
    [Authorize(Roles = "User")]
    public class SalesController : Controller
    {

        private readonly ICombosHelper _combosHelper;
        private readonly DataContext _context;
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
    }
}
