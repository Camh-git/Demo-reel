<?php
session_start();
  // If the user is logged in - delete the session and log them out
  if (isset($_SESSION['user_id'])) {
    // Delete the session by clearing the $_SESSION array - empty array
    $_SESSION = array();

    // Delete the session cookie by setting its expiration to an hour ago (3600)
    if (isset($_COOKIE[session_name()])) {      setcookie(session_name(), '', time() - 3600);    }
    // Destroy the session
    session_destroy();
  }
  // Delete the user ID, username and firstname cookies - set expirations in the past (-1 hour)
  setcookie('user_id', '', time() - 3600);
  setcookie('username', '', time() - 3600);
  setcookie('firstname', '', time() - 3600);

  // Redirect to the home page
  $home_url = 'http://' . $_SERVER['HTTP_HOST'] . dirname($_SERVER['PHP_SELF']) . '/Homepage.php';
  header('Location: ' . $home_url);
?>
