<?php
// set title for contact us page
require('header.php');

//initialise variables
$name = isset($_POST['name']) ? $_POST['name'] : '';
$email = isset($_POST['email']) ? $_POST['email'] : '';
$comments = isset($_POST['comments']) ? $_POST['comments'] : '';
$verify = isset($_POST['verify']) ? $_POST['verify'] : '';

// default values for error messages - display next to required fields
$nameErr = $emailErr = $commentsErr = $verifyErr = "";

// check if form was submitted
if ($_SERVER["REQUEST_METHOD"] == "POST") {
	// set flag to false - if any field is invalid, the flag will reset to true
	$display_form = 0;
	
	// #1 check name
	if (empty($name)) {
		//error - no first name provided
		$nameErr = 'Please enter a name';
		// display form
		$display_form = 1;
	} else {
		if (!preg_match("/^[a-zA-Z]*$/", $name)) {
			// invalid name - set error message
			$nameErr = 'Invalid name. No spaces allowed';
			// display form
			$display_form = 1;
		}
	}
	
	// #2 check email
	if (empty($email)) {
		$emailErr = 'Please enter an email address';
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
	
	// #3 check comments
	if (empty($comments)) {
		$commentsErr = 'Please provide some information';
		$display_form = 1;
	}
	
} else {
	// no post request - show form
	$display_form = 1;
}

if ($display_form == 1) {
?>
<title>Contact us</title>
   <div align = "center">
    <h3>Contact us</h3>
	 Should you wish to contact us you can do so using the form or any of the contacts found bellow.<br>
	 feedback is always welcome.
	<div class="form_box">
	<form action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]);?>" method="post" >
	Name:<br><input type="text" name="name" class="box_style" value="<?php echo $name; ?>"/><span class="error"> * <?php echo $nameErr;?></span></br>
	Email:<br><input type="text" name="email" class="box_style" value="<?php echo $email; ?>"/><span class="error"> * <?php echo $emailErr;?></span></br>
	Comments:<br><textarea name="comments" class="box_style" rows="4" cols="30"><?php echo $comments;?></textarea><span class="error"> * <?php echo $commentsErr;?></span></br>
	<br>
	<input type="submit" name="submit" class="submit" value="Send"/>
	<br><br>
	</form>
    Alternatively you can contact us at these locations:<br>
	Facebook:wes1tefacebook<br>
    Twitter:webs1tetweet<br>
    Company address: 123 Example Road<br>
    Phone number: 07700912345 <!--this number should never connect to anyone --><br>
    Email:website+123@gmail.com<!--invalid address due to "+" sign--><br>
    Postcode:GA14 123A <!--intentionaly incorrect area code--><br>
    Website: <a href="Homepage.php">Our website</a><br>
    PO Box::123456789<br>
    Fax:0 999 888<br>
	</div>
</div>
<?php
} else {
	//display thank you message for feedback
	echo '<p>Thank you for your feedback, we will consider your request and get back to you soon!</p>';
}
include_once('footer.php');
?>