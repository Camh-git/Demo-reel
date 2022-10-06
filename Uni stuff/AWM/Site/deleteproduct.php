<?php
require_once('connect.inc.php');
include_once('header.php');
$product = isset($_POST['productid']) ? $_POST['productid'] : '';
?><title>Delete product</title>
    <form method="post" action="deleteproduct.php" align = "center">
	ID of product to be deleted:<br>
	<input type="text" name="productid"><br>
	<br>
    <input type="submit" value="Submit" class="submit" name="submit" />
    </form>
<?php
// Delete the speaker record from the database
		$query = "DELETE FROM product WHERE product_id = '$product'";
		mysqli_query($dbc, $query);
		// Confirm success with the user
		
	
	//close connection
	mysqli_close($dbc);
	// Insert the footer page
	include_once('footer.php');
?>