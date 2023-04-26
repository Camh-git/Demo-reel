var slideIndex = 0;
showSlides();

function showSlides()
{
  //Declare vars, inc arrays containing the dots and images
  var i;
  var slides = document.getElementsByClassName("mySlides"); 
 
  //Hide every item in slides, which is every item using the "mySlides" css class
  for (i = 0; i < slides.length; i++)
  {
    slides[i].style.display = "none";  
  }
  slideIndex++;
  if (slideIndex > slides.length)
  {slideIndex = 1}   
  
  slides[slideIndex-1].style.display = "block";    
  setTimeout(showSlides, 5000); // Change image every 2 seconds
}
