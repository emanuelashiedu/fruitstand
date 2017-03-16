using FruitStand.Filters;
using FruitStand.Models;
using FruitStand.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using FruitStand.Data.Models;

namespace FruitStand.Controllers
{
    [RoutePrefix("api/fruit")]
    public class FruitController : BaseController
    {

        public readonly IService _service;
        private readonly IMapper _mapper;

        public FruitController(IService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpPost]
        [ValidateModel]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, FruitStandBindingModel model)
        {
            return CreateHttpResponse(request, () =>
            {
                var viewModel = _mapper.Map<FruitStandViewModel>(model);
                var dto = _mapper.Map<FruitStandModel>(viewModel);
                _service.Save(dto);

                //Write(model);
                return request.CreateResponse(HttpStatusCode.OK, new Response
                {
                    Status = Status.Ok,
                    Message = "record saved"
                });
            });
        }



        [HttpGet]
        [Route("GetAll")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                
                return request.CreateResponse(HttpStatusCode.OK, new Response
                {
                    Status = Status.Ok,
                    Extra = new
                    {
                        reviews = GetItems()
                    }
                });
            });
        }

        [HttpPost]
        [Route("getFilter")]
        public HttpResponseMessage getFilter(HttpRequestMessage request, FruitStandFilterBindingModel model)
        {
            return CreateHttpResponse(request, () =>
            {
                return request.CreateResponse(HttpStatusCode.OK, new Response
                {
                    Status = Status.Ok,
                    Extra = new
                    {
                        reviews = GetItems().Where(x => Convert.ToDateTime(x.saleDate) >= model.StartDate && Convert.ToDateTime(x.saleDate) <= model.EndDate).ToList()
                    }
                });
            });
        }


        private List<FruitStandViewModel> GetItems()
        {
            var fruits = _service.GetAll();
            var viewModel = _mapper.Map<List<FruitStandViewModel>>(fruits);
            return viewModel;

        }

        private bool Write(FruitStandBindingModel model)
        {
            try
            {
                //var items = GetItems();
                //items.Add(dto);
                var viewModel = _mapper.Map<FruitStandViewModel>(model);
                var dto = _mapper.Map<FruitStandModel>(model);
                _service.Save(dto);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}
