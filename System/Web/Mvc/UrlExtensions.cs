using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Dynamic;
using System.Web.Routing;


namespace System.Web.Mvc
{
    public static class UrlExtensions
    {

        public static string Action<TController>(this UrlHelper urlHelper, Expression<Func<TController, object>> actionExpression)
        {
            Type controller = typeof(TController);
            string controllerName = controller.Name.Replace("Controller", "");

            LambdaExpression action = actionExpression;
            MethodCallExpression body = action.Body as MethodCallExpression;           
            MethodInfo method = body.Method;
            string actionName = method.Name;

            ParameterInfo[] parameters = method.GetParameters();

            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (Expression arg in body.Arguments)
            {
                if (arg is ConstantExpression)
                {
                    ConstantExpression argument = arg as ConstantExpression;
                    int i = body.Arguments.IndexOf(argument);
                    string key = parameters[i].Name;
                    object value = argument.Value;
                    dict.Add(key, value);
                }
                else
                {
                    //TODO
                }
            }

            RouteValueDictionary routeDict = null;
            if (dict.Count() > 0)
            {
                 routeDict = new RouteValueDictionary(dict);
            }
            return urlHelper.Action(actionName, controllerName, routeDict);
        }



    }


}