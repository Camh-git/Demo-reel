<html>
<?php
require_once('header.php');
require_once('connect.inc.php');

if (isset($_SESSION['user_id'])) {
		$id = $_SESSION['user_id'];
		$query = "SELECT user_id FROM user WHERE admin_status =0 AND user_id = '$id'";
		$result = mysqli_query($dbc, $query);
		// check if user has user rights to view customer information
		if (mysqli_num_rows($result) == 1) {
			return true;
		} else {
			$allowedentry ="true";
			("you must be an admin to use the admin area");
		}
	} else {
	echo ("you must be an admin to use the admin area");
		return false;
	}
?>
<title>Admin area</title>
<div align = "center">
<h3>Admin Area</h3>
Welcome to the admin area, here you can add,edit and delete users, products and apointments<br>
You can also view the planned appointments as well.<br><br>
<u><b>Bookings</b></u><br>
 <a href="todaybooking.php">view todays bookings.</a><br><br>
  <a href="deletebooking.php">Delete booking.</a><br><br>
 <u><b>Speakers</b></u><br>
 <a href="createspeaker.php">Add a speaker.</a><br><br>
 <a href="editspeaker.php">Edit a speaker.</a><br><br>
 <a href="deletespeaker.php">Delete a speaker.</a><br><br>
 <u><b>Accounts</b></u><br>
 <a href="register.php">Create a new account.</a><br><br>
 <a href="deleteuser.php">Delete a user.</a><br><br>
 
  <u><b>Products</b></u><br>
 <a href="addproduct.php">Add a new product.</a><br><br>
 <a href="deleteproduct.php">Delete a product.</a><br><br>


</div>
<?php
// Insert the footer page
include('footer.php');
?>

</html>