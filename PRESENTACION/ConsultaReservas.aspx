<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaReservas.aspx.cs" Inherits="PRESENTACION.ConsultaReservas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>    
    <title></title>
    <link href="CSS/Reservas.css" rel="stylesheet" type="text/css" />
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>

</head>
<body>
    <form id="form1" runat="server">

    <div class="logoCine">
        <asp:ImageButton ID="btnLogoCine" runat="server" ImageUrl="~/ImagenesBotones/logo mauri.png" style=" width:125px; height:115px; padding-left:10px; padding-top:10px" OnClick="btnLogoCine_Click1" />    
    </div>

    <div class="usuarioConectado">
        <asp:ImageButton ID="btnUsuario" runat="server" Height="50px" Width="50px" style="margin-left:50px" ImageUrl="~/ImagenesBotones/usuario.png" OnClick="btnUsuario_Click1" /><br />
        <asp:Label ID="lblusuario" runat="server" style="margin-left:30px" ForeColor="White">Nombre y Apellido</asp:Label><br />
        <asp:DropDownList ID="ddpPerfil" CssClass="btn btn-info dropdown-toggle dropdown-toggle-split"  data-toggle="dropdown"  aria-haspopup="true" aria-expanded="false"  runat="server" AutoPostBack="True" Visible="False" OnSelectedIndexChanged="ddpPerfil_SelectedIndexChanged"></asp:DropDownList>
    </div>

    <div class="Titulo">
        <asp:Label ID="lblTitulo" runat="server" CssClass="display-4" Font-Size="50px" ForeColor="White" Text="Mis compras:"></asp:Label>
    </div>
     
    <br />

    <div class="Compras">
        <asp:ListBox ID="lstReservas" style="width:700px; border-radius:10px; border-color:gray; background-color:lightblue" runat="server" Height="385px" Width="570px"></asp:ListBox>
    </div>


    </form>
</body>
</html>
