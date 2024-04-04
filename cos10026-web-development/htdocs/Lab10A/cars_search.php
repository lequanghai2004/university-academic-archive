<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="description" content="Creating Web Application Lab10">
  <meta name="keyword" content="PHP, MySQL">
  <title>Retrieving record to HTML</title>
</head>
<body>

<?php
  require_once("settings.php");

  if(!$_POST["submitt"]) {
    header("location: searchcar.html");
  }
  
  foreach($_POST as $key => $value) {
    $_POST[$key] = trim(htmlspecialchars($value));
  }

  if (!$conn) {
    echo "<p>Database connection failure</p>";
  } else {
    $sql_table = "cars";
    $make   = trim($_POST["carmake"]);
    $model  = trim($_POST["carmodel"]);
    $price  = trim($_POST["price"]);

    $sql_search_result = 
      "SELECT * FROM cars
      WHERE make = '$make' 
      AND model = '$model' 
      AND price <= '$price'";
    
    $result = mysqli_query($conn, $sql_search_result);
        
    if(mysqli_num_rows($result) == 0) {
      echo "No result found";
    } else {
      echo "<table border=1>";
      while ($row = mysqli_fetch_assoc($result)) {
        echo "<td>" . $row['make'] . "</td>";
        echo "<td>" . $row['model'] . "</td>";
        echo "<td>" . $row['price'] . "</td>";
        echo "<td>" . $row['yom'] . "</td>";
      }
      echo "</table>";
    }

    mysqli_close($conn);
  }
?>

</body>
</html>