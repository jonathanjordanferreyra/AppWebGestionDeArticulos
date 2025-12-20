<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="Presentacion.Administracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="row">
            <div class="col">
                <h2>Administración</h2>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <hr class="mb-3" />
            </div>
        </div>
        <asp:UpdatePanel ID="UPGridView" runat="server">
            <ContentTemplate>
                <div class="row mb-4">
                    <div class="col-6">
                        <asp:Label ID="lblFiltro" runat="server" CssClass="form-label" Text="Buscar"></asp:Label>
                        <asp:TextBox ID="txtFiltro" OnTextChanged="txtFiltro_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col">
                        <br />
                        <asp:CheckBox ID="CKBFiltroAvanzado" CssClass="form-check" Text="Filtro Avanzado" runat="server" />
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:GridView ID="GVArticulos" DataKeyNames="Id" OnSelectedIndexChanged="GVArticulos_SelectedIndexChanged" OnRowDeleting="GVArticulos_RowDeleting" AutoGenerateColumns="false" CssClass="table table-dark table-striped" AllowPaging="true" PageSize="5" PagerStyle-ForeColor="Gold" PagerStyle-BorderStyle="Solid" PagerStyle-Font-Bold="true" OnPageIndexChanging="GVArticulos_PageIndexChanging" runat="server">

                            <Columns>
                                <asp:BoundField HeaderText="Código" DataField="Codigo" />
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                                <asp:TemplateField HeaderText="Marca">
                                    <ItemTemplate>
                                        <%#Eval("Marca.Descripcion") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Categoría">
                                    <ItemTemplate>
                                        <%# Eval("Categoria.Descripcion") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:F2}" />

                                <asp:TemplateField HeaderText="Editar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEditar" runat="server" Text="✏️" CommandName="Select" CssClass="btn btn-warning btn-sm" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Eliminar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEliminar" runat="server" Text="🗑️" CommandName="Delete" CssClass="btn btn-danger btn-sm"  OnClientClick="return confirm('⚠️ ATENCIÓN\n¿Está seguro que desea eliminar este artículo?\nEsta acción no se puede deshacer.');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:Button ID="BtnAgregar" runat="server" CssClass="btn btn-primary" Text="Agregar Artículo" OnClick="BtnAgregar_Click" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
