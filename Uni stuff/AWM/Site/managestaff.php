<?php
//edit and delete barbers
$page_title = "Manage speakers";
require_once('header.php');
// connect to the database
require_once('connect.inc.php');

// check for admin session
if (isset($_SESSION['user_id'])) {
	$id = $_SESSION['user_id'];
	$query = "SELECT user_id FROM user WHERE admin_status = 1 AND user_id = '$id'";
	$result = mysqli_query($dbc, $query);
	// check if user has admin rights to view customer information
	if (mysqli_num_rows($result) == 1) {
	
		$query = "SELECT * FROM speaker ORDER BY name";
		$result = mysqli_query($dbc, $query);
		//if returned rows = 0 do not display table
		if (mysqli_num_rows($result) > 0) {
			echo '<table class="table_1">
			<tr>
			<th>speaker Name</th>
			<th>Available</th>
			<th>Action</th>
			</tr>';
			while($row = mysqli_fetch_assoc($result)) {
				echo '<tr>';
				echo '<td>' . $row['name'] . '</td>';
				echo '<td>' . $row['available'] . '</td>';
				echo '<td><a href="editspeaker.php?speaker_id=' . $row['speaker_id'] . '">Edit</a>/<a href="deletespeaker.php?speaker_id=' . $row['speaker_id'] . '">Remove?</a></td>';
				echo '</tr>';
			}
			echo '</table>';
		} else {
			echo '<p class="error"> No Records Found! </p>';
		}
	} else {
		//not admin - redirect to home page (index.php)
		header('Location: ' . $home_url);
	}
	
} else {
	// no session - redirect to home page
	header('Location: ' . $home_url);
}

// close connection
mysqli_close($dbc);
include_once('footer.php');
?>