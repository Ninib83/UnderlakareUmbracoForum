using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using System.Web.Http.Routing;

namespace UmderlakareUmbCms.Business.Registries
{
    public class OptInApiExplorer : ApiExplorer
    {
        public OptInApiExplorer( HttpConfiguration configuration)
            : base(configuration)
        {

        }

        public override bool ShouldExploreAction(string actionVariableValue, HttpActionDescriptor actionDescriptor, IHttpRoute route)
        {
            var includeAttribute = actionDescriptor.GetCustomAttributes<IncludeInApiExplorerAttribute>().FirstOrDefault();
            var nonAction = actionDescriptor.GetCustomAttributes<NonActionAttribute>().FirstOrDefault();

            if (includeAttribute == null && nonAction == null)
            {
                var includeAttributeOnController = actionDescriptor.ControllerDescriptor.GetCustomAttributes<IncludeInApiExplorerAttribute>().FirstOrDefault();
                return includeAttributeOnController != null && MatchRegexConstraint(route, "action", actionVariableValue);
            }

            return includeAttribute != null && nonAction == null && MatchRegexConstraint(route, "action", actionVariableValue);
        }

        private static bool MatchRegexConstraint(IHttpRoute route, string parameterName, string parameterValue)
        {
            IDictionary<string, object> constraints = route.Constraints;
            if (constraints != null)
            {
                object constraint;
                if (constraints.TryGetValue(parameterName, out constraint))
                {
                    string constraintsRule = constraint as string;
                    if (constraintsRule != null)
                    {
                        string constraintsRegEx = "^(" + constraintsRule + ")$";
                        return parameterValue != null && Regex.IsMatch(parameterValue, constraintsRegEx, RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
                    }
                }
            }

            return true;
        }

    }
}