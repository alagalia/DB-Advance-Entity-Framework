using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using ProductsShop.Data;
using ProductShop.Models;

namespace Products_Shop.Client
{
    class Application
    {
        static void Main(string[] args)
        {
            ShopContext context = new ShopContext();
            //3.Query and Export Data
            ProductsInRange(context);
        }

        private static void ProductsInRange(ShopContext context)
        {
            var productsInRangePrice500To1000 =
                context.Products
                .Where(p => p.Price > 500 && p.Price < 1000 && p.Buyer == null)
                .Select(p => new
                {   
                    name = p.Name,
                    price = p.Price,
                    seller = (p.Seller.FirstName + " " + p.Seller.LastName).Trim()
                }).OrderBy(p=>p.price);
            //SerializeObject(productsInRangePrice500To1000, "../../../JsonData/results/productsInRangePrice500To1000.json");

            //XML
            XElement root = new XElement("products");
            foreach (var product in productsInRangePrice500To1000)
            {
                XElement productElement = new XElement("product");
                productElement.Add(new XElement(nameof(product.name), product.name));
                productElement.Add(new XElement(nameof(product.price), product.price));
                productElement.Add(new XElement(nameof(product.seller), product.seller));
                root.Add(productElement);
            }
            root.Save("../../../JsonData/results/productsInRangePrice500To1000.xml");
        }

        

        private static void SerializeObject<T>(T entity, string path)
        {
            string entityAsJson = JsonConvert.SerializeObject(entity, Formatting.Indented);
            File.WriteAllText(path, entityAsJson);

        }
        private static void SeedDB(ShopContext context)
        {
            //SeedUsers(context);
            //SeedProducts(context);
            //SeedCategory(context);
            try
            {
                context.SaveChanges();

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
        }

        private static IEnumerable<Category> AddCategoriIntoProducts(ShopContext context, IEnumerable<Category> importedCategories)
        {
            var products = context.Products.ToList();
            int prodCount = products.Count;
            Random rnd = new Random();
            for (int i = 0; i < 14; i++)
            {
                foreach (Category importedCategory in importedCategories)
                {
                    int productInt = rnd.Next(0, prodCount + 100);
                    if (productInt < prodCount)
                    {
                        importedCategory.Products.Add(products[productInt]);
                    }
                }
            }
            return importedCategories;
        }

        private static void SeedCategory(ShopContext context)
        {
            string jsonCategories = File.ReadAllText("../../../JsonData/categories.json");
            IEnumerable<Category> importedCategories = JsonConvert.DeserializeObject<IEnumerable<Category>>(jsonCategories);
            IEnumerable<Category> categoriesWithProducts = AddCategoriIntoProducts(context, importedCategories);
            context.Categories.AddRange(categoriesWithProducts);
        }

        private static void SeedProducts(ShopContext context)
        {
            string jsonProducts = File.ReadAllText("../../../JsonData/products.json");
            IEnumerable<Product> importedProducts = JsonConvert.DeserializeObject<IEnumerable<Product>>(jsonProducts);
            User[] users = context.Users.ToArray();
            int userCount = users.Count();
            Random rnd = new Random();

            foreach (Product importedProduct in importedProducts)
            {
                int selerInt = rnd.Next(0, userCount);
                User seller = users[selerInt];
                int buyerInt = rnd.Next(0, userCount + 100);
                if (buyerInt < userCount)
                {
                    User buyer = users[buyerInt];
                    importedProduct.Buyer = buyer;
                }
                importedProduct.Seller = seller;
            }
            context.Products.AddRange(importedProducts);

        }

        private static void SeedUsers(ShopContext context)
        {
            string jsonUsers = File.ReadAllText("../../../JsonData/users.json");
            IEnumerable<User> importedUsers = JsonConvert.DeserializeObject<IEnumerable<User>>(jsonUsers);
            context.Users.AddRange(importedUsers);
        }
    }
}
