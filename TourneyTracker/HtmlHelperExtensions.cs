using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TourneyTracker
{
    public static class HtmlHelperExtensions
    {
        private static string buttonId = "btn-" + Guid.NewGuid().ToString();

        public static MvcHtmlString CustomHtml5ValidationInit(this HtmlHelper html)
        {
            return MvcHtmlString.Create("<button id=\"" + buttonId + "\" hidden/>");
        }

        public static MvcHtmlString CustomHtml5ValidationFor<TModel, TResult>(this HtmlHelper<TModel> html, Expression<Func<TModel, TResult>> expression)
        {
            if (expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                var memberExpression = (MemberExpression)expression.Body;
                var propName = memberExpression.Member.Name;

                var value = html.ViewData.ModelState[propName];
                var errorMessage = "";
                if (value != null && value.Errors.Any())
                {
                    errorMessage = value.Errors.First().ErrorMessage;
                }

                return MvcHtmlString.Create(
                    String.Format(@"
                        $(document).ready(function () {{
                        var email = document.getElementById('{0}');
                        var message = '{1}';
                        if (message.length > 0) {{
                            email.setCustomValidity(message);
                            $('#{2}').click();
                        }}
                        }});

                        $(document).on('change', '#{0}', function () {{
                            var email = document.getElementById('{0}');
                            email.setCustomValidity('');
                            email.checkValidity();
                        }});
                        ", propName, errorMessage, buttonId
                    )
                );
            }
            return MvcHtmlString.Create("");
        }

        public static MvcHtmlString CustomHtml5PasswordValidationFor<TModel, TResult>(this HtmlHelper<TModel> html, Expression<Func<TModel, TResult>> expression, string confirmPasswordId)
        {
            if (expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                var memberExpression = (MemberExpression)expression.Body;
                var propName = memberExpression.Member.Name;

                return MvcHtmlString.Create(
                    String.Format(@"
                        function validatePassword() {{
                            var password = document.getElementById('{0}');
                            if (password.value.length < 6) {{
                                password.setCustomValidity('Password must have at least 6 characters');
                            }} else {{
                                password.setCustomValidity('');
                            }}

                            var confirmPassword = document.getElementById('{1}');
                            if (password.value != confirmPassword.value) {{
                                confirmPassword.setCustomValidity({2}Passwords don't match{2});
                            }} else {{
                                confirmPassword.setCustomValidity('');
                            }}
                        }}

                        $(document).on('change', '#{0}', function () {{
                            validatePassword();
                        }});

                        $(document).on('change', '#{1}', function () {{
                            validatePassword();
                        }});
                        ", propName, confirmPasswordId, "\""
                        )
                    );
            }
            return MvcHtmlString.Create("");
        }
    }
}