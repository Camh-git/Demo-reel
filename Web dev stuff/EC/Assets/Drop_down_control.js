//Get the drop downs and the buttons that open/close them
var Open_btn_1 = document.getElementById("DD_open_1");
var Open_btn_2 = document.getElementById("DD_open_2");
var Open_btn_3 = document.getElementById("DD_open_3");

var Close_btn_1 = document.getElementById("DD_close_1");
var Close_btn_2 = document.getElementById("DD_close_2");
var Close_btn_3 = document.getElementById("DD_close_3");

var Dropdown_1 = document.getElementById("Dropdown_1");
var Dropdown_2 = document.getElementById("Dropdown_2");
var Dropdown_3 = document.getElementById("Dropdown_3");


//Open the dropdown when the user clicks the appropriate box, close it if it's already open
Open_btn_1.onclick = function()
{
	if (window.getComputedStyle(Dropdown_1).display === "none")
	{
	 Dropdown_1.style.display = "block";	
	}
	else if (window.getComputedStyle(Dropdown_1).display === "block")
	{
	 Dropdown_1.style.display ="none";	 
	}
  Deselect();
}
Open_btn_2.onclick = function()
{
	if (window.getComputedStyle(Dropdown_2).display === "none")
	{
	 Dropdown_2.style.display = "block";	 
	}
	else if (window.getComputedStyle(Dropdown_2).display === "block")
	{
	 Dropdown_2.style.display ="none";	 	 
	}
  Deselect();
}
Open_btn_3.onclick = function()
{
	if (window.getComputedStyle(Dropdown_3).display === "none")
	{
	 Dropdown_3.style.display = "block";	
	}
	else if (window.getComputedStyle(Dropdown_3).display === "block")
	{
	 Dropdown_3.style.display ="none";	 
	}
  Deselect();
}
//When the user presses the close button, close the appropriate box
Close_btn_1.onclick = function()
{
	Dropdown_1.style.display = "none";
}
Close_btn_2.onclick = function()
{
	Dropdown_2.style.display = "none";
}
Close_btn_3.onclick = function()
{
	Dropdown_3.style.display ="none";
}
//A deselect function to stop the double click to close causing ugly large selects
function Deselect()
{
 let sel = document.getSelection();
 sel.removeAllRanges();
}