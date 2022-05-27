using LeratoShop.Data;
using LeratoShop.Data.Entities;
using LeratoShop.Helper;
using LeratoShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Vereyon.Web;
using static LeratoShop.Helper.ModalHelper;

namespace LeratoShop.Controllers
{
    [Authorize(Roles = "Admin")]

    public class ProductTypesController : Controller
    {
        private readonly DataContext _context;
        private readonly IFlashMessage _flashMessage;

        public ProductTypesController(DataContext context, IFlashMessage flashMessage)
        {
            _context = context;
            _flashMessage = flashMessage;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductTypes.Include(pt => pt.Products).ToListAsync());

        }
        public IActionResult Create()
        {
            ProductType productType = new() { Products = new List<Product>() };
            return View(productType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(productType);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        _flashMessage.Danger("Ya existe un tipo producto con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(productType);

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductType productType = await _context.ProductTypes
                .Include(pt => pt.Products)
                .FirstOrDefaultAsync(pt => pt.Id == id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductType productType)
        {
            if (id != productType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productType);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        _flashMessage.Danger("Ya existe un tipo producto con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(productType);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductType productType = await _context.ProductTypes
                .Include(pt => pt.Products)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        public async Task<IActionResult> ProductDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = await _context.Products
                .Include(p => p.ProductDetails)
                .Include(pt => pt.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {

                return NotFound();
            }

            return View(product);
        }



        [NoDirectAccess]
        public async Task<IActionResult> Delete(int id)
        {
            ProductType productType = await _context.ProductTypes.FirstOrDefaultAsync(c => c.Id == id);
            if (productType == null)
            {
                return NotFound();
            }

            try
            {
                _context.ProductTypes.Remove(productType);
                await _context.SaveChangesAsync();
                _flashMessage.Info("Registro borrado.");
            }
            catch
            {
                _flashMessage.Danger("No se puede borrar el país porque tiene registros relacionados.");
            }

            return RedirectToAction(nameof(Index));
        }


        /* public async Task<IActionResult> DeleteProduct(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             Product product = await _context.Products
                 .Include(p => p.ProductType)
                 .FirstOrDefaultAsync(p => p.Id == id);
             if (product == null)
             {
                 return NotFound();
             }

             return View(product);
         }

         [HttpPost, ActionName("DeleteProduct")]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> DeleteProductConfirmed(int id)
         {
             Product product = await _context.Products
                 .Include(p => p.ProductType)
                 .FirstOrDefaultAsync(p => p.Id == id);
             _context.Products.Remove(product);
             await _context.SaveChangesAsync();
             _flashMessage.Info("Registro Borrado.");
             return RedirectToAction(nameof(Details), new { Id = product.ProductType.Id });
         }*/

        [NoDirectAccess]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            Debug.WriteLine("Llego al null product inicial");
            Product product = await _context.Products
                .Include(s => s.ProductType)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (product == null)
            {
                Debug.WriteLine("Llego al null product");
                return NotFound();
            }

            try
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                _flashMessage.Info("Registro borrado.");
            }
            catch
            {
                _flashMessage.Danger("No se puede borrar el producto porque tiene registros relacionados.");
            }

            return RedirectToAction(nameof(Details), new { id = product.ProductType.Id });
        }



        [NoDirectAccess]
        public async Task<IActionResult> DeleteProductDetails(int id)
        {
            ProductDetail productDetail = await _context.ProductDetails
                .Include(c => c.Product)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (productDetail == null)
            {
                return NotFound();
            }

            try
            {
                _context.ProductDetails.Remove(productDetail);
                await _context.SaveChangesAsync();
            }
            catch
            {
                _flashMessage.Danger("No se puede borrar la ciudad porque tiene registros relacionados.");
            }

            _flashMessage.Info("Registro borrado.");
            return RedirectToAction(nameof(ProductDetails), new { id = productDetail.Product.Id });
        }


/*public async Task<IActionResult> DeleteProductDetails(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    ProductDetail productDetail = await _context.ProductDetails
        .Include(pd => pd.Product)
        .FirstOrDefaultAsync(pd => pd.Id == id);
    if (productDetail == null)
    {
        return NotFound();
    }

    return View(productDetail);
}

[HttpPost, ActionName("DeleteProductDetails")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteProductDetailsConfirmed(int id)
{
    ProductDetail productDetail = await _context.ProductDetails
        .Include(pd => pd.Product)
        .FirstOrDefaultAsync(pd => pd.Id == id);
    _context.ProductDetails.Remove(productDetail);
    await _context.SaveChangesAsync();
    _flashMessage.Info("Registro Borrado.");
    return RedirectToAction(nameof(ProductDetails), new { Id = productDetail.Product.Id });
}*/

/*public async Task<IActionResult> AddProduct(int? id)

{
    if (id == null)
    {

        return NotFound();
    }

    ProductType productType = await _context.ProductTypes.FindAsync(id);
    if (productType == null)
    {
        return NotFound();
    }

    ProductViewModel model = new()
    {
        ProductTypeId = productType.Id,
    };

    return View(model);
}


[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> AddProduct(ProductViewModel model)
{
    if (ModelState.IsValid)
    {
        try
        {
            Product product = new()
            {
                ProductType = await _context.ProductTypes.FindAsync(model.ProductTypeId),
                Quantity = model.Quantity,
                Price = model.Price,
                Name = model.Name,

            };

            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new {Id = model.ProductTypeId});
        }
        catch (DbUpdateException dbUpdateException)
        {
            if (dbUpdateException.InnerException.Message.Contains("duplicate"))
            {
                _flashMessage.Danger("Ya existe un producto con el mismo nombre.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
            }
        }
        catch (Exception exception)
        {
            ModelState.AddModelError(string.Empty, exception.Message);
        }
    }
    return View(model);

}*/

[NoDirectAccess]
        public async Task<IActionResult> AddProduct(int id)
        {
            ProductType productType = await _context.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }

            ProductViewModel model = new()
            {
                ProductTypeId = productType.Id,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Product product = new()
                    {
                        ProductDetails = new List<ProductDetail>(),
                        ProductType = await _context.ProductTypes.FindAsync(model.ProductTypeId),
                        Name = model.Name,
                        Quantity = model.Quantity,
                        Price = model.Price,
                    };
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    ProductType productType = await _context.ProductTypes
                        .Include(c => c.Products)
                        .ThenInclude(s => s.ProductDetails)
                        .FirstOrDefaultAsync(c => c.Id == model.ProductTypeId);
                    _flashMessage.Info("Registro creado.");
                    return Json(new { isValid = true, html = ModalHelper.RenderRazorViewToString(this, "_ViewAllProducts", productType) });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un Producto con el mismo nombre en este país.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return Json(new { isValid = false, html = ModalHelper.RenderRazorViewToString(this, "AddProduct", model) });
        }



        [NoDirectAccess]
        public async Task<IActionResult> AddProductDetails(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ProductDetailViewModel model = new()
            {
                ProductId = product.Id,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProductDetails(ProductDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ProductDetail productDetail = new()
                    {
                        Product = await _context.Products.FindAsync(model.ProductId),
                        Color = model.Color,
                    };
                    _context.Add(productDetail);
                    await _context.SaveChangesAsync();
                    Product product = await _context.Products
                        .Include(s => s.ProductDetails)
                        .FirstOrDefaultAsync(c => c.Id == model.ProductId);
                    _flashMessage.Confirmation("Registro creado.");
                    return Json(new { isValid = true, html = ModalHelper.RenderRazorViewToString(this, "_ViewAllProductDetails", product) });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe una producto detalle con el mismo nombre en este Producto");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return Json(new { isValid = false, html = ModalHelper.RenderRazorViewToString(this, "AddProductDetails", model) });
        }


        /* public async Task<IActionResult> AddProductDetails(int? id)

         {
             if (id == null)
             {

                 return NotFound();
             }

             Product product = await _context.Products.FindAsync(id);
             if (product == null)
             {
                 return NotFound();
             }

             ProductDetailViewModel model = new()
             {
                 ProductId = product.Id,
             };

             return View(model);
         }

         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> AddProductDetails(ProductDetailViewModel model)
         {
             if (ModelState.IsValid)
             {
                 try
                 {
                     ProductDetail productDetails = new()
                     {
                         Product = await _context.Products.FindAsync(model.ProductId),
                         Color = model.Color,

                     };

                     _context.Add(productDetails);
                     await _context.SaveChangesAsync();
                     return RedirectToAction(nameof(ProductDetails), new { Id = model.ProductId });
                 }
                 catch (DbUpdateException dbUpdateException)
                 {
                     if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                     {
                         _flashMessage.Danger("Ya existe un detalle producto con el mismo nombre.");
                     }
                     else
                     {
                         ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                     }
                 }
                 catch (Exception exception)
                 {
                     ModelState.AddModelError(string.Empty, exception.Message);
                 }
             }
             return View(model);

         }*/


        public async Task<IActionResult> EditProduct(int id)
        {
            Product product = await _context.Products
                .Include(s => s.ProductType)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            ProductViewModel model = new()
            {
                ProductTypeId = product.ProductType.Id,
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(int id, ProductViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Product product = new()
                    {
                        Id = model.Id,
                        Name= model.Name,
                        Quantity = model.Quantity,
                        Price = model.Price,
                    };
                    _context.Update(product);
                    ProductType productType = await _context.ProductTypes
                        .Include(c => c.Products)
                        .ThenInclude(s => s.ProductDetails)
                        .FirstOrDefaultAsync(c => c.Id == model.ProductTypeId);
                    await _context.SaveChangesAsync();
                    _flashMessage.Confirmation("Registro actualizado.");
                    return Json(new { isValid = true, html = ModalHelper.RenderRazorViewToString(this, "_ViewAllProducts", productType) });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        _flashMessage.Danger("Ya existe un producto con el mismo nombre en este tipo de producto.");
                    }
                    else
                    {
                        _flashMessage.Danger(dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return Json(new { isValid = false, html = ModalHelper.RenderRazorViewToString(this, "EditProduct", model) });
        }



        [NoDirectAccess]
        public async Task<IActionResult> EditProductDetails(int id)
        {
            ProductDetail productDetail = await _context.ProductDetails
                .Include(c => c.Product)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (productDetail == null)
            {
                return NotFound();
            }

            ProductDetailViewModel model = new()
            {
                ProductId = productDetail.Product.Id,
                Id = productDetail.Id,
                Color = productDetail.Color,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProductDetails(int id, ProductDetailViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ProductDetail productDetail = new()
                    {
                        Id = model.Id,
                        Color = model.Color,
                    };
                    _context.Update(productDetail);
                    await _context.SaveChangesAsync();
                    Product product = await _context.Products
                        .Include(s => s.ProductDetails)
                        .FirstOrDefaultAsync(c => c.Id == model.ProductId);
                    _flashMessage.Confirmation("Registro actualizado.");
                    return Json(new { isValid = true, html = ModalHelper.RenderRazorViewToString(this, "_ViewAllProductDetails", product) });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un detalle producto con el mismo nombre en este Producto");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return Json(new { isValid = false, html = ModalHelper.RenderRazorViewToString(this, "EditProductDetails", model) });
        }





        /*public async Task<IActionResult> EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = await _context.Products
             .Include(p => p.ProductType)
             .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            ProductViewModel model = new()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                ProductTypeId = product.ProductType.Id
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(int id, ProductViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Product product = new()
                    {
                        Id =model.Id,   
                        Name =model.Name,
                        Quantity = model.Quantity,
                        Price = model.Price,
                       
                    };
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new {Id = model.ProductTypeId});

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        _flashMessage.Danger("Ya existe un producto con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(model);
        }*/

        /* public async Task<IActionResult> EditProductDetails(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             ProductDetail productDetail = await _context.ProductDetails
              .Include(pd => pd.Product)
              .FirstOrDefaultAsync(pd => pd.Id == id);

             if (productDetail == null)
             {
                 return NotFound();
             }

             ProductDetailViewModel model = new()
             {
                 Id = productDetail.Id,
                 Color = productDetail.Color,
                 ProductId = productDetail.Product.Id
             };
             return View(model);
         }

         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> EditProductDetails(int id, ProductDetailViewModel model)
         {
             if (id != model.Id)
             {
                 return NotFound();
             }

             if (ModelState.IsValid)
             {
                 try
                 {
                     ProductDetail productDetail = new()
                     {
                         Id =model.Id,
                         Color =model.Color,

                     };
                     _context.Update(productDetail);
                     await _context.SaveChangesAsync();
                     return RedirectToAction(nameof(ProductDetails), new { Id = model.ProductId });

                 }
                 catch (DbUpdateException dbUpdateException)
                 {
                     if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                     {
                         _flashMessage.Danger("Ya existe un producto con el mismo nombre.");
                     }
                     else
                     {
                         ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                     }
                 }
                 catch (Exception exception)
                 {
                     ModelState.AddModelError(string.Empty, exception.Message);
                 }
             }
             return View(model);
         }*/

        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new ProductType());
            }
            else
            {
                ProductType productType = await _context.ProductTypes.FindAsync(id);
                if (productType == null)
                {
                    return NotFound();
                }

                return View(productType);
            }
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, ProductType productType)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0) //Insert
                    {
                        _context.Add(productType);
                        await _context.SaveChangesAsync();
                        _flashMessage.Info("Registro creado.");
                    }
                    else //Update
                    {
                        _context.Update(productType);
                        await _context.SaveChangesAsync();
                        _flashMessage.Info("Registro actualizado.");
                    }
                    return Json(new
                    {
                        isValid = true,
                        html = ModalHelper.RenderRazorViewToString(
                            this,
                            "_ViewAllProductTypes",
                            _context.ProductTypes
                                .Include(pt => pt.Products)
                                .ToList())
                    });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        _flashMessage.Danger("Ya existe un país con el mismo nombre.");
                    }
                    else
                    {
                        _flashMessage.Danger(dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    _flashMessage.Danger(exception.Message);
                }
            }

            return Json(new { isValid = false, html = ModalHelper.RenderRazorViewToString(this, "AddOrEdit", productType) });
        }
    }
}
