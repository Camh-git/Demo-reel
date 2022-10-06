<?php
require_once('connect.inc.php');
$page_title = 'Today\'s Bookings';
require_once('header.php');
// check for session
if (isset($_SESSION['user_id'])) {
	$id = $_SESSION['user_id'];
	$query = "SELECT user_id FROM user WHERE admin_status = 1 AND user_id = '$id'";
	$result = mysqli_query($dbc, $query);
	// check if user has admin rights to view customer information
	if (mysqli_num_rows($result) == 1) {
	
		$current_date = date('Y-m-d');
		// get appointment information - next appointment
		$query = "select user.surname, appointment.time_slot, appointment.date_slot, barber.name
		from user
		inner join appointment
		on user.user_id = appointment.user_id
		inner join barber
		on barber.barber_id = appointment.barber_id
		where user.user_id = appointment.user_id and appointment.date_slot = '$current_date'
		order by appointment.date_slot, appointment.time_slot";
		$result = mysqli_query($dbc, $query);
		//if returned rows = 0 do not display table
		if (mysqli_num_rows($result) > 0) {
			echo '<table class="table_1">
			<tr>
			<th>Customer Name</th>
			<th>What Time</th>
			<th>Barber</th>
			</tr>';
			while($row = mysqli_fetch_assoc($result)) {
				echo '<tr>';
				echo '<td>' . $row['surname'] . '</td>';
				echo '<td>' . $row['time_slot'] . '</td>';
				echo '<td>' . $row['name'] . '</td>';
				echo '</tr>';
			}
			echo '</table>';
		} else {
			echo '<p class="error"> No Bookings for Today </p>';
		}
	} else {
		// redirect to home page (index.php)
		header('Location: ' . $home_url);
	}
} else {
	//redirect - no session
	header('Location: ' . $home_url);
}
// close connection
mysqli_close($dbc);
include_once('footer.php');
?>