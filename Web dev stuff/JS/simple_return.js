console.log("called simple return");
function write_stuff(){
	alert("This is from simple return \n" + location.hostname);
	console.log("write_stuff got called");
}
write_stuff();

//IF CHANGES DONT APEAR MAKE SURE THE BROWSER IS NOT RUNNING AN OLD CACHED VERSION OF THE SCRIPT
