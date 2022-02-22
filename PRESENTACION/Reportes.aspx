<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="PRESENTACION.Reportes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
<link rel="stylesheet" href="CSS/Reportes.css">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
    <div class="Usuario">
        <asp:Label ID="lblUsuario" runat="server" Font-Size="16px" ForeColor="Black">USUARIO</asp:Label>            
        <asp:LinkButton ID="btnLinkCerrarSesion" runat="server" CssClass="btn btn-warning"  Visible="False" OnClick="btnLinkCerrarSesion_Click">Cerrar session</asp:LinkButton>
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
		        <li><a href="AdminModificarClasificacion.aspx">Mod. Clasificacion</a></li>
		        <li><a href="Reportes.aspx">Ver reportes</a></li>
            </ul>
        </div>

        <div class="RecaudacionxFormato">
            <asp:Label ID="lblRecaudacionXFormato" runat="server" CssClass="display-4" Font-Size="20px" ForeColor="black" Text="Pelicula con mas recaudación: "></asp:Label><br /><br />
            <asp:Button ID="btnRecaudacion3D" runat="server" Text="3D" Width="66px" CssClass="btn btn-outline-danger" OnClick="btnRecaudacion3D_Click"/>
            <asp:Label ID="lblRecaudacion3D" runat="server" style="margin-left:20px; border-radius:35px;" class="btn btn-primary" Visible="False"  ></asp:Label><br /><br />
            <asp:Button ID="btnRecaudacion2D" runat="server" Text="2D" Width="66px" CssClass="btn btn-outline-danger" OnClick="btnRecaudacion2D_Click" />
            <asp:Label ID="lblRecaudacion2D" style="margin-left:20px; border-radius:35px;" class="btn btn-primary" runat="server" Visible="False"></asp:Label>
        </div>

        <div class="VendidasxFormato">
            <asp:Label ID="lblVendidasXFormato" runat="server" CssClass="display-4" Font-Size="20px" ForeColor="black" Text="Tickets vendidos por formato: "></asp:Label><br /><br />        
            <asp:Button ID="btnVendidas3D" runat="server" Text="3D" Width="66px" CssClass="btn btn-outline-danger" OnClick="btnVendidas3D_Click"/> 
            <asp:Label ID="lblCantVend3D" runat="server" style="margin-left:40px; border-radius:35px;" class="btn btn-primary" Visible="False"  ></asp:Label><br /><br />
            <asp:Button ID="btnVendidas2D" runat="server" Text="2D" Width="66px" CssClass="btn btn-outline-danger" OnClick="btnVendidas2D_Click" />
            <asp:Label ID="lblCantVend2D" runat="server" style="margin-left:40px; border-radius:35px;" class="btn btn-primary" Visible="False"  ></asp:Label><br /><br />
        </div>

        <div class="FacturacionxFormato">
            <asp:Label ID="lblFacturacion" runat="server" CssClass="display-4" Font-Size="20px" ForeColor="black" Text="Facturación por formato: "></asp:Label><br /><br />       
            <asp:Button ID="btnFacturacion3D" runat="server" Text="3D" Width="66px" CssClass="btn btn-outline-danger" OnClick="btnFacturacion3D_Click"/> 
            <asp:Label ID="lblFacturacion3D" runat="server" style="margin-left:40px; border-radius:35px;" class="btn btn-primary" Visible="False"  ></asp:Label>
            <asp:Button ID="btnFacturacion2D" runat="server" Text="2D" Width="66px" Style="margin-left:30px" CssClass="btn btn-outline-danger" OnClick="btnFacturacion2D_Click" />
            <asp:Label ID="lblFacturacion2D" runat="server" style="margin-left:40px; border-radius:35px;" class="btn btn-primary" Visible="False"  ></asp:Label>
        </div>

        <div class="VariosReportes">
            <asp:Label ID="lblFecha" runat="server" CssClass="display-4"  Font-Size="20px" ForeColor="black" style="margin-left:220px"  Text="Periodo: "></asp:Label> <br /> <br />         
            <asp:Label ID="lblDesde" runat="server" CssClass="display-4" Font-Size="20px" Style="margin-left:50px" ForeColor="black" Text="Desde: "></asp:Label>
            <asp:Calendar ID="calDesde" runat="server" Width="30px" Height="40px" OnSelectionChanged="Calendar1_SelectionChanged" SelectedDate="2015-01-01"></asp:Calendar><br />
            <asp:Button ID="btnFecha" runat="server" CssClass="btn btn-danger" Width="550px" OnClick="btnFecha_Click" Text="Ver reportes" />
            <br /><br />         
            <asp:Label ID="lblCantidadVendidas" runat="server" style="margin-left:325px" CssClass="display-4"  Font-Size="20px" ForeColor="black" Text="Entradas vendidas: "></asp:Label> <br /><br />
            <asp:Label ID="lblTitulo" runat="server" CssClass="display-4"  Font-Size="20px" ForeColor="black" Text="Titulo: "></asp:Label> 
            <asp:DropDownList ID="dropTitulo" runat="server" style="margin-left:24px;  width:215px" CssClass="btn btn-secondary secondary-toggle"></asp:DropDownList>
            <asp:Label ID="lblCantidadxTitulo" runat="server" Text="Ver entradas vendidas" style="margin-left:20px; border-radius:35px;" class="btn btn-primary" ></asp:Label><br /><br />
            <asp:Label ID="lblGenero" runat="server" CssClass="display-4"  Font-Size="20px" ForeColor="black" Text="Genero: "></asp:Label> 
            <asp:DropDownList ID="dropGenero" runat="server" style="margin-left:9px; height:35px; width:215px" CssClass="btn btn-secondary secondary-toggle"></asp:DropDownList>
            <asp:Label ID="lblCantidadxGenero" runat="server" Text="Ver entradas vendidas" style="margin-left:20px; border-radius:35px;" class="btn btn-primary"  ></asp:Label><br /><br />
            <asp:Label ID="lblSucursal" runat="server" CssClass="display-4"  Font-Size="20px" ForeColor="black" Text="Sucursal: "></asp:Label> 
            <asp:DropDownList ID="dropSucursal" runat="server" style="margin-left:3px; height:35px; width:215px" CssClass="btn btn-secondary secondary-toggle"></asp:DropDownList>
            <asp:Label ID="lblCantidadxSucursal" runat="server" Text="Ver entradas vendidas" style="margin-left:20px; border-radius:35px;" class="btn btn-primary" ></asp:Label><br /><br />
        </div>

        <div class="CalendarioHasta">
            <asp:Label ID="lblHasta" runat="server" CssClass="display-4" Font-Size="20px" ForeColor="black" Text="Hasta: "></asp:Label>
            <asp:Calendar ID="calHasta" runat="server" Width="30px"  Height="40px"  OnSelectionChanged="calHasta_SelectionChanged" SelectedDate="09/15/2020 15:01:54" ></asp:Calendar>
        </div>

      <br /><br />
    </form>
</body>
</html>
