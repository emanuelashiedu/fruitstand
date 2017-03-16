using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FruitStand.Controllers
{
    public class BaseController : ApiController
    {
        public BaseController()
        {
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage request, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;
            string customErrorMessage = "Oops! There's been a problem. Contact support if problem persists.";

            try
            {
                response = function.Invoke();
            }
             
            catch (NotImplementedException ex)
            {
                LogError("NotImplementedException", ex);
                response = request.CreateResponse<string>(HttpStatusCode.InternalServerError, customErrorMessage);
            }
            
            catch (UnauthorizedAccessException ex)
            {
                LogError("UnauthorizedAccessException", ex);
                response = request.CreateResponse<string>(HttpStatusCode.InternalServerError, customErrorMessage);
            }
            catch (Exception ex)
            {
                LogError("General", ex);
                response = request.CreateResponse<string>(HttpStatusCode.InternalServerError, customErrorMessage);
            }

            return response;
        }

      

        private void LogError(string exceptionType, Exception ex)
        {
            try
            {
                string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                message += Environment.NewLine;
                message += "-----------------------------------------------------------";
                message += Environment.NewLine;
                message += string.Format("Message: {0}", ex.Message);
                message += Environment.NewLine;
                message += string.Format("StackTrace: {0}", ex.StackTrace);
                message += Environment.NewLine;
                message += string.Format("Source: {0}", ex.Source);
                message += Environment.NewLine;
                message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());

                this.LogError(exceptionType, ex.Message, ex.InnerException != null ? ex.InnerException.Message : default(string), message);
            }
            catch (Exception ex1)
            {
                //LogError(ex1);
            }
        }

        private void LogError(string exceptionType, string message, string innerException, string stackTrace)
        {
            // TODO: Save the log information into database
        }
    }
}
