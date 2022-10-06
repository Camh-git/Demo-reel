<?php
// function used to clean data entry
function clean_input($input) {
	// remove white space
	$input = trim($input);
	$input = stripslashes($input);
	// prevent cross-site scripting (XSS)
	// convert special characters into html entities (e.g. '<' becomes &lt)
	$input = htmlspecialchars($input);
	// return clean input data
	return $input;
}
?>