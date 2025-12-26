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
                <div class="row mb-2">
                    <%if (!CKBFiltroAvanzado.Checked)
                        {%>
                    <div class="col-6">
                        <asp:Label ID="lblFiltro" runat="server" CssClass="form-label" Text="Buscar"></asp:Label>
                        <asp:TextBox ID="txtFiltro" OnTextChanged="txtFiltro_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <%}
                    %>
                    <%else
                        { %>
                    <div class="col-6">
                        <asp:Label ID="lblFiltroAvanzado" runat="server" CssClass="form-label" Text="Buscar"></asp:Label>
                        <asp:TextBox ID="txtFiltroAvanzado" OnTextChanged="txtFiltroAvanzado_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <%} %>
                    <div class="col-4 mt-4">
                        <asp:Button ID="btnLimpiar" CssClass="btn btn-secondary" OnClick="btnLimpiar_Click" runat="server" Text="Limpiar" />
                    </div>
                    <div class="col-2 mt-4">
                        <asp:CheckBox ID="CKBFiltroAvanzado" AutoPostBack="true" CssClass="form-check" Text="Filtro Avanzado" runat="server" OnCheckedChanged="CKBFiltroAvanzado_CheckedChanged" />
                    </div>
                </div>
                <%if (CKBFiltroAvanzado.Checked)
                    { %>
                <div class="row mb-4">
                    <div class="col-6">
                        <asp:Label ID="lblCampo" runat="server" CssClass="form-label" Text="Campo"></asp:Label>
                        <asp:DropDownList ID="ddlCampo" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" CssClass="form-control" runat="server">
                            <asp:ListItem Text="Nombre"></asp:ListItem>
                            <asp:ListItem Text="Marca"></asp:ListItem>
                            <asp:ListItem Text="Categoría"></asp:ListItem>
                            <asp:ListItem Text="Precio"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-4">
                        <asp:Label ID="lblCriterio" runat="server" CssClass="form-label" Text="Criterio"></asp:Label>
                        <asp:DropDownList ID="ddlCriterio" CssClass="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Seleccione un criterio" CssClass="text-danger" Display="Dynamic" ControlToValidate="ddlCriterio"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-2 mt-4">
                        <asp:Button ID="btnBuscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary" runat="server" Text="Buscar" />
                    </div>
                </div>
                <%} %>
                <div class="row mt-4">
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
                                        <asp:Button ID="btnEliminar" runat="server" Text="🗑️" CommandName="Delete" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('⚠️ ATENCIÓN\n¿Está seguro que desea eliminar este artículo?\nEsta acción no se puede deshacer.');" />
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
