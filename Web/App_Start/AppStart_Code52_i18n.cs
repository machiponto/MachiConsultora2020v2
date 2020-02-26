[assembly: WebActivator.PreApplicationStartMethod(typeof(Web.App_Start.Code52_i18n), "Start")]
namespace Web.App_Start {

    using System.Web.Mvc;
    using System.Web.Routing;
	using Code52.i18n;

    public class Code52_i18n {
        public static void Start() {
            RouteTable.Routes.MapRoute("Language", "i18n/Code52.i18n.language.js", new { controller = "Language", action = "Language" });
			GlobalFilters.Filters.Add(new LanguageFilterAttribute());
        }
    }
}
