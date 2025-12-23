<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Presentacion.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-12 col-lg-6">
                <div class="card shadow-sm p-4">
                    <h3 class="mb-3">Crear Cuenta</h3>
                    <asp:ValidationSummary ID="vsRegistro" runat="server" CssClass="text-danger" ValidationGroup="Registro" />
                    <div class="mb-3">
                        <asp:Label ID="lblNombre" runat="server" CssClass="form-label" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="txtNombreCompleto" runat="server" CssClass="form-control" ValidationGroup="Register" />
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server"
                            ControlToValidate="txtNombreCompleto" ErrorMessage="Nombre requerido"
                            CssClass="text-danger" Display="Dynamic" ValidationGroup="vgRegister" />
                    </div>
                    <div class="mb-3">
                        <asp:Label runat="server" CssClass="form-label" Text="Email"></asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="tuemail@gmail.com" ValidationGroup="Registro" />
                        <!--Validaciones para el txtEmail-->
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                            ControlToValidate="txtEmail" ErrorMessage="Email requerido"
                            CssClass="text-danger" Display="Dynamic" ValidationGroup="Registro" />
                        <asp:RegularExpressionValidator ID="revEmail" runat="server"
                            ControlToValidate="txtEmail" ErrorMessage="Formato de email inválido"
                            ValidationExpression="^[^\s@]+@[^\s@]+\.[^\s@]+$"
                            CssClass="text-danger" Display="Dynamic" ValidationGroup="Registro" />
                    </div>

                    <div class="mb-3">
                        <asp:Label runat="server" CssClass="form-label" Text="Contraseña"></asp:Label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" ValidationGroup="Registro" />
                        <!--Validaciones para el la password-->
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                            ControlToValidate="txtPassword" ErrorMessage="Contraseña requerida"
                            CssClass="text-danger" Display="Dynamic" ValidationGroup="Registro" />
                    </div>
                    <div class="mb-3">
                        <asp:Button ID="btnRegistro" runat="server" CssClass="btn btn-primary" Text="Crear Cuenta" ValidationGroup="Registro" />
                        <a class="btn btn-link align-self-center" href="Login.aspx">Iniciar sesión</a>
                    </div>

                    <div class="mt-3 small">
                        <a href="RecuperarPassword.aspx">¿Olvidaste tu contraseña?</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
