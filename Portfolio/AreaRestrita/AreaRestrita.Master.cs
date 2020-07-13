using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio.AreaRestrita
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        //"dados" é o nome do namespace. "Conexao" é o nome da classe"
        dados.Conexao banco = new dados.Conexao(); //nova instancia do objeto

        string usuario      = string.Empty;
        string nome         = string.Empty;
        string sobrenome    = string.Empty;
        string imagemPerfil = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            //if (usuario != null)
            {

                usuario = Session["usuario"].ToString();

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

            if (!IsPostBack)
            {

                #region Obtém dados do usuário

                string sql = "SELECT"
                               //+ " Login "
                               //+ ", Senha "
                               //+ ", TipoUsuario " 
                               //+ ", Nome "
                               + " Nome "
                               + ", Sobrenome "
                               //+ ", Email "
                               //+ ", CONVERT(NVARCHAR, DataNascimento,103) as DataNascimento "
                               //+ ", UsuEst "
                               //+ ", Genero "
                               //+ ", CPF "
                               //+ ", RG "
                               //+ ", DataRegistro "
                               //+ ", Endereco "
                               //+ ", CEP "
                               //+ ", Telefone "
                               //+ ", Celular "
                               //+ ", PerfilFacebook "
                               //+ ", PerfilInstagram "
                               //+ ", PerfilLinkedIn "
                               //+ ", Sobre "
                               //+ ", Portfolio "
                               + ", ImagemPerfil " 
                               //+ ", DataUltimaModificacao " 
                               + " FROM dbo.Usuarios WHERE Login = '" + usuario + "'";

                SqlConnection conn = new SqlConnection(banco.conexao);
                try
                {
                    conn.Open();
                    SqlCommand comando = new SqlCommand(sql, conn); //executa o comando passado por parâmetro junto com a conexão
                    SqlDataReader dr = comando.ExecuteReader();  //armazena o retorno obtido no objeto passado por parâmetro
                    if (dr.Read()) //lê o retorno obtido
                    {
                        //login = dr["Login"].ToString();
                        //senha = dr["Senha"].ToString();
                        nome = dr["Nome"].ToString();
                        sobrenome = dr["Sobrenome"].ToString();
                        //tipoUsuario = dr["TipoUsuario"].ToString();
                        //status = dr["UsuEst"].ToString();
                        //genero = dr["Genero"].ToString();
                        //cpf = dr["CPF"].ToString();
                        //rg = dr["RG"].ToString();
                        //email = dr["Email"].ToString();
                        //endereco = dr["Endereco"].ToString();
                        //cep = dr["CEP"].ToString();
                        //telefone = dr["Telefone"].ToString();
                        //celular = dr["Celular"].ToString();
                        imagemPerfil = dr["ImagemPerfil"].ToString();
                        //dataNascimento = dr["DataNascimento"].ToString();
                        //linkFacebook = dr["PerfilFacebook"].ToString();
                        //linkInstagram = dr["PerfilInstagram"].ToString();
                        //linkLinkedIn = dr["PerfilLinkedIn"].ToString();
                        //sobre = dr["Sobre"].ToString();
                        //site = dr["Portfolio"].ToString();
                    }
                }
                finally
                {
                    conn.Close();
                }

                //txtLogin.Text = login.ToString();
                //txtSenha.Text = senha.ToString();

                //txtNome.Text = nome.ToString();
                //txtSobrenome.Text = sobrenome.ToString();
                //txtCPF.Text = cpf.ToString();
                //txtRG.Text = rg.ToString();
                //txtEmail.Text = email.ToString();
                //txtEndereco.Text = endereco.ToString();
                //txtCEP.Text = cep.ToString();
                //txtTelefone.Text = telefone.ToString();
                //txtCelular.Text = celular.ToString();
                ////txtDataNascimento.UniqueID
                //txtDataNascimento.Text = dataNascimento.ToString();
                //txtFacebook.Text = linkFacebook.ToString();
                //txtInstagram.Text = linkInstagram.ToString();
                //txtLinkedIn.Text = linkLinkedIn.ToString();
                //txtSobreMim.Text = sobre.ToString();
                //txtSite.Text = site.ToString();

                //if (status == "1")
                //{
                //    rbAtivo.Checked = true;
                //    rbInativo.Checked = false;
                //}
                //else
                //{
                //    rbAtivo.Checked = false;
                //    rbInativo.Checked = true;
                //}

                //if (genero == "M")
                //{
                //    rbMasculino.Checked = true;
                //    rbFeminino.Checked = false;
                //}
                //else
                //{
                //    rbMasculino.Checked = false;
                //    rbFeminino.Checked = true;
                //}

                #endregion
            }

            lblUsuarioLogado.Text = nome + " " + sobrenome;

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

        //Add the following method
        protected string SetCssClass(string page)
        {
            //retorna página ativa na classe da linha do menu da MasterPage
            return Request.Url.AbsolutePath.ToLower().EndsWith(page.ToLower()) ? "active" : "";
        }

    }
}