<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="Presentacion.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .img-articulo {
            max-height: 250px;
            object-fit: contain;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="card shadow-sm p-4">
            <div class="row mb-3">
                <div class="col-2">
                    <asp:Label Text="ID" CssClass="form-label" runat="server" />
                    <asp:TextBox ID="txtId" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-4">
                    <asp:Label Text="Código" CssClass="form-label" runat="server" />
                    <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ErrorMessage="Ingrese el código" ControlToValidate="txtCodigo"></asp:RequiredFieldValidator>
                </div>
                <div class="col">
                    <asp:Label Text="Nombre" CssClass="form-label" runat="server" />
                    <asp:TextBox ID="txtNombre" CssClass="form-control mb-2" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="Ingrese el nombre" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row g-2 mb-3">
                <div class="col-6">
                    <asp:Label Text="URL Imagen" CssClass="form-label" runat="server" />
                    <asp:TextBox ID="txtImagenUrl" OnTextChanged="txtImagenUrl_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" CssClass="text-danger" ControlToValidate="txtImagenUrl" ValidationExpression="^$|^https?:\/\/.+" runat="server" ErrorMessage="Ingrese una URL válida"></asp:RegularExpressionValidator>
                </div>
                <div class="col-3">
                    <asp:Label Text="Marca" CssClass="form-label" runat="server" />
                    <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>
                <div class="col-3">
                    <asp:Label Text="Categoría" CssClass="form-label" runat="server" />
                    <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>
                <div class="row g-2 mb-3">
                    <div class="col-6">
                        <asp:Image ID="imgArticulo" CssClass="img-fluid rounded img-articulo" runat="server" />
                    </div>
                    <div class="col">
                        <!-- Precio y descripcion -->
                        <asp:Label Text="Precio" CssClass="form-label" runat="server" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Ingrese un valor numérico" CssClass="text-danger" ValidationExpression="^[0-9]+$" ControlToValidate="txtPrecio"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese un valor numérico" CssClass="text-danger" ControlToValidate="txtPrecio"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPrecio" CssClass="form-control mb-2" runat="server"></asp:TextBox><asp:Label Text="Descripción" CssClass="form-label" runat="server" />
                        <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control mb-4" runat="server"></asp:TextBox>
                        <asp:Button ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-success" runat="server" Text="Aceptar" />
                        <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" runat="server" CssClass="btn btn-danger" Text="Cancelar" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
