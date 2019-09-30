<%@ Page Title="Registro de Evaluaciones" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="RegistroEvaluacion.aspx.cs" 
    Inherits="Parcial1_NeysiFM_A2.UI.Registros.RegistroEvaluacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="card text-center bg-light">
            <div class="card-header"><%:Page.Title %></div>

            <%--ID--%>
            <div>
                <label for="EvaluacionID" runat="server">ID</label>
                <asp:TextBox ID="EvaluacionID" runat="server" TextMode="Number" placeHolder="ID"></asp:TextBox>
                <asp:Button ID="BuscarButton" class="btn btn-info btn-lg" Text="Buscar" OnClick="BuscarButton_Click" runat="server" />
            </div>

            <%--FECHA--%>
            <div>
                <label for="FechaTextBox" runat="server">Fecha</label>
                <asp:TextBox ID="FechaTextBox" runat="server" TextMode="Date"></asp:TextBox>
            </div>

            <%--ESTUDIANTE--%>
            <div>
                <label for="EstudianteTextBox" runat="server">Estudiante</label>
                <asp:TextBox ID="EstudianteTextBox" runat="server" placeHolder="Nombre"></asp:TextBox>
            </div>

            <%--CATEGORIA--%>
            <div>
                <label for="CategoriaTextBox" runat="server">Categoria</label>
                <asp:TextBox ID="CategoriaTextBox" runat="server" placeHolder="Categoria"></asp:TextBox>
            </div>

            <%--VALOR--%>
            <div>
                <label for="ValorTextBox" runat="server">Valor</label>
                <asp:TextBox ID="ValorTextBox" runat="server" placeHolder="Valor"></asp:TextBox>
            </div>

            <%--LOGRADO--%>
            <div>
                <label for="LogradoTextBox" runat="server">Logrado</label>
                <asp:TextBox ID="LogradoTextBox" runat="server" placeHolder="Logrado"></asp:TextBox>
            </div>

            <%--BOTON AGREGAR--%>
            <div>
                <asp:Button ID="AgregarButton" Text="Agregar" runat="server" OnClick="AgregarButton_Click" />
            </div>

            <%--GRID--%>
            <div>
                <div class="row">
                    <div class="table table-responsive col-md-12">
                        <asp:GridView ID="DetalleGridView" runat="server"
                            CssClass="table table-condensed table-bordered table-responsive"
                            GridLines="None" CellPadding="4" ForeColor="#333333" 
                            AllowPaging="true" PageSize="5">
                        </asp:GridView>
                    </div>
                </div>
            </div>

            <%--TOTAL PERDIDO--%>
            <div>
                <label for="TotalPerdidoTextBox" runat="server">Total Perdido</label>
                <asp:TextBox ID="TotalPerdidoTextBox" AutoPostBack="true" runat="server" ReadOnly="true" placeHolder="Total Perdido"></asp:TextBox>
            </div>

            <%--BOTONES--%>
            <div class="panel-footer">
                <div class="text-center">
                    <div class="form-group" display: inline-block>
                        <asp:Button Text="Nuevo" class="btn btn-warning btn-lg" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                        <asp:Button Text="Guardar" class="btn btn-success btn-lg" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click" />
                        <asp:Button Text="Eliminar" class="btn btn-danger btn-lg" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />
                    </div>
                </div>
            </div>

            <%--MENSAJES--%>
            <asp:Label ID="MostrarMensajes" runat="server" Text="Label" Visible="false"></asp:Label>

        </div>
    </div>
</asp:Content>



