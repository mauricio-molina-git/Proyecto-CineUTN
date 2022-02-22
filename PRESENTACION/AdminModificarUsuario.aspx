<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminModificarUsuario.aspx.cs" Inherits="PRESENTACION.AdminModificarUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
   <link rel="stylesheet" href="CSS/ModificarUsuario.css">
   <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>

<body>
    <form id="form1" runat="server">

         <div class="Usuario">
            <asp:Label ID="lblUsuario" runat="server" Font-Size="16px" ForeColor="Black">USUARIO</asp:Label>
            <asp:LinkButton ID="btnLinkCerrarSesion" runat="server" CssClass="btn btn-warning" OnClick="btnLinkCerrarSesion_Click">Cerrar session</asp:LinkButton>
        </div>

        <div class="Titulo">
            <asp:Label ID="lblTitulo" runat="server" CssClass="display-4" Font-Size="35px" ForeColor="Black" Text="Modificar usuario"></asp:Label>
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
            <asp:Label ID="lblUser" runat="server" Text="Usuario:"></asp:Label>
            <asp:DropDownList ID="dropUsuarios" runat="server" style="margin-left:30px; width:230px" CssClass="btn btn-danger dropdown-toggle" OnSelectedIndexChanged="dropUsuarios_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList><br /><br />
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="txtNombre" CssClass="btn btn-light" style="margin-left:25px; width:230px" runat="server" Enabled="False"></asp:TextBox><br /><br />
            <asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label>
            <asp:TextBox ID="txtApellido" CssClass="btn btn-light" style="margin-left:25px; width:230px" runat="server" Enabled="False"></asp:TextBox><br /><br />
            <asp:Label ID="lblDni" runat="server" Text="DNI:"></asp:Label>
            <asp:TextBox ID="txtDni" CssClass="btn btn-light" style="margin-left:55px; width:230px" runat="server" Enabled="False" TextMode="Number"></asp:TextBox><br /><br />
            <asp:Label ID="lblGenero" runat="server" Text="Genero:"></asp:Label>
            <asp:DropDownList ID="dropGenero" CssClass="btn btn-light" style="margin-left:30px; width:230px" runat="server" Enabled="False"></asp:DropDownList><br /><br />          
            
            <asp:Label ID="lblNacimiento" runat="server" Text="F. Nac. "></asp:Label>
            <asp:Label ID="lbldia" runat="server" Text="Día:"></asp:Label>
            <asp:TextBox ID="txtDia" runat="server" CssClass="btn btn-light" Width="60px" BorderColor="#E8E1DF" Enabled="False" ></asp:TextBox>   
            
            <asp:Label ID="lblMes" runat="server" Text="Mes:"></asp:Label>
            <asp:TextBox ID="txtMes" runat="server" CssClass="btn btn-light" Width="60px" BorderColor="#E8E1DF" Enabled="False" ></asp:TextBox>   
            
            <asp:Label ID="lblaño" runat="server" Text="Año:"></asp:Label>
            <asp:TextBox ID="txtAño" runat="server" CssClass="btn btn-light" Width="60px" BorderColor="#E8E1DF" Enabled="False" ></asp:TextBox><br /><br />                   
            
            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" CssClass="btn btn-light" style="margin-left:41px; width:230px" runat="server" Enabled="False"></asp:TextBox><br /><br />
            <asp:Label ID="lblTelefono" runat="server" Text="Telefono:"></asp:Label>
            <asp:TextBox ID="txtTelefono" CssClass="btn btn-light" style="margin-left:20px; width:230px" runat="server" Enabled="False"></asp:TextBox><br /><br />
            <asp:Label ID="lblContraseña" runat="server" Text="Contraseña:"></asp:Label>
            <asp:TextBox ID="txtContraseña" CssClass="btn btn-light" Width="230px" runat="server" Enabled="False"></asp:TextBox><br /><br />
            <asp:Label ID="lblAdmin" runat="server" Text="Admin:"></asp:Label>
            <asp:CheckBox ID="chkAdmin" runat="server" style="margin-left:32px; width:230px" CssClass="btn btn-light" Text="Administrador" Enabled="False" /><br /><br />
            <asp:Label ID="lblActiva" runat="server" Text="Estado:"></asp:Label>
            <asp:CheckBox ID="chkActivo" runat="server"  style="margin-left:32px; width:230px" CssClass="btn btn-light" Text="Activo" Enabled="False" /><br /><br />

            <asp:Button ID="btnEditar" runat="server" style="margin-left:85px" CssClass="btn btn-primary dropdown-toggle"  Text="Editar" OnClick="btnEditar_Click" />
            <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger dropdown-toggle"  Text="Cancelar" Visible="False" OnClick="btnCancelar_Click" />
        </div>
            <br /><br />

        <div class="Calendario">
<%--            <asp:Calendar ID="calNacimiento"  CssClass="btn btn-info" runat="server" ShowGridLines="True" Visible="False"></asp:Calendar>--%>
        </div>

        <div class="Alerta">
             <asp:Label ID="lblMensaje" CssClass="alert alert-danger" runat="server" Visible="False"></asp:Label>
            <asp:Button ID="btnOk" CssClass="btn btn-danger dropdown-toggle" runat="server" Text="Aceptar" Visible="False" OnClick="btnOk_Click" />
        </div>

    </form>
</body>
</html>
