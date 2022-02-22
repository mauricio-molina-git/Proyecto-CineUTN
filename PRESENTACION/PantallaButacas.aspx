<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PantallaButacas.aspx.cs" Inherits="PRESENTACION.PantallaButacas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <link rel="stylesheet" href="CSS/SeleccionButacas.css"/>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>

</head>
<body>
    <form id="form1" runat="server">
        
        <div class ="BotonesPrincipales">
            <asp:ImageButton ID="btnBack" ImageUrl="~/ImagenesBotones/atrasLogin.png" style="width:90px; height:90px; padding-left:10px; padding-top:10px" runat="server" OnClick="btnBack_Click" />
            <asp:ImageButton ID="btnLogoCine" runat="server" ImageUrl="~/ImagenesBotones/logo mauri.png"  style="width:115px; height:105px; padding-left:10px; padding-top:10px" OnClick="btnLogoCine_Click1" />   
        </div>

        <div class="usuarioConectado">
            <asp:ImageButton ID="btnUsuario" style="margin-left:50px" runat="server" ImageUrl="~/ImagenesBotones/usuario.png" Height="50px" Width="50px" OnClick="btnUsuario_Click2" /><br />
            <asp:Label ID="lblusuario" runat="server" style="margin-left:30px" ForeColor="White">Nombre y Apellido</asp:Label><br />
            <asp:DropDownList ID="ddpPerfil" CssClass="btn btn-info dropdown-toggle dropdown-toggle-split"  data-toggle="dropdown"  aria-haspopup="true" aria-expanded="false"  runat="server" AutoPostBack="True" Visible="False" OnSelectedIndexChanged="ddpPerfil_SelectedIndexChanged"></asp:DropDownList>
       </div>

        <div class="Pantalla">
            <asp:Label ID="lblTitulo" runat="server" CssClass="display-4" Font-Size="20px" ForeColor="black" Text="Seleccione sus butacas:"></asp:Label><br />          
            <asp:Image ID="imgPantalla" runat="server" ImageUrl="~/ImagenesBotones/PantallaButacas.jpg" Height="122px" Width="545px" style="margin-left: 0px" />
        </div>

        <div class="ResumenFuncion">
            <asp:Label ID="lblResumen" CssClass="display-4" Font-Size="23px" ForeColor="White" runat="server" Text="Resumen de función: "></asp:Label><br />
            <asp:Label ID="lblPelicula" runat="server"></asp:Label><br />
            <asp:Label ID="lblFormato" runat="server"></asp:Label><br />
            <asp:Label ID="lblFecha" runat="server"></asp:Label><br />
            <asp:Label ID="lblHora" runat="server"></asp:Label><br />
            <asp:Label ID="lblDireccion" runat="server"></asp:Label><br />
            <asp:Label ID="lblSucursal" runat="server"></asp:Label><br />
            <asp:Label ID="lblSala" runat="server"></asp:Label><br />
        </div>

        <div class="BotonComprar">
            <asp:Button ID="btnComprar" runat="server" CssClass="btn btn-danger" OnClick="btnComprar_Click1" Text="Comprar" Enabled="False" /><br />
        </div>

    <div class="Butacas">
        <asp:ImageButton ID="ImageButton1" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton1_Click" />
        <asp:ImageButton ID="ImageButton2" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton2_Click" />
        <asp:ImageButton ID="ImageButton3" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton3_Click" />
        <asp:ImageButton ID="ImageButton4" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton4_Click" />
        <asp:ImageButton ID="ImageButton5" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton5_Click" />
        <asp:ImageButton ID="ImageButton6" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton6_Click" />
        <asp:ImageButton ID="ImageButton7" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton7_Click" />
        <asp:ImageButton ID="ImageButton8" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton8_Click" />
        <asp:ImageButton ID="ImageButton9" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton9_Click" />
        <asp:ImageButton ID="ImageButton10" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton10_Click" />
        <br />
&nbsp;&nbsp;&nbsp; A1 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; A2
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;A3 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; A4 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; A5 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; A6
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; A7
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;A8
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; A9
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; A10
        <br />
        <asp:ImageButton ID="ImageButton11" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton11_Click" />
        <asp:ImageButton ID="ImageButton12" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton12_Click" />
        <asp:ImageButton ID="ImageButton13" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton13_Click" />
        <asp:ImageButton ID="ImageButton14" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton14_Click" />
        <asp:ImageButton ID="ImageButton15" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton15_Click" />
        <asp:ImageButton ID="ImageButton16" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton16_Click" />
        <asp:ImageButton ID="ImageButton17" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton17_Click" />
        <asp:ImageButton ID="ImageButton18" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton18_Click" />
        <asp:ImageButton ID="ImageButton19" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton19_Click" />
        <asp:ImageButton ID="ImageButton20" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton20_Click" />
        <br />
        &nbsp;&nbsp;&nbsp; B1 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; B2
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;B3 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; B4 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; B5 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; B6
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; B7
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;B8
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; B9
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; B10
        <br />
        <asp:ImageButton ID="ImageButton21" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton21_Click" />
        <asp:ImageButton ID="ImageButton22" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton22_Click" />
        <asp:ImageButton ID="ImageButton23" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton23_Click" />
        <asp:ImageButton ID="ImageButton24" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton24_Click" />
        <asp:ImageButton ID="ImageButton25" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton25_Click" />
        <asp:ImageButton ID="ImageButton26" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton26_Click" />
        <asp:ImageButton ID="ImageButton27" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton27_Click" />
        <asp:ImageButton ID="ImageButton28" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton28_Click" />
        <asp:ImageButton ID="ImageButton29" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton29_Click" />
        <asp:ImageButton ID="ImageButton30" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton30_Click" />
        <br />
        &nbsp;&nbsp;&nbsp; C1 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; C2
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;C3 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; C4 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; C5 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; C6
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; C7
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;C8
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; C9
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; C10
        <br />
        <asp:ImageButton ID="ImageButton31" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton31_Click" />
        <asp:ImageButton ID="ImageButton32" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton32_Click" />
        <asp:ImageButton ID="ImageButton33" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton33_Click" />
        <asp:ImageButton ID="ImageButton34" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton34_Click" />
        <asp:ImageButton ID="ImageButton35" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton35_Click" />
        <asp:ImageButton ID="ImageButton36" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton36_Click" />
        <asp:ImageButton ID="ImageButton37" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton37_Click" />
        <asp:ImageButton ID="ImageButton38" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton38_Click" />
        <asp:ImageButton ID="ImageButton39" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton39_Click" />
        <asp:ImageButton ID="ImageButton40" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton40_Click" />
        <br />
        &nbsp;&nbsp;&nbsp; D1 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; D2
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D3 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; D4 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; D5 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; D6
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; D7
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;D8
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; D9
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; D10
        <br />
        <asp:ImageButton ID="ImageButton41" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton41_Click" />
        <asp:ImageButton ID="ImageButton42" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton42_Click" />
        <asp:ImageButton ID="ImageButton43" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton43_Click" />
        <asp:ImageButton ID="ImageButton44" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton44_Click" />
        <asp:ImageButton ID="ImageButton45" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton45_Click" />
        <asp:ImageButton ID="ImageButton46" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton46_Click" />
        <asp:ImageButton ID="ImageButton47" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton47_Click" />
        <asp:ImageButton ID="ImageButton48" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton48_Click" />
        <asp:ImageButton ID="ImageButton49" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton49_Click" />
        <asp:ImageButton ID="ImageButton50" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton50_Click" />
        <br />
        &nbsp;&nbsp;&nbsp; E1 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; E2
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; E3 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;E4 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; E5 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; E6
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; E7
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;E8
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; E9
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; E10
        <br />
        <asp:ImageButton ID="ImageButton51" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton51_Click" />
        <asp:ImageButton ID="ImageButton52" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton52_Click" />
        <asp:ImageButton ID="ImageButton53" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton53_Click" />
        <asp:ImageButton ID="ImageButton54" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton54_Click" />
        <asp:ImageButton ID="ImageButton55" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton55_Click" />
        <asp:ImageButton ID="ImageButton56" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton56_Click" />
        <asp:ImageButton ID="ImageButton57" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton57_Click" />
        <asp:ImageButton ID="ImageButton58" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton58_Click" />
        <asp:ImageButton ID="ImageButton59" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton59_Click" />
        <asp:ImageButton ID="ImageButton60" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton60_Click" />
        <br />
        &nbsp;&nbsp;&nbsp; F1 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; F2
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; F3 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; F4 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; F5 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; F6
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; F7
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; F8
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; F9
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; F10
        <br />
        <asp:ImageButton ID="ImageButton61" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton61_Click" />
        <asp:ImageButton ID="ImageButton62" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton62_Click" />
        <asp:ImageButton ID="ImageButton63" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton63_Click" />
        <asp:ImageButton ID="ImageButton64" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton64_Click" />
        <asp:ImageButton ID="ImageButton65" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton65_Click" />
        <asp:ImageButton ID="ImageButton66" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="52px" OnClick="ImageButton66_Click" />
        <asp:ImageButton ID="ImageButton67" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton67_Click" />
        <asp:ImageButton ID="ImageButton68" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton68_Click" />
        <asp:ImageButton ID="ImageButton69" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton69_Click" />
        <asp:ImageButton ID="ImageButton70" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton70_Click" />
        <br />
        &nbsp;&nbsp;&nbsp; G1 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; G2
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;G3 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; G4 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; G5 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; G6
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; G7
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;G8
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; G9
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; G10
        <br />
        <asp:ImageButton ID="ImageButton71" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton71_Click" />
        <asp:ImageButton ID="ImageButton72" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton72_Click" />
        <asp:ImageButton ID="ImageButton73" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton73_Click" />
        <asp:ImageButton ID="ImageButton74" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton74_Click" />
        <asp:ImageButton ID="ImageButton75" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton75_Click" />
        <asp:ImageButton ID="ImageButton76" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton76_Click" />
        <asp:ImageButton ID="ImageButton77" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton77_Click" />
        <asp:ImageButton ID="ImageButton78" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton78_Click" />
        <asp:ImageButton ID="ImageButton79" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton79_Click" />
        <asp:ImageButton ID="ImageButton80" runat="server" Height="50px" ImageUrl="~/ImagenesBotones/butacas.png" Width="50px" OnClick="ImageButton80_Click" />
        <br />
        &nbsp;&nbsp;&nbsp; H1 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; H2 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;H3 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; H4 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;H5 &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; H6
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; H7
        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;H8
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; H9
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; H10
        <br />
        <br />
        <asp:Button ID="btnAnterior" runat="server" CssClass="btn btn-danger" OnClick="btnAnterior_Click" Text="Anterior" style="margin-left: 195px" />
        <asp:Button ID="btnSiguiente" runat="server" CssClass="btn btn-warning" OnClick="btnSiguiente_Click" Text="Siguiente" />  
    </div>
        
    </form>
</body>
</html>
