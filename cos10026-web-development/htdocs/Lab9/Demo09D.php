<?php 
    session_start();
    $SessionID = $_GET["PHPSESSID"];

    echo "<br> $SessionID";

    echo "<br>".$_SESSION['firstName'];
    echo "<br>".$_SESSION['lastName'];
    echo "<br>".$_SESSION['occupation'];
?>