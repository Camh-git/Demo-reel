<?php
require_once('connect.inc.php');
$page_title = 'Edit user';
include_once('header.php');


?>


<?php
//close connection
mysqli_close($dbc);
// Insert the footer page
include_once('footer.php');

?>