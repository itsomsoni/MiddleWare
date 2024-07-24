
using System.Text.RegularExpressions;

namespace MiddleWare.CustomRouting
{
    public class AlphaNumericConstraint : IRouteConstraint
    {
        public bool Match(
            HttpContext? httpContext,
            IRouter? route,
            string routeKey,
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            if (!values.ContainsKey(routeKey))
                return false;

            Regex regex = new Regex("^[a-zA-Z][a-zA-Z0-9]*$");
            string strValue = Convert.ToString(values[routeKey]);

            return regex.IsMatch(strValue);
        }
    }
}
