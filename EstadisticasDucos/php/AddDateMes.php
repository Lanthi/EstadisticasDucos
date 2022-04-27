<?php
include 'Config.php';
$conn = new mysqli($servername, $username, $password, $dbname);
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
if ($Fecha !=''){
    $sql = "INSERT INTO mes (Fecha, Dia01, Precio01, Diferencia01,Transaciones01)VALUES ('".$Fecha."', '".$Balance."', '".$Precio."','".$Diferencia."', '".$Transaciones."')";
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