using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dotnet_webform_site.classes;

namespace dotnet_webform_site
{

    public partial class contact : System.Web.UI.Page
    {

        public String title;

        protected void Page_Load(object sender, EventArgs e)
        {
            title = "Contact";

            if(IsPostBack) {
                String fullName = Request["fullName"];
                String email = Request["email"];
                String telephone = Request["telephone"];
                String comments = Request["comments"];

                Hashtable data = new Hashtable();
                data.Add("to", "bwt.bluewebtech@gmail.com");
                data.Add("from", "bwt.bluewebtech@gmail.com");
                data.Add("subject", "Test Subject");
                data.Add("body", "email-contact");
                data.Add("template", true);

                Mail.send(data);
            }
        }

    }

}