using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace APIDemo
{
    public class Authentication: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                if (authenticationToken.Length > 1)
                {
                    if (!Message.APIKEY.Equals(authenticationToken))
                    {
                        string resp = Response(Code.Fail, "Invalid Header Authorization");
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, JsonConvert.DeserializeObject(resp));
                    }
                }
                else
                {
                    string resp = Response(Code.Fail, "Invalid Header Authorization");
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, JsonConvert.DeserializeObject(resp));
                }
            }
        }
        private static string Response(string status, string DispalyMessage)
        {
            try
            {
                JObject JO = new JObject(new JProperty("status", status),
                                         new JProperty("message", DispalyMessage));
                return JsonConvert.SerializeObject(JO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}