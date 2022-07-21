using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;
using API.Dtos;
using AutoMapper;
using API.Helpers;
using API.Errors;

namespace API.Controllers
{
    public class ProductsVersion2Controller: BaseApiController
    {
        private readonly IGenericRepository<Product2> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

         public ProductsVersion2Controller(IGenericRepository<Product2> productRepo, IGenericRepository<ProductBrand> productBrandRepo
        , IGenericRepository<ProductType> productTypeRepo, IMapper mapper)
        {
            _mapper = mapper;
            _productTypeRepo = productTypeRepo;
            _productBrandRepo = productBrandRepo;
            _productRepo = productRepo;


        }
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto2>>> GetProducts(
           [FromQuery] Product2SpecParams productparams)
        {
            var spec = new Product2WithTypesAndBrandsSpecification(productparams);

            var countSpec=new Product2WithFilterForCountSpecification(productparams);

            var totalItems=await _productRepo.CountAsync(countSpec);



            var products = await _productRepo.ListAsync(spec);

            var data =_mapper.Map<IReadOnlyList<Product2>,IReadOnlyList<ProductToReturnDto2>>(products);

           
            return Ok (new Pagination<ProductToReturnDto2>(productparams.PageIndex,
            productparams.PageSize,totalItems,data));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto2>> GetProduct(int id)
        {
            var spec = new Product2WithTypesAndBrandsSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            
            if (product == null) return NotFound(new ApiResponse(404));
            return _mapper.Map<Product2,ProductToReturnDto2>(product);
        }

    }
}