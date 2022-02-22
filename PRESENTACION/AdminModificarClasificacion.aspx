<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminModificarClasificacion.aspx.cs" Inherits="PRESENTACION.AdminModificarClasificacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<link rel="stylesheet" href="CSS/ModificarClasificacion.css">
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>

<body>
    <form id="form1" runat="server">

    <div class="Usuario">
        <asp:Label ID="lblUsuario" runat="server" Font-Size="16px" ForeColor="Black">USUARIO</asp:Label>
        <asp:LinkButton ID="btnLinkCerrarSesion" runat="server" CssClass="btn btn-warning"  Visible="False" OnClick="btnLinkCerrarSesion_Click">Cerrar session</asp:LinkButton>
    </div>

    <div class="Titulo">
        <asp:Label ID="lblTitulo" runat="server" CssClass="display-4" Font-Size="45px" ForeColor="Black" Text="Modificar clasificación"></asp:Label>
    </div>

    <div class="Home">
        <asp:ImageButton ID="btnPrincipal" Height="50px" Width="50px" ImageUrl="~/ImagenesBotones/Home3.png" runat="server" OnClick="btnPrincipal_Click" />
    </div>

    <div class="menu">
		<ul>
			<li><a href="AdminAgregarPelicula.aspx">Agregar Pelicula</a></li>
			<li><a href="AdminAgregarFuncion.aspx">Agregar Funcion</a></li>
			<li><a href="AdminAgregarGenero.aspx">Agregar Genero</a></li>
			<li><a href="AdminAgregarClasificacion.aspx">Agr. Clasificacion</a></li>
            <li><a href="AdminAgregarUsuario.aspx">Agregar usuario</a></li>
            <li><a href="AdminModificarUsuario.aspx">Modificar Usuario</a></li>
			<li><a href="AdminModificarPelicula.aspx">Modificar Pelicula</a></li>
			<li><a href="AdminModificarGenero.aspx">Modificar Genero</a></li>
            <li><a href="AdminModificarPrecio.aspx">Modificar precios</a></li>
			<li><a href="AdminModificarClasificacion.aspx">Mod. Clasificacion</a></li>
		    <li><a href="Reportes.aspx">Ver reportes</a></li>
		</ul>
    </div>

    <div class="Ingreso">
        <asp:Label ID="lblmensajeClasificacion" runat="server" Text="Seleccione una clasificación:"></asp:Label>
        <asp:DropDownList ID="dropCalificacion" CssClass="btn btn-danger dropdown-toggle" style="width:150px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropCalificacion_SelectedIndexChanged"></asp:DropDownList><br /><br />
        <asp:Label ID="lblGenero" runat="server" Text="Descripcion clasificación:"></asp:Label>
        <asp:TextBox ID="txtCalificacion" CssClass="btn btn-light" style="width:150px; margin-left:21px" runat="server" Enabled="False"></asp:TextBox><br /><br />
        <asp:Label ID="lblActivo" runat="server" Text="Estado:"></asp:Label>
        <asp:CheckBox ID="chkActivo" runat="server" Text="Activo" Style="margin-left:145px" Enabled="False" /><br />       
        <asp:Button ID="btnEditar" CssClass="btn btn-primary dropdown-toggle" style="margin-left:135px" runat="server" Text="Editar" OnClick="btnEditar_Click" />
        <asp:Button ID="btnCancelar" CssClass="btn btn-danger dropdown-toggle" runat="server" Text="Cancelar" Visible="False" OnClick="btnCancelar_Click" />
    </div>

    <div class="Alerta">
        <asp:Label ID="lblMensaje" CssClass="alert alert-danger" runat="server" Visible="False"></asp:Label>
        <asp:Button ID="btnOk" runat="server"  CssClass="btn btn-danger" OnClick="btnOk_Click" Text="Aceptar" Visible="False"/>
    </div>

    </form>
</body>
</html>
