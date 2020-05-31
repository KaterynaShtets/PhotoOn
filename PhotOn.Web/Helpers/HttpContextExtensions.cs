using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotOn.Web.Helpers
{
    public static class HttpContextExtensions 
    {
        public static void InsertPaginationParametersInRepsonse<T>(this HttpContext httpContext,
            IEnumerable<T> list, int recordsPerPage)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            double count = list.Count();
            double totalAmountPages = Math.Ceiling(count / recordsPerPage);
            httpContext.Response.Headers.Add("totalAmountPages", totalAmountPages.ToString());
        }
    }
}

