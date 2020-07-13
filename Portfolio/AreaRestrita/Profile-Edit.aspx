<%@ Page Title="" Language="C#" MasterPageFile="~/AreaRestrita/AreaRestrita.Master" AutoEventWireup="true" CodeBehind="Profile-Edit.aspx.cs" Inherits="Portfolio.AreaRestrita.Profile_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



    <%--<link href="//netdna.bootstrapcdn.com/bootstrap/3.1.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.0/js/bootstrap.min.js"></script>--%>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>

    <%--CSS--%>
    <style type="text/css">
        .container {
            margin-top: 20px;
        }

        .image-preview-input {
            position: relative;
            overflow: hidden;
            margin: 0px;
            color: #333;
            background-color: #fff;
            border-color: #ccc;
        }

        .image-preview-input input[type=file] {
            position: absolute;
            top: -1px;
            right: 0;
            margin: 0;
            padding: 0;
            font-size: 20px;
            cursor: pointer;
            opacity: 0;
            filter: alpha(opacity=0);
        }

        .image-preview-input-title {
            margin-left: 2px;
        }
    </style>

    <script>
        //JS p/para prévia da imagem de perfil na página de edição de perfil
        $(document).on('click', '#close-preview', function () {
            $('.image-preview').popover('hide');
            // Hover befor close the preview
            $('.image-preview').hover(
                function () {
                    $('.image-preview').popover('show');
                },
                function () {
                    $('.image-preview').popover('hide');
                }
            );
        });

        $(function () {
            // Create the close button
            var closebtn = $('<button/>', {
                type: "button",
                text: 'x',
                id: 'close-preview',
                style: 'font-size: initial;',
            });
            closebtn.attr("class", "close pull-right");
            // Set the popover default content
            $('.image-preview').popover({
                trigger: 'manual',
                html: true,
                //title: "<strong>Preview</strong>" + $(closebtn)[0].outerHTML,
                title: "<strong>Visualização Prévia</strong>" + $(closebtn)[0].outerHTML,
                content: "There's no image",
                placement: 'bottom'
            });
            // Clear event
            $('.image-preview-clear').click(function () {
                $('.image-preview').attr("data-content", "").popover('hide');
                $('.image-preview-filename').val("");
                $('.image-preview-clear').hide();
                $('.image-preview-input input:file').val("");
                //$(".image-preview-input-title").text("Browse");
                $(".image-preview-input-title").text(" Pesquisar");
            });
            // Create the preview image
            $(".image-preview-input input:file").change(function () {
                var img = $('<img/>', {
                    id: 'dynamic',
                    width: 250,
                    height: 200
                });
                var file = this.files[0];
                var reader = new FileReader();
                // Set preview image into the popover data-content
                reader.onload = function (e) {
                    //$(".image-preview-input-title").text("Change");
                    $(".image-preview-input-title").text(" Alterar");
                    $(".image-preview-clear").show();
                    $(".image-preview-filename").val(file.name);
                    img.attr('src', e.target.result);
                    $(".image-preview").attr("data-content", $(img)[0].outerHTML).popover("show");
                }
                reader.readAsDataURL(file);
            });
        });
    </script>

    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="panel panel-headline">
            <div class="panel-heading">

                <h1>Editar Perfil</h1>
                <hr />


                <%--<div class="panel-heading">
                <h3 class="panel-title">Atualize as informações de seu cadastro</h3>
                <p class="panel-subtitle">Panel to display most important information</p>
            </div>--%>
                <div class="panel-body">


                    <%--<div class="profile-right" style="float:left; 2%; margin:2%;">
                    <h4>Login</h4>
                    <input type="text" class="form-control" placeholder="text field">
                </div>--%>


                    <div id="cadastroEfetuado" class="alert alert-success" runat="server">
                        <i class="fa fa-check-circle"></i>Dados atualizados com sucesso!
                        <%--<i class="fa fa-check-circle"></i> Your settings have been succesfully saved--%>
                    </div>
                    <div id="cadastroNaoEfetuado" class="alert alert-danger" runat="server">
                        <%--<i class="fa fa-times-circle"></i> Your account has been suspended--%>
                        <i class="fa fa-times-circle"></i>&nbsp;
                        <%--<strong>--%>
                        <asp:Label ID="erroAoAtualizar" runat="server" Text="Dados inválidos."></asp:Label>
                        <%--<asp:Label ID="erroAoAtualizar" runat="server" Text="Dados inválidos."></asp:Label> <span class="glyphicon glyphicon-remove"></span>--%>
                        <%--</strong>--%>
                    </div>


                    <!-- Início Painel à Esquerda -->
                    <div class="profile-right" style="float: left; width: 50%;">

                        <h4>Login</h4>
                        <asp:TextBox ID="txtLogin" runat="server" CssClass="form-control" placeholder="Digite seu Login" required="required" data-error="Campo de preenchimento obrigatório." Enabled="False"></asp:TextBox>

                        <br />
                        <h4>Senha</h4>
                        <%--<asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" placeholder="Digite sua senha" required="required" data-error="Senha é obrigatório." TextMode="Password"></asp:TextBox>--%>
                        <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" placeholder="Digite sua senha" required="required" data-error="Campo de preenchimento obrigatório."></asp:TextBox>

                        <br />
                        <h4>Nome</h4>
                        <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" placeholder="Digite seu nome" required="required" data-error="Campo de preenchimento obrigatório."></asp:TextBox>

                        <br />
                        <h4>Sobrenome</h4>
                        <asp:TextBox ID="txtSobrenome" runat="server" CssClass="form-control" placeholder="Digite seu sobrenome" required="required" data-error="Campo de preenchimento obrigatório."></asp:TextBox>

                        <br />
                        <h4>E-mail</h4>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Digite seu e-mail" required="required" data-error="E-Campo de preenchimento obrigatório." TextMode="Email"></asp:TextBox>
                        
                        <br />
                        <h4>Data de Nascimento</h4>
                        <%--<asp:TextBox ID="txtDataNascimento" runat="server" CssClass="form-control" placeholder="Em que dia você nasceu?" data-error="Campo de preenchimento obrigatório." Enabled="False"></asp:TextBox>--%>
                        <asp:TextBox ID="txtDataNascimento" runat="server" CssClass="form-control" data-provide="datepicker" data-date-autoclose="true" data-date-format="dd/mm/yyyy" placeholder="Em que dia você nasceu?" data-error="Campo de preenchimento obrigatório." ReadOnly="true" ></asp:TextBox>
                        
                        <%--<br />
                        <h4>Sexo</h4>
                        <label class="fancy-radio">
                            <asp:RadioButton GroupName="rbGenero" runat="server" ID="rbMasculino" Checked="True" />
                            <span><i></i>Masculino</span>
                        </label>
                        <label class="fancy-radio">
                            <asp:RadioButton GroupName="rbGenero" runat="server" ID="rbFeminino" />
                            <span><i></i>Feminino</span>
                        </label>--%>
                        
                        <br />
                        <div style="float:none; width:100%;">
                            <div style="float:left; width:50%">
                                <%--<br />--%>
                                <h4>Sexo</h4>
                                <label class="fancy-radio">
                                    <asp:RadioButton GroupName="rbGenero" runat="server" ID="rbMasculino" Checked="True" />
                                    <span><i></i>Masculino</span>
                                </label>
                                <label class="fancy-radio">
                                    <asp:RadioButton GroupName="rbGenero" runat="server" ID="rbFeminino" />
                                    <span><i></i>Feminino</span>
                                </label>
                            </div>
                            <div style="float:right; width:50%">
                                <%--<br />--%>
                                <h4>Status</h4>
                                <label class="fancy-radio">
                                    <asp:RadioButton GroupName="rbStatus" runat="server" ID="rbAtivo" Checked="True" />
                                    <span><i></i>Ativo</span>
                                </label>
                                <label class="fancy-radio">
                                    <asp:RadioButton GroupName="rbStatus" runat="server" ID="rbInativo" />
                                    <span><i></i>Inativo</span>
                                </label>
                            </div>
                            &nbsp;
                            
                        </div>


                        <%--<br />--%>
                        <h4>CPF</h4>
                        <asp:TextBox ID="txtCPF" runat="server" CssClass="form-control" placeholder="Digite seu CPF" required="required" data-error="Campo de preenchimento obrigatório."></asp:TextBox>

                        <br />
                        <h4>RG</h4>
                        <asp:TextBox ID="txtRG" runat="server" CssClass="form-control" placeholder="Digite seu RG" required="required" data-error="Campo de preenchimento obrigatório."></asp:TextBox>

                        <br />
                        <h4>Endereço</h4>
                        <asp:TextBox ID="txtEndereco" runat="server" CssClass="form-control" placeholder="Digite seu endereço" required="required" data-error="Campo de preenchimento obrigatório."></asp:TextBox>

                        <br />
                        <h4>CEP</h4>
                        <asp:TextBox ID="txtCEP" runat="server" CssClass="form-control" placeholder="Digite seu CEP" required="required" data-error="Campo de preenchimento obrigatório."></asp:TextBox>

                        <br />
                        <h4>Telefone</h4>
                        <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control" placeholder="Digite seu telefone" TextMode="Phone"></asp:TextBox>

                        <br />
                        <h4>Celular</h4>
                        <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control" placeholder="Digite seu celular" TextMode="Phone"></asp:TextBox>

                    </div>
                    <!-- Fim Painel à Esquerda -->

                    <!-- Início Painel à Direita -->
                    <div class="profile-right" style="float: right; width: 50%;">
                        <h4>Foto de Perfil</h4>
                        <%--<asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Digite qualquer coisa, é teste CSS mesmo"></asp:TextBox>--%>

                        <!-- image-preview-filename input [CUT FROM HERE]-->
                        <div class="input-group image-preview">
                            <input type="text" class="form-control image-preview-filename" disabled="disabled">
                            <!-- don't give a name === doesn't send on POST/GET -->
                            <span class="input-group-btn">
                                <!-- image-preview-clear button -->
                                <span type="button" class="btn btn-default image-preview-clear" style="display: none;">
                                    <span class="glyphicon glyphicon-remove"></span> Limpar
                                </span>
                                <!-- image-preview-input -->
                                <div class="btn btn-default image-preview-input">
                                    <span class="glyphicon glyphicon-folder-open"></span>
                                    <span class="image-preview-input-title"> Pesquisar</span>
                                    <%--<input type="file" accept="image/png, image/jpeg, image/gif" name="input-file-preview" />--%>
                                    <asp:FileUpload ID="fuFotoPerfil" runat="server" type="file" accept="image/png, image/jpeg, image/gif" name="input-file-preview" />
                                    <!-- rename it -->
                                </div>
                   
                            </span>
                        </div>
                        <!-- /input-group image-preview [TO HERE]-->


                        <br />
                        <h4>Site Pessoal</h4>
                        <asp:TextBox ID="txtSite" runat="server" CssClass="form-control" placeholder="Link do seu site pessoal. Ex.: www.site.com.br"></asp:TextBox>
                        
                        <br />
                        <h4>Facebook</h4>
                        <asp:TextBox ID="txtFacebook" runat="server" CssClass="form-control" placeholder="Link do seu perfil no Facebook. Ex.: https://www.facebook.com/perfil"></asp:TextBox>

                        <br />
                        <h4>Instagram</h4>
                        <asp:TextBox ID="txtInstagram" runat="server" CssClass="form-control" placeholder="Link do seu perfil no Instagram. Ex.: https://www.facebook.com/perfil"></asp:TextBox>

                        <br />
                        <h4>LinkedIn</h4>
                        <asp:TextBox ID="txtLinkedIn" runat="server" CssClass="form-control" placeholder="Link do seu perfil no LinkedIn. Ex.: https://www.linkedin.com/in/perfil/"></asp:TextBox>
                        
                        <br />
                        <h4>Sobre Mim</h4>
                        <asp:TextBox ID="txtSobreMim" runat="server" CssClass="form-control" placeholder="Conte-nos mais sobre você" TextMode="MultiLine" Rows="10" MaxLength="500"></asp:TextBox>


                    </div>
                    <!-- Fim Painel à Direita -->


                </div>

                <hr />

                <asp:Button ID="btnSalvarPerfil" runat="server" class="btn btn-primary" Text="Salvar" OnClick="btnSalvarPerfil_Click" />



                <%--<button type="button" class="btn btn-primary">Default Size</button>
            <button type="button" class="btn btn-primary">Salvar</button>--%>

                <%--<p>Make a paragraph stand out by adding <code>.lead</code></p>
            <p class="lead">Objectively re-engineer maintainable total linkage after proactive intellectual capital. Dynamically evolve best-of-breed e-services for user-centric customer.</p>


            <hr />

            <div class="well">
                <p class="text-left"><code>.text-left</code> Left aligned text.</p>
                <p class="text-center"><code>.text-center</code> Center aligned text.</p>
                <p class="text-right"><code>.text-right</code> Right aligned text.</p>
            </div>--%>
            </div>
        </div>



        </asp:Content>
