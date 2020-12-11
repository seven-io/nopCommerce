using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc.Routing;

namespace Nop.Plugin.Misc.Sms77.Infrastructure {
    /// <summary>
    /// Represents plugin route provider
    /// </summary>
    public class RouteProvider : IRouteProvider {
        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="endpointRouteBuilder">Route Builder</param>
        public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder) {
            MapBulkRoute(endpointRouteBuilder, "Sms");
            MapBulkRoute(endpointRouteBuilder, "Voice");
        }

        private static void MapBulkRoute(IEndpointRouteBuilder endpointRouteBuilder, string controller) {
            var id = $"Bulk{controller}";

            endpointRouteBuilder.MapControllerRoute(
                $"Plugin.Misc.Sms77.{id}",
                $"Admin/Plugins/Sms77/{id}",
                new {action = "Bulk", area = AreaNames.Admin, controller});
        }

        /// <summary>
        /// Gets a priority of route provider
        /// </summary>
        public int Priority => 0;
    }
}