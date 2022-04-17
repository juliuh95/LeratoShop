using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeratoShop.Helper
{
    public interface ICombosHelper
    {
        public interface ICombosHelper
        {
            Task<IEnumerable<SelectListItem>> GetComboPlatformsAsync();

            Task<IEnumerable<SelectListItem>> GetComboProductTypesAsync();

            Task<IEnumerable<SelectListItem>> GetComboProductsAsync(int productTypeId);

            Task<IEnumerable<SelectListItem>> GetComboProductDiteilsAsync(int productId);
        }

    }
}
