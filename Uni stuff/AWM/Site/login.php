<?php
$page_title = "Login";
require_once('header.php');
// connect to the database
require_once('connect.inc.php');
// Clear the error message
$error_msg = "";

// If there is no session, check if the user has logged in
if (!isset($_SESSION['user_id'])) {

	// post data posted
	if (isset($_POST['username']) && isset($_POST['password'])) {

		// access the user input - protect against sql injections by using the trim and real escape string methods
		$user_username = mysqli_real_escape_string($dbc, trim($_POST['username']));
		$user_password = mysqli_real_escape_string($dbc, trim($_POST['password']));

		// are the fields empty
		if (!empty($user_username) && !empty($user_password)) {

			// Look up the username and password in the database
			$query = "SELECT user_id, username, firstname FROM user WHERE username = '$user_username' AND password = SHA('$user_password')";
			$data = mysqli_query($dbc, $query);

			// if a row is returned - a user exists with that username and password combination
			if (mysqli_num_rows($data) == 1) {
				// The login is OK so set the user_id and username session variables and cookies
				$row = mysqli_fetch_array($data);

				// set the session variables
				$_SESSION['user_id'] = $row['user_id'];
				$_SESSION['username'] = $row['username'];
				$_SESSION['firstname'] = $row['firstname'];

				// set the cookie variables
				setcookie('user_id', $row['user_id'], time() + (60 * 60 * 24 * 1));    // expires in 1 day
				setcookie('username', $row['username'], time() + (60 * 60 * 24 * 1));
				setcookie('firstname', $row['firstname'], time() + (60 * 60 * 24 * 1));

				// redirect to home page (Homepage.php)
				header('Location: ' . $home_url);
			} else {
			// The username and password did not match a record in the database - set error message
			$error_msg = 'Login failed, you must enter a valid username and password to log in.';
			}
		} else {
		// The username and password fields were empty - set error message
		$error_msg = 'Login failed, you must enter your username and password to log in.';
		}
	} // no submit action
}  // session exists

// Insert the page header - change the title to Login
$page_title = 'Login';
include_once('header.php');

// if there is a session but it is empty, show error message and the form - else confirm login and display username
if (empty($_SESSION['user_id'])) {
	echo '<p class="error">' . $error_msg . '</p>';
?>
<title>Login</title>
<div class="form_box" align = "center">
<h3>login</h3>
Please enter your username and password<br><br>
	<form method="post" action="<?php echo $_SERVER['SCRIPT_NAME']; ?>">
		<input type="text" name="username" placeholder="Username" value="<?php if (isset($user_username) && !empty($user_username)) echo $user_username; ?>"/>
		<br></br>
		<input type="password" name="password" placeholder="Password" />
		<br></br>
		<input type="submit" name="submit" class="submit" value="Login" /><br><br>
		If you do not have an account you can create one here:<br>
      <a href="register.php">Create a new account.</a><br><br>
	</form>
</div>
<?php
} else {
	// Confirm the successful login - redirect to home page
	header('Location: ' . $home_url);
}
// close connection
mysqli_close($dbc);
// Insert the footer page
include_once('footer.php');
?>
