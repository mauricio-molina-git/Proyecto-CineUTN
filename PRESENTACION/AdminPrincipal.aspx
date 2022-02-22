<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPrincipal.aspx.cs" Inherits="PRESENTACION.AdminPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
     <link rel="stylesheet" href="CSS/PrincipalAdmin.css">
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>

<body>
    <form id="form1" runat="server">

        <div class="Usuario">
            <asp:Label ID="lblUsuario" runat="server" Font-Size="16px" ForeColor="Black">USUARIO</asp:Label>
            <asp:LinkButton ID="btnLinkCerrarSesion" runat="server" CssClass="btn btn-warning" OnClick="btnLinkCerrarSesion_Click" Visible="False">Cerrar session</asp:LinkButton>
        </div>

        <div class="Titulo">
            <asp:Label ID="lblTitulo" runat="server" CssClass="display-4" Font-Size="45px" ForeColor="Black" Text="Menu principal"></asp:Label>
        </div>

        <div class="MenuAgregar">
            <asp:Button ID="btnAgregarPelicula" Width="180px" Style="border-radius:25px" CssClass="btn btn-primary" runat="server" Text="Agregar pelicula" OnClick="btnAgregarPelicula_Click" /><br /><br />     
            <asp:Button ID="btnAgregarUsuario"  Width="180px" Style="border-radius:25px" CssClass="btn btn-primary" runat="server" Text="Agregar usuario" OnClick="btnAgregarUsuario_Click" /><br /><br />  
            <asp:Button ID="btnAgregarGenero"   Width="180px" Style="border-radius:25px" CssClass="btn btn-primary" runat="server" Text="Agregar genero" OnClick="btnAgregarGenero_Click"/><br /><br />  
            <asp:Button ID="btnAgregarClasificacion"  Width="180px" Style="border-radius:25px" CssClass="btn btn-primary" runat="server" Text="Agregar clasificacion" OnClick="btnAgregarClasificacion_Click"/><br /><br />  
            <asp:Button ID="btnAgregarFuncion"  Width="180px" Style="border-radius:25px" CssClass="btn btn-primary" runat="server" Text="Agregar función" OnClick="btnAgregarFuncion_Click"/><br /><br />  

        </div>

        <div class="MenuModificar">
            <asp:Button ID="btnModificarPelicula" Width="180px" Style="border-radius:25px"  CssClass="btn btn-danger"  runat="server" Text="Modificar pelicula" OnClick="btnModificarPelicula_Click" /><br /><br />
            <asp:Button ID="btnModificarUsuario"  Width="180px" Style="border-radius:25px"  CssClass="btn btn-danger"  runat="server" Text="Modificar usuario" OnClick="btnModificarUsuario_Click" /><br /><br />
            <asp:Button ID="btnModificarGenero"   Width="180px" Style="border-radius:25px"  CssClass="btn btn-danger"  runat="server" Text="Modificar genero" OnClick="btnModificarGenero_Click" /><br /><br />
            <asp:Button ID="btnModificarClasificacion" Width="180px" Style="border-radius:25px"  CssClass="btn btn-danger" runat="server" Text="Modificar clasificación" OnClick="btnModificarClasificacion_Click" /><br /><br />
            <asp:Button ID="btnModificarPrecio" Width="180px" Style="border-radius:25px"  CssClass="btn btn-danger" runat="server" Text="Modificar Precios" OnClick="btnModificarPrecio_Click" /><br /><br />
            <asp:Button ID="btnReportes" Width="180px" Style="border-radius:25px"  CssClass="btn btn-secondary" runat="server" Text="Reportes" OnClick="btnReportes_Click" />
        </div>

    </form>
</body>
</html>
