<?php
#since this version expects a post it must be called, the intended sender is check_code_and_con.html
$code = "";
try{
    $code =  $_POST["Code"]; 
    if ($code !=""){
        check_code($code);
      }
    } 
catch (Exception  $e) {$code = "";}

$con = 0;
try {
    $con = $_POST["Con"];
    if($con != 0){
            get_candidates($con);
       }
    }
catch (Exception $e){$con = 1;}
sanity_check();

function check_code($code)
{
    $xml = file_get_contents('http://localhost:27732/Code?Code=' . $code);
    echo "Check on code:" . $code . " returned: " . $xml . "<br>";
}
function get_candidates($con)
{
    $xml = file_get_contents('http://localhost:27732/Get_candidates?Con_ID=' . $con);
    echo "Candidates for constituency " . $con . " are as follows: <br>" . $xml;
}

function sanity_check()
{
    $curl = curl_init();
    curl_setopt($curl, CURLOPT_URL,'http://localhost:27732/Sanity');
    $result= curl_exec($curl);
    echo "<br> Sanity check result: " . $result;
}
?>