<html>
<style type="text/css">
body {
    background-image: url(Fondo.png);
    background-repeat: no-repeat;
}
</style>
<link href="LED/stylesheet.css" rel="stylesheet" type="text/css">
<title>Duco Estadisticas</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="icon" href="https://wallet.duinocoin.com/assets/duco.svg">
	<?php 
$username = "root"; 
$password = "vb3507042"; 
$database = "estadisticas"; 
$fechaActual = date('d/m/Y');
$mysqli = new mysqli("localhost", $username, $password, $database); 
//$query = "SELECT * FROM `horas` WHERE Fecha='".$fechaActual."'";
	$query = "SELECT * FROM `horas` WHERE Fecha='25/04/2022'";
?>        
<body>
<table width="1272" border="0">
  <tbody>
    <tr>
      <td width="232" rowspan="3" valign="top"><table width="230" height="656" border="0">
  <tbody>
    <tr>
      <td height="33" colspan="2" align="right" valign="middle"  style="font-style: normal; font-family: LED; font-size: 24px;">11233.122336544459</td>
    </tr>
    <tr>
      <td height="34" colspan="2" align="right" valign="middle"  style="font-style: normal; font-family: LED; font-size: 24px;">&nbsp;</td>
    </tr>
    <tr>
      <td height="53" colspan="2" align="right" valign="top" style="font-size: 24px; font-family: LED;">0.0000145$</td>
    </tr>
    <tr>
      <td height="56" colspan="2" align="right" valign="top" style="font-family: LED; font-size: 24px;">1.051848451548484$</td>
    </tr>
    <tr>
      <td height="85" colspan="2" align="right" valign="top"><h1><strong style="font-weight: bold; color: #FF9600; font-size: 50px; font-family: LED;">0.0000&euro;</strong></h1></td>
    </tr>
    <tr>
      <td width="86" height="23"align="right"><strong style="font-weight: bold; color: #FF9600; font-family: LED; font-size: 24px;">48.25</strong></td>
      <td width="121" height="23" align="left">diario(0.0004)$</td>
    </tr>
    <tr>
      <td height="33"align="right"><strong style="font-weight: bold; color: #FF9600; font-family: LED; font-size: 24px;">1450</strong></td>
      <td height="33"lign="left">Mensual(0.120)$</td>
    </tr>
    <tr>
      <td height="23" colspan="2">&nbsp;</td>
    </tr>
    <tr>
      <td height="45" align="right" style="font-size: 24px; font-weight: bold;">Mineros:</td>
      <td height="45" align="center" style="font-family: LED; font-size: 36px;">00/50</td>
    </tr>
    <tr>
      <td height="35" align="right" style="font-size: 24px; font-weight: bold;">Hases:</td>
      <td height="35" align="center" style="font-size: 24px; color: #000DFF;"> <span style="font-family: LED">235</span> Kh/s</td>
    </tr>
    <tr>
      <td height="51" colspan="2" valign="bottom" style="font-size: 24px; font-weight: bold;">Apuesta:<span style="font-family: LED; color: #FF9600; font-weight: bold;"> 2500</span></td>
    </tr>
    <tr>
      <td height="23" colspan="2" style="font-size: 24px; font-weight: bold;">Finaliza:<span style="font-size: 16px"> 10/10/2015 2:00:00</span></td>
    </tr>
    <tr>
      <td height="23" colspan="2" style="font-size: 24px; font-weight: bold;">Premio: <span style="color: #FF9600; font-family: LED;">50.25</span></td>
    </tr>
    <tr>
      <td height="27" colspan="2" style="font-size: 24px"><span style="font-weight: bold">Restante:</span> <span style="font-size: 16px">14 d&iacute;as, 05:36h.</span></td>
    </tr>
    <tr>
      
    </tr>
    <tr>
      <td height="44" align="center"><span style="font-size: 36px; font-weight: bold; color: #0AFF00;">30&ordm;   </span></td>
      <td height="44" align="center"><span style="font-size: 36px; font-weight: bold; color: #1100F7;">30%</span></td>
    </tr>
  </tbody>
</table></td>
      <td width="261" rowspan="3" valign="top"><?
	echo '<table border="1" width="500" cellspacing="2" cellpadding="2">
      <tr>
      <th colspan="5" scope="col">Balance por Hora</th>
    </tr>
    <tr>
      <th width="62" scope="row"><strong>Hora</strong></th>
      <td width="71" align="center" scope="row"><strong>Balance</strong></td>
      <td width="71" align="center"><strong>Precio</strong></td>
      <td width="89" align="center"><strong>Transaciones</strong></td>
      <td width="73" align="center"><strong>Ganado</strong></td>
    </tr>';

if ($result = $mysqli->query($query)) {
    while ($row = $result->fetch_assoc()) {
        echo '<tr> 
				  <td align="center">00:00</td>
                  <td align="center">'.$row["Hora00"].'</td> 
                  <td align="center">'.$row["Precio00"].'</td> 
                  <td align="center">'.$row["Transaciones00"].'</td> 
                  <td align="center">'.$row["Diferencia00"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">01:00</td>
                  <td align="center">'.$row["Hora01"].'</td> 
                  <td align="center">'.$row["Precio01"].'</td> 
                  <td align="center">'.$row["Transaciones01"].'</td> 
                  <td align="center">'.$row["Diferencia01"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">02:00</td>
                  <td align="center">'.$row["Hora02"].'</td> 
                  <td align="center">'.$row["Precio02"].'</td> 
                  <td align="center">'.$row["Transaciones02"].'</td> 
                  <td align="center">'.$row["Diferencia02"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">03:00</td>
                  <td align="center">'.$row["Hora03"].'</td> 
                  <td align="center">'.$row["Precio03"].'</td> 
                  <td align="center">'.$row["Transaciones03"].'</td> 
                  <td align="center">'.$row["Diferencia03"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">04:00</td>
                  <td align="center">'.$row["Hora04"].'</td> 
                  <td align="center">'.$row["Precio04"].'</td> 
                  <td align="center">'.$row["Transaciones04"].'</td> 
                  <td align="center">'.$row["Diferencia04"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">05:00</td>
                  <td align="center">'.$row["Hora05"].'</td> 
                  <td align="center">'.$row["Precio05"].'</td> 
                  <td align="center">'.$row["Transaciones05"].'</td> 
                  <td align="center">'.$row["Diferencia05"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">06:00</td>
                  <td align="center">'.$row["Hora06"].'</td> 
                  <td align="center">'.$row["Precio06"].'</td> 
                  <td align="center">'.$row["Transaciones06"].'</td> 
                  <td align="center">'.$row["Diferencia06"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">07:00</td>
                  <td align="center">'.$row["Hora07"].'</td> 
                  <td align="center">'.$row["Precio07"].'</td> 
                  <td align="center">'.$row["Transaciones07"].'</td> 
                  <td align="center">'.$row["Diferencia07"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">08:00</td>
                  <td align="center">'.$row["Hora08"].'</td> 
                  <td align="center">'.$row["Precio08"].'</td> 
                  <td align="center">'.$row["Transaciones08"].'</td> 
                  <td align="center">'.$row["Diferencia08"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">09:00</td>
                  <td align="center">'.$row["Hora09"].'</td> 
                  <td align="center">'.$row["Precio09"].'</td> 
                  <td align="center">'.$row["Transaciones09"].'</td> 
                  <td align="center">'.$row["Diferencia09"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">10:00</td>
                  <td align="center">'.$row["Hora10"].'</td> 
                  <td align="center">'.$row["Precio10"].'</td> 
                  <td align="center">'.$row["Transaciones10"].'</td> 
                  <td align="center">'.$row["Diferencia10"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">11:00</td>
                  <td align="center">'.$row["Hora11"].'</td> 
                  <td align="center">'.$row["Precio11"].'</td> 
                  <td align="center">'.$row["Transaciones11"].'</td> 
                  <td align="center">'.$row["Diferencia11"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">12:00</td>
                  <td align="center">'.$row["Hora12"].'</td> 
                  <td align="center">'.$row["Precio12"].'</td> 
                  <td align="center">'.$row["Transaciones12"].'</td> 
                  <td align="center">'.$row["Diferencia12"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">13:00</td>
                  <td align="center">'.$row["Hora13"].'</td> 
                  <td align="center">'.$row["Precio13"].'</td> 
                  <td align="center">'.$row["Transaciones13"].'</td> 
                  <td align="center">'.$row["Diferencia13"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">14:00</td>
                  <td align="center">'.$row["Hora14"].'</td> 
                  <td align="center">'.$row["Precio14"].'</td> 
                  <td align="center">'.$row["Transaciones14"].'</td> 
                  <td align="center">'.$row["Diferencia14"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">15:00</td>
                  <td align="center">'.$row["Hora15"].'</td> 
                  <td align="center">'.$row["Precio15"].'</td> 
                  <td align="center">'.$row["Transaciones15"].'</td> 
                  <td align="center">'.$row["Diferencia15"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">16:00</td>
                  <td align="center">'.$row["Hora16"].'</td> 
                  <td align="center">'.$row["Precio16"].'</td> 
                  <td align="center">'.$row["Transaciones16"].'</td> 
                  <td align="center">'.$row["Diferencia16"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">17:00</td>
                  <td align="center">'.$row["Hora17"].'</td> 
                  <td align="center">'.$row["Precio17"].'</td> 
                  <td align="center">'.$row["Transaciones17"].'</td> 
                  <td align="center">'.$row["Diferencia17"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">18:00</td>
                  <td align="center">'.$row["Hora18"].'</td> 
                  <td align="center">'.$row["Precio18"].'</td> 
                  <td align="center">'.$row["Transaciones18"].'</td> 
                  <td align="center">'.$row["Diferencia18"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">19:00</td>
                  <td align="center">'.$row["Hora19"].'</td> 
                  <td align="center">'.$row["Precio19"].'</td> 
                  <td align="center">'.$row["Transaciones19"].'</td> 
                  <td align="center">'.$row["Diferencia19"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">20:00</td>
                  <td align="center">'.$row["Hora20"].'</td> 
                  <td align="center">'.$row["Precio20"].'</td> 
                  <td align="center">'.$row["Transaciones20"].'</td> 
                  <td align="center">'.$row["Diferencia20"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">21:00</td>
                  <td align="center">'.$row["Hora21"].'</td> 
                  <td align="center">'.$row["Precio21"].'</td> 
                  <td align="center">'.$row["Transaciones21"].'</td> 
                  <td align="center">'.$row["Diferencia21"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">22:00</td>
                  <td align="center">'.$row["Hora22"].'</td> 
                  <td align="center">'.$row["Precio22"].'</td> 
                  <td align="center">'.$row["Transaciones22"].'</td> 
                  <td align="center">'.$row["Diferencia22"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">23:00</td>
                  <td align="center">'.$row["Hora23"].'</td> 
                  <td align="center">'.$row["Precio23"].'</td> 
                  <td align="center">'.$row["Transaciones23"].'</td> 
                  <td align="center">'.$row["Diferencia23"].'</td> 
              </tr>';
		echo '<tr>
      			<th colspan="2" scope="row" align="right">Total diario:</th>
      			<td align="center">'.$row["PrecioMedio"].'</td>
      			<td align="center">0</td>
				<td align="center">'.$row["DucosTotal"].'</td>
   </tbody>
</table></td>';
    }
    $result->free();
} 
?></td>
		<td width="350" rowspan="3" valign="top"><?
			$query = "SELECT * FROM `mes` WHERE Fecha='25/04/2022'";
	echo '<table border="1" width="500" cellspacing="2" cellpadding="2">
      <tr>
      <th colspan="5" scope="col">Balance por Mes</th>
    </tr>
    <tr>
      <th width="62" scope="row"><strong>Dia</strong></th>
      <td width="71" align="center" scope="row"><strong>Balance</strong></td>
      <td width="71" align="center"><strong>Precio</strong></td>
      <td width="89" align="center"><strong>Transaciones</strong></td>
      <td width="73" align="center"><strong>Ganado</strong></td>
    </tr>';

if ($result = $mysqli->query($query)) {
    while ($row = $result->fetch_assoc()) {
       		echo '<tr> 
				  <td align="center">01</td>
                  <td align="center">'.$row["Dia01"].'</td> 
                  <td align="center">'.$row["Precio01"].'</td> 
                  <td align="center">'.$row["Transaciones01"].'</td> 
                  <td align="center">'.$row["Diferencia01"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">02</td>
                  <td align="center">'.$row["Dia02"].'</td> 
                  <td align="center">'.$row["Precio02"].'</td> 
                  <td align="center">'.$row["Transaciones02"].'</td> 
                  <td align="center">'.$row["Diferencia02"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">03</td>
                  <td align="center">'.$row["Dia03"].'</td> 
                  <td align="center">'.$row["Precio03"].'</td> 
                  <td align="center">'.$row["Transaciones03"].'</td> 
                  <td align="center">'.$row["Diferencia03"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">04</td>
                  <td align="center">'.$row["Dia04"].'</td> 
                  <td align="center">'.$row["Precio04"].'</td> 
                  <td align="center">'.$row["Transaciones04"].'</td> 
                  <td align="center">'.$row["Diferencia04"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">05</td>
                  <td align="center">'.$row["Dia05"].'</td> 
                  <td align="center">'.$row["Precio05"].'</td> 
                  <td align="center">'.$row["Transaciones05"].'</td> 
                  <td align="center">'.$row["Diferencia05"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">06</td>
                  <td align="center">'.$row["Dia06"].'</td> 
                  <td align="center">'.$row["Precio06"].'</td> 
                  <td align="center">'.$row["Transaciones06"].'</td> 
                  <td align="center">'.$row["Diferencia06"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">07</td>
                  <td align="center">'.$row["Dia07"].'</td> 
                  <td align="center">'.$row["Precio07"].'</td> 
                  <td align="center">'.$row["Transaciones07"].'</td> 
                  <td align="center">'.$row["Diferencia07"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">08</td>
                  <td align="center">'.$row["Dia08"].'</td> 
                  <td align="center">'.$row["Precio08"].'</td> 
                  <td align="center">'.$row["Transaciones08"].'</td> 
                  <td align="center">'.$row["Diferencia08"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">09</td>
                  <td align="center">'.$row["Dia09"].'</td> 
                  <td align="center">'.$row["Precio09"].'</td> 
                  <td align="center">'.$row["Transaciones09"].'</td> 
                  <td align="center">'.$row["Diferencia09"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">10</td>
                  <td align="center">'.$row["Dia10"].'</td> 
                  <td align="center">'.$row["Precio10"].'</td> 
                  <td align="center">'.$row["Transaciones10"].'</td> 
                  <td align="center">'.$row["Diferencia10"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">11</td>
                  <td align="center">'.$row["Dia11"].'</td> 
                  <td align="center">'.$row["Precio11"].'</td> 
                  <td align="center">'.$row["Transaciones11"].'</td> 
                  <td align="center">'.$row["Diferencia11"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">12</td>
                  <td align="center">'.$row["Dia12"].'</td> 
                  <td align="center">'.$row["Precio12"].'</td> 
                  <td align="center">'.$row["Transaciones12"].'</td> 
                  <td align="center">'.$row["Diferencia12"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">13</td>
                  <td align="center">'.$row["Dia13"].'</td> 
                  <td align="center">'.$row["Precio13"].'</td> 
                  <td align="center">'.$row["Transaciones13"].'</td> 
                  <td align="center">'.$row["Diferencia13"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">14</td>
                  <td align="center">'.$row["Dia14"].'</td> 
                  <td align="center">'.$row["Precio14"].'</td> 
                  <td align="center">'.$row["Transaciones14"].'</td> 
                  <td align="center">'.$row["Diferencia14"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">15</td>
                  <td align="center">'.$row["Dia15"].'</td> 
                  <td align="center">'.$row["Precio15"].'</td> 
                  <td align="center">'.$row["Transaciones15"].'</td> 
                  <td align="center">'.$row["Diferencia15"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">16</td>
                  <td align="center">'.$row["Dia16"].'</td> 
                  <td align="center">'.$row["Precio16"].'</td> 
                  <td align="center">'.$row["Transaciones16"].'</td> 
                  <td align="center">'.$row["Diferencia16"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">17</td>
                  <td align="center">'.$row["Dia17"].'</td> 
                  <td align="center">'.$row["Precio17"].'</td> 
                  <td align="center">'.$row["Transaciones17"].'</td> 
                  <td align="center">'.$row["Diferencia17"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">18</td>
                  <td align="center">'.$row["Dia18"].'</td> 
                  <td align="center">'.$row["Precio18"].'</td> 
                  <td align="center">'.$row["Transaciones18"].'</td> 
                  <td align="center">'.$row["Diferencia18"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">19</td>
                  <td align="center">'.$row["Dia19"].'</td> 
                  <td align="center">'.$row["Precio19"].'</td> 
                  <td align="center">'.$row["Transaciones19"].'</td> 
                  <td align="center">'.$row["Diferencia19"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">20</td>
                  <td align="center">'.$row["Dia20"].'</td> 
                  <td align="center">'.$row["Precio20"].'</td> 
                  <td align="center">'.$row["Transaciones20"].'</td> 
                  <td align="center">'.$row["Diferencia20"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">21</td>
                  <td align="center">'.$row["Dia21"].'</td> 
                  <td align="center">'.$row["Precio21"].'</td> 
                  <td align="center">'.$row["Transaciones21"].'</td> 
                  <td align="center">'.$row["Diferencia21"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">22</td>
                  <td align="center">'.$row["Dia22"].'</td> 
                  <td align="center">'.$row["Precio22"].'</td> 
                  <td align="center">'.$row["Transaciones22"].'</td> 
                  <td align="center">'.$row["Diferencia22"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">23</td>
                  <td align="center">'.$row["Dia23"].'</td> 
                  <td align="center">'.$row["Precio23"].'</td> 
                  <td align="center">'.$row["Transaciones23"].'</td> 
                  <td align="center">'.$row["Diferencia23"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">24</td>
                  <td align="center">'.$row["Dia24"].'</td> 
                  <td align="center">'.$row["Precio24"].'</td> 
                  <td align="center">'.$row["Transaciones24"].'</td> 
                  <td align="center">'.$row["Diferencia24"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">25</td>
                  <td align="center">'.$row["Dia25"].'</td> 
                  <td align="center">'.$row["Precio25"].'</td> 
                  <td align="center">'.$row["Transaciones25"].'</td> 
                  <td align="center">'.$row["Diferencia25"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">26</td>
                  <td align="center">'.$row["Dia26"].'</td> 
                  <td align="center">'.$row["Precio26"].'</td> 
                  <td align="center">'.$row["Transaciones26"].'</td> 
                  <td align="center">'.$row["Diferencia26"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">27</td>
                  <td align="center">'.$row["Dia27"].'</td> 
                  <td align="center">'.$row["Precio27"].'</td> 
                  <td align="center">'.$row["Transaciones27"].'</td> 
                  <td align="center">'.$row["Diferencia27"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">28</td>
                  <td align="center">'.$row["Dia28"].'</td> 
                  <td align="center">'.$row["Precio28"].'</td> 
                  <td align="center">'.$row["Transaciones28"].'</td> 
                  <td align="center">'.$row["Diferencia28"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">29</td>
                  <td align="center">'.$row["Dia29"].'</td> 
                  <td align="center">'.$row["Precio29"].'</td> 
                  <td align="center">'.$row["Transaciones29"].'</td> 
                  <td align="center">'.$row["Diferencia29"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">30</td>
                  <td align="center">'.$row["Dia30"].'</td> 
                  <td align="center">'.$row["Precio30"].'</td> 
                  <td align="center">'.$row["Transaciones30"].'</td> 
                  <td align="center">'.$row["Diferencia30"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">31</td>
                  <td align="center">'.$row["Dia31"].'</td> 
                  <td align="center">'.$row["Precio31"].'</td> 
                  <td align="center">'.$row["Transaciones31"].'</td> 
                  <td align="center">'.$row["Diferencia31"].'</td> 
              </tr>';
		echo '<tr>
      			<th colspan="2" scope="row" align="right">Total Mensual:</th>
      			<td align="center">'.$row["PrecioMedio"].'</td>
      			<td align="center">0</td>
				<td align="center">'.$row["DucosTotal"].'</td>
   </tbody>
</table></td>';
    }
    $result->free();
} 
?>
      <td width="401" height="32" valign="top"><?
			$query = "SELECT * FROM `mes` WHERE Fecha='25/04/2022'";
	echo '<table border="1" width="500" cellspacing="2" cellpadding="2">
      <tr>
      <th colspan="5" scope="col">Balance por Año</th>
    </tr>
    <tr>
      <th width="62" scope="row"><strong>Dia</strong></th>
      <td width="71" align="center" scope="row"><strong>Balance</strong></td>
      <td width="71" align="center"><strong>Precio</strong></td>
      <td width="89" align="center"><strong>Transaciones</strong></td>
      <td width="73" align="center"><strong>Ganado</strong></td>
    </tr>';

if ($result = $mysqli->query($query)) {
    while ($row = $result->fetch_assoc()) {
       		echo '<tr> 
				  <td align="center">01</td>
                  <td align="center">'.$row["Dia01"].'</td> 
                  <td align="center">'.$row["Precio01"].'</td> 
                  <td align="center">'.$row["Transaciones01"].'</td> 
                  <td align="center">'.$row["Diferencia01"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">02</td>
                  <td align="center">'.$row["Dia02"].'</td> 
                  <td align="center">'.$row["Precio02"].'</td> 
                  <td align="center">'.$row["Transaciones02"].'</td> 
                  <td align="center">'.$row["Diferencia02"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">03</td>
                  <td align="center">'.$row["Dia03"].'</td> 
                  <td align="center">'.$row["Precio03"].'</td> 
                  <td align="center">'.$row["Transaciones03"].'</td> 
                  <td align="center">'.$row["Diferencia03"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">04</td>
                  <td align="center">'.$row["Dia04"].'</td> 
                  <td align="center">'.$row["Precio04"].'</td> 
                  <td align="center">'.$row["Transaciones04"].'</td> 
                  <td align="center">'.$row["Diferencia04"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">05</td>
                  <td align="center">'.$row["Dia05"].'</td> 
                  <td align="center">'.$row["Precio05"].'</td> 
                  <td align="center">'.$row["Transaciones05"].'</td> 
                  <td align="center">'.$row["Diferencia05"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">06</td>
                  <td align="center">'.$row["Dia06"].'</td> 
                  <td align="center">'.$row["Precio06"].'</td> 
                  <td align="center">'.$row["Transaciones06"].'</td> 
                  <td align="center">'.$row["Diferencia06"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">07</td>
                  <td align="center">'.$row["Dia07"].'</td> 
                  <td align="center">'.$row["Precio07"].'</td> 
                  <td align="center">'.$row["Transaciones07"].'</td> 
                  <td align="center">'.$row["Diferencia07"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">08</td>
                  <td align="center">'.$row["Dia08"].'</td> 
                  <td align="center">'.$row["Precio08"].'</td> 
                  <td align="center">'.$row["Transaciones08"].'</td> 
                  <td align="center">'.$row["Diferencia08"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">09</td>
                  <td align="center">'.$row["Dia09"].'</td> 
                  <td align="center">'.$row["Precio09"].'</td> 
                  <td align="center">'.$row["Transaciones09"].'</td> 
                  <td align="center">'.$row["Diferencia09"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">10</td>
                  <td align="center">'.$row["Dia10"].'</td> 
                  <td align="center">'.$row["Precio10"].'</td> 
                  <td align="center">'.$row["Transaciones10"].'</td> 
                  <td align="center">'.$row["Diferencia10"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">11</td>
                  <td align="center">'.$row["Dia11"].'</td> 
                  <td align="center">'.$row["Precio11"].'</td> 
                  <td align="center">'.$row["Transaciones11"].'</td> 
                  <td align="center">'.$row["Diferencia11"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">12</td>
                  <td align="center">'.$row["Dia12"].'</td> 
                  <td align="center">'.$row["Precio12"].'</td> 
                  <td align="center">'.$row["Transaciones12"].'</td> 
                  <td align="center">'.$row["Diferencia12"].'</td> 
              </tr>';
		echo '<tr>
      			<th colspan="2" scope="row" align="right">Total Anual:</th>
      			<td align="center">'.$row["PrecioMedio"].'</td>
      			<td align="center">0</td>
				<td align="center">'.$row["DucosTotal"].'</td>
   </tbody>
</table></td>';
    }
    $result->free();
} 
?></td>
    </tr>
    <tr>
      <td height="32" valign="top"><?
			$query = "SELECT * FROM `mes` WHERE Fecha='25/04/2022'";
	echo '<table border="1" width="500" cellspacing="2" cellpadding="2">
      <tr>
      <th colspan="5" scope="col">Balance por Años</th>
    </tr>
    <tr>
      <th width="62" scope="row"><strong>Año</strong></th>
      <td width="71" align="center" scope="row"><strong>Balance</strong></td>
      <td width="71" align="center"><strong>Precio</strong></td>
      <td width="89" align="center"><strong>Transaciones</strong></td>
      <td width="73" align="center"><strong>Ganado</strong></td>
    </tr>';

if ($result = $mysqli->query($query)) {
    while ($row = $result->fetch_assoc()) {
       		echo '<tr> 
				  <td align="center">2022</td>
                  <td align="center">'.$row["Balance22"].'</td> 
                  <td align="center">'.$row["Precio22"].'</td> 
                  <td align="center">'.$row["Transaciones22"].'</td> 
                  <td align="center">'.$row["Diferencia22"].'</td> 
              </tr>';
		echo '<tr> 
				  <td align="center">2023</td>
                  <td align="center">'.$row["Balance23"].'</td> 
                  <td align="center">'.$row["Precio23"].'</td> 
                  <td align="center">'.$row["Transaciones23"].'</td> 
                  <td align="center">'.$row["Diferencia23"].'</td> 
              </tr>';
		echo '<tr>
      			<th colspan="2" scope="row" align="right">Total Anual:</th>
      			<td align="center">'.$row["PrecioMedio"].'</td>
      			<td align="center">0</td>
				<td align="center">'.$row["DucosTotal"].'</td>
   </tbody>
</table></td>';
    }
    $result->free();
} 
?></td>
    </tr>
    <tr>
      <td valign="top">&nbsp;</td>
    </tr>
  </tbody>
</table>
</body>
</html>