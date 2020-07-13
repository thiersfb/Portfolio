using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data;
using System.IO;

namespace Portfolio.AreaRestrita
{
    public partial class Profile_Edit : System.Web.UI.Page
    {
        #region Declaração de variáveis e conexão com banco

        dados.Conexao banco = new dados.Conexao(); //nova instancia do objeto

        string login            = string.Empty;
        string senha            = string.Empty;
        string nome             = string.Empty;
        string sobrenome        = string.Empty;
        string status           = string.Empty;
        string genero           = string.Empty;
        string dataNascimento   = string.Empty;
        string cpf              = string.Empty;
        string rg               = string.Empty;
        string email            = string.Empty;
        string endereco         = string.Empty;
        string cep              = string.Empty;
        string telefone         = string.Empty;
        string celular          = string.Empty;
        string linkFacebook     = string.Empty;
        string linkInstagram    = string.Empty;
        string linkLinkedIn     = string.Empty;
        string sobre            = string.Empty;
        string site             = string.Empty;


        string usuario = string.Empty;
        //string tipoUsuario = string.Empty;


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //define o tipo de máscara, pois caso o modo texto seja senha, o valor obtido no BD não será preenchido no campo
            txtSenha.Attributes["type"] = "password";
            btnSalvarPerfil.CssClass = "btn btn-primary";

            #region Valida sessão usuário logado

            //variavel 'usuario' receberá o login do usuário que está acessando o sistema
            //string usuario = Session["usuario"].ToString();

            if (Session["usuario"] != null)
            //if (usuario != null)
            {
                usuario = Session["usuario"].ToString();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            #endregion

            cadastroEfetuado.Visible = false;
            btnSalvarPerfil.Enabled = true;

            if (!IsPostBack)
            {
                #region Manipulação de componentes

                txtLogin.Text = string.Empty;
                txtSenha.Text = string.Empty;
                txtNome.Text = string.Empty;
                txtSobrenome.Text = string.Empty;
                txtCPF.Text = string.Empty;
                txtRG.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtEndereco.Text = string.Empty;
                txtCEP.Text = string.Empty;
                txtTelefone.Text = string.Empty;
                txtCelular.Text = string.Empty;
                txtDataNascimento.Text = string.Empty;
                txtFacebook.Text = string.Empty;
                txtInstagram.Text = string.Empty;
                txtLinkedIn.Text = string.Empty;
                txtSobreMim.Text = string.Empty;
                txtSite.Text = string.Empty;

                cadastroEfetuado.Visible = false;
                cadastroNaoEfetuado.Visible = false;

                //recebe dados enviados da página que lista os usuários
                //login = string.Format("{0}", Request.Params["login"]);

                #endregion

                #region Obtém dados do usuário

                string sql = "SELECT" 
                               + " Login " 
                               + ", Senha " 
                               //+ ", TipoUsuario " 
                               + ", Nome " 
                               + ", Sobrenome " 
                               + ", Email " 
                               + ", CONVERT(NVARCHAR, DataNascimento,103) as DataNascimento " 
                               + ", UsuEst " 
                               + ", Genero " 
                               + ", CPF " 
                               + ", RG " 
                               //+ ", DataRegistro "
                               + ", Endereco " 
                               + ", CEP " 
                               + ", Telefone " 
                               + ", Celular "
                               + ", PerfilFacebook "
                               + ", PerfilInstagram "
                               + ", PerfilLinkedIn "
                               + ", Sobre "
                               //+ ", Portfolio "
                               + ", Site "
                               //+ ", ImagemPerfil " 
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
                        login = dr["Login"].ToString();
                        senha = dr["Senha"].ToString();
                        nome = dr["Nome"].ToString();
                        sobrenome = dr["Sobrenome"].ToString();
                        //tipoUsuario = dr["TipoUsuario"].ToString();
                        status = dr["UsuEst"].ToString();
                        genero = dr["Genero"].ToString();
                        cpf = dr["CPF"].ToString();
                        rg = dr["RG"].ToString();
                        email = dr["Email"].ToString();
                        endereco = dr["Endereco"].ToString();
                        cep = dr["CEP"].ToString();
                        telefone = dr["Telefone"].ToString();
                        celular = dr["Celular"].ToString();
                        //imagemPerfil = dr["ImagemPerfil"].ToString();
                        dataNascimento = dr["DataNascimento"].ToString();
                        linkFacebook = dr["PerfilFacebook"].ToString();
                        linkInstagram = dr["PerfilInstagram"].ToString();
                        linkLinkedIn = dr["PerfilLinkedIn"].ToString();
                        sobre = dr["Sobre"].ToString();
                        //site = dr["Portfolio"].ToString();
                        site = dr["Site"].ToString();
                    }
                }
                finally
                {
                    conn.Close();
                }

                txtLogin.Text = login.ToString();
                txtSenha.Text = senha.ToString();

                txtNome.Text = nome.ToString();
                txtSobrenome.Text = sobrenome.ToString();
                txtCPF.Text = cpf.ToString();
                txtRG.Text = rg.ToString();
                txtEmail.Text = email.ToString();
                txtEndereco.Text = endereco.ToString();
                txtCEP.Text = cep.ToString();
                txtTelefone.Text = telefone.ToString();
                txtCelular.Text = celular.ToString();
                //txtDataNascimento.UniqueID
                txtDataNascimento.Text = dataNascimento.ToString();
                txtFacebook.Text = linkFacebook.ToString();
                txtInstagram.Text = linkInstagram.ToString();
                txtLinkedIn.Text = linkLinkedIn.ToString();
                txtSobreMim.Text = sobre.ToString();
                txtSite.Text = site.ToString();

                if (status == "1") {
                    rbAtivo.Checked = true;
                    rbInativo.Checked = false;
                } else {
                    rbAtivo.Checked = false;
                    rbInativo.Checked = true;
                }

                if (genero == "M") {
                    rbMasculino.Checked = true;
                    rbFeminino.Checked = false;
                } else {
                    rbMasculino.Checked = false;
                    rbFeminino.Checked = true;
                }

                #endregion
            }
        }

        protected void btnSalvarPerfil_Click(object sender, EventArgs e)
        {
            #region Atribuição de valores nas variáveis p/ gravação dos dados.

            login           = txtLogin.Text.ToString();
            senha           = txtSenha.Text.ToString();
            nome            = txtNome.Text.ToString();
            sobrenome       = txtSobrenome.Text.ToString();
            cpf             = txtCPF.Text.ToString();
            rg              = txtRG.Text.ToString();
            email           = txtEmail.Text.ToString();
            endereco        = txtEndereco.Text.ToString();
            cep             = txtCEP.Text.ToString();
            telefone        = txtTelefone.Text.ToString();
            celular         = txtCelular.Text.ToString();
            dataNascimento  = Request.Form[txtDataNascimento.UniqueID].ToString();
            linkFacebook    = txtFacebook.Text.ToString();
            linkInstagram   = txtInstagram.Text.ToString();
            linkLinkedIn    = txtLinkedIn.Text.ToString();
            sobre           = txtSobreMim.Text.ToString();
            site            = txtSite.Text.ToString();

            if (rbAtivo.Checked == true) {
                status = "1";
            } else {
                status = "0";
            }

            if (rbMasculino.Checked == true) {
                genero = "M";
            } else {
                genero = "F";
            }

            #endregion

            string vrfCpf = banco.verificaCpf(cpf);
            if (vrfCpf == "0" || vrfCpf == "1") // 0 caso não encontre registro e 1 caso o registro encontrado seja o que está sendo atualizado
            {
                //string vrfEmail recebe o retorno do metodo "verificaEmail" do objeto "banco"
                string vrfEmail = banco.verificaEmail(email);

                if (vrfEmail == "0" || vrfEmail == "1") // 0 caso não encontre registro e 1 caso o registro encontrado seja o que está sendo atualizado
                {

                    //string resultado recebe o retorno do metodo "atualizaDadosUsuario" do objeto "banco"
                    string resultado = banco.atualizaDadosUsuario(login, senha, /*tipoUsuario,*/ nome, sobrenome, cpf, rg, email, status, endereco, cep, telefone, celular, dataNascimento, genero, linkFacebook, linkInstagram, linkLinkedIn, sobre, site);

                    if (resultado == "1") //verifica quantidade de linhas afetadas no banco de dados
                    {
                        #region Insere/Atualiza imagem de perfil do usuário

                        //fuFotoPerfil é o nome do componente fileUpload do asp
                        //verificação se o componente possui arquivo selecionado.
                        if (fuFotoPerfil.HasFile)
                        {
                            //variaveis p/ salvar foto
                            string fileName = fuFotoPerfil.FileName.ToString(); //obtem o nome do arquivo postado
                            string imgPath = "images/profiles/" + fileName;     //defino o diretório de armazenamento

                            string fileExtension = Path.GetExtension(fileName);
                            //int fileSize = postedFile.ContentLength;

                            #region Deleta imagem de perfil anterior do usuário
                            string imagemPerfil = banco.obtemFotoPerfilUsuario(login);
                            //string pathOldImage = "images/profiles/" + imagemPerfil;

                            if (!string.IsNullOrEmpty(imagemPerfil))
                            {
                                if ((File.Exists(Server.MapPath("images/profiles/" + imagemPerfil))))
                                {
                                    File.Delete(Server.MapPath("images/profiles/" + imagemPerfil));
                                }
                            }
                            #endregion

                            #region Validação de extensão e tamanho do arquivo, e atualização da imagem de perfil do usuário
                            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".bmp" || fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".png")
                            {
                                int imgSize = fuFotoPerfil.PostedFile.ContentLength;

                                if (fuFotoPerfil.PostedFile.ContentLength > 5242880) // 5242880 bytes means 5MB
                                {
                                    cadastroEfetuado.Visible = false;
                                    erroAoAtualizar.Text = "Somente imagens com tamanho menores a 5MB."; //variável de erro definido no arquivo .aspx
                                    cadastroNaoEfetuado.Visible = true;
                                    return;
                                }
                                else
                                {
                                    //string retornoFoto = banco.atualizaFotoPerfilUsuario(login, imgPath);
                                    string retornoFoto = banco.atualizaFotoPerfilUsuario(login, fileName);

                                    if (retornoFoto == "1")
                                    {
                                        //grava a imagem selecionada no componente FileUpload no diretório definido
                                        fuFotoPerfil.SaveAs(Server.MapPath(imgPath));                                    
                                    }
                                    else
                                    {
                                        Console.WriteLine("Foto de perfil não alterada");
                                    }
                                }
                            }
                            else
                            {
                                cadastroEfetuado.Visible = false;
                                erroAoAtualizar.Text = "Somente imagens (.jpg, .bmp, .gif e .gif) podem ser inseridas como imagem de perfil."; //variável de erro definido no arquivo .aspx
                                cadastroNaoEfetuado.Visible = true;
                                return;
                            }
                            #endregion
                        }

                        #endregion

                        cadastroEfetuado.Visible = true;
                        //script de alerta de confirmação. não funciona devido ao redirect   
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Dados atualizados com sucesso')", true);

                        #region Desabilita campos e botões caso a atualização dos dados de perfil seja bem sucedida.

                        btnSalvarPerfil.Enabled = false;
                        
                        txtLogin.Enabled = false;
                        txtSenha.Enabled = false;
                        txtNome.Enabled = false;
                        txtSobrenome.Enabled = false;
                        txtCPF.Enabled = false;
                        txtRG.Enabled = false;
                        txtEmail.Enabled = false;
                        //rbMasculino.Enabled = false;
                        //rbFeminino.Enabled = false;
                        //rbAtivo.Enabled = false;
                        //rbInativo.Enabled = false;
                        txtEndereco.Enabled = false;
                        txtCEP.Enabled = false;
                        txtTelefone.Enabled = false;
                        txtCelular.Enabled = false;
                        txtDataNascimento.Enabled = false;
                        txtFacebook.Enabled = false;
                        txtInstagram.Enabled = false;
                        txtLinkedIn.Enabled = false;
                        txtSobreMim.Enabled = false;
                        txtSite.Enabled = false;


                        #endregion
                    }
                    else
                    {
                        erroAoAtualizar.Text = "Dados inválidos."; //variável de erro definido no arquivo .aspx
                        cadastroNaoEfetuado.Visible = true;
                    }
                }
                else
                {
                    erroAoAtualizar.Text = "E-mail já cadastrado em outro usuário."; //variável de erro definido no arquivo .aspx
                    cadastroNaoEfetuado.Visible = true;
                }
            }
            else
            {
                erroAoAtualizar.Text = "CPF já cadastrado em outro usuário."; //variável de erro definido no arquivo .aspx
                cadastroNaoEfetuado.Visible = true;
            }
        }

    }
}