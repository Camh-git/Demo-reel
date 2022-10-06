<?php
$page_title = "Register";
require_once('header.php');
// establish connection
require_once('connect.inc.php');
// get access to function - clean_input
require_once('function.inc.php');

// define variables for register form - assign empty values if not set by user.
$firstname = isset($_POST['firstname']) ? $_POST['firstname'] : '';
$surname = isset($_POST['surname']) ? $_POST['surname'] : '';
$email = isset($_POST['email']) ? $_POST['email'] : '';
$mobile = isset($_POST['mobile']) ? $_POST['mobile'] : '';
$username = isset($_POST['username']) ? $_POST['username'] : '';
$pass1 = isset($_POST['pass1']) ? $_POST['pass1'] : '';
$pass2 = isset($_POST['pass2']) ? $_POST['pass2'] : '';
// default values for error messages - display next to required fields
$firstErr = $surnameErr = $emailErr = $mobileErr = $userErr = $passErr = "";

// check if form was submitted
if ($_SERVER["REQUEST_METHOD"] == "POST") {
	// set flag to false - if any field is invalid, the flag will reset to true
	$display_form = 0;
	
	// #1 check first name
	if (empty($firstname)) {
		//error - no first name provided
		$firstErr = 'Please enter your first name';
		// display form
		$display_form = 1;
	} else {
		$firstname = clean_input($firstname);
		// validate the first name field - characters only (no spaces)
		if (!preg_match("/^[a-zA-Z]*$/", $firstname)) {
			// invalid first name - set error message
			$firstErr = 'Invalid name. No spaces allowed';
			// display form
			$display_form = 1;
		}
		//set first letter to upper-case
		$firstname = ucfirst($firstname);
	} // end of first name check
	
	// #2 surname check
	if (empty($surname)) {
		//error - no surname provided
		$surnameErr = 'Please enter your surname';
		// display form
		$display_form = 1;
	} else {
		$surname = clean_input($surname);
		// validate the surname field - characters and '-' allowed (must end with letter)
		if (!preg_match('/^[a-zA-Z]*-?[a-zA-Z]$/', $surname)) {
			// invalid
			$surnameErr = 'Please enter a valid surname';
			// display form
			$display_form = 1;
		}
	} // end of surname check
	
	// #3 check email
	if (empty($email)) {
		$emailErr = 'Please enter your email address';
		$display_form = 1;
	} else {
		// not empty
		// using the php filter_var function - sanitize the email removing illegal characters
		$email = filter_var($email, FILTER_SANITIZE_EMAIL);
		// check if email address is valid
		if (filter_var($email, FILTER_VALIDATE_EMAIL) === false) {
			// invalid
			$emailErr = 'Please enter a valid email address';
			$display_form = 1;
		}
	} // end of email check
	
	// #4 check mobile
	if (empty($mobile)) {
		$mobileErr = 'Please enter your mobile number';
		$display_form = 1;
	} else {
		// not empty
		$mobile = clean_input($mobile);
		// check for valid UK mobile (+44 or 07)
		if (!preg_match('/^(\+44\s?7\d{3}|\(?07\d{3}\)?)\s?\d{3}\s?\d{3}$/', $mobile)) {
			//invalid
			$mobileErr = 'Please enter a valid mobile number';
			$display_form = 1;
		} else {
			//apply standardised format (remove spaces and save)
			$new_mobile = preg_replace('/[\s]/', '', $mobile);
		}
	}// end of mobile check
	
	// #5 username
	if (empty($username)) {
		//empty
		$userErr = 'Please enter a username';
		$display_form = 1;
	} else {
		//not empty - check if username already exists in database
		// clean user input
		$username = mysqli_real_escape_string($dbc, trim($_POST['username']));
		// select a row from the user table that matches the username input value
		$query = "SELECT 1 FROM user WHERE username = '$username'";
		$data = mysqli_query($dbc, $query);
		// if a matching username exists - a different username must be selected
		if (mysqli_num_rows($data) == 0) {
			// unique username
		} else {
			// username exists - display error message
			$userErr = 'Sorry, this username already exists. Please choose a different username';
			$display_form = 1;
		}
	}
	// #6 passwords
	// if either password field is empty
	if (empty($pass1) || empty($pass2)) {
		//empty
		$passErr = 'Please enter both passwords (must be the same)';
		$display_form = 1;
	} else {
		$pass1 = clean_input($pass1);
		$pass2 = clean_input($pass2);
		//both not empty - check if they match
		if ($pass1 === $pass2) {
			// match
		} else {
			// no match
			$passErr = 'The passwords entered do not match';
			$display_form = 1;
		}
	}
// register button not used
} else {
	$display_form = 1;
}
// 1 = show form if user has entered invalid details
// 0 = don't display the register form - valid details provided and saved
if ($display_form == 1) {
	// show form
?>
<title>Register</title>
<div class="form_box"align = "center">
On this page you can create a a new account, this will let you access the user area and purchase products.<br>
<span class="error"> * required field </span>
<form action = "<?php echo $_SERVER['SCRIPT_NAME']; ?>" method = "post" >
	<input type="text" name="firstname" placeholder="First Name" class="box_style" value="<?php echo $firstname; ?>"><span class="error"> * <?php echo $firstErr;?></span>
	<br></br>
	<input type="text" name="surname" placeholder="Surname" class="box_style" value="<?php echo $surname; ?>"><span class="error"> * <?php echo $surnameErr;?></span>
	<br></br>
	<input type="text" name="email" placeholder="Email" class="box_style" value="<?php echo $email; ?>"><span class="error"> * <?php echo $emailErr;?></span>
	<br></br>
	<input type="text" name="mobile" placeholder="Mobile" class="box_style" value="<?php echo $mobile; ?>"><span class="error"> * <?php echo $mobileErr;?></span>
	<br></br>
	<input type="text" name="username" placeholder="Username" class="box_style" value="<?php echo $username; ?>"><span class="error"> * <?php echo $userErr;?></span>
	<br></br>
	<input type="password" name="pass1" placeholder="Password" class="box_style"><span class="error"> * <?php echo $passErr;?></span>
	<br></br>
	<input type="password" name="pass2" placeholder="Password (re-type)" class="box_style"><span class="error"> *</span>
	<br></br>
	<input type="submit" name="register" class="submit" value="Register" >
	<br></br>
</form>
</div>
<?php
} else {
	// insert data into database
	$query = "INSERT INTO user (firstname, surname, email, mobile, username, password) VALUES ('$firstname', '$surname', '$email', '$new_mobile', '$username', SHA('$pass1'))";
    if (mysqli_query($dbc, $query)) {
		// Confirm success with the user
		echo '<div align = "center"><p>Your new account has been successfully created.</p></div>';
		echo '<br><div align = "center"><a href="login.php">Login</a> and you can start using your account</div>';
	} else {
		// the query did not complete - inform the user and provide a link back to the homepage
		echo '<p class="error">Unfortunately your account has not been created.  There is currently a problem with our database.  Please try again later.';
	}
}
//close connection
mysqli_close($dbc);
include_once('footer.php');
?>