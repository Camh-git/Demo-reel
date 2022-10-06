<?php
?>
<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="utf-8"/>
	<link rel="stylesheet" type="text/css" href="style.css" />
	
	<link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/blitzer/jquery-ui.css"/>
	<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
	<script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
	<link rel="stylesheet" href="style.css"/>
	<style type="text/css">
		.ui-widget { width: 70% }
	</style>
</head>
<body>
<!-- start of main container -->
<div id ="Menu">
<a href="Homepage.php">
 <div id = "Menu_Entry"><br>Home</div></a>
<a href="aboutus.php">
 <div id = "Menu_Entry"><br>About us</div></a>
<a href="contactus.php">
 <div id = "Menu_Entry"><br>Contact us</div></a>
<a href="Products.php">
 <div id = "Menu_Entry"><br>Products</div></a>
<a href="News.php">
 <div id = "Menu_Entry"><br>News</div></a>
<a href="login.php">
 <div id = "Menu_Entry"><br>Login</div></a>
<a href="User_area.php">
 <div id = "Menu_Entry"><br>User area</div></a>
</div>
<?php
// start the session
session_start();
// every page will use this variable ($home) to redirect to the home page (index.php)
$home_url = 'http://' . $_SERVER['HTTP_HOST'] . dirname($_SERVER['PHP_SELF']) . '/Homepage.php';

// change header contents if user is logged in - display name
if (isset($_SESSION['user_id'])) {
	echo '<p class="welcome">Welcome <span style="color:#111111"><strong>' . $_SESSION['firstname'] . '</strong></span>, ';
	echo 'not you? <a href="logout.php">Logout</a>' . '<span style="color:#111111"></span>';
// no user session so show log-in option
}
// display the heading - dynamic heading changes for each page

echo '</div>'; //end of header <div>

echo '<div id="main">';
echo '<div id="middle">'; // start of middle <div>
?>
