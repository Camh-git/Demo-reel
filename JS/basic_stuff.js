//IF CHANGES DONT APEAR MAKE SURE THE BROWSER IS NOT RUNNING AN OLD CACHED VERSION OF THE SCRIPT

//declaring than setting vars
var x,y,z;
x=2;
y=3;
z = x+y;
var az = 5;
//let v var: var is accessaable throught the whole function at any point(thanks hoisting), let is visible only in its block and is not hoisted

var a = "apple" ;
var b = Boolean('false');
var wanaBeNum = "3.14";

//data types/conversions
typeof z;
String(az); //convert num,bool or date to string
Number(wanaBeNum); //also converts bools to 0(false) or 1(true) or dates to their unix time int
parseFloat(wanaBeNum); 
parseInt(wanaBeNum);
//the 5 data types that have values: string, num, bool, obj, function
//the 6 types of object:Object, Date, Array, String, Number, Boolean
//remember if js thinks a var is the wrong type it will try to make it "right", see true + true = 2, so make sure u convert properly

//arrays
//call the array numbers
fruits =["apples","pears","oranges","bananas"];
numbers = [5,3,2,9,6,7,1,4,8];

//importing/getting objects
//making an object:
var person = {firstName:"John", lastName:"Smith", age:36, hairColor:"brown", fullName : function() {return this.firstName + " " + this.lastName;}};
console.log("the person: " + person.firstName + " " + person.lastName + " is " + person.age + " and has " + person.hairColor + " hair.");
console.log ("the persons full name is: " + person.fullName());
//geting it from another script: make it, go to other script then function/obj name.attribute or obj name if its solo

//for loop
for (i = 0; i < 5; i++) {
  var text = "The number is " + i + "<br>";
}
for (i in numbers){
	if (i !=0){
		console.log(i);
		}else {
			continue; //loops over and goes to the next iteration, where break exits the loop
		}
}
for (let x of fruits){
	console.log(x);
}
for (let x of a){ //loop over a string
 	console.log(x + "     ");
}

// if statement
if (a = "apple"){
	console.log("a is what you expected");
} else {
	console.log("a is not what you expected");
}
//switch
switch(z){
	case 5: console.log("z=5");break;
	case 3: console.log("z=3");break;
	case 2: console.log("z=2");break;
	
	default:
	  console.log("z is not 2,3, or 5");
}

//error handling
try {
	divByZero = 0/5;
} catch{
	console.log("Couldnt do the try contents");
	//throw "Bad maths"; 
} //final 
	

//calling a method
write_text();

//inputs
// you can get html elements, script content, forms, buttons and more, for a more complete list: https://www.w3schools.com/js/js_input_examples.asp
//button, in hmtl <input type="button" onclick="function()" value="Btn text">, buttons can be disabled

// outputs (most of these will need to be inserted into an html element to show (see bellow))
console.log("");
//alert("Hello!, this is an alert!!");
document.write(2 + 3 + ", this is from doc.write");//note:using this after loading will delete all the previous html, use dom insert to add content
console.log("an example error message");
// in html: <button onclick="window.print()">Print this page</button> to print a page

//insert into/edit html
var stuff = document.createTextNode("welcome");
document.getElementById("content").appendChild(stuff);

//dates
var day = new Date();
var days = new Date("October 13, 2014 11:13:00");
//formating: var d = new Date(2018(y), 11(mo), 24(d), 10(h), 33(mi), 30(s), 0(ms));
//notes: months are 0-11, two digit years are 19XX (y2k lol),
//alt you can do Date(int) for millseconds since unix zero time
//usefull methods: .toUTCString(); , .toDateString(); , .toISOString();

//calling external scripts
// in the html page <script src="Script.js">also any method</script>

function write_text() {
 //see simple return, calling a method from inside a sript is methodname(values);
}

//IF CHANGES DONT APEAR MAKE SURE THE BROWSER IS NOT RUNNING AN OLD CACHED VERSION OF THE SCRIPT
