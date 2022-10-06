<html>
<?php
require_once('header.php');
?>
<title>News</title>
<div align = "center">
<h3>News</h3>
Welcome to the news page, here you can find the latest news about everything to do with space.<br>
The page currently shows the three latest stories with an archive of stories coming soon.<br>
Should you spot anything wrong or want to contact us with feedback you can do so at the contact us page.<br><br>

</div>
<div id = "news_item" align = "center">
<div id = "news_image"><img src ="images/Spacex.jpg" style = "margin-top:20%; width:100%;height:100%"></div>
<h3>Spacex re-launches a rocket.</h3><br>
 Today SpaceX reached a major milestone in their plans to develop re-useable rockets when a recovered falcon 9 rocket launched for a second time. Having already launched a dragon spacecraft as part of the CRS8 mission, it was used to launch the SES-10 communication satellite before landing for a second time.
</div>
<div id = "news_item" align = "center">
<div id = "news_image"><img src ="images/Cassini.jpg" style = "margin-top:20%; width:100%;height:100%"></div>
<h3>Cassini starts it's grand finale.</h3><br>
After nearly 13 years around saturn the cassini spacecraft has completed it's mission and begun it's "grand finale"(as nasa describes it), having flown around the moon Titan it passed through saturn's rings on it's way to a collision with the gas giant on the 15th of september this year, just shy of 20 years after launch.
</div>
<div id = "news_item" align = "center">
<div id = "news_image"><img src ="images/JWST.jpg" style = "margin-top:20%; width:100%;height:100%"></div>
<h3>James web space telescope leaves goddard.</h3><br>
Nasa's succesor to hubble, the james webb space telescope has passed all major tests at the goddard space flight center, these included thermal and optical tests to ensure it will function in space and vibration and acoustic testing to ensure it can survive it's launch, which will occur next year aboard an ESA Ariane 5 rocket after further testing in houston, texas.
</div>

<?php
// Insert the footer page
include('footer.php');
?>

</html>