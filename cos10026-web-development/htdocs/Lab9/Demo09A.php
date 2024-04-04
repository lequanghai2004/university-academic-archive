<!DOCTYPE html>
<html>
    <head>
        <title> PHP Programming Language </title>
    </head>
    <body>
        <?php
            session_set_cookie_params(3600);
            session_start();
            require("Banner.html");
            include_once("Demo09A.html");

            $_SESSION['firstName'] = "John";
            $_SESSION['lastName'] = "Smith";
            $_SESSION['occupation'] = "singer";

            $fname = "Mr";
            $lname = "Alex";
            $occ = "Employee";
        ?> 

        <a href="Demo09C.php?
            firstName=<?php echo $fname; ?>
            &lastName=<?php echo $lname; ?>
            &occupation=<?php echo $occ; ?>">
            <?php echo "Contact : ", $fname, " ", $lname; ?>
        </a>
        <p>
        <a href='<?php echo "Demo09D.php?PHPSESSID=". session_id() ?>'>Show SessionID</a>
        </p>

        <form method="post" action="Demo09B.php" >
            <label>User Name</label>
            <input type="text" name="uname" placeholder="User Name"><br>
            <label>Password</label>
            <input type="password" name="password" placeholder="Password"><br> 
            <input type="hidden" name="status" value="First Login" />
            <button type="submit">Login</button>
        </form>

        <p> Here are some products in my shop : 
            <ol>
                <li> Iphone </li>
                <li> Samsung </li>
                <li> Mac Laptop </li>
            </ol>
        </p>
    </body>
</html>