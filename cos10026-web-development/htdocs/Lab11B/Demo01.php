<?php
    require_once "setting.php";
    $dbconn = @mysqli_connect($host, $user, $pwd, $sql_db);
    if($dbconn)
    {
        echo "<br> Connect Successfully";
        $sqlString = "CREATE TABLE cars (
            car_id INT,
            model VARCHAR(30), 
            make VARCHAR(25),
            price INT, 
            yom DATE, PRIMARY KEY (car_id))";
            
        $queryResult = @mysqli_query($dbconn, $sqlString);
        if($queryResult)
        {
          echo "<br> Create Car Table Successfully";
        }
        else 
        {
          echo "<br> The table already exists";
        }
    }
    else 
    {
        echo "<br> Connect Unsuccessfully";
    }
    mysqli_close($dbconn)
?>