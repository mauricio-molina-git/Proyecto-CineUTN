<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAgregarFuncion.aspx.cs" Inherits="PRESENTACION.AdminAgregarFuncion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>
 <link rel="stylesheet" href="CSS/Funcion.css">

<body>
    <form id="form1" runat="server">

        <div class="Usuario">
            <asp:Label ID="lblUsuario" runat="server" Font-Size="16px" ForeColor="Black">USUARIO</asp:Label>
            <asp:LinkButton ID="btnLinkCerrarSesion" runat="server" CssClass="btn btn-warning" Visible="False" OnClick="btnLinkCerrarSesion_Click">Cerrar session</asp:LinkButton>
        </div>

        <div class="Titulo">
            <asp:Label ID="lblTitulo" runat="server" CssClass="display-4" Font-Size="45px" ForeColor="Black" Text="Agregar función"></asp:Label>
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
                <asp:Label ID="lblPelicula" runat="server" Text="Pelicula: "></asp:Label>
                <asp:DropDownList ID="dropPelicula" runat="server" style="margin-left:10px"  CssClass="btn btn-danger dropdown-toggle"></asp:DropDownList><br /><br />
                <asp:Label ID="lblSala" runat="server" Text="Sala:"></asp:Label>
                <asp:DropDownList ID="dropSala" runat="server" style="margin-left:33px; width:225px"  CssClass="btn btn-danger dropdown-toggle"></asp:DropDownList><br /><br />
                <asp:Label ID="lblSala0" runat="server" Text="Fecha:"></asp:Label>
                <asp:Button ID="btnCalendario" style="margin-left:20px; width:225px" CssClass="btn btn-light" runat="server" Text="Ver calendario" OnClick="btnCalendario_Click" /><br /><br />
                <asp:Label ID="lblSala1" runat="server" Text="Hora:"></asp:Label>
                <asp:TextBox ID="txtHora" runat="server" placeholder="Hora + min. Ejemplo 1800" TextMode="Number"  style="margin-left:27px; width:225px" CssClass="btn btn-light"></asp:TextBox><br /><br />
                <asp:Button ID="btnConfirmar" runat="server" style="margin-left:110px" CssClass="btn btn-primary dropdown-toggle" OnClick="btnConfirmar_Click" Text="Confirmar"/>
                <asp:Button ID="btnResetear" runat="server" CssClass="btn btn-danger dropdown-toggle"  Text="Resetear" OnClick="btnCancelar_Click"/>
            </div>

        <div class="Calendario">
            <asp:Calendar ID="calFecha" runat="server" CssClass="btn btn-info" OnSelectionChanged="calFecha_SelectionChanged" Visible="False" DayNameFormat="Shortest"></asp:Calendar>
        </div>

        <div class="Alerta">
                <asp:Label ID="errormsg" CssClass="alert alert-danger" runat="server" Visible="False"></asp:Label>
                <asp:Button ID="btnOK" runat="server" CssClass="btn btn-danger dropdown-toggle" OnClick="btnOK_Click" Text="Aceptar" Visible="False"/>
        </div>
    </form>
</body>
</html>
