<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PantallaPrincipal.aspx.cs" Inherits="PRESENTACION.PantallaPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

     <link rel="stylesheet" href="CSS/Principal.css"/>
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>

</head>
<body>
    <form id="form1" runat="server">

     <div class="logoCine">
        <asp:ImageButton ID="btnLogoCine" runat="server" ImageUrl="~/ImagenesBotones/logo mauri.png" style="width:125px; height:115px; padding-left:10px; padding-top:10px" />    
      </div>

    <div class="usuarioConectado">
        <asp:ImageButton ID="btnUsuario" runat="server" style="margin-left:50px" ImageUrl="~/ImagenesBotones/usuario.png" OnClick="btnUsuario_Click" /><br />
        <asp:Label ID="lblusuario" runat="server" style="margin-left:30px" ForeColor="White">Nombre y Apellido</asp:Label><br />
        <asp:DropDownList ID="ddpPerfil" CssClass="btn btn-info dropdown-toggle dropdown-toggle-split"  data-toggle="dropdown"  aria-haspopup="true" aria-expanded="false"  runat="server" AutoPostBack="True" Visible="False" OnSelectedIndexChanged="ddpPerfil_SelectedIndexChanged"></asp:DropDownList>
    </div>
                         
    <div class="Peliculas">
        <br />
        <asp:Image ID="titulo2D" ImageUrl="~/ImagenesBotones/Titulo2D.png" style="height:70px; width:240px; margin-left:130px" runat="server" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label" Width="167px" Font-Bold="True" Font-Names="Arial Rounded MT Bold" Font-Size="12pt" ForeColor="White" style="margin-left: 60px"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Label" Width="166px" Font-Bold="True" Font-Names="Arial Rounded MT Bold" Font-Size="12pt" ForeColor="White" Height="20px" style="margin-left: 69px"></asp:Label> 
        <br />
        <asp:ImageButton ID="ImageButton1" runat="server" Height="250px" Width="250px" OnClick="ImageButton1_Click" style="border-radius:35px; border-style:groove"/>
        <asp:ImageButton ID="ImageButton2" runat="server" Height="250px" Width="250px" OnClick="ImageButton2_Click" style="border-radius:35px; border-style:groove"/>      
        <br />
        <asp:Label ID="Label3" runat="server" Text="Label" Width="167px" Font-Bold="True" Font-Names="Arial Rounded MT Bold" Font-Size="12pt" ForeColor="White" style="margin-left: 55px"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="Label" Width="166px" Font-Bold="True" Font-Names="Arial Rounded MT Bold" Font-Size="12pt" ForeColor="White" Height="20px" style="margin-left: 100px"></asp:Label>
        <br />
        <asp:ImageButton ID="ImageButton3" runat="server" Height="250px" Width="250px" OnClick="ImageButton3_Click" style="border-radius:35px; border-style:groove" />
        <asp:ImageButton ID="ImageButton4" runat="server" Height="250px" Width="250px" OnClick="ImageButton4_Click" style="border-radius:35px; border-style:groove" /><br /><br />
        
        <asp:Button ID="btnAnterior2D" runat="server" OnClick="btnAnterior_Click" Text="Anterior" style="margin-left: 181px" CssClass ="btn btn-primary" />
        <asp:Button ID="btnSiguiente2D" runat="server" OnClick="btnSiguiente_Click" Text="Siguiente" CssClass ="btn btn-danger"/>
        <br />
        <br />
        <br />
        <asp:Image ID="Titulo3D" ImageUrl="~/ImagenesBotones/Titulo3D.png" style="height:70px; width:240px; margin-left:130px" runat="server" />

        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Label" Width="167px" Font-Bold="True" Font-Names="Arial Rounded MT Bold" Font-Size="12pt" ForeColor="White" style="margin-left: 60px"></asp:Label>
        <asp:Label ID="Label6" runat="server" Text="Label" Width="166px" Font-Bold="True" Font-Names="Arial Rounded MT Bold" Font-Size="12pt" ForeColor="White" Height="20px" style="margin-left: 105px"></asp:Label> 
        <br />
        <asp:ImageButton ID="ImageButton13D" runat="server" Height="250px" Width="250px" OnClick="ImageButton13D_Click" style="border-radius:35px; border-style:groove"/>   
        <asp:ImageButton ID="ImageButton23D" runat="server" Height="250px" Width="250px" OnClick="ImageButton23D_Click" style="border-radius:35px; border-style:groove"/>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Label" Width="167px" Font-Bold="True" Font-Names="Arial Rounded MT Bold" Font-Size="12pt" ForeColor="White" style="margin-left: 80px"></asp:Label>
        <asp:Label ID="Label8" runat="server" Text="Label" Width="166px" Font-Bold="True" Font-Names="Arial Rounded MT Bold" Font-Size="12pt" ForeColor="White" Height="20px" style="margin-left: 72px"></asp:Label> 
        <br />
        <asp:ImageButton ID="ImageButton33D" runat="server" Height="250px" Width="250px" OnClick="ImageButton33D_Click" style="border-radius:35px; border-style:groove"/>
        <asp:ImageButton ID="ImageButton43D" runat="server" Height="250px" Width="250px" OnClick="ImageButton43D_Click" style="border-radius:35px; border-style:groove"/><br /><br />
           
        <asp:Button ID="btnAnterior3D" runat="server" OnClick="btnAnterior3D_Click" Text="Anterior" style="margin-left: 181px" CssClass ="btn btn-primary" />
        <asp:Button ID="btnSiguiente3D" runat="server" OnClick="btnSiguiente3D_Click" Text="Siguiente"  CssClass ="btn btn-danger" /><br /><br />
    </div>

    </form>
</body>
</html>
