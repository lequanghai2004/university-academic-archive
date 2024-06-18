<?php
    require_once "setting.php";
    $dbconn = @mysqli_connect($host, $user, $pwd, $sql_db);
    if($dbconn)
    {
        echo "<br> Connect Successfully";

        $query = "INSERT INTO cars (car_id, model, make, price, yom)
        VALUES(1, 'BWM', 'Germany', 100000, '2023-03-29')";
        $result = @mysqli_query($dbconn, $query);
        if($result)
        {
          echo "<p>Insert operation successful.</p>";
        }
        else
        {
          echo "<p>Can not insert the duplicate Car_id.</p>"; 
        }

        $query = "UPDATE cars SET price = 300000, yom = '2023-03-28' WHERE car_id = 1";
        $result = @mysqli_query($dbconn, $query);
        if($result)
        {
          echo "<p>Update operation successful.</p>";
          echo "<br> Result : " . mysqli_affected_rows($dbconn) . " records affected ";
        }
        else
        {
          echo "<p>Update operation unsuccessful.</p>"; 
        }
        
        // try{
        //     $query = "INSERT INTO cars (car_id, model, make, price, yom)
        //     VALUES(1, 'BWM', 'Germany', 100000, '2023-03-29')";
        //     $result = @mysqli_query($dbconn, $query);
        //     // $cal = 1/0;
        //     echo "<br> Do Successfully";
        // }
        // catch (Exception $e){
        //     echo "Something Wrong";
        // }
    }
    else 
    {
        echo "<br> Connect Unsuccessfully";
    }
    mysqli_close($dbconn)
?>