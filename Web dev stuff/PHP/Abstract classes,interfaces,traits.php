<?php
abstract class Vehicle {
    public $Name;
    public $Price;
    public $Mass;
    public $Road_legal;

    public function Drive(){
        echo "<br>". $this->Name . " Says: Brooom. <br>";
    }
}
class Car extends Vehicle{
    public $Seats;
    public $Range;
    function __construct($Name,$Price,$Mass,$Road_legal,$Seats,$Range){
        $this->Name = $Name;
        $this->Price = $Price;
        $this->Mass = $Mass;
        $this->Road_legal = $Road_legal;
        $this->Seats = $Seats;
        $this->Range = $Range;
    }
    use Check_milage;
    use Inspect;
}
class Constuction_vic extends Vehicle implements Use_vic{
    public $Capacity;
    public $Type;
    public $Current_project;
    function __construct($Name,$Price,$Mass,$Road_legal,$Capacity,$Type,$Current_project){
        $this->Name = $Name;
        $this->Price = $Price;
        $this->Mass = $Mass;
        $this->Road_legal = $Road_legal;
        $this->Capacity = $Capacity;
        $this->Type = $Type;
        $this->Current_project = $Current_project;
    }
    function Get_in(){
        echo"The driver climbs up to the cabin, and gets ready for work.<br>";
    }
    function  Use(){
        echo"The driver moves a heavy part of the building into position.<br>";
    }
}
class RaceCar extends Vehicle implements Use_vic{
    public $Top_speed;
    public $Series;
    function __construct($Name,$Price,$Mass,$Road_legal,$Top_speed,$Series){
        $this->Name = $Name;
        $this->Price = $Price;
        $this->Mass = $Mass;
        $this->Road_legal = $Road_legal;
        $this->Top_speed = $Top_speed;
        $this->Series = $Series;
    }
    function Upgrade($i){
        $this->Top_speed = $this->Top_speed + $i;
        echo"<br> The cars top speed is now: " . $this->Top_speed . ".<br>";
    }
    function Get_in(){
        echo"The Driver climbs into the car, straps themself in and gets ready to race.<br>";
    }
    function  Use(){
        echo"The driver races fast and wins the race.<br>";
    }
    use Inspect;
}
interface Use_vic{
    public function Get_in();
    public function Use();
}
trait Check_milage{
    Public function Check_milage($Name){
        echo"<br> You check " . $Name . "'s millage, it's better than you expected.<br>";
    }
}
trait Inspect{
    public function Inspect(){
        echo"<br>You inspect the vehicle and find that everything is as it should be.<br>";
    }
}

$Ford = new Car("Mustang",27155,1662,true,4,305);
echo "ford mustang (2021). " . var_dump($Ford) ."<br><br>";

$Crane = new Constuction_vic("LTM 1450-8.1",300000,500000,true,450,"Crane","None");
echo "Mobile crane (2019). " . var_dump($Crane) ."<br><br>";

$F1 = new Racecar("Mercedes AMG F1 W10",50000000,746,false,246,"F1");
echo "F1 car (2020). " . var_dump($F1) ."<br><br>";
$F1->Drive();
echo "The car's top speed is: " . $F1->Top_speed;
$F1->Upgrade(7);
$Crane->Get_in();
$F1->Get_in();
$Crane->Use();
$F1->use();

$Ford->Check_milage("Mustang");
$Ford->Inspect();
$F1->Inspect();
?>
