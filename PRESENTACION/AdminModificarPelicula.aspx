<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminModificarPelicula.aspx.cs" Inherits="PRESENTACION.AdminModificarPelicula" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>
    <link rel="stylesheet" href="CSS/ModificarPelicula.css">
</head>

<body>
    <form id="form1" runat="server">

        <div class="Usuario">
            <asp:Label ID="lblUsuario" runat="server" Font-Size="16px" ForeColor="Black">USUARIO</asp:Label><br />     
            <asp:LinkButton ID="btnLinkCerrarSesion" CssClass="btn btn-warning" runat="server"  Visible="False" OnClick="btnLinkCerrarSesion_Click">Cerrar session</asp:LinkButton>
        </div>

        <div class="Titulo">
            <asp:Label ID="lblTitulo" runat="server" CssClass="display-4" Font-Size="35px" ForeColor="Black" Text="Modificar pelicula"></asp:Label>
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
         <asp:Label ID="lblModificar" runat="server" Text="Seleccione pelicula:" ></asp:Label>
         <asp:DropDownList ID="dropPelicula" runat="server" Width="200px" CssClass="btn btn-danger dropdown-toggle" AutoPostBack="True" OnSelectedIndexChanged="dropPelicula_SelectedIndexChanged"></asp:DropDownList><br /><br />
         <asp:Label ID="lblPelicula" runat="server" Text="Nombre pelicula:"></asp:Label>
         <asp:TextBox ID="txtNmbrePelicula" runat="server" style="margin-left:15px" CssClass="btn btn-light" Enabled="False"></asp:TextBox><br /><br />
         <asp:Label ID="lblCalificacion" runat="server" Text="Calificacion:"></asp:Label>
         <asp:TextBox ID="txtCalificacion" runat="server" CssClass="btn btn-light" style="margin-left:52px" Enabled="False"></asp:TextBox>      
         <asp:LinkButton ID="btnReferenciaClasificacion"  runat="server" Text="Referencia" OnClick="btnReferenciaClasificacion_Click"></asp:LinkButton><br /><br />
         <asp:Label ID="lblFormato" runat="server" Text="Formato 3D"></asp:Label>
         <asp:CheckBox ID="chk3D" runat="server" style="margin-left:52px"  CssClass="btn btn-light" Text="3D" Enabled="False" /><br /><br />
         <asp:Label ID="lblDuracion" runat="server" Text="Duracion:"></asp:Label>
         <asp:TextBox ID="txtDuracion" runat="server" style="margin-left:66px"  CssClass="btn btn-light" Enabled="False"></asp:TextBox><br /><br />
         <asp:Label ID="lblGenero" runat="server" Text="Genero:"></asp:Label>
         <asp:TextBox ID="txtGenero" runat="server" style="margin-left:78px" CssClass="btn btn-light" Enabled="False"></asp:TextBox>
         <asp:LinkButton ID="btnReferenciaGen" runat="server" Text="Referencia" OnClick="btnReferenciaGen_Click"></asp:LinkButton><br /><br />
         <asp:Label ID="lblSinopsis" runat="server"  Text="Sinopsis:"></asp:Label>
         <asp:TextBox ID="txtSinopsis" runat="server" style="margin-left:70px" CssClass="btn btn-light" Enabled="False"></asp:TextBox><br /><br />
         <asp:Label ID="lblImagen" runat="server" Text="Imagen:"></asp:Label>
         <asp:TextBox ID="txtImagen" runat="server" style="margin-left:76px" CssClass="btn btn-light" AutoPostBack="True" Enabled="False"></asp:TextBox>
         <asp:FileUpload ID="FileUpload1"  runat="server" Enabled="False" /><br /><br />
         <asp:Label ID="lblActiva" runat="server" Text="Estado de pelicula:"></asp:Label>
         <asp:CheckBox ID="chkActiva" runat="server" style="margin-left:3px" CssClass="btn btn-light" Text="Activa" Enabled="False" /> <br /><br />

        <asp:Button ID="btnEditar" runat="server" Style="margin-left:140px" CssClass="btn btn-primary dropdown-toggle" OnClick="btnEditar_Click" Text="Editar" />
        <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger dropdown-toggle" OnClick="btnCancelar_Click" Text="Cancelar" Visible="False" />
        <br /><br />
    </div>
        <br />

    <div class="Alerta">
        <asp:Label ID="lblMensaje" CssClass="alert alert-danger" runat="server" Visible="False"></asp:Label>
        <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" CssClass="btn btn-danger" Text="Aceptar" Visible="False" />
    </div>

    <div class="RefClasificacion">
        <asp:Label ID="lblReferenciaClasificacion" runat="server" Text="Referencias clasificación: " Visible="False"></asp:Label><br />
        <asp:DropDownList ID="ddpClasificacion" CssClass="btn btn-info dropdown-toggle"  runat="server" Visible="False"></asp:DropDownList>
        <asp:LinkButton ID="btnOcultarRefClas" runat="server" Visible="false" OnClick="lblOcultarRefClas_Click">Ocultar</asp:LinkButton>
    </div>

    <div class="RefGenero">
        <asp:Label ID="lblReferenciaGenero" runat="server" Text="Referencias Generos: " Visible="False"></asp:Label><br />
        <asp:DropDownList ID="ddpGeneros" CssClass="btn btn-info dropdown-toggle"  runat="server" Visible="False"></asp:DropDownList>
        <asp:LinkButton ID="btnOcultarRefGen" runat="server" Visible="false" OnClick="btnOcultarRefGen_Click">Ocultar</asp:LinkButton>
    </div>

        <br /><br />
    </form>
</body>
</html>
