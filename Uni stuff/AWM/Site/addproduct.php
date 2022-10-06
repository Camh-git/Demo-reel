<?php
require_once('connect.inc.php');
require_once('function.inc.php');
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
		// initialise product name variable
		$prodname = isset($_POST['productname']) ? $_POST['productname'] : '';
		$product = isset($_POST['productid']) ? $_POST['productid'] : '';
					$stock = isset($_POST['stockno']) ? $_POST['stockno'] : '';
					$price = isset($_POST['prodprice']) ? $_POST['prodprice'] : '';
					$description = isset($_POST['proddescription']) ? $_POST['proddescription'] : '';
		if (isset($_POST['submit'])) {
			//if posted and not empty
			if (isset($_POST['productname']) && !empty($_POST['productname'])) {
				$name = $_POST['productname'];
				$b_name = clean_input($prodname);
				$b_name = ucfirst($b_prodname);
				if (!preg_match("/^[a-zA-Z]*$/", $b_productname)) {
					//invalid name
					echo '<p class="error">Invalid name. Please use letters only!</p>';
					$display_form = 1;
					
				}
			} else {
				echo '<p class="error">Please enter a name</p>';
				$display_form = 1;
			}
			
		} else {
			// no submit action - show form
			$display_form = 1;
		}
		if ($display_form == 1) {
			?>
			<div class="form_box" align ="center">
			<title>Add product</title>
			 <h3>Add product</h3><br>
			 Please enter the information of the Product you wish to add.<br><br>
				<form action="addproduct.php" method="post">
				Name:
				<input type="text" name="productname">
				<br>
				Stock:
				<input type="text" name="stockno">
				<br>
				Price:
				<input type="text" name="prodprice">
				<br>
				Description:
				<input type="text" name="proddescription">
				<br>
				<input type="submit" name="submit" class="submit" value="submit">
				<br>
				</form>
				</div>
			<?php
		} else {
			// don't display form - insert record to database
			$query = "INSERT INTO product(product_name, product_stock,product_price,product_description) VALUES('$prodname', '$stock', '$price', '$description')";
			if (mysqli_query($dbc, $query)) {
				//success
				echo '<p>The product has been created</p>';
				
			} else {
				//failure
				echo '<p class="error">Unfortunately, this product has not been add.  An error has occurred</p>';
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