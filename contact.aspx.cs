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
                String comments = Request["comments"];
                String email = Request["email"];
                String fullName = Request["fullName"];
                String telephone = Request["telephone"];
                
                Hashtable data = new Hashtable();
                data.Add("comments", comments);
                data.Add("email", email);
                data.Add("fullName", Format.upperCaseWords(fullName));
                data.Add("telephone", Format.telephone(telephone));

                Hashtable mail = new Hashtable();
                mail.Add("body", "email-contact");
                mail.Add("data", data);
                mail.Add("from", "bwt.bluewebtech@gmail.com");
                mail.Add("subject", "Test Subject");
                mail.Add("template", true);
                mail.Add("to", "bwt.bluewebtech@gmail.com");
  
                Mail.send(mail);
            }
        }

    }

}