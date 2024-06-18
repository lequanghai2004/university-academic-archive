<!DOCTYPE html>

<head lang="en">
  <meta charset="utf-8">
  <title>Welcome to MySQL</title>
</head>

<body>

  <?php
  require_once("settings.php");
  $dbconn = @mysqli_connect($host, $user, $password, $sql_db);

  if ($dbconn) {
    echo "Successfully Connect";
    $query = "SELECT * FROM Customer";
    $result = mysqli_query($dbconn, $query);
    if ($result->num_rows > 0) {
      while ($row = $result->$fetch_assoc()) {
        echo "CustomerID: " . $row["CustomerID"] . "-Name: " . $row["CustomerName"] . "<br>";
      }
    }
  } else {
    echo "Unsuccessfully Connect";
  }


  ?>

</body>