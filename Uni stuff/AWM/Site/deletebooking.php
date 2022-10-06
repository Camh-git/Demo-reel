<?php
require_once('connect.inc.php');
include_once('header.php');
$booking = isset($_POST['bookid']) ? $_POST['bookid'] : '';
?><title>Delete booking</title>
    <form method="post" action="deletebooking.php" align = "center">
	ID of booking to be deleted:<br>
	<input type="text" name="bookid"><br>
	<br>
    <input type="submit" value="Submit" class="submit" name="submit" />
    </form>
<?php
// Delete the speaker record from the database
		$query = "DELETE FROM appointment WHERE appointment_id = '$booking'";
		mysqli_query($dbc, $query);
		// Confirm success with the user
		
	
	//close connection
	mysqli_close($dbc);
	// Insert the footer page
	include_once('footer.php');
?>