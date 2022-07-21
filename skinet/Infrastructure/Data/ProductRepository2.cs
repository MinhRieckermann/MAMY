using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository2 : IProduct2Repository
    {

         private readonly StoreContext _context;
        public ProductRepository2(StoreContext context)
        {
            _context = context;

        }
        public Task<IReadOnlyList<ProductBrand>> GetPProductBrandsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Product2>> GetProductAsync()
        {
            return await _context.Products2
            .ToListAsync();
        }

        public async Task<Product2> GetProductByIdAsync(int id)
        {
            return await _context.Products2
                    .FirstOrDefaultAsync(p=>p.Id==id);
        }

        public Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            throw new NotImplementedException();
        }
    }
}