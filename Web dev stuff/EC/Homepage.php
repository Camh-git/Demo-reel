<html>
 <head>
  <meta charset="utf-8"/>
  <link rel="stylesheet" href="Assets/Stylesheet.css"/>
  <title>Electoral Commision</title>
 </head>
 
<?php
require_once('Assets/Header.html');
?>

<body>
 <div align = "Center">
  <h1>Welcome to the electoral commsion website</h1>
    This is the offical website for the office of her majesty's most honorable and loyal electoral commision, operated by her majesty's government.<br>
    We adminster and oversee all major offical elections in the United Kingdom and conduct investigations into any electoral irregularities.<br>
	<br>
	<?php require_once('Notifications/Permanent_notes/Homepage_notice.inc.html');?><br>
	<?php require_once('Assets/Slideshow.html');?><br>
   
   On this website you can find more information about the electoral commision, including our histroy and responsabilities, vacancies and contact details.<br>
   We also maintain a Regularly updated tracker for all upcoming elections that we are involved in, everything from local councillors and mayors.<br>
   all the way up to the next parilamentary general election can be found on the election info page.<br><br>
   
   <div id = "DD_open_1" class = "Home_text_box">    
	<h2>Register to vote</h2>
   </div>
	 <div id = "Dropdown_1" class ="Home_drop_down">
      <p>In order to vote in the united kingdom you need to be on the electoral register.<br>
      If you where born after 1987 registration should have been done automaticaly on your 18th birthday, if not you may need to register manually.<br>   
      If you are unsure if you are on the register or not you can check with your local authority and register if you haven't already.<br>
      Each  local authority handles their register differently, but you will generaly need some form of I.D in order to check your status or add yourself to the list.<br><br>
      By law registering and checking your status is required to be free, if someone asks you to pay for this service they are almost certainly scammers, we will never call asking you to take action.<br>
      Registers are regularly cleared of people who have not voted in the past 5 consecutive general elections to prevent fraud and to clear the deceased from the rolls,
      if you have not voted in any of the last 5 elections(Currently 2005) you may need to re-register.<br>
      <h3>You must be on the register at least 2 weeks prior to any election you wish to take part in.</h3> 
      <h3>Data losses and computer errors in 2012, 2015 and 2017 erased most of people added in those years, if you are under 31 you should check your status.</h3></p>
       <div id = "DD_close_1"><br><img src ="Assets/Images/Arrow.png" style="width:10%;height:2.5%;"></a></div><br>    
	</div>
	
	<div id = "DD_open_2" class = "Home_text_box">	 
     <h2>Political finance database</h2>
	</div>
	 <div id = "Dropdown_2" class ="Home_drop_down">
	  <p>In order to better oversee elections and ensure fair play the electoral commision maintains a database of political finances.<br>
	  This includes all spending by campaigns, candidates and parties in pursuite of any election, as well as any donation and any third parties with financial intrests in a party.<br>
	  How much a candidate can spend varies depending on the election, for example MP candidates can spend up to £15,000, while a party may spend £22 million across the whole country in a GE.<br><br>
	  All candidates must register with us and submit an expenses report including ALL campaign costs, not just adverts but also transport, refreshments and the likes.<br>
      A candidates report must be a complete and honnest assessment. All candidates must accept investigations into any of their reports.<br>
	  If candidates are found to have lied or gone over budget they may be sanctioned, punishments include fines, repremands, police investigations, disqualification from holding future office, and:</p>
	  <h3> Major violations can lead to disqualification, even after the election has taken place.</h3>
       <div id = "DD_close_2"><br><img src ="Assets/Images/Arrow.png" style="width:10%;height:2.5%;"></a></div><br>  
	 </div>
	
    <div id = "DD_open_3" class = "Home_text_box">	 
     <h2> Registration of campaigns and personel</h2>
	</div>
	 <div id = "Dropdown_3" class ="Home_drop_down">
	  <p>All pollitical parties, campaigns, candidates and associated personel must register with the commision prior to partaking in any democratic activities, failure to do is is a criminal offence.<br>
	  We also designate the lead campaigns in referendums and determine funding grants for them, we provide feedback on the wording of referendums (Based on HMG's proposal), although it is confirmed by parilament.<br>
	  The commission produces guidance and advice on electoral registration for electoral officers in the UK, these guidelines are publicly available and all officers are required to comply with them.<br><br>	 
	  The chair of the commission, or someone appointed by the chair, will also be appointed as Chief Counting Officer, all counting officers are registered with and monitored by the commision.<br>
	  These measures are undertaken to allow us to verify the electoral process and certify the results prior to anouncement.<br>
	  After each election a report is prepared on the administration of the election, the campaigns and their finances, feedback, recomended changes and any irregularities needing investigation.</p>
	  <div id = "DD_close_3"><br><img src ="Assets/Images/Arrow.png" style="width:10%;height:2.5%;"></a></div><br>
	 </div>
	
	<br>
	If you would like to know more feel free to contact us using the information available on the <a href="Contact_us.php">Contact us page.</a>
 <script src ="Assets/Drop_down_control.js"></script>
</body>

<?php
require_once('Assets/Footer.html');
?>
</html>