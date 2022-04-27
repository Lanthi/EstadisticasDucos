<?php
include 'Config.php';
$conn = new mysqli($servername, $username, $password, $dbname);
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
if ($Fecha !=''){
    echo $Fecha. " Hora".$Hora."=".$Balance." Precio".$Hora."= ".$Precio." Diferencia".$Hora."= ".$Diferencia." Transaciones".$Hora."=".$Transaciones."";
    $sql = "UPDATE mes SET Dia".$Hora."='".$Balance."', Precio".$Hora."='".$Precio."', Diferencia".$Hora."='".$Diferencia."', Transaciones".$Hora."='".$Transaciones."' WHERE Fecha='".$Fecha."'";
    if ($conn->query($sql) === TRUE) {
     echo "<br>Datos Modificados Correctamente.";
    } else {
     echo "Error: " . $sql . "<br>" . $conn->error;
    }
    $conn->close();
    }else{
     echo 'Debes de introducir Fecha, Hora y Valor.';
    }
?>