<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="description" content="Creating Web Application Lab10">
  <meta name="keyword" content="PHP, MySQL">
  <title>Retrieving record to HTML</title>
</head>
<body>

<h1>Creating Web Application</h1>

<?php
  require_once("settings.php");

  if(!$conn) {
    echo "<p>Database connection failure</p>";
  } else {
    //upon successful connection
    $sql_table = "cars";
    //sql command to query or add data to the table
    $query = "SELECT make, model, price FROM $sql_table ORDER BY make, model";
    //execut query and store result into result pointer
    $result = mysqli_query($conn, $query);
    //check if successful
    
    if(!$result) {
      echo "<p>Something went wrong with $query</p>";
    } else {
      //display retrieve records
      
      echo "<table border=1>\n";
      echo "<tr>\n"
        ."<th scope='col'>Make</th>\n"
        ."<th scope='col'>Model</th>\n"
        ."<th scope='col'>Price</th>\n"
        ."</tr>\n";
      //retrieve current record pointed by the result pointer
      while($row = mysqli_fetch_assoc($result)) {
        echo "<tr>\n";
        echo "<td>",$row["make"],"</td>";
        echo "<td>",$row["model"],"</td>";
        echo "<td>",$row["price"],"</td>";
        echo "</tr>\n";
      }
      echo "</table>\n"; 
      //free up memory after using result pointer
    }

    mysqli_close($conn);
  }

?>

</body>
</html>