using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Module.Core.Models;
using Microsoft.Extensions.DependencyInjection;

namespace TekeriumCommerce.Module.Core.Extensions
{
    public class UrlSlugRoute : IRouter
    {
        private readonly IRouter _target;

        public UrlSlugRoute(IRouter target)
        {
            _target = target;
        }

        public async Task RouteAsync(RouteContext context)
        {
            var requestPath = context.HttpContext.Request.Path.Value;

            if (!string.IsNullOrEmpty(requestPath) && requestPath[0] == '/')
            {
                // trim the leading slash
                requestPath = requestPath.Substring(1);
            }

            var urlSlugRepository = context.HttpContext.RequestServices.GetService<IRepository<Entity>>();

            // get the slug that matches
            var urlSlug = await urlSlugRepository.Query().Include(x => x.EntityType)
                .FirstOrDefaultAsync(x => x.Slug == requestPath);

            // invoke mvc controller/action
            var oldRouteData = context.RouteData;
            var newRouteData = new RouteData(oldRouteData);
            newRouteData.Routers.Add(_target);

            // if we got back a null value set, that means the uri did not match
            if (urlSlug is null)
                return;

            newRouteData.Values["area"] = urlSlug.EntityType.AreaName;
            newRouteData.Values["controller"] = urlSlug.EntityType.RoutingController;
            newRouteData.Values["action"] = urlSlug.EntityType.RoutingAction;
            newRouteData.Values["id"] = urlSlug.EntityId;

            context.RouteData = newRouteData;
            await _target.RouteAsync(context);

        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }
    }
}