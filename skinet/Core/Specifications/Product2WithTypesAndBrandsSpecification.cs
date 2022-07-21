using Core.Entities;

namespace Core.Specifications
{
    public class Product2WithTypesAndBrandsSpecification:BaseSpecification<Product2>
    {
        
        public Product2WithTypesAndBrandsSpecification(Product2SpecParams productParams)
        :base(x =>
                (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains
                (productParams.Search)) 
                // &&
                // (!productParams.BrandId.HasValue|| x.ProductBrandId==productParams.BrandId) &&
                // (!productParams.TypeId.HasValue || x.ProductTypeId== productParams.TypeId)
                    
                
            )
            {
                    //AddInclude(x=>x.ProductType);
                    //AddInclude(x=>x.ProductBrand);
                    AddOrderBy(x=>x.Name);
                    ApplyPaging(productParams.PageSize*(productParams.PageIndex-1),productParams.PageSize);
                    if (!string.IsNullOrEmpty(productParams.Sort))
                    {
                        switch(productParams.Sort)
                        {
                            case "priceAsc":
                            AddOrderBy(p => p.price);
                            break;
                            case "priceDesc":
                            AddOrderByDescending(p => p.price);
                            break;
                            default:
                            AddOrderBy(x=>x.Name);
                            break;

                        }
                    }
            }
        public Product2WithTypesAndBrandsSpecification(int id) :base(x=>x.Id==id)
        {
            //AddInclude(x=>x.ProductType);
            //AddInclude(x=>x.ProductBrand);
        }
    }
}