<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="description" content="Add Car PHP">
  <meta name="keyword" content="PHP, MySQL">
  <title>Retrieving record to HTML</title>
</head>
<body>

<?php
  require_once("settings.php");

  if(!$_POST["submit"]) {
    header("location: addcar.html");
  }

  foreach($_POST as $key => $value) {
    $_POST[$key] = htmlspecialchars($value);
  }

  if(!$conn) {
    echo "<p>Database connection failure</p>";
  } else {
    $sql_table = "cars";
    $make   = trim($_POST["carmake"]);
    $model  = trim($_POST["carmodel"]);
    $price  = trim($_POST["price"]);
    $yom    = trim($_POST["yom"]);

    $query = "INSERT INTO $sql_table (make, model, price, yom) VALUES ('$make', '$model', '$price', '$yom')";

    $result = mysqli_query($conn, $query);
    if(!$result) {
      echo "<p class='wrong'>Something is wrong with $query</p>";
    } else {
      echo "<p class='ok'>Successfully added new car record</p>";
    }

    mysqli_close($conn);
  }


?>

</body>  
</html>