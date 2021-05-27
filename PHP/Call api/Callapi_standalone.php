<?php
$code = "letmein123"; #deliberately rubish dev code
$con = 1;

check_code($code);
get_candidates($con);
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