<?php
  #Goes with User_input.html
  $Name = $_POST["name"];
  $address = $_POST["email"];
  echo"Details: username: " .  $Name . " email: " . $address. "<br>";
  #or just:
  echo "Deatials: " . $_POST["name"] . " email:" . $_POST["email"];
?>
