<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Presentacion.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="alert alert-danger text-center shadow-sm">
                    <h4 class="mb-3">Sucedió un problema</h4>
                    <asp:Label ID="lblError" runat="server" CssClass="d-block mb-3" Text="Label"></asp:Label>
                    <a href="Default.aspx" class="btn btn-outline-dark btn-sm">Volver al inicio</a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
