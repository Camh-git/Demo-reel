<html>
 <head>
  <meta charset="utf-8"/>
  <link rel="stylesheet" href="Assets/stylesheet.css"/>
  <title>Electoral Commision</title>
 </head>
 
<?php
require_once('Assets/Header.html');
?>

<body>
<!-- The following commented out code calls the standard message for when no information is available
 Uncomment the php to show the no election notice and comment the rest of the body to hide the other notices, or vice versa-->
<?php //require_once('Notifications/Permanent_notes/No_election_notice.inc.html');?>

<br>
 <div id = "Election_notice_box">
   <h3>Ongoing elections</h3>
   The following is a a list of ongoing elections being monitored by the electoral commision.
<!--Place php require commands here for each of the notices that are to be displayed, the notices can be found in the Notifications folder-->
   <br><?php require_once('Notifications/General_election_2024.inc.html');?>
   <br><?php require_once('Notifications/Manchester_city_mayor_2024.inc.html');?>
   <br><?php require_once('Notifications/Hampshire_pc_2024.inc.html');?><br>

   End of Notices.<br><br>
   If you belive anything on this page contains errors, or that we have missed something, please contact us using the link below:<br>
   <a href="Contact_us.php">Contacts page</a>
 </div>
</body>

<?php
require_once('Assets/Footer.html');
?>

</html>