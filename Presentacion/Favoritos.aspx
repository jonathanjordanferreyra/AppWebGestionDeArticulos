<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Presentacion.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
        <asp:Label ID="lblAvisoo" Visible="false" CssClass="alert alert-info" runat="server" Text="No tiene artículos en favoritos..."></asp:Label>
    </div>
    <asp:Repeater ID="repFavoritos" runat="server">
        <ItemTemplate>
            <div class="card mb-3">
                <div class="row g-0 align-items-center">
                    <div class="col-md-2">
                        <img src='<%# Eval("ImagenUrl") ?? "https://ralfvanveen.com/wp-content/uploads/2021/06/Placeholder-_-Glossary.svg" %>' class="img-fluid rounded" style="max-height: 120px; object-fit: cover;" />
                    </div>

                    <div class="col-md-7">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <p class="card-text"><%# Eval("Descripcion") %></p>
                            <p class="card-text fw-bold">$ <%# Eval("Precio", "{0:N2}") %></p>
                        </div>
                    </div>

                    <div class="col-md-3 text-center">
                        <asp:Button runat="server" ID="btnQuitarFavorito" Text="Quitar de favoritos" CssClass="btn btn-outline-danger" CommandArgument='<%# Eval("Id") %>' OnClick="btnQuitarFavorito_Click" />
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
