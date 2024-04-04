<!DOCTYPE html>
<html>
    <p> Please Input the Information to Update Cars </p>
    <form method = "post" action = "Demo03.php">
        <br><label for="car_id">Card ID:</label> <input type="text" name="car_id"><br>
        <br><label for="model">Model :</label> <input type="text" name="model"><br>
        <br><label for="make">Make :</label> <input type="text" name="make"><br>
        <br><label for="price">Price :</label> <input type="text" name="price"><br>
        <br><label for="yom">YOM :</label> <input type="text" name="yom"><br>
        <br>
        <input type="submit" name = "btnSelect" value="Select">
        <input type="submit" name = "btnUpdate" value="Update">
        <input type="submit" name = "btnDelete" value="Delete">
        <input type="submit" name = "btnInsert" value="Insert">
    </form>
    <br> <hr>
    <?php
        require_once "setting.php";
        $dbconn = @mysqli_connect($host, $user, $pwd, $sql_db);
    ?>
    <?php
        if($dbconn)
        {
            $CarID = $_POST["car_id"];
            $Model = $_POST["model"];
            $Make = $_POST["make"];
            $Price = $_POST["price"];
            $yom = $_POST["yom"];

            if (isset($_POST['btnSelect']))
            {
                echo "Select";
            }
            if (isset($_POST['btnUpdate']))
            {
                echo "Update";
            }
            if (isset($_POST['btnDelete']))
            {
                echo "Delete";
            }
            if (isset($_POST['btnInsert']))
            {
                echo "Insert";
                $query = "INSERT INTO cars (car_id, model, make, price, yom)
                VALUES($CarID, '$Model', '$Make', $Price, '$yom')";
                $result = @mysqli_query($dbconn, $query);
                if($result)
                {
                  echo "<p>Insert operation successful.</p>";
                }
                else
                {
                  echo "<p>Insert operation unsuccessful.</p>"; 
                }
            }
        }
    ?>
    <?php  
        if($dbconn)
        {
            $sqlQuery = "SELECT car_id, make, model, price, yom FROM cars"; 
            $results = mysqli_query($dbconn, $sqlQuery);
            if ($results) {
                echo "<table border='1'>";
                echo "<tr>
                        <th> ID </th>
                        <th> Make </th>
                        <th> Model</th>
                        <th>Price</th>
                        <th>Yr of Manufacture</th>
                     </tr>";
                $record = mysqli_fetch_assoc ($results);
                while ($record){
                    echo "<tr><td>{$record['car_id']}</td>";
                    echo "<td>{$record['make']}</td>";
                    echo "<td>{$record['model']}</td>";
                    echo "<td>{$record['price']}</td>";
                    echo "<td>{$record['yom']}</td></tr>";
                    $record = mysqli_fetch_assoc($results);
                }
            }
        }
        else 
        {
            echo "<br> Connect Unsuccessfully";
        }
        mysqli_close($dbconn)
    ?>
</html>