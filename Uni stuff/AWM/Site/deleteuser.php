<?php
require_once('connect.inc.php');
include_once('header.php');
$User = isset($_POST['userid']) ? $_POST['userid'] : '';
?><title>Delete user</title>
    <form method="post" action="deleteuser.php"align = "center">
	ID of user to be deleted:<br>
	<input type="text" name="userid"><br>
	<br>
    <input type="submit" value="Submit" class="submit" name="submit" />
    </form>
<?php
// Delete the user record from the database
		$query = "DELETE FROM appointment WHERE user_id = '$User'";
		mysqli_query($dbc, $query);
		$query = "DELETE FROM user WHERE user_id = '$User'";
		mysqli_query($dbc, $query);
		// Confirm success with the user
		
	
	//close connection
	mysqli_close($dbc);
	// Insert the footer page
	include_once('footer.php');
?>