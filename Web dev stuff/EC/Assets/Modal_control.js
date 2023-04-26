// Get the modals and the buttons that open them
var modal_1 = document.getElementById("Privacy_modal");
var modal_2 = document.getElementById("FAQ_modal");
var modal_3 = document.getElementById("Cookie_modal");

var btn_1 = document.getElementById("Open_privacy");
var btn_2 = document.getElementById("Open_FAQ");
var btn_3 = document.getElementById("Open_cookies");

// When the user clicks a button, open the appropriate modal 
btn_1.onclick = function()
{
  modal_1.style.display = "block";
}
btn_2.onclick = function()
{
	modal_2.style.display = "block";
}
btn_3.onclick = function()
{
	modal_3.style.display = "block";
}

// When the user clicks anywhere outside of the modal content (the entire screen is covered in the modal), close it
window.onclick = function(event)
{
  if (event.target == modal_1) 
  {
    modal_1.style.display = "none";
  }
  else if(event.target == modal_2)
  {
	  modal_2.style.display = "none";
  }
  else if (event.target == modal_3)
  {
	  modal_3.style.display = "none";
  }  
}