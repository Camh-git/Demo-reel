<?php
require_once('connect.inc.php');
$page_title = 'Edit speaker';
include_once('header.php');

// check if the user submited a cancel request
if (isset($_GET['speaker_id'])) {

	//store speaker id from managestaff.php get method
	$b_id = $_GET['speaker_id'];
	// select the speaker record with the id
	$query = "SELECT * FROM speaker WHERE speaker_id = '$b_id'";
	$result = mysqli_query($dbc, $query);
	if (mysqli_num_rows($result) > 0) {
		// store each attribute in a variable
		while($row = mysqli_fetch_assoc($result)) {
			$b_id = $row['speaker_id'];
			$name = $row['name'];
			$available = $row['available'];
		}
		
	} else {
		echo '<p>Whoops! No records for this ID</p>';
		
	}
// if the user selects (save changes)
} else if (isset($_POST['submit'])) {
	// sanitise the input from the user and store in new variables
	$b_id = $_POST['speaker_id'];
	$new_name = mysqli_real_escape_string($dbc, trim($_POST['new_name']));
	$new_available = mysqli_real_escape_string($dbc, trim($_POST['new_available']));
	
	// update speaker record with new data
	$query = "UPDATE speaker SET name = '$new_name', available = '$new_available' WHERE speaker_id = '$b_id'";
	mysqli_query($dbc, $query);
	// redirect to manage speakers and display changes made
	header('Location: ' . 'http://' . $_SERVER['HTTP_HOST'] . dirname($_SERVER['PHP_SELF']) . '/managestaff.php');
} else {
	echo '<p class="error">To access this page you must log in as an administrator</p>';
	exit();
}
// show the form with the original data for that speaker
?>
	<form method="post" action="<?php echo $_SERVER['PHP_SELF']; ?>">
	Name:
	<input type="text" name="new_name" value="<?php echo $name; ?>">
	<br></br>
	Available?: 
	<input type="radio" name="new_available" <?php if (isset($available) && $available=="1") echo "checked";?>  value="1">Yes
	<input type="radio" name="new_available" <?php if (isset($available) && $available=="0") echo "checked";?>
	value="0">No
	<br></br>
	<input type="submit" value="Save Changes" class="submit" name="submit" />
	<input type="hidden" name="speaker_id" value="<?php echo $b_id ?>" />
	</form>
<?php

//close connection
mysqli_close($dbc);
// Insert the footer page
include_once('footer.php');
?>