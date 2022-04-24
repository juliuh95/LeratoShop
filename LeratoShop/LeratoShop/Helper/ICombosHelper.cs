using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeratoShop.Helper
{
    public interface ICombosHelper
    {
        
            Task<IEnumerable<SelectListItem>> GetComboPlatformsAsync();

            Task<IEnumerable<SelectListItem>> GetComboProductTypesAsync();

            Task<IEnumerable<SelectListItem>> GetComboProductsAsync(int productTypeId);

            Task<IEnumerable<SelectListItem>> GetComboProductDetailsAsync(int productId);

            Task<IEnumerable<SelectListItem>> GetComboCountriesAsync();

            Task<IEnumerable<SelectListItem>> GetComboStatesAsync(int countryId);

            Task<IEnumerable<SelectListItem>> GetComboCitiesAsync(int stateId);



    }
}
