<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Presentacion.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="card shadow-sm p-4">
            <h2 class="mb-3 text-center">Mi Perfil</h2>

            <div class="row mb-3">
                <div class="col-4 text-center">
                    <asp:Label Text="Imagen Perfil" CssClass="form-label" runat="server" />
                    <asp:FileUpload ID="fuImagenPerfil" CssClass="form-control mb-2" runat="server" />
                    <asp:Image ID="imgPerfil"
                        CssClass="img-fluid rounded-circle mb-3" Style="width: 200px; height: 200px; object-fit: cover;"
                        runat="server" />
                </div>

                <div class="col">
                    <div class="mb-3">
                        <asp:Label Text="Email" CssClass="form-label" runat="server" />
                        <asp:TextBox ID="txtEmail" CssClass="form-control" ReadOnly="true" runat="server" />
                    </div>

                    <div class="mb-3">
                        <asp:Label Text="Nombre" CssClass="form-label" runat="server" />
                        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
                    </div>

                    <div class="mb-3">
                        <asp:Label Text="Apellido" CssClass="form-label" runat="server" />
                        <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server" />
                    </div>

                    <asp:Button ID="btnGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" Text="Guardar cambios" runat="server" />

                    <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary ms-2" Text="Cancelar" runat="server" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
