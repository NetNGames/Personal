<html>
    <body>
        
        <?php
        $con = mysqli_connect("setapproject.org", "csc412", "csc412", "csc412");
// Check connection
        if (mysqli_connect_errno()) {
            echo "Failed to connect to MySQL: " . mysqli_connect_error();
        }

// escape variables for security
        $first = mysqli_real_escape_string($con, $_POST['fname']);
        $last = mysqli_real_escape_string($con, $_POST['lname']);
        $email = mysqli_real_escape_string($con, $_POST['email']);

        $sql = "INSERT INTO `csc412`.`testVisitors` (`First Name`, `Last Name`,`Email`)
                VALUES ('$first', '$last','$email')";

        if (!mysqli_query($con, $sql)) {
            die('Error: ' . mysqli_error($con));
        } else {
            echo "Thanks visiting '$first'!\n";
        }
        echo "List of previous visitors:\n";

        $result = mysqli_query($con, "SELECT * FROM testVisitors");
        
        //Sequential List
//        while ($row = mysqli_fetch_array($result)) {
//            echo $row['Quote'] . " " . $row['Quotee'];
//            echo "<br>";
//        }
        
        //Table List
        echo "<table border='1'>
                <tr>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Email</th>
                </tr>";

        while ($row = mysqli_fetch_array($result)) {
            echo "<tr>";
            echo "<td>" . $row['First Name'] . "</td>";
            echo "<td>" . $row['Last Name'] . "</td>";
            echo "<td>" . $row['Email'] . "</td>";
            echo "</tr>";
        }
        echo "</table>";

        mysqli_close($con);
        ?>
    </body>
</html>