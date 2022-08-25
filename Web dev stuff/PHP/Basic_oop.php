<?php
class Person{
    public $name;
    public $age;
    public $address;
    #public = scriptwide, protected = this class and derived classes, private = only this class, can also apply to methods

    //Methods
    function __construct($name,$age,$address){
        $this->name = $name;
        $this->age = $age;
        $this->address = $address;
    }
    function __destruct(){
        echo"<br>Closing " . $this->name . "<br>";
    }
    function set_name($name){
        $this->name = $name;
    }
    function set_age($age){
        $this->age = $age;
    }
    function set_address($address){
        $this->address = $address;
    }
    function get_name(){
        return $this->name;
    }
    function get_age(){
        return $this->age;
    }
    function get_address(){
        return $this->address;
    }
    public static function Say_hello($name){
    echo"<br> Hello: " . $name;
    }
    public static $Species = "Human";
 
} 
  
final class Car_owner extends Person{
    public $Car_name;
    const msg = "This person owns a car";
    function __construct($name,$age,$address,$carName){
        $this->name = $name;
        $this->age = $age;
        $this->address = $address;
        $this->Car_name = $carName;
    }
    #you can also overwrite inherited methods
    function set_car_name($carName){        
        $this->Car_name = $carName;
    }
    function get_car_name(){
        return $this->Car_name;
    }
}

//creating and setting an obj manualy (params needed to satisfy the constructor that was added later)
$Person_1 = new Person("Abe",0,"nowhere");
$Person_1->set_name('Bob');
$Person_1->set_age(32);
$Person_1->address = "someplace";

echo $Person_1->get_name() . "<br>";
echo $Person_1->age;
var_dump($Person_1 instanceof Person);
echo "<br>" . $Person_1->address;


$Person_2 = new Car_owner("Charlie",37,"A house","volvo");
echo "<br> person 2 is called: " . $Person_2->name . " and they own a: " . $Person_2->Car_name;
$Person_2->name = "Alice";
echo "<br>Person 2 is now called: " . $Person_2->name;
echo "<br>" . $Person_2::msg;
Person::Say_hello($Person_2->name);
echo "<br> These people are: " . Person::$Species;
?>
