<?php
$db_host = "localhost";
$db_user = "20138563";
$db_pass = "20138563";
$db_name = "20138563";

// Create connection
$dbc = mysqli_connect($db_host, $db_user, $db_pass, $db_name);

// Check connection
if (!$dbc) {
  die("Connection failed: " . mysqli_connect_error());
}
//echo "Connected successfully.";
?>