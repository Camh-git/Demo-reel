<?php
//session_start();

function check_admin() {
// function to verify whether user is admin
	if (isset($_SESSION['user_id'])) {
		$id = $_SESSION['user_id'];
		$query = "SELECT user_id FROM user WHERE admin_status = 0 or 1 AND user_id = '$id'";
		$result = mysqli_query($dbc, $query);
		// check if user has admin rights to view customer information
		if (mysqli_num_rows($result) == 1) {
			return true;
		} else {
			return false;
		}
	} else {
		return false;
	}
}
?>