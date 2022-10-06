<?php
require_once('connect.inc.php');
$page_title = 'Cancel Booking';
include_once('header.php');

// check if the user submited a cancel request
if (isset($_GET['appointment_id'])) {
	//store appointment id from viewbooking.php get method
	$a_id = $_GET['appointment_id'];
	
//posted form request - confirm cancellation
} else if(isset($_POST['submit'])) {
	// store appointment id from post method
	$a_id = $_POST['appointment_id'];
	
} else {
	//no request received
	echo '<p class="error">Sorry, no appointment was specified for cancellation.</p>';
	exit();
}

if (isset($_POST['submit'])) {
    if ($_POST['confirm'] == 'yes') { 
		// Delete the appointment record from the database - cancel
		$query = "DELETE FROM appointment WHERE appointment_id = '$a_id' LIMIT 1";
		mysqli_query($dbc, $query);
		// Confirm success with the user
		echo '<p>Appointment successfully removed</p>';
    } else {
		echo '<p class="error">The record was not removed</p>';
    }
} else if (isset($a_id)) {
    echo '<p>Are you sure you want to delete the following appointment?</p>';
?>
    <form method="post" action="cancelbooking.php">
    <input type="radio" name="confirm" value="yes" />Yes
    <input type="radio" name="confirm" value="no" checked="checked" /> No
	<br></br>
    <input type="submit" value="Submit" class="submit" name="submit" />
    <input type="hidden" name="appointment_id" value="<?php echo $a_id ?>" />
    </form>
<?php
	}
	//close connection
	mysqli_close($dbc);
	// Insert the footer page
	include_once('footer.php');
?>