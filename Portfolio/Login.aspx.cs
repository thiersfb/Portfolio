using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio
{
    public partial class Login : System.Web.UI.Page
    {
        //"dados" é o nome do namespace. "Conexao" é o nome da classe"
        dados.Conexao banco = new dados.Conexao(); //nova instancia do objeto
        protected void Page_Load(object sender, EventArgs e)
        {
            senhaInvalida.Visible = false;
            cadastroEfetuado.Visible = false;
            cadastroNaoEfetuado.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            senhaInvalida.Visible = false;
            cadastroEfetuado.Visible = false;
            cadastroNaoEfetuado.Visible = false;

            string login = txtLogin.Text.ToString();
            string senha = txtSenha.Text.ToString();

            string resultado = banco.validaLogin(login, senha);

            if (resultado == "1")
            {
                //aqui criamos a sessão
                Session["usuario"] = login;

                //Response.Write("Acesso efetuado com sucesso");
                //redireciona p/ página desejada
                //Response.Redirect("~/Default.aspx");
                //Response.Redirect("~/AreaRestrita/index.html");
                Response.Redirect("~/AreaRestrita/Default.aspx");
            }
            else
            {
                //Response.Write("Usuário Inválido");
                senhaInvalida.Visible = true;

            }

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            senhaInvalida.Visible = false;
            cadastroEfetuado.Visible = false;
            cadastroNaoEfetuado.Visible = false;

            if(txtLoginNovoUser.Text == "")
            {
                erroAoCadastrar.Text = "Por favor digite um login para o cadastro";
                cadastroNaoEfetuado.Visible = true;
            }
            else if (txtSenhaNovoUser.Text == "")
            {
                erroAoCadastrar.Text = "Por favor digite uma senha para o cadastro";
                cadastroNaoEfetuado.Visible = true;
            }
            else if (txtConfirmarSenhaNovoUser.Text == "")
            {
                erroAoCadastrar.Text = "Por favor confirme a senha para o cadastro";
                cadastroNaoEfetuado.Visible = true;
            }
            else if (txtEmail.Text == "")
            {
                erroAoCadastrar.Text = "Por favor digite um e-mail para o cadastro";
                cadastroNaoEfetuado.Visible = true;
            }
            else if (txtSenhaNovoUser.Text.ToString() != txtConfirmarSenhaNovoUser.Text.ToString())
            {
                //Response.Write("Senha e Confirmação de Senha não são iguais!");
                erroAoCadastrar.Text = "Senha e Confirmação de Senha não são iguais!"; //variável de erro definido no arquivo .aspx
                cadastroNaoEfetuado.Visible = true;
            }
            else
            {
                string loginNovoUser = txtLoginNovoUser.Text.ToString();
                string senhaNovoUser = txtSenhaNovoUser.Text.ToString();
                string confirmaSenhaNovoUser = txtConfirmarSenhaNovoUser.Text.ToString();
                //string nome = txtNome.Text.ToString();
                //string sobrenome = txtSobrenome.Text.ToString();
                //string cpf = txtCPF.Text.ToString();
                //string rg = txtRG.Text.ToString();
                string emailNovoUser = txtEmail.Text.ToString();
                //string endereco = txtEndereco.Text.ToString();
                //string cep = txtCEP.Text.ToString();
                //string telefone = txtTelefone.Text.ToString();
                //string celular = txtCelular.Text.ToString();




                //string vrfLogin recebe o retorno do metodo "verificaLogin" do objeto "banco"
                string vrfLogin = banco.verificaLogin(loginNovoUser);
                if (vrfLogin == "0")
                {
                    //string vrfCpf recebe o retorno do metodo "verificaCpf" do objeto "banco"
                    //string vrfCpf = banco.verificaCpf(cpf);
                    //if (vrfCpf == "0")
                    //{

                    //string vrfEmail recebe o retorno do metodo "verificaEmail" do objeto "banco"
                    string vrfEmail = banco.verificaEmail(emailNovoUser);
                    if (vrfEmail == "0")
                    {
                        //string resultado recebe o retorno do metodo "registraNovoUsuario" do objeto "banco"
                        //string resultado = banco.registraNovoUsuario(login, senha, nome, sobrenome, cpf, rg, email, endereco, cep, telefone, celular);
                        string resultado = banco.registraNovoUsuario(loginNovoUser, senhaNovoUser, emailNovoUser);

                        if (resultado == "1") //verifica quantidade de linhas afetadas no banco de dados
                        {
                            txtLoginNovoUser.Text = "";
                            txtSenhaNovoUser.Text = "";
                            txtConfirmarSenhaNovoUser.Text = "";
                            //txtNome.Text = "";
                            //txtSobrenome.Text = "";
                            //txtCPF.Text = "";
                            //txtRG.Text = "";
                            txtEmail.Text = "";
                            //txtEndereco.Text = "";
                            //txtCEP.Text = "";
                            //txtTelefone.Text = "";
                            //txtCelular.Text = "";

                            cadastroEfetuado.Visible = true;
                            //Response.Write("Cadastro efetuado com sucesso!");
                        }
                        else
                        {
                            erroAoCadastrar.Text = "Dados inválidos."; //variável de erro definido no arquivo .aspx
                            cadastroNaoEfetuado.Visible = true;
                        }
                    }
                    else
                    {
                        erroAoCadastrar.Text = "E-mail já cadastrado em outro usuário."; //variável de erro definido no arquivo .aspx
                        cadastroNaoEfetuado.Visible = true;
                    }
                    //}
                    //else
                    //{
                    //    erroAoCadastrar.Text = "CPF já cadastrado em outro usuário."; //variável de erro definido no arquivo .aspx
                    //    cadastroNaoEfetuado.Visible = true;
                    //}
                }
                else
                {
                    erroAoCadastrar.Text = "Login já cadastrado em outro usuário."; //variável de erro definido no arquivo .aspx
                    cadastroNaoEfetuado.Visible = true;
                }
            }
            
        }
    }
}