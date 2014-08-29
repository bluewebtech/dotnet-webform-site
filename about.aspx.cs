using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dotnet_webform_site
{

    public partial class about : System.Web.UI.Page
    {

        public String title;

        protected void Page_Load(object sender, EventArgs e)
        {
            title = "About";
        }

    }

}