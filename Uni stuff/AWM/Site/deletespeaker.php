<?php
require_once('connect.inc.php');
include_once('header.php');
$speaker = isset($_POST['speakerid']) ? $_POST['speakerid'] : '';
?><title>Delete speaker</title>
    <form method="post" action="deletespeaker.php" align = "center">
	ID of speaker to be deleted:<br>
	<input type="text" name="speakerid"><br>
	<br>
    <input type="submit" value="Submit" class="submit" name="submit" />
    </form>
<?php
// Delete the speaker record from the database
		$query = "DELETE FROM appointment WHERE speaker_id = '$speaker'";
		mysqli_query($dbc, $query);
		$query = "DELETE FROM speaker WHERE speaker_id = '$speaker'";
		mysqli_query($dbc, $query);
		// Confirm success with the user
		
	
	//close connection
	mysqli_close($dbc);
	// Insert the footer page
	include_once('footer.php');
?>