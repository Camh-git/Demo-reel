var xmlhttp = new XMLHttpRequest();
xmlhttp.onreadystatechange = function() {
    if (this.readyState == 4 && this.status == 200) {
        var myObj = JSON.parse(this.responseText);
    
    }
}
xmlhttp.open("GET", "Ship_page_content.json", true);
xmlhttp.send();