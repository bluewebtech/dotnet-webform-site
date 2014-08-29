using System;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Reflection;

namespace dotnet_webform_site.classes
{

    public class View
    {

        public static string make(string view, string value = null)
        {
            string path = Path.template() + view.Replace(".", @"\") + ".aspx";
            System.IO.FileStream f1 = new System.IO.FileStream(path, System.IO.FileMode.Open);
            System.IO.StreamReader sr = new System.IO.StreamReader(f1);
            return sr.ReadToEnd();
        }

    }

}