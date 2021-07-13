using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_Team.DAL;
using WebAPI_Team.ViewModels;
using WebAPI_Team.Models;
using WebAPI_Team.Services.BaseService;
using WebAPI_Team.Repositories;
namespace WebAPI_Team.Services.ProductServices
{
    public class ProductService
    {
        private UnitOfWork _unitOfWork;
        public ProductService(UnitOfWork unitofwork)
        {
            this._unitOfWork = unitofwork;
        }




        // Get  all Products 
        public JsonObject GetAllProduct()
        {
            try
            {
                var listCate = _unitOfWork.CategoryRepository.Get().ToList();
                var ListProduct = _unitOfWork.ProductRepository.Get().ToList();


                var fullProduct = from a in ListProduct
                            join b in listCate on a.Category_Id equals b.Id into ps
                            from f in ps.DefaultIfEmpty()
                            select new
                            {
                                ProductsId=a.ProductsId,
                                Name=a.Name,
                                Prices = a.Prices,
                                Stock = a.Stock,
                                SalePrice = a.SalePrice,
                                Discount = a.Discount,
                                Images = a.Images,
                                Short_desc = a.Short_desc,
                                Description = a.Description,
                                Brand = a.Brand,
                                NewPro = a.NewPro,
                                Sale = a.Sale,
                                State = a.State,
                                Category = f.Title


                            };
                var total = fullProduct.Count();
                //ListProduct.Count();
                //ListProduct = ListProduct.Skip(model.pagesize * (model.pagenumber - 1)).Take(model.pagesize).OrderBy(x => x.Week);
                JsonObject json = new JsonObject()
                {
                    objects = fullProduct,
                    totalItem = total,
                };
                return json;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}