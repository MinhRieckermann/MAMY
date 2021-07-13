using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_Team.DAL;
using WebAPI_Team.ViewModels;
using WebAPI_Team.Models;
using WebAPI_Team.Services.BaseService;
using WebAPI_Team.Repositories;

namespace WebAPI_Team.Services.CategoryServices
{
    public class CategoryService
    {
        private UnitOfWork _unitOfWork;
        public CategoryService(UnitOfWork unitofwork)
        {
            this._unitOfWork = unitofwork;
        }

        // Get  all Products 
        public JsonObject GetAllCategory()
        {
            try
            {

                var ListCategory = _unitOfWork.CategoryRepository.Get();
                //.Get(x => x.country.Equals(model.country) && x.tournament.Equals(model.tournament) && x.season.Equals(model.season)).OrderBy(x => x.Week);

                var total = ListCategory.Count();
                //ListProduct = ListProduct.Skip(model.pagesize * (model.pagenumber - 1)).Take(model.pagesize).OrderBy(x => x.Week);
                JsonObject json = new JsonObject()
                {
                    objects = ListCategory,
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