<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAgregarGenero.aspx.cs" Inherits="PRESENTACION.AdminAgregarGenero" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
    </style>
</head>
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>
     <link rel="stylesheet" href="CSS/Genero.css">
<body>
    <form id="form1" runat="server">

        <div class="Usuario">
            <asp:Label ID="lblUsuario" runat="server" Font-Size="16px" ForeColor="Black">USUARIO</asp:Label>
            <asp:LinkButton ID="btnLinkCerrarSesion" runat="server" CssClass="btn btn-warning"  Visible="False" OnClick="btnLinkCerrarSesion_Click">Cerrar session</asp:LinkButton>
        </div>

        <div class="Titulo">
            <asp:Label ID="lblTitulo" runat="server" CssClass="display-4" Font-Size="45px" ForeColor="Black" Text="Agregar género"></asp:Label>
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

        <div class ="Ingreso">
            <asp:Label ID="lblNombreGenero" runat="server" Text="Nombre género:"></asp:Label>       
            <asp:TextBox ID="txtGenero" placeholder="Descripción género"  CssClass="btn btn-light" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="btnAgregar" runat="server" style="margin-left:120px" CssClass="btn btn-primary dropdown-toggle" OnClick="btnAgregar_Click" Text="Agregar" />        
            <asp:Button ID="btnResetear" runat="server" CssClass="btn btn-danger dropdown-toggle" Text="Resetear" OnClick="btnResetear_Click" />        
        </div>

        <div class="Alerta">
            <asp:Label ID="lblMje" CssClass="alert alert-danger" runat="server" Visible="False"></asp:Label>
            <asp:Button ID="btnOk" runat="server" CssClass="btn btn-danger dropdown-toggle" OnClick="btnOk_Click" Text="Aceptar" Visible="False" />
        </div>
    </form>
</body>
</html>
