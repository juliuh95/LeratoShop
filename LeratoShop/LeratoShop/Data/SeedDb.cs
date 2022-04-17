using LeratoShop.Data.Entities;

namespace LeratoShop.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckPlatformsAsync();
            await CheckProductTypesAsync();
        }

        private async Task CheckPlatformsAsync()
        {
            if (!_context.Platforms.Any())
            {
                _context.Platforms.Add(new Platform { Name="Instagram" });
                _context.Platforms.Add(new Platform { Name="MercadoLibre" });
                _context.Platforms.Add(new Platform { Name="Facebook" });
                _context.Platforms.Add(new Platform { Name="Whatsapp" });
            }
            await _context.SaveChangesAsync();
        }

        private async Task CheckProductTypesAsync()
        {
            if (!_context.ProductTypes.Any())
            {
                _context.ProductTypes.Add(new ProductType
                {
                    Name= "Audifonos Inalambricos",
                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            Name="Xiaomi Erbuds Basic 2",
                            ProductDetails  = new List<ProductDetail>()
                            {new ProductDetail(){Color ="Negro"}}

                        },

                        new Product()
                        {
                            Name ="Lenovo P12",
                            ProductDetails = new List<ProductDetail>()
                            {new ProductDetail(){Color="Blanco"}}
                        },
                        new Product()
                        {
                            Name="Haylou GT6",
                            ProductDetails  = new List<ProductDetail>()
                            {new ProductDetail(){Color ="Amarillo"}}

                        },

                        new Product()
                        {
                            Name ="Generic G06",
                            ProductDetails = new List<ProductDetail>()
                            {new ProductDetail(){Color="Negro"}}
                        }

                    },

                });
                _context.ProductTypes.Add(new ProductType
                {
                    Name= "SmartWatch",
                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            Name="Haylou Ls02",
                            ProductDetails  = new List<ProductDetail>()
                            {new ProductDetail(){Color ="Negro"}}

                        },

                        new Product()
                        {
                            Name ="Haylou Ls05",
                            ProductDetails = new List<ProductDetail>()
                            {new ProductDetail(){Color="Blanco"}}
                        },
                        new Product()
                        {
                            Name="Mi Band 5",
                            ProductDetails  = new List<ProductDetail>()
                            {new ProductDetail(){Color ="Amarillo"}}

                        },

                        new Product()
                        {
                            Name ="Mi band 6",
                            ProductDetails = new List<ProductDetail>()
                            {new ProductDetail(){Color="Negro"}}
                        }

                    },

                });
                _context.ProductTypes.Add(new ProductType
                {
                    Name= "Parlantes",
                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            Name="JBL NMax",
                            ProductDetails  = new List<ProductDetail>()
                            {new ProductDetail(){Color ="Negro"}}

                        },

                        new Product()
                        {
                            Name ="Bose Xs",
                            ProductDetails = new List<ProductDetail>()
                            {new ProductDetail(){Color="Blanco"}}
                        },
                        new Product()
                        {
                            Name="Sony reload",
                            ProductDetails  = new List<ProductDetail>()
                            {new ProductDetail(){Color ="Amarillo"}}

                        },

                        new Product()
                        {
                            Name ="Samsung Galaxy 3",
                            ProductDetails = new List<ProductDetail>()
                            {new ProductDetail(){Color="Negro"}}
                        }

                    },

                });

            }
            await _context.SaveChangesAsync();

        }

    }
}
