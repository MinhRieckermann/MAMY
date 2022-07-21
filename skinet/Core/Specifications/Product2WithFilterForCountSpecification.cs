using Core.Entities;

namespace Core.Specifications
{
    public class Product2WithFilterForCountSpecification : BaseSpecification<Product2>
    {
        public Product2WithFilterForCountSpecification(Product2SpecParams productParams)
        :base(x =>
                (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains
                (productParams.Search)) 
                // &&
                // (!productParams.BrandId.HasValue|| x.ProductBrandId==productParams.BrandId) &&
                // (!productParams.TypeId.HasValue || x.ProductTypeId== productParams.TypeId)
                    
                
            )
        {
        }
    }
}