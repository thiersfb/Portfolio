using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio.AreaRestrita
{
    public partial class Default_old : System.Web.UI.Page
    {
        //"dados" é o nome do namespace. "Conexao" é o nome da classe"
        dados.Conexao banco = new dados.Conexao(); //nova instancia do objeto
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] != null)
            //if (usuario != null)
            {

                string usuario = Session["usuario"].ToString();

                //Response.Write("Bem-vindo " + usuario.ToString());
                //lblUsuarioLogado.Text = "";
                //Response.Write("<script>alert('Bem-vindo "' + usuario + '");</script>");
                //Response.Write("<script>alert('Bem-vindo " + usuario + "');</script>");
                //lblUsuarioLogado.Text = usuario;

            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}