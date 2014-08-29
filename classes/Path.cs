namespace dotnet_webform_site.classes
{

    public class Path
    {

        public static string app()
        {
            return System.Web.Hosting.HostingEnvironment.MapPath("~/app/");
        }

        public static string controller()
        {
            return System.Web.Hosting.HostingEnvironment.MapPath("~/app/controllers/");
        }

        public static string model()
        {
            return System.Web.Hosting.HostingEnvironment.MapPath("~/app/models/");
        }

        public static string template()
        {
            return System.Web.Hosting.HostingEnvironment.MapPath("~/templates/");
        }

        public static string view()
        {
            return System.Web.Hosting.HostingEnvironment.MapPath("~/app/views/");
        }

    }

}