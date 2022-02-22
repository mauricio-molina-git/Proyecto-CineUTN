<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PantallaDatosUsuario.aspx.cs" Inherits="PRESENTACION.PantallaDatosUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     
     <link rel="stylesheet" href="CSS/DatosUsuario.css"/>
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>
</head>
<body>
    <form id="form1" runat="server">

    <div class="logoCine">
        <asp:ImageButton ID="btnLogoCine" runat="server" ImageUrl="~/ImagenesBotones/logo mauri.png" style=" width:125px; height:115px; padding-left:10px; padding-top:10px" OnClick="btnLogoCine_Click1" />    
    </div>

    <div class="usuarioConectado">
        <asp:Image ID="btnUsuario" runat="server" Height="50px" Width="50px" style="margin-left:50px" ImageUrl="~/ImagenesBotones/usuario.png"/><br />
        <asp:Label ID="lblusuario" runat="server" style="margin-left:30px" ForeColor="White">Nombre y Apellido</asp:Label><br />
        <asp:DropDownList ID="ddpPerfil"  CssClass="btn btn-info dropdown-toggle dropdown-toggle-split"  data-toggle="dropdown"  aria-haspopup="true" aria-expanded="false"  runat="server" OnSelectedIndexChanged="ddpPerfil_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
    </div>

        <div class="FormularioDatos">     
            <asp:Image ID="imgUser" ImageUrl="~/ImagenesBotones/UserLogin.png" Height="100px" Width="100px" style="margin-left:90px" runat="server" /><br /><br />
            <asp:Label ID="lblTitulo" runat="server" CssClass="display-4" Text="Mis datos" Font-Size="19px" Style="margin-left:100px"></asp:Label><br />
            <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label><br />
            <asp:TextBox ID="txtNombre" runat="server" CssClass="btn btn-light" BorderColor="#E8E1DF" Enabled="False" ></asp:TextBox><br />    
            <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label><br />
            <asp:TextBox ID="txtApellido" runat="server" CssClass="btn btn-light" BorderColor="#E8E1DF" Enabled="False" ></asp:TextBox><br />
            <asp:Label ID="lblDni" runat="server" Text="DNI: "></asp:Label><br />
            <asp:TextBox ID="txtDni" runat="server" CssClass="btn btn-light" TextMode="Number" BorderColor="#E8E1DF" Enabled="False" ></asp:TextBox><br />
            <asp:Label ID="lblFecha" runat="server" Text="Fecha de nacimiento: "></asp:Label><br />
           
            <asp:Label ID="lbldia" runat="server" Text="Día:"></asp:Label>
            <asp:TextBox ID="txtDia" runat="server" TextMode="Number" CssClass="btn btn-light" Width="60px" BorderColor="#E8E1DF" Enabled="False" ></asp:TextBox>   
            
            <asp:Label ID="lblMes" runat="server" Text="Mes:"></asp:Label>
            <asp:TextBox ID="txtMes" runat="server" TextMode="Number" CssClass="btn btn-light" Width="60px" BorderColor="#E8E1DF" Enabled="False" ></asp:TextBox>   
            <asp:Label ID="lblAño" runat="server" Text="Año:"></asp:Label>
            <asp:TextBox ID="txtAño" runat="server" TextMode="Number" CssClass="btn btn-light" Width="60px" BorderColor="#E8E1DF" Enabled="False" ></asp:TextBox><br />    


            <asp:Label ID="lblTelefono" runat="server" Text="Telefono: "></asp:Label><br />
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="btn btn-light" BorderColor="#E8E1DF" Enabled="False"></asp:TextBox><br />
            <asp:Label ID="lblCorreo" runat="server" Text="Correo electronico: "></asp:Label><br />
            <asp:TextBox ID="txtEmail" runat="server" CssClass="btn btn-light" BorderColor="#E8E1DF" Enabled="False"></asp:TextBox><br /><br />

            <asp:Button ID="btnEditar" runat="server" CssClass="btn btn-primary" OnClick="btnEditar_Click" Text="Editar" />
            <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" OnClick="btnCancelar_Click" Text="Cancelar" Visible="False" />          
        </div>

        <div class="Alerta">
            <asp:Label ID="lblMensaje" CssClass="alert alert-primary" Width="180px" runat="server" Visible="False"></asp:Label>
            <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="Aceptar" CssClass="btn btn-primary" Visible="False" />    
        </div>

    </form>
</body>
</html>
