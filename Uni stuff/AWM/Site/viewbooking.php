<?php
require_once('connect.inc.php');
$page_title = 'Your Next Appointment';
require_once('header.php');

if (isset($_SESSION['user_id'])) {

	$id = $_SESSION['user_id'];
	$current_date = date('Y-m-d');
	// get appointment information - next appointment
	$query = "select appointment.appointment_id, appointment.time_slot, appointment.date_slot, speaker.name
	from user
	inner join appointment
	on user.user_id = appointment.user_id
	inner join speaker
	on speaker.speaker_id = appointment.speaker_id
	where user.user_id = '$id' and appointment.date_slot >= '$current_date'
	order by appointment.date_slot, appointment.time_slot LIMIT 3";
	$result = mysqli_query($dbc, $query);
	// any bookings to view?
	if (mysqli_num_rows($result) > 0) {
		echo '<table class="table_1">
		<tr>
		<th>What Time</th>
		<th>When</th>
		<th>Who With</th>
		<th>Action</th>
		</tr>';
		while($row = mysqli_fetch_assoc($result)) {
			echo '<tr><td>' . $row['time_slot'] . '</td>';
			echo '<td>' . $row['date_slot'] . '</td>';
			echo '<td>' . $row['name'] . '</td>';
			echo '<td><a href="cancelbooking.php?appointment_id=' . $row['appointment_id'] . '">Cancel?</a></td></tr>';
		}
		echo "</table>";
	} else {
		// no bookings - display message
		echo '<p class="error">No Bookings</p>';
	}
} else {
	// no session - redirect to home page
	header('Location: ' . $home_url);
}
// close connection
mysqli_close($dbc);
include_once('footer.php');
?>