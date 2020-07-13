using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio.AreaRestrita
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Label lblTitulo = (Label)Page.Master.FindControl("lblPageTitle"); //lblPageTitle é o nome da Label definida na MasterPage
            //lblTitulo.Text = "Dashboard";
            //lblTitulo.Visible = false;
            //lblTitulo.Width = 0;
            //lblTitulo.Height = 0;

            lblTitulo.Text = "Dashboard";
        }
    }
}