<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAgregarPelicula.aspx.cs" Inherits="PRESENTACION.PantallaAdminAgregar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
 <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>
 <link rel="stylesheet" href="CSS/Pelicula.css">

<body style="height: 344px">
    <form id="form1" runat="server">

         <div class="Usuario">
            <asp:Label ID="lblUsuario" runat="server" Font-Size="16px" ForeColor="Black">USUARIO</asp:Label>
            <br />
            <asp:LinkButton ID="btnLinkCerrarSesion" runat="server" CssClass="btn btn-warning" Visible="False" OnClick="btnLinkCerrarSesion_Click">Cerrar session</asp:LinkButton>
        </div>

        <div class="Titulo">
            <asp:Label ID="lblTitulo" runat="server" CssClass="display-4" Font-Size="45px" ForeColor="Black" Text="Agregar pelicula"></asp:Label>
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
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre pelicula"  style="margin-left:35px" CssClass="btn btn-light" ></asp:TextBox><br /><br />
            <asp:Label ID="lblImagen" runat="server" Text="Imagen"></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" style="margin-left:45px" /><br /><br />
            <asp:Label ID="lblClasificacion" runat="server" Text="Calificacion:"></asp:Label>
            <asp:DropDownList ID="dropCalificacion" style="margin-left:15px; width:200px" CssClass="btn btn-light" runat="server"></asp:DropDownList><br /><br />
            <asp:Label ID="lblFormato" runat="server"  Text="Formato3D:"></asp:Label>
            <asp:CheckBox ID="CheckBox1" runat="server" style="margin-left:15px" CssClass="btn btn-light" Text="3D" /><br /><br />
            <asp:Label ID="lblDuracion" runat="server" Text="Duracion:"></asp:Label>
            <asp:TextBox ID="txtDuracion" runat="server" placeholder="Duración en minutos" style="margin-left:30px" TextMode="Number" CssClass="btn btn-light" ></asp:TextBox><br /><br />
            <asp:Label ID="lblGenero" runat="server" Text="Genero:"></asp:Label>
            <asp:DropDownList ID="dropGenero" runat="server" style="margin-left:42px; width:200px" CssClass="btn btn-light" ></asp:DropDownList><br /><br />
            <asp:Label ID="lblSinopsis" runat="server" Text="Sinopsis:"></asp:Label>
            <asp:TextBox ID="txtSinopsis" runat="server" placeholder="Sinopsis pelicula" style="margin-left:36px" CssClass="btn btn-light"></asp:TextBox><br /><br />      
            <asp:Button ID="Button1" runat="server" style="margin-left:100px" CssClass="btn btn-primary dropdown-toggle" OnClick="Button1_Click1" Text="Confirmar"/>
            <asp:Button ID="btnLimpiar" runat="server" CssClass="btn btn-danger" Text="Resetear" OnClick="btnLimpiar_Click"/>

            </div>

        <div class="Alerta">
            <asp:Label ID="errormsg" CssClass="alert alert-danger" runat="server" Visible="False"></asp:Label>
            <asp:Button ID="btnOk" runat="server" CssClass="btn btn-danger dropdown-toggle" OnClick="btnOk_Click" Text="Aceptar" Visible="False"/>
            </div>

    </form>
</body>
</html>
