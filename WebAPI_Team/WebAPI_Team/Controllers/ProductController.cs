using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using WebAPI_Team.Models;
using WebAPI_Team.ViewModels;
using WebAPI_Team.Providers;
using WebAPI_Team.Results;
using WebAPI_Team.Repositories;
using WebAPI_Team.DAL;
using WebAPI_Team.Filter;
using WebAPI_Team.Services;
using WebAPI_Team.Services.AccountServices;
using WebAPI_Team.Services.SportService;
using WebAPI_Team.Services.ProductServices;
using Newtonsoft.Json;
using System.Text;
using System.Data.SqlClient;

namespace WebAPI_Team.Controllers
{
    [CustomAuthorizationFilterAttribute]
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public ProductController()
        {

        }
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

            // Get All product
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("GetProduct")]
        public HttpResponseMessage GetProduct()
        {

            ProductService Service = new ProductService(unitOfWork);
            var result = Service.GetAllProduct();

            if (result != null)
            {
                var json = JsonConvert.SerializeObject(result);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Success");
                response.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                return response;

            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "False");
                response.Content = new StringContent("Can not get data from database", Encoding.Unicode);
                return response;
            }
        }
        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}