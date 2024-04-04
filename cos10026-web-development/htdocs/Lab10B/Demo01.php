<?php
    require_once "setting.php";

    $dbconn = @mysqli_connect($host, $user, $pwd, $sql_db);

    if($dbconn )
    {
        $query = "SELECT * FROM `Order`";
        $result = @mysqli_query($dbconn,$query);
        if($result)
        {
            echo "<br> Connect and Query Successfully <br> ";

            if ($result->num_rows > 0) {
                while($row = $result->fetch_assoc()) {
                  echo "OrderID: " . $row["OrderID"]. " - Date: " . $row["OrderDate"]. "<br>";
                }
              } else {
                echo "0 results";
              }
        }
        else
        {
            echo "<br> Only Connect Successfully. Query is failed";
        }
    }
    else 
    {
        echo "<br> Connect Unsuccessfully";
    }
    mysqli_close($dbconn)
?>