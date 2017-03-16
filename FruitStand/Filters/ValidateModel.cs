using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Web.Http.ModelBinding;
using FruitStand.Models;

namespace FruitStand.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {

            if (actionContext.ActionArguments.Any(kv => kv.Value == null))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, new Response
                {
                    Status = Status.Failed,
                    Message = "Arguments cannot be null"
                });
            }

            if (actionContext.ModelState.IsValid == false)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, new Response
                {
                    Status = Status.Failed,
                    Extra = new
                    {
                        Errors = GetErrors(actionContext.ModelState)
                    }
                });
            }
        }

        private List<string> GetErrors(ModelStateDictionary modelState)
        {
            List<string> retVal = new List<string>();

            if (modelState != null)
            {
                foreach (KeyValuePair<string, System.Web.Http.ModelBinding.ModelState> model in modelState)
                {
                    foreach (var error in model.Value.Errors)
                    {
                        if (false == string.IsNullOrEmpty(error.ErrorMessage))
                            retVal.Add(error.ErrorMessage);
                        else if (error.Exception != null)
                            retVal.Add(error.Exception.Message);
                    }
                }
            }

            return retVal;
        }
    }
}