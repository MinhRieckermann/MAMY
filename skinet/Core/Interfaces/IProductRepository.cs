using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product>  GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>>  GetProductAsync();
        Task<IReadOnlyList<ProductBrand>>  GetPProductBrandsAsync();
        Task<IReadOnlyList<ProductType>>  GetProductTypesAsync();
    }
}
