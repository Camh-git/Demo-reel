<?php
    //$files = array_filter($_FILES['inpFiles']['name']); 

    //Create a folder for the books, using the name the user provided
    $folder = "../../Books/";
    mkdir($folder);

    //upload the files
    $total = count($_FILES['inpFiles']['name']);
    for( $i=0 ; $i < $total ; $i++ ) {

        //Get the temp file path
        $tmpFilePath = $_FILES['inpFiles']['tmp_name'][$i];
      
        //Make sure we have a file path
        if ($tmpFilePath != ""){
          //Setup our new file path
          $newFilePath = $folder . $_FILES['inpFiles']['name'][$i];
      
          //Upload the file into the temp dir
          if(move_uploaded_file($tmpFilePath, $newFilePath)) {
      
            //Handle other code here
      
          }
        }
      }
?>