using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Portfolio.AreaRestrita
{
    public partial class Profile : System.Web.UI.Page
    {
        dados.Conexao banco = new dados.Conexao(); //nova instancia do objeto

        string usuario          = string.Empty;

        string login            = string.Empty;
        //string senha            = string.Empty;
        string nome             = string.Empty;
        string sobrenome        = string.Empty;
        //string cpf              = string.Empty;
        //string rg               = string.Empty;
        string email            = string.Empty;
        string dataNascimento   = string.Empty;
        //string endereco         = string.Empty;
        //string cep              = string.Empty;
        //string telefone         = string.Empty;
        string celular          = string.Empty;

        //public string site      = string.Empty;
        string site             = string.Empty;
        string linkFace         = string.Empty;
        string linkInsta        = string.Empty;
        string linkLinked       = string.Empty;
        string sobre            = string.Empty;

        string imagemPerfil = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            
            //byte[] bytes;
            if (Session["usuario"] != null)
            //if (usuario != null)
            {
                usuario = Session["usuario"].ToString();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            string sql = "SELECT "
                               + "Login"
                               + ", Senha"
                               + ", Nome"
                               + ", Sobrenome"
                               + ", Email "
                               + ", CONVERT(NVARCHAR, DataNascimento,103) as DataNascimento "
                               + ", Celular "
                               + ", ImagemPerfil"
                               //+ ", Portfolio"
                               + ", Site"
                               + ", PerfilFacebook"
                               + ", PerfilInstagram"
                               + ", PerfilLinkedIn"
                               + ", Sobre"
                               + " FROM dbo.Usuarios WHERE Login = '" + usuario + "'";

            SqlConnection conn = new SqlConnection(banco.conexao);
            try
            {
                conn.Open();
                SqlCommand comando = new SqlCommand(sql, conn); //executa o comando passado por parâmetro junto com a conexão
                SqlDataReader dr = comando.ExecuteReader();  //armazena o retorno obtido no objeto passado por parâmetro
                if (dr.Read()) //lê o retorno obtido
                {
                    login           = dr["Login"].ToString();
                    //senha         = dr["Senha"].ToString();
                    nome            = dr["Nome"].ToString();
                    sobrenome       = dr["Sobrenome"].ToString();
                    //tipoUsuario   = dr["TipoUsuario"].ToString();
                    //site            = dr["Portfolio"].ToString();
                    site            = dr["Site"].ToString();
                    //cpf           = dr["CPF"].ToString();
                    //rg            = dr["RG"].ToString();
                    email           = dr["Email"].ToString();
                    dataNascimento  = dr["DataNascimento"].ToString();
                    //endereco      = dr["Endereco"].ToString();
                    //cep           = dr["CEP"].ToString();
                    //telefone      = dr["Telefone"].ToString();
                    celular         = dr["Celular"].ToString();
                    imagemPerfil    = dr["ImagemPerfil"].ToString();
                    linkFace        = dr["PerfilFacebook"].ToString();
                    linkInsta       = dr["PerfilInstagram"].ToString();
                    linkLinked      = dr["PerfilLinkedIn"].ToString();
                    sobre           = dr["Sobre"].ToString();

                }

                lblNomeUsuario.Text = nome.ToString() + " " + sobrenome.ToString();


                //label de contato Fixo
                lblDataNascimento.Text = "Data de Nascimento";
                lblCelular.Text = "Celular";
                lblEMail.Text = "E-mail";
                lblSite.Text = "Website";

                //lblUserDataNascimento.Text = "Data";
                //lblUserCelular.Text = "Cel Num";
                //lblUserEMail.Text = "Email";
                //hplUSerSite.Text = "site";

                //label de contato variavel de acordo com os dados do usuario
                lblUserDataNascimento.Text = dataNascimento.ToString();
                lblUserCelular.Text = celular.ToString();
                lblUserEMail.Text = email.ToString();
                lblUserAbout.Text = sobre.ToString();
                
                
                if (!string.IsNullOrEmpty(site))
                {
                    hplUSerSite.Text = site.ToString();
                    hplUSerSite.NavigateUrl = "http://" + site.ToString();
                    //hplUSerSite.NavigateUrl = site.ToString();
                    //PlaceHolder1.Controls.add(new literalcontrol(strHTMLFromDB))
                    //plhUserSite.Controls.Add(new LiteralControl(site));
                }


                if (!string.IsNullOrEmpty(linkFace))
                {
                    //hplUSerFacebook.Text = linkFace.ToString();
                    hplUSerFacebook.NavigateUrl = linkFace.ToString();
                    divFacebook.Visible = true;
                }
                else
                {
                    divFacebook.Visible = false;
                }

                if (!string.IsNullOrEmpty(linkInsta))
                {
                    //hplUSerInstagram.Text = linkInsta.ToString();
                    hplUSerInstagram.NavigateUrl = linkInsta.ToString();
                    divInstagram.Visible = true;
                }
                else
                {
                    divInstagram.Visible = false;
                }

                if (!string.IsNullOrEmpty(linkLinked))
                {
                    //hplUSerLinkedIn.Text = linkLinked.ToString();
                    hplUSerLinkedIn.NavigateUrl = linkLinked.ToString();
                    divLinkedIn.Visible = true;
                }
                else
                {
                    divLinkedIn.Visible = false;
                }



                //caso usuário não tenha inserido foto, será exibido o avatar padrão
                if (string.IsNullOrEmpty(imagemPerfil))
                {
                    imgFotoPerfil.ImageUrl = "images/profiles/avatar.png";
                }
                else
                {
                    imgFotoPerfil.ImageUrl = "images/profiles/" + imagemPerfil;
                }
            }
            finally
            {
                conn.Close();
            }

        }
    }
}