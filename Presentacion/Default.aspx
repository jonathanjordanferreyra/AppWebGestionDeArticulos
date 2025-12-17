<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentacion.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .imagenArticulo {
            height: 250px;
            object-fit: contain;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:UpdatePanel ID="UpdatePanelListado" runat="server">
            <ContentTemplate>
                <!--Filtro-->
                <div class="row">
                    <div class="col-6 mt-2 mb-4">
                        <asp:TextBox ID="txtFiltro" CssClass="form-control" placeholder="Nombre del producto" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-4 mt-2">
                        <asp:Button ID="btnBuscar" CssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                        <asp:Button ID="btnLimpiar" CssClass="btn btn-secondary" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
                    </div>
                </div>
                <!--Listado de Artículos-->
                <div class="row">
                    <asp:Repeater ID="RepeaterProductos" runat="server">
                        <ItemTemplate>
                            <div class="col-4 mb-4">
                                <div class="card" style="width: 18rem;">
                                    <!-- valido si es la imagen es null, vacia o no se carga la imagen-->
                                    <img src='<%#Eval("ImagenUrl") != null && Eval("ImagenUrl").ToString() != "" && Eval("ImagenUrl").ToString().StartsWith("http") ? Eval("ImagenUrl") : "https://ralfvanveen.com/wp-content/uploads/2021/06/Placeholder-_-Glossary.svg"%>' class="card-img-top imagenArticulo" alt="<%#Eval("Descripcion")%>" onerror="this.onerror=null; this.src='https://ralfvanveen.com/wp-content/uploads/2021/06/Placeholder-_-Glossary.svg';" />
                                    <div class="card-body">
                                        <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                        <p class="card-text"><%#Eval("Descripcion") %></p>
                                        <asp:Button CssClass="btn btn-primary" ID="btnDetalle" runat="server" OnClick="btnDetalle_Click" Text="Detalle" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
