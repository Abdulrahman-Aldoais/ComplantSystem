using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace ComplantSystem.Service.Helpers
{

    public class GetRoutingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        public GetRoutingMiddleware(RequestDelegate next, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _next = next;
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            var allMenuList = _actionDescriptorCollectionProvider.ActionDescriptors.Items.Select(x => new
            {
                Action = x.RouteValues["Action"],
                Controller = x.RouteValues["Controller"],
                Name = x.AttributeRouteInfo != null ? x.AttributeRouteInfo.Name : "",
                Template = x.AttributeRouteInfo != null ? x.AttributeRouteInfo.Template : x.RouteValues["Controller"] + "/" + x.RouteValues["Action"],
            }).ToList();

            var menu = allMenuList.GroupBy(x => x.Controller).ToList();
            var subMenus = "";
            foreach (var subMenuList in menu)
            {
                if (subMenuList.Count() > 0)
                {
                    subMenus += "<li class=\"nav-item dropdown\"><a href=\"#\" class=\"nav-link dropdown-toggle\" role=\"button\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\"><span>" + subMenuList.Key + "</span></a>";
                    subMenus += "<div class=\"dropdown-menu\" arialabelledby=\"navbarDropdown\">";
                    foreach (var mnu in subMenuList)
                    {
                        subMenus += "<a class=\"dropdown-item\" href=\"/" + mnu.Template + "\">" + mnu.Action + "</a>";
                    }
                    subMenus += "</div>";
                    subMenus += "</li>";
                }
                else
                {
                    subMenus += "<li class=\"nav-item\"><a href=\"/" + subMenuList.FirstOrDefault().Template + "\" class=\"nav-link\"><span>" + subMenuList.Key + "</span></a></li>";
                }
            }
            context.Items.Add("routeMenu", subMenus);
            await _next.Invoke(context);
        }
    }
}
