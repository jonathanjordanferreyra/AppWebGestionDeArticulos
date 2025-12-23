<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentacion.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-12 col-md-6">
                <div class="card shadow-sm p-4">
                    <h3 class="mb-3">Iniciar sesión</h3>
                    <asp:ValidationSummary ID="vsLogin" runat="server" CssClass="text-danger" ValidationGroup="Login" />
                    <div class="mb-3">
                        <label class="form-label">Email</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="tuemail@gmail.com" ValidationGroup="Login" />
                        <!--Validaciones para el txtEmail-->
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                            ControlToValidate="txtEmail" ErrorMessage="Email requerido"
                            CssClass="text-danger" Display="Dynamic" ValidationGroup="Login" />
                        <asp:RegularExpressionValidator ID="revEmail" runat="server"
                            ControlToValidate="txtEmail" ErrorMessage="Formato de email inválido"
                            ValidationExpression="^[^\s@]+@[^\s@]+\.[^\s@]+$"
                            CssClass="text-danger" Display="Dynamic" ValidationGroup="Login" />
                    </div>

                    <div class="mb-3">
                        <label class="form-label">Contraseña</label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" ValidationGroup="Login" />
                        <!--Validaciones para el la password-->
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                            ControlToValidate="txtPassword" ErrorMessage="Contraseña requerida"
                            CssClass="text-danger" Display="Dynamic" ValidationGroup="Login" />
                    </div>

                    <div class="mb-3">
                        <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary" OnClick="btnLogin_Click" Text="Ingresar" ValidationGroup="Login" />
                        <a class="btn btn-link align-self-center" href="Registro.aspx">Crear cuenta</a>
                    </div>

                    <div class="mt-3 small">
                        <a href="RecuperarPassword.aspx">¿Olvidaste tu contraseña?</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
