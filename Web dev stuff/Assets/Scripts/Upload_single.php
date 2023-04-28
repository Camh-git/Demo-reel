<?php
  if(isset($_FILES['inpFile']))
  {
    //var_dump($_FILES); #For debug, disable in production
    try{
      $file = $_FILES["inpFile"];
      $targetPath="../../Books/Misc/".basename($_FILES["inpFile"]["name"]);
    
      if(copy($_FILES['inpFile']['tmp_name'],$targetPath))
      {
        echo("Book uploaded to: uploads/".basename($_FILES["inpFile"]["name"]));
      }
      //Send the user to the success screen
      readfile("../Confirmations,modals,popups/Upload_success_page.html");
    }
    catch(Exception $e) {
      echo $e->getMessage();
    }
  } else {
    echo("Input file not set, this is likely because the file is too large, the limit is ~30MB");
  }
?>