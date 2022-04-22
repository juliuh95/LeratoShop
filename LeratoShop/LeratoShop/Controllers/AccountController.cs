using LeratoShop.Data;
using LeratoShop.Data.Entities;
using LeratoShop.Enums;
using LeratoShop.Helper;
using LeratoShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeratoShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper;
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;
        private readonly IBlobHelper _blobHelper;

        public AccountController(IUserHelper userHelper, DataContext context, ICombosHelper combosHelper, IBlobHelper blobHelper)
        {
            _userHelper = userHelper;
            _context=context;
            _combosHelper=combosHelper;
            _blobHelper=blobHelper;
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Email o contraseña incorrectos.");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Register()
        {
            AddUserViewModel model =  new()
            {
                Id = Guid.Empty.ToString(),
                ProductTypes = await _combosHelper.GetComboProductTypesAsync(),
                Products = await _combosHelper.GetComboProductsAsync(0),
                ProductDetails = await _combosHelper.GetComboProductDiteilsAsync(0),
                UserType = UserType.User,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                Guid imageId = Guid.Empty;

                if (model.ImageFile != null)
                {
                    imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "users");
                }
                model.ImageId = imageId; ;

                User user = await _userHelper.AddUserAsync(model);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Este correo ya está siendo usado.");
                    return View(model);
                }

                LoginViewModel loginViewModel = new()
                {
                    Password = model.Password,
                    RememberMe = false,
                    Username = model.Username
                };

                var result2 = await _userHelper.LoginAsync(loginViewModel);

                if (result2.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

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

