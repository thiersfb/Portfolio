<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Portfolio.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Content/login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <%--<div>
        </div>--%>

        <div class="login-wrap">
            <div class="login-html">
                <input id="tab-1" type="radio" name="tab" class="sign-in" checked><label for="tab-1" class="tab">Acesso</label>
                <input id="tab-2" type="radio" name="tab" class="sign-up"><label for="tab-2" class="tab">Cadastro</label>
                <div class="login-form">
                    <%--div--%>
                    <%--<form class="login-form" runat="server">--%>
                        <div class="sign-in-htm">
                            <div class="group">
                                <%--<label for="user" class="label">Username</label>--%>
                                <label for="user" class="label">Usuário</label>
                                <%--<input id="user" type="text" class="input">--%>
                                <%--<asp:TextBox ID="txtLogin" runat="server" CssClass="input" placeholder="Login" required="" autofocus=""></asp:TextBox>--%>
                                <asp:TextBox ID="txtLogin" runat="server" CssClass="input" placeholder="Login"></asp:TextBox>
                            </div>
                            <div class="group">
                                <%--<label for="pass" class="label">Password</label>--%>
                                <label for="pass" class="label">Senha</label>
                                <%--<input id="pass" type="password" class="input" data-type="password">--%>
                                <%--<asp:TextBox ID="txtSenha" runat="server" CssClass="input" placeholder="Senha" required="" TextMode="Password"></asp:TextBox>--%>
                                <asp:TextBox ID="txtSenha" runat="server" CssClass="input" placeholder="Senha" TextMode="Password"></asp:TextBox>
                            </div>
                            <div class="group">
                                <input id="check" type="checkbox" class="check" checked>
                                <%--<label for="check"><span class="icon"></span>Keep me Signed in</label>--%>
                                <label for="check"><span class="icon"></span>Mantenha-me logado</label>
                            </div>
                            <div class="group">
                                <%--<input type="submit" class="button" value="Sign In">--%>
                                <asp:Button ID="btnLogin" runat="server" Text="Entrar" CssClass="button" OnClick="btnLogin_Click" />
                            </div>
                            <div class="hr"></div>
                            <div class="foot-lnk">
                                <%--<a href="#forgot">Forgot Password?</a>--%>
                                <a href="#forgot">Esqueceu a senha?</a>
                            </div>
                            <div id="senhaInvalida" runat="server" visible="false" class="alert alert-danger" role="alert">
                                <br />
                                <br />
                                Login e/ou senha inválido(a)
                            </div>

                        </div>
                        <div class="sign-up-htm">
                            <%--<div class="group">
                            <label for="firstName" class="label">First Name</label>
                            <input id="firstName" type="text" class="input">
                        </div>
                        <div class="group">
                            <label for="lastName" class="label">Last Name</label>
                            <input id="lastName" type="text" class="input">
                        </div>--%>
                            <div class="group">
                                <%--<label for="user" class="label">Username</label>--%>
                                <label for="user" class="label">Usuário</label>
                                <%--<input id="user" type="text" class="input">--%>
                                <%--<asp:TextBox ID="txtLoginNovoUser" runat="server" CssClass="input" placeholder="Login" required="" autofocus=""></asp:TextBox>--%>
                                <asp:TextBox ID="txtLoginNovoUser" runat="server" CssClass="input" placeholder="Login"></asp:TextBox>
                            </div>
                            <div class="group">
                                <%--<label for="pass" class="label">Password</label>--%>
                                <label for="pass" class="label">Senha</label>
                                <%--<input id="pass" type="password" class="input" data-type="password">--%>
                                <%--<asp:TextBox ID="txtSenhaNovoUser" runat="server" CssClass="input" placeholder="Senha" required="" TextMode="Password"></asp:TextBox>--%>
                                <asp:TextBox ID="txtSenhaNovoUser" runat="server" CssClass="input" placeholder="Senha" TextMode="Password"></asp:TextBox>
                            </div>
                            <div class="group">
                                <%--<label for="pass" class="label">Repeat Password</label>--%>
                                <label for="pass" class="label">Confirmar senha</label>
                                <%--<input id="pass" type="password" class="input" data-type="password">--%>
                                <%--<asp:TextBox ID="txtConfirmarSenhaNovoUser" runat="server" CssClass="input" placeholder="Confirmar Senha" required="" TextMode="Password"></asp:TextBox>--%>
                                <asp:TextBox ID="txtConfirmarSenhaNovoUser" runat="server" CssClass="input" placeholder="Confirmar Senha" TextMode="Password"></asp:TextBox>
                            </div>
                            <div class="group">
                                <%--<label for="pass" class="label">Email Address</label>--%>
                                <label for="mail" class="label">Email</label>
                                <%--<input id="pass" type="text" class="input">--%>
                                <%--<asp:TextBox ID="txtEmail" runat="server" CssClass="input" placeholder="E-mail" required="required" data-error="E-mail é obrigatório." TextMode="Email"></asp:TextBox>--%>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="input" placeholder="E-mail" TextMode="Email"></asp:TextBox>
                            </div>
                            <div class="group">
                                <%--<input type="submit" class="button" value="Sign Up">--%>
                                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="button" OnClick="btnRegistrar_Click" />
                            </div>
                            <div class="hr"></div>
                            <%--<div class="foot-lnk">
                                <label for="tab-1">Already Member?</a>
                            </div>--%>
                            <div id="cadastroEfetuado" class="alert alert-success" runat="server">
                                <%--<br />
                                <br />--%>
                                <strong>Registro efetuado com sucesso! <span class="glyphicon glyphicon-ok"></span>
                                    <br />
                                    Aguarde a mensagem de confirmação de ativação de seu cadastro que será enviada no e-mail cadastrado.</strong>
                            </div>
                            <div id="cadastroNaoEfetuado" class="alert alert-danger" runat="server">
                                <%--<br />
                                <br />--%>
                                <strong>
                                    <asp:Label ID="erroAoCadastrar" runat="server" Text="Dados inválidos."></asp:Label> <span class="glyphicon glyphicon-remove"></span>
                                </strong>
                            </div>
                        </div>
                    <%--</form>--%>

                </div>
                <%--</div>--%>
            </div>
        </div>

    </form>
</body>
</html>
