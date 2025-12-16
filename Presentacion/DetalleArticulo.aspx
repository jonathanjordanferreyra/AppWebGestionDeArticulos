<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="Presentacion.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .img-articulo {
            max-height: 400px;
            object-fit: contain;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="card shadow-sm p-4">
            <div class="row g-2 mb-3">
                <div class="col-6">
                    <!--Imagen del artículo-->
                    <asp:Image ID="imgArticulo" CssClass="img-fluid rounded img-articulo" runat="server" />
                </div>
                <div class="col-6 mt-5">
                    <!--información del artículo-->
                    <h2>
                        <asp:TextBox ID="txtNombre" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                    </h2>
                    <h4>
                        <asp:Label ID="lblPrecio" runat="server" CssClass="form-label" Text="Precio"></asp:Label>
                        <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>
                    </h4>
                    <h5>
                        <asp:Label ID="lblDescripcion" CssClass="form-label" runat="server" Text="Descripción"></asp:Label>
                        <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server"></asp:TextBox>
                    </h5>
                    <div class="row mb-3">
                        <div class="col-6">
                            <asp:Label ID="lblMarca" CssClass="form-label" runat="server" Text="Marca"></asp:Label>
                            <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-6">
                            <asp:Label ID="lblCategoria" runat="server" Text="Categoría"></asp:Label>
                            <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
