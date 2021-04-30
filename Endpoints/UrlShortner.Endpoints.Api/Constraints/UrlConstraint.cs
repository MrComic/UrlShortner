using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UrlShortner.Endpoints.Api.Constraints
{
    public class UrlConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out var routeValue))
            {
                var parameterValueString = Convert.ToString(routeValue, CultureInfo.InvariantCulture);
                return IsNationalCodeValid(parameterValueString);
            }
            return false;
        }

        private bool IsNationalCodeValid(string input)
        {
            if (!Regex.IsMatch(input, @"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$"))
                return false;
            return true;
        }
    }
}
