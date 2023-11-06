<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />

    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="StyleSheet.css" />
    <title>Audiobooks</title>
  </head>

  <body>
    <h1>Main index</h1>
  </body>
  <?php
  #Fetch every folder in books   
  $path = "\Books\\".DIRECTORY_SEPARATOR."*";
  $Folders = glob($path,GLOB_ONLYDIR);

  #Show the links
  $Output ="<ul>";
  foreach ($Folders as $dir){
    #Get the name and add the link

    $Title = substr($dir,6);
    $Output .= "<li><a href ='./Books/".$Title."'>";
    #Add the name and close the li
    $Output .= $Title ."</a></li>";
  }
  $Output .= "</ul>";
  echo($Output)
  

  ?>
</html>
