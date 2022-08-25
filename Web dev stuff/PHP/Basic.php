<?php
//Variables
$txt = "Some text";
$x = 5;
$y = 5.5;
echo "The variables are: $txt,  $x,  $y <br>"; 
print" The total of the ints is: ". $x + $y . "<br>";

//constants
define("Version",1.5);
echo "This is version number: ". Version . "<br>";
define("countries",["England","Scotland","Wales","Northern_Ireland"]);

//arrays
$people = array("bob","steve","chloe","anne");
for($i = 0; $i < count($people);$i++){
    echo " " . $people[$i] . " ";
}
sort($people);
echo"<br>sorted people:";
foreach($people as $value){
	echo"$value ";
}
rsort($people);
echo"<br>Reverse sorted people:";
foreach($people as $value){
	echo"$value ";
}
echo"<br>People has: " . count($people) . " members";

//switch and rand
$n = 7;
switch($n){
	case 5: echo"<br>n is 5<br>"; break;
	case 7: echo"<br>n is 7<br>"; break;
	case 8: echo"<br>n is 8<br>"; break;
	case 9: echo"<br>n is 9<br>"; break;

	default: echo"<br> Couldn't find the value of n";
}
echo(rand() . "<br>");
echo(rand() . "<br>");
echo(rand(10,100));

//exception handling
try{
	if ($x > 1){
			throw new Exception("X is bigger than 1");
		}
	}
catch(Exception $e){
	echo"<br> caught intentional error: " . $e->getMessage() ."<br>";
} 
// custom exception at bottom
try{
	if ($y != 9){
		throw new customException();
	}
}
catch (customException $e){
	echo $e->Error_msg();
}

//get user input
//typicaly a hmtl form with the inputs is created, a simple form may be:
//<form action="File.php" method="post"> Name: <input type="text" name="name"></form>	
//This form calls the php file when submitted and uses the post method to send its values, 
//the php then uses the $_POST["input_name"] method to get the info, in this exxample it would be $Name = $_POST["name"];

//getting input via forms is better demonstrated in seperate files, see: User_input.html and User_input.php

//set cookies
$someone = "clive";
$cookie_name = "user";
$cookie_value = $someone;
setcookie($cookie_name, $cookie_value, time() + (86400 * 30), "/");

if(!isset($_COOKIE[$cookie_name])) {
	echo "Cookie named '" . $cookie_name . "' is not set!";
  } else {
	echo "Cookie '" . $cookie_name . "' is set! ";
	echo "Value is: " . $_COOKIE[$cookie_name] . "<br>";
  }

//set sessions, these variables are accessable site wide so long as it's open
session_start();
$_SESSION["userFirstName"] ="John";
$_SESSION["userLastName"] ="Smith";
$_SESSION["date"] = date("d/m/Y");
$_SESSION["time"] = date("h:i:sa");
if (isset($_SESSION["userFirstName"])){
	echo"The session user's name is: " . $_SESSION["userFirstName"] . "<br>";
}else {
	echo"The session username is not set<br>";
}
echo"Session time: " . $_SESSION["time"] . " Session date: " . $_SESSION["date"] . "<br>";
$_SESSION["userFirstName"] = "bob";
echo"Session username is now: " . $_SESSION["userFirstName"] . "<br>"; 

sleep(2); echo "The time is now: " . date("h:i:sa") . ", Session time is: " . $_SESSION["time"];//maybe comment this out to not w8 for it
session_unset();
session_destroy();

//making and calling a void function
function SayHello(){
  echo"<br>Hello world!<br>";
}
SayHello();
//making and calling a function that returns
function Add($A = 1, $B = 2){//the = x is a default value	
	$answer = $A+ $B;
	return	$answer;
	//yes, realisticaly this would be return $A + $B;
}
$addition = Add($x,$y);
echo"Result is: $addition";

//custom error handler
class customException extends Exception{
	public function Error_msg(){
		$error_msg = "Error on line " . $this->getLine() . " in " .  $this->getFile() . "this was a custom msg<br>";
		return $error_msg; 
	}
}
?>
