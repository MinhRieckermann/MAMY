using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_Team.DAL;
using WebAPI_Team.ViewModels;
using WebAPI_Team.Models;
using WebAPI_Team.Services.BaseService;
using WebAPI_Team.Repositories;

namespace WebAPI_Team.Services.OrderServices
{
    public class OrderService
    {

        private UnitOfWork _unitOfWork;
        public OrderService(UnitOfWork unitofwork)
        {
            this._unitOfWork = unitofwork;
        }
        // create new order 
        public long CreateNewOder(JsonRegisterOrder model)
        {
            try
            {
                var newOrder = ConvertJsonToModel(model);
                var CrOddAnal = _unitOfWork.OrderRepository.Add(newOrder);
                return CrOddAnal.OrdersId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        // Get All Order
        public JsonObject GetAllOrder()
        {
            try
            {

                var ListOrder = _unitOfWork.OrderRepository.Get();
                //.Get(x => x.country.Equals(model.country) && x.tournament.Equals(model.tournament) && x.season.Equals(model.season)).OrderBy(x => x.Week);

                var total = ListOrder.Count();
                //ListProduct = ListProduct.Skip(model.pagesize * (model.pagenumber - 1)).Take(model.pagesize).OrderBy(x => x.Week);
                JsonObject json = new JsonObject()
                {
                    objects = ListOrder,
                    totalItem = total,
                };
                return json;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //Get Order for Specific User 
        public JsonObject GetOrder_User(int accountid)
        {
            try
            {

                var ListOrder = _unitOfWork.OrderRepository.Get(x=>x.AccountId.Equals(accountid));
                //.Get(x => x.country.Equals(model.country) && x.tournament.Equals(model.tournament) && x.season.Equals(model.season)).OrderBy(x => x.Week);

                var total = ListOrder.Count();
                //ListProduct = ListProduct.Skip(model.pagesize * (model.pagenumber - 1)).Take(model.pagesize).OrderBy(x => x.Week);
                JsonObject json = new JsonObject()
                {
                    objects = ListOrder,
                    totalItem = total,
                };
                return json;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        #region Private Method
        private Order ConvertJsonToModel(JsonRegisterOrder mo)
        {
            var neworder = new Order()
            {
                OrdersId = 0,
                AccountId = mo.accountid
                //CreateTime = DateTime.Now

            };
            return neworder;
        }
        #endregion
    }
}