<?php
require_once('connect.inc.php');
require_once('function.inc.php');
$page_title = 'Create speaker Profile';
//redirect variable '$home' included
require_once('header.php');

//check for session
if (isset($_SESSION['user_id'])) {
	$id = $_SESSION['user_id'];
	$query = "SELECT user_id FROM user WHERE admin_status = 1 AND user_id = $id";
	$result = mysqli_query($dbc, $query);
	// check if user has admin rights to view customer information
	if (mysqli_num_rows($result) == 1) {
		$display_form = 0;
		//continue - admin
		// initialise speaker name variable
		$name = isset($_POST['name']) ? $_POST['name'] : '';
		if (isset($_POST['submit'])) {
			//if posted and not empty
			if (isset($_POST['name']) && !empty($_POST['name'])) {
				$name = $_POST['name'];
				$b_name = clean_input($name);
				$b_name = ucfirst($b_name);
				if (!preg_match("/^[a-zA-Z]*$/", $b_name)) {
					//invalid name
					echo '<p class="error">Invalid name. Please use letters only!</p>';
					$display_form = 1;
				}
			} else {
				echo '<p class="error">Please enter a name</p>';
				$display_form = 1;
			}
			if (isset($_POST['available'])) {
				$available = $_POST['available'];
				$available = clean_input($available);
			} else {
				$display_form = 1;
				echo '<p class="error">Please provide availability status</p>';
			}
			
		} else {
			// no submit action - show form
			$display_form = 1;
		}
		if ($display_form == 1) {
			?>
			<div class="form_box" align ="center">
			 <h3>Add speaker</h3><br>
			 Please enter the information of the speaker you wish to add.<br><br>
				<form action="createspeaker.php" method="post">
				Name:
				<input type="text" name="name" value="<?php echo $name; ?>">
				<br></br>
				Available?: 
				<input type="radio" name="available" <?php if (isset($available) && $available=="1") echo "checked";?>  value="1">Yes
				<input type="radio" name="available" <?php if (isset($available) && $available=="0") echo "checked";?>
				value="0">No
				<br></br>
				<input type="submit" name="submit" class="submit" value="submit">
				<br></br>
				</form>
				</div>
			<?php
		} else {
			// don't display form - insert record to database
			$query = "INSERT INTO speaker(name, available) VALUES('$b_name', '$available')";
			if (mysqli_query($dbc, $query)) {
				//success
				echo '<p>The profile for <span style="color:#2196F3">' . $b_name . '</span> has been created</p>';
				echo '<a href="managestaff.php">Manage new profile?</a>';
			} else {
				//failure
				echo '<p class="error">Unfortunately, this profile has not been created.  An error has occurred</p>';
			}
		}
	} else {
		//redirect - not admin
		header('Location: ' . $home_url);
	}
} else {
	//redirect - no session
	header('Location: ' . $home_url);
}
//close connection
mysqli_close($dbc);
// Insert the footer page
include_once('footer.php');
?>