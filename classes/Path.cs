using System.Web.Hosting;

namespace dotnet_webform_site.classes
{

    public class Path
    {

        public static string app()
        {
            return HostingEnvironment.MapPath("~/app/");
        }

        public static string controller()
        {
            return HostingEnvironment.MapPath("~/app/controllers/");
        }

        public static string model()
        {
            return HostingEnvironment.MapPath("~/app/models/");
        }

        public static string template()
        {
            return HostingEnvironment.MapPath("~/templates/");
        }

        public static string view()
        {
            return HostingEnvironment.MapPath("~/app/views/");
        }

    }

}