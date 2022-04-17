using LeratoShop.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LeratoShop.Helper
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboPlatformsAsync()
        {
            List<SelectListItem> list = await _context.Platforms.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una Plataforma...]",
                Value = "0"
            });

            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboProductDiteilsAsync(int productId)
        {
            List<SelectListItem> list = await _context.ProductDetails
                .Where(x => x.Product.Id == productId)
                .Select(x => new SelectListItem
                {
                    Text = x.Color,
                    Value = $"{x.Id}"
                })
                .OrderBy(x => x.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Detalle del producto...]",
                Value = "0"
            });

            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboProductTypesAsync()
        {
            List<SelectListItem> list = await _context.ProductTypes.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Tipo Producto...]",
                Value = "0"
            });

            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboProductsAsync(int productTypeId)
        {
            List<SelectListItem> list = await _context.Products
               .Where(p => p.ProductType.Id == productTypeId)
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = $"{x.Id}"
                })
                .OrderBy(x => x.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Producto...]",
                Value = "0"
            });

            return list;
        }

    }
}
