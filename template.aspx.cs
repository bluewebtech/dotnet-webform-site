using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using dotnet_webform_site.classes;

namespace dotnet_webform_site
{

    public partial class template : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Hashtable data = new Hashtable();
            data.Add("firstName", "Bob");
            data.Add("lastName", "Baker");
            data.Add("email", "bob.barker@gmail.com");
            data.Add("telephone", "(555) 555-5555");
            data.Add("state", "California");
            data.Add("country", "United States");

            Response.Write(Template.make("test", data));
        }

    }

}