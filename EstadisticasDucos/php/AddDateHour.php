<?php
include 'Config.php';
$conn = new mysqli($servername, $username, $password, $dbname);
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
if ($Fecha !=''){
    $sql = "INSERT INTO horas (Fecha, Hora00, Precio00, Diferencia00)VALUES ('".$Fecha."', '".$Hora."', '".Precio."','".$Diferencia."')";
    if ($conn->query($sql) === TRUE) {
       echo "<br>Datos Introducidos Correctamente.";
    } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
    }
    $conn->close();
    }else{
     echo 'Debes de introducir Fecha, Hora, Precio y Diferencia.';
    }

?>