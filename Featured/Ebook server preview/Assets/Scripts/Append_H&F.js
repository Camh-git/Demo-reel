//This is the functional version
function getheader(){	
	var header_container = document.getElementById("header_container");
	var header_file = "Assets/Header.html";
	if (header_file)
	{
		var xhttp = new XMLHttpRequest();		
		xhttp.onreadystatechange = function() {
			if (this.readyState == 4) {
				console.log("Header request state/status: ", this.readyState, this.status);
				if (this.status == 200) {header_container.innerHTML = this.responseText;}
				else if (this.status == 404) {header_container.innerHTML = "Page not found.";}
				else {header_container.innerHTML ="Error fetching header.";}
			}
		}
		xhttp.open("GET", header_file, true);			
		xhttp.send();
		return;						
    }
}

function getfooter(){
	var footer_container = document.getElementById("footer_container");
	var footer_file = "Assets/Footer.html";
	if (footer_file)
	{
		var xhttp = new XMLHttpRequest();		
		xhttp.onreadystatechange = function() {
			if (this.readyState == 4) {
				console.log("Footer request state/status: ", this.readyState, this.status);
				if (this.status == 200) {footer_container.innerHTML = this.responseText;}
				else if (this.status == 404) {footer_container.innerHTML = "Page not found.";}
				else {header_container.innerHTML ="Error fetching footer.";}
			}
		}
		xhttp.open("GET", footer_file, true);
		xhttp.send();
		return;						
    }
}

getheader();
getfooter();
