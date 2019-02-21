using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetConsul.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DotnetConsul.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IOptionsSnapshot<AppSettings> _options;

        List<Product> products = new List<Product>
        {
            new Product{ ProductId = Guid.Parse("09BCA8D1-CE5D-43D8-A59B-2375F4D39C40"), ProductName="Sword", StockQuantity=10 },
            new Product{ ProductId = Guid.Parse("75D6B3B2-697B-47B6-9CD1-1A82FBACAB6F"), ProductName="Axe", StockQuantity=2 },
            new Product{ ProductId = Guid.Parse("3EF663A4-AF66-4F6A-BD73-0D8E8C014AB4"), ProductName="Bow", StockQuantity=6 },
            new Product{ ProductId = Guid.Parse("5D73CEEE-30AF-40A5-B06F-7802520E3F52"), ProductName="Rifle", StockQuantity=1 },
            new Product{ ProductId = Guid.Parse("AF82DCB1-8F34-4F41-B3B9-D0D05A376EF8"), ProductName="Spear", StockQuantity=100 },
        };

        public ProductController(IOptionsSnapshot<AppSettings> options)
        {
            _options = options;
        }

        public IQueryable<Product> List()
        {
            return products.Where(p => p.StockQuantity > _options.Value.SecureStockQuantity).AsQueryable();
        }
    }
}