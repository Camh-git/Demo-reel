<?php
$page_title = "Book a Haircut";
require_once('header.php');
// establish connection
require_once('connect.inc.php');
// get access to function - clean_input()
require_once('function.inc.php');

// set variables (empty value if not set)
$speaker = isset($_POST['speaker']) ? $_POST['speaker'] : '';
$date_slot = isset($_POST['date_slot']) ? $_POST['date_slot'] : '';
$time_slot = isset($_POST['time_slot']) ? $_POST['time_slot'] : '';

// default value for error message - display next to required field (note: speaker and time_slot already selected)
$dayErr = "";

// check for valid user session
if (isset($_SESSION['user_id'])) {
	// store session in variable - used in query later
	$user_id = $_SESSION['user_id'];
} else {
	// no session - must be logged in as a member to book haircut
	echo '<p>If you are a member please <a href="login.php">sign-in</a> to use the online booking service.  If you want to use the booking service and are currently not a Big Haircut member then please <a href="register.php">register</a> to book today.</p>';
	// do not display form - user not logged in
	$display_form = 0;
	// exit the script - show no more
	exit();
}

// check for post response
if ($_SERVER["REQUEST_METHOD"] == "POST") {
	//check input - initialise display form flag to false
	$display_form = 0;
	
	if (empty($_POST['speaker'])) {
		echo '<p class="error">Please select a speaker</p>';
		$display_form = 1;
	} else {
		$speaker = $_POST['speaker'];
		$Speaker = clean_input($Speaker);
	}
	if (empty($date_slot)) {
		//error - no date selected
		$dayErr = 'Please select a date for your appointment';
		// display form - invalid entry
		$display_form = 1;
	} else {
		// sanitise date input
		$date_slot = clean_input($date_slot);
		//not empty - convert to match SQL date format (yyyy-mm-dd)
		$new_date = date("Y-m-d", strtotime($date_slot));
		// check if date is in the future
		if($new_date <= date("Y-m-d")){
			//booking something in the past or now - invalid
			$display_form = 1;
			$dayErr = 'The selected date is either in the past or today. Please select a different date.';
		}
	}
	
	if (empty($time_slot)) {
		//error - no time slot selected
		echo '<p class="error">Please select a time for your appointment</p>';
		// display form - invalid entry
		$display_form = 1;
	} else {
		//sanitise time slot input
		$time_slot = clean_input($time_slot);
		//display result to user without seconds (hh:mm)
		$new_time = substr($time_slot,0,5);
	}
	// check availability
	if (!empty($time_slot) && !empty($date_slot)) {
		//begin query - check if time_slot, date_slot and speaker already exists
		$query = "SELECT speaker_id, date_slot, time_slot FROM appointment WHERE speaker_id = $speaker AND date_slot = '$new_date' AND time_slot = '$time_slot'";
		$result = mysqli_query($dbc, $query);
		//check availability
		if (mysqli_num_rows($result) > 0) {
			//this time slot is already booked
			echo '<p class="error">Please select a different time of day. This time slot has already been taken</p>';
			$display_form = 1;
		}
		// check if user has same slot booked with another speaker
		$query2 = "SELECT * FROM appointment WHERE user_id = '$user_id' AND date_slot = '$new_date' AND time_slot = '$time_slot'";
		$result2 = mysqli_query($dbc, $query2);
		// if a row is returned this user has booked with someone else - double booking prevented
		if (mysqli_num_rows($result2) > 0) {
			//the user is already booked in for this day and time with another speaker
			echo '<p class="error">You already have this day and time booked with someone else. Please select a different day.</p>';
			$display_form = 1;
		}
	}
	
	// check if this user has a booking with another speaker on same day and time
} else {
	// no post response - display form
	$display_form = 1;
}

if ($display_form == 1) {
	//true - display form
	?>
	<script> <!--JQuery function to display calendar picker widget when input field is clicked -->
		$(function() {
		$( "#date_slot" ).datepicker({ dateFormat: 'dd-mm-yy' });
		});
	</script>
	<div class="form_box">
	<form action="<?php echo $_SERVER['SCRIPT_NAME']; ?>" method="post" align ="center">
	 Should you wish to book one of our expert speakers you can do so here.<br>
	 Just pick your Preferred speaker, day and time then click book.<br><br>
		Select speaker:
		<br><select name="speaker" id="speaker">
		<?php 
		// only display available speakers
		$sql = mysqli_query($dbc, "SELECT * FROM speaker WHERE available = 1");
		while($row = mysqli_fetch_array($sql)) {
		?>
			<option value="<?php echo $row['speaker_id']; ?>"><?php echo $row['name']; ?></option>;
		<?php
		}
		?>
		</select></br>
		Choose Day:
		<br><input type="text" name="date_slot" id="date_slot" value="<?php echo $date_slot ?>"><span class="error"> * <?php echo $dayErr;?></span></br>
		Choose Time:
		<br><select name="time_slot">
		<option value="09:00:00"<?php if($time_slot == "09:00:00") echo "selected"; ?>>09:00</option>
		<option value="10:00:00"<?php if($time_slot == "10:00:00") echo "selected"; ?>>10:00</option>
		<option value="11:00:00"<?php if($time_slot == "11:00:00") echo "selected"; ?>>11:00</option>
		<option value="12:00:00"<?php if($time_slot == "12:00:00") echo "selected"; ?>>12:00</option>
		<option value="13:00:00"<?php if($time_slot == "13:00:00") echo "selected"; ?>>13:00</option>
		<option value="14:00:00"<?php if($time_slot == "14:00:00") echo "selected"; ?>>14:00</option>
		<option value="15:00:00"<?php if($time_slot == "15:00:00") echo "selected"; ?>>15:00</option>
		<option value="16:00:00"<?php if($time_slot == "16:00:00") echo "selected"; ?>>16:00</option>
		<option value="17:00:00"<?php if($time_slot == "17:00:00") echo "selected"; ?>>17:00</option>
		</select></br>
		<br></br>
		<input type="submit" name="submit" class="submit" value="Book speaker" >
		<br></br>
	</form>
	</div>
	<?php
} else {
	$id = $_SESSION['user_id'];
	//false - do not display form
	//begin database query - insert record
	
	// query to get speaker name for display purposes
	$get_name = "SELECT name FROM speaker WHERE speaker_id = '$speaker'";
	$result = mysqli_query($dbc, $get_name);
	if ($row = mysqli_fetch_assoc($result)) {
		//assign name value
		$speaker_name = $row['name'];
	}
	//query - insert record
	$query = "INSERT INTO appointment(user_id, speaker_id, date_slot, time_slot) VALUES('$id', '$speaker', '$new_date', '$time_slot')";
	if (mysqli_query($dbc, $query)) {
		//success
		echo '<p>You are booked in with <span style="color:#2196f3">' . $speaker_name . '</span> on <span style="color:#2196f3">' . $date_slot . '</span> at <span style="color:#2196f3">' . $new_time . '</span>.</p>';
	} else {
		//failed
		echo '<p class="error">Sorry, this booking has not been processed. Please try again later.</p>';
		// redirect to home page (index.php)
		header('Location: ' . $home_url);
	}
}
//close connection
mysqli_close($dbc);
// display footer page
include_once('footer.php');
?>