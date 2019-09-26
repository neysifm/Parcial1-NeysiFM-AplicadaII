<%@ Page Title="Registro de Evaluaciones" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="RegistroEvaluacion.aspx.cs" 
    Inherits="Parcial1_NeysiFM_A2.UI.Registros.RegistroEvaluacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--ID--%>
    <div class="container container-fluid">
    <div class="card">
		<div class="card-title"> <h2>Registro de Evaluaciones</h2></div>
		<div class="card-body">
			<div class="form-group col-md-3">
			<div class="input-group">
			<div class="input-group-prepend">
				<span class="input-group-text">ID</span>
			</div>
			<asp:textbox type="text" runat="server" class="form-control" ID="Textbox5"></asp:textbox>
			<div class="input-group-append">
				<asp:linkbutton ID="Linkbutton5" class="btn btn-primary" runat="server" OnClick="ButtonBuscar_Click"><i class="fa fa-search"></i></asp:linkbutton>							
			</div>
			</div>
			</div>
        </div>
     </div>
    </div>

    <%--ESTUDIANTE--%>
    <div class="form-group">
		<div class="input-group">
			<div class="input-group-prepend">
				<span class="input-group-text">Nombre Estudiante</span>
			</div>
			<asp:textbox type="text" runat="server" class="form-control" ID="NombreTextBox"></asp:textbox>
			<asp:requiredfieldvalidator runat="server" ControlToValidate="NombreTextBox" errormessage="RequiredFieldValidator"></asp:requiredfieldvalidator>
		</div>
	</div>

    <%--CATEGORIA--%>
    <div class="row">
	<div class="form-group col-md-3">
		<asp:Label runat="server">Categoria</asp:Label>
		<asp:TextBox runat="server" class="form-control" ID="TextBox2"></asp:TextBox>
		<asp:requiredfieldvalidator runat="server" ControlToValidate="NombreCategoriaTextBox" errormessage="RequiredFieldValidator"></asp:requiredfieldvalidator>
	</div>
    </div>

    <%--VALOR--%>
    <div class="form-group col-md-3">
		<asp:Label runat="server">Valor</asp:Label>
		<asp:TextBox runat="server" class="form-control" ID="TextBox4"></asp:TextBox>
		<asp:requiredfieldvalidator runat="server" ControlToValidate="ValorTextBox" errormessage="RequiredFieldValidator"></asp:requiredfieldvalidator>
	</div>

    <%--LOGRADO--%>
    <div class="form-group col-md-3">
	<asp:Label runat="server">Logrado</asp:Label>
	<asp:TextBox runat="server" class="form-control" ID="TextBox3"></asp:TextBox>
	<asp:requiredfieldvalidator runat="server" ControlToValidate="LogradoTextBox" errormessage="RequiredFieldValidator"></asp:requiredfieldvalidator>
    </div>

    <%--AGREGAR--%>
    <div class="form-group col-md-3">
	<asp:LinkButton runat="server" ID="LinkButton4" OnClick="Agregar_Click" CssClass="btn btn-info">Agregar</asp:LinkButton>
    </div>

    <%--GRID--%>
	<div class="col-md-12">
		<asp:GridView ID="DatosGridView"
			runat="server"
			class="table table-condensed table-bordered table-responsive"
			CellPadding="4" ForeColor="#333333" GridLines="None">

			<AlternatingRowStyle BackColor="White" />
			<Columns>
				<asp:HyperLinkField ControlStyle-ForeColor="blue"
					DataNavigateUrlFields="EvaluacionId"
					DataNavigateUrlFormatString="~/UI/Registros/RegistroEvaluacion.aspx?Id={0}"
					Text="Editar"></asp:HyperLinkField>
			</Columns>
			<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
			<RowStyle BackColor="#EFF3FB" />
		</asp:GridView>
    </div>

    <%--ERROR--%>
    <div>
        <asp:Label ID="ErrorLabel" runat="server" Text=" "></asp:Label>
    </div>

    <%--BOTONES--%>
    <div class="card-footer">
	<asp:linkbutton ID="Linkbutton1"  class="btn btn-primary" runat="server" OnClick="NuevoButton_Click">Nuevo</asp:linkbutton>
	<asp:linkbutton ID="Linkbutton2"  class="btn btn-success" runat="server" OnClick="GuadarButton_Click">Guardar</asp:linkbutton>
	<asp:linkbutton ID="Linkbutton3"  class="btn btn-danger" runat="server" OnClick="EliminarButton_Click">Eliminar</asp:linkbutton>
    </div>

</asp:Content>



