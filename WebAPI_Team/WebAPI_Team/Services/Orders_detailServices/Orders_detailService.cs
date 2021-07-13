using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_Team.DAL;
using WebAPI_Team.ViewModels;
using WebAPI_Team.Models;
using WebAPI_Team.Services.BaseService;
using WebAPI_Team.Repositories;

namespace WebAPI_Team.Services.Orders_detailServices
{
    public class Orders_detailService
    {

        private UnitOfWork _unitOfWork;
        public Orders_detailService(UnitOfWork unitofwork)
        {
            this._unitOfWork = unitofwork;
        }

        // Get All Data Order Detail 
        public JsonObject GetAllOrders_detail()
        {
            try
            {

                var ListOrderDetail = _unitOfWork.Orders_detailRepository.Get();
                //.Get(x => x.country.Equals(model.country) && x.tournament.Equals(model.tournament) && x.season.Equals(model.season)).OrderBy(x => x.Week);

                var total = ListOrderDetail.Count();
                //ListProduct = ListProduct.Skip(model.pagesize * (model.pagenumber - 1)).Take(model.pagesize).OrderBy(x => x.Week);
                JsonObject json = new JsonObject()
                {
                    objects = ListOrderDetail,
                    totalItem = total,
                };
                return json;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        // Get  Data Order Detail dor specifying OrderId
        public JsonObject GetAllOrders_detail(int orderid)
        {
            try
            {

                var ListOrderDetail = _unitOfWork.Orders_detailRepository.Get(x=>x.order_id.Equals(orderid));
                //.Get(x => x.country.Equals(model.country) && x.tournament.Equals(model.tournament) && x.season.Equals(model.season)).OrderBy(x => x.Week);

                var total = ListOrderDetail.Count();
                //ListProduct = ListProduct.Skip(model.pagesize * (model.pagenumber - 1)).Take(model.pagesize).OrderBy(x => x.Week);
                JsonObject json = new JsonObject()
                {
                    objects = ListOrderDetail,
                    totalItem = total,
                };
                return json;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        // Get  Data Order Detail dor specifying accountid
        public JsonObject GetAOrders_detail_user(int accountid)
        {
            try
            {

                var ListOrderDetail = _unitOfWork.Orders_detailRepository.Get().ToList();
                var ListOrder = _unitOfWork.OrderRepository.Get(x => x.AccountId.Equals(accountid)).ToList();
                var ListProduct = _unitOfWork.ProductRepository.Get().ToList();

                //.Get(x => x.country.Equals(model.country) && x.tournament.Equals(model.tournament) && x.season.Equals(model.season)).OrderBy(x => x.Week);

                var fulldata = from a in ListOrderDetail
                               join b in ListOrder on a.order_id equals b.OrdersId
                               join c in ListProduct on a.product_id equals c.ProductsId
                               where b.AccountId ==accountid
                               select new
                               {
                                   id = a.id,
                                   order_id = a.order_id,
                                   Name = c.Name,
                                   quantity = a.quantity


                               };
                var total = fulldata.Count();
                //ListOrderDetail.Count();
                //ListProduct = ListProduct.Skip(model.pagesize * (model.pagenumber - 1)).Take(model.pagesize).OrderBy(x => x.Week);
                JsonObject json = new JsonObject()
                {
                    objects = fulldata,
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