<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PantallaDetallesPeliculas.aspx.cs" Inherits="CineUtn.DetalleReserva" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

     <link rel="stylesheet" href="CSS/DetallePelicula.css"/>
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>

</head>
<body>

    <form id="form1" runat="server">

       <div class="logoCine">           
            <asp:ImageButton ID="btnLogoCine" runat="server" ImageUrl="~/ImagenesBotones/logo mauri.png" OnClick="btnLogoPrincipal_Click" style="width:125px; height:115px; padding-left:10px; padding-top:10px" />  
        </div>

       <div class="usuarioConectado">
           <asp:ImageButton ID="btnUsuario" runat="server" style="margin-left:50px" ImageUrl="~/ImagenesBotones/usuario.png" OnClick="btnUsuario_Click" /><br />
           <asp:Label ID="lblusuario" runat="server" style="margin-left:30px" ForeColor="White">Nombre y Apellido</asp:Label><br />
           <asp:DropDownList ID="ddpPerfil" CssClass="btn btn-info dropdown-toggle dropdown-toggle-split"  data-toggle="dropdown"  aria-haspopup="true" aria-expanded="false"  runat="server" AutoPostBack="True" Visible="False" OnSelectedIndexChanged="ddpPerfil_SelectedIndexChanged"></asp:DropDownList>
       </div>

        <div class="Comprar">
            <asp:Label ID="lblSucursal" runat="server" CssClass="display-4" Style="font-size:25px;" ForeColor="White" Text="Sucursales:"></asp:Label>
            <asp:DropDownList ID="lstSucursales" runat="server" AutoPostBack="True" Height="30px" Width="330px" Style="padding-top:1px" CssClass="btn btn-secondary dropdown-toggle" ></asp:DropDownList><br />
            <asp:Label ID="lblFunciones" runat="server" CssClass="display-4" Style="font-size:25px;" ForeColor="White" Text="Funciones:"></asp:Label>
            <asp:Button ID="btnFunciones" runat="server" Text="Ver funciones disponibles" CssClass="btn btn-outline-warning" style="margin-left:4px; line-height:5px; " Height="35px" Width="210px" OnClick="btnFunciones_Click" />
        </div>

        <div class="Alerta">            
              <asp:Label ID="lblMensaje" runat="server" class="alert alert-primary" role="alert" Text="¡Debe iniciar sesión para ver todas las funciones disponibles!" Height="80px" Width="410px" style="border-radius:20px" Visible="False"></asp:Label>
              <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-warning" Visible="false" Text="Aceptar" OnClick="btnAceptar_Click" />
              <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-warning" style="width:130px" OnClick="btnLogin_Click" Text="Iniciar sesión" Visible="False" Width="70px" />
        </div>

        <div class="FichaPelicula">
            <asp:Label ID="lblNombrePelicula" runat="server" style="margin-left:15px;" CssClass="display-4" ForeColor="White" Font-Size="30px"></asp:Label><br /><br />
            <asp:ImageButton ID="imgDetalle" runat="server" Height="320px" Width="300px" style="border-radius:0px; float:left" />
            <asp:Label ID="lblGenero" runat="server" CssClass="display-4" style="margin-left:10px;" ForeColor="White" Font-Size="17px" >Genero:  </asp:Label><br />
            <asp:Label ID="lblClasificacion" runat="server" CssClass="display-4" style="margin-left:10px;" ForeColor="White" Font-Size="17px">Clasificacion: </asp:Label><br />
            <asp:Label ID="lblDuracion" runat="server" CssClass="display-4" ForeColor="White" Font-Size="17px" style="margin-left:10px;" >Duracion:  </asp:Label><br />
            <asp:Label ID="lblFormato" runat="server" CssClass="display-4" ForeColor="White" Font-Size="17px" style="margin-left:10px;" >Formato:  </asp:Label><br />
            <asp:Label ID="lblPrecio" runat="server" CssClass="display-4" ForeColor="White" Font-Size="17px" style="margin-left:10px;" Text="Precio: $"></asp:Label>

            <asp:Label ID="lblSinopsis" runat="server" CssClass="display-4" ForeColor="White" Font-Size="15px " BorderStyle="Groove" style="border-radius:15px; margin-top:15px; margin-right:5px; padding-top:3px; padding-bottom:3px; padding-left:10px; padding-right:10px; text-align:justify" ></asp:Label><br />
        </div>
    </form>
    
</body>
</html>
