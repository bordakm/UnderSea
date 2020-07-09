using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http.Filters;
using UnderSea.BLL.Services;

namespace UnderSea.BLL.Exceptions.Filters
{
    public class PurchaseFailedExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            base.OnException(context);
            if (context.Exception is PurchaseFailedException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                context.Response.Content = new StringContent(context.Exception.Message);
            }
        }
    }
}
