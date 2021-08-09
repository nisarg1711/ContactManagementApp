using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq.Expressions;

namespace ContactManagement.ExtensionMethods
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Checks that required string value is not blank and adds a validation error
        /// message to the ModelStateDictionary if so.
        /// </summary>
        /// <param name="modelState">State of the model.</param>
        /// <param name="expr">The expr.</param>
        /// <returns></returns>
        public static bool RequiredField(this ModelStateDictionary modelState, Expression<Func<string>> expr)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(expr.Compile()()))
                {
                    return true;
                }
            }
            catch (System.Exception)
            {
                // Intentionally empty 
            }

            var arg = GetFieldNameFromExpressionBody(expr.Body);

            modelState.AddModelError(arg, string.Format("{0} is required", arg));
            return false;
        }

        /// <summary>
        /// Gets the field name from expression.
        /// </summary>
        /// <param name="body">The parameter.</param>
        /// <returns></returns>
        private static string GetFieldNameFromExpressionBody(Expression body)
        {
            var arg = body.ToString();
            string pattern = @"^.+\)\.(?<tail>.+)$";
            arg = System.Text.RegularExpressions.Regex.Match(arg, pattern).Groups["tail"].Value;
            int ix = arg.IndexOf(".");
            if (ix > 0)
            {
                arg = arg.Substring(ix + 1);
            }

            return arg;
        }
    }
}
