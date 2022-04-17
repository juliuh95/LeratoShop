using LeratoShop.Data.Entities;
using LeratoShop.Enums;
using LeratoShop.Helper;

namespace LeratoShop.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper=userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckPlatformsAsync();
            await CheckProductTypesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "Juan", "Zuluaga", "zulu@yopmail.com", "322 311 4620", "Calle Luna Calle Sol", UserType.Admin);

        }
        private async Task<User> CheckUserAsync(
        string document,
        string firstName,
        string lastName,
        string email,
        string phone,
        string address,
        UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }




        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());

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
                            Price= 190000,
                            Quantity =100,
                            ProductDetails  = new List<ProductDetail>()
                            {new ProductDetail(){Color ="Negro"}}

                        },

                        new Product()
                        {
                            Name ="Lenovo P12",
                            Price= 120000,
                            Quantity =100,
                            ProductDetails = new List<ProductDetail>()
                            {new ProductDetail(){Color="Blanco"}}
                        },
                        new Product()
                        {
                            Name="Haylou GT6",
                            Price= 150000,
                            Quantity =120,
                            ProductDetails  = new List<ProductDetail>()
                            {new ProductDetail(){Color ="Amarillo"}}

                        },

                        new Product()
                        {
                            Name ="Generic G06",
                            Price= 90000,
                            Quantity =50,
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
                            Price= 160000,
                            Quantity =30,
                            ProductDetails  = new List<ProductDetail>()
                            {new ProductDetail(){Color ="Negro"}}

                        },

                        new Product()
                        {
                            Name ="Haylou Ls05",
                            Price= 179999,
                            Quantity =100,
                            ProductDetails = new List<ProductDetail>()
                            {new ProductDetail(){Color="Blanco"}}
                        },
                        new Product()
                        {
                            Name="Mi Band 5",
                            Price= 99000,
                            Quantity =220,
                            ProductDetails  = new List<ProductDetail>()
                            {new ProductDetail(){Color ="Amarillo"}}

                        },

                        new Product()
                        {
                            Name ="Mi band 6",
                            Price= 145000,
                            Quantity =20,
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
                            Price= 220000,
                            Quantity =5,
                            ProductDetails  = new List<ProductDetail>()
                            {new ProductDetail(){Color ="Negro"}}

                        },

                        new Product()
                        {
                            Name ="Bose Xs",
                            Price= 199999,
                            Quantity =40,
                            ProductDetails = new List<ProductDetail>()
                            {new ProductDetail(){Color="Blanco"}}
                        },
                        new Product()
                        {
                            Name="Sony reload",
                            Price= 120000,
                            Quantity =12,
                            ProductDetails  = new List<ProductDetail>()
                            {new ProductDetail(){Color ="Amarillo"}}

                        },

                        new Product()
                        {
                            Name ="Samsung Galaxy 3",
                            Price= 135888,
                            Quantity =10,
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
