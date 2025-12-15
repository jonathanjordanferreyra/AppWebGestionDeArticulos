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
                                <a href="DetalleArticulo.aspx?id=" <%#Eval("Id") %> class="btn btn-primary">Detalle</a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
