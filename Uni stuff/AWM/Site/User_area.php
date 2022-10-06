<html>
<?php
require_once('header.php');
require_once('connect.inc.php');

if (isset($_SESSION['user_id'])) {
		$id = $_SESSION['user_id'];
		$query = "SELECT user_id FROM user WHERE admin_status = 0 or 1 AND user_id = '$id'";
		$result = mysqli_query($dbc, $query);
		// check if user has user rights to view customer information
		if (mysqli_num_rows($result) == 1) {
			return true;
		} else {
			$allowedentry ="true";
		}
	} else {
	echo ("Please log in before trying to enter the user area");
		return false;
	}
?>
<title>User area</title>
<div align = "center">
<h3>User Area</h3>
Welcome to the user area, here you can book appointments and order products.<br>
If you are an admin you can click the link bellow to be taken to the admin page.<br><br>
 <a href="Admin_area.php">Admin area</a><br><br>
 <a href="appointment.php">Book an appointment/lecture.</a><br><br>


  


</div>
<?php
// Insert the footer page
include('footer.php');
?>

</html>
