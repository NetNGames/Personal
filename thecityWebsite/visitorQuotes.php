<html>
    <body>
       <!-- Thanks entering the quote: "<?php echo $_POST["quote"]; ?>"<br>
        By: <?php echo $_POST["person"]; ?><br> 
        -->
        
        <?php
        $con = mysqli_connect("setapproject.org", "csc412", "csc412", "csc412");
// Check connection
        if (mysqli_connect_errno()) {
            echo "Failed to connect to MySQL: " . mysqli_connect_error();
        }

// escape variables for security
        $quote = mysqli_real_escape_string($con, $_POST['quote']);
        $person = mysqli_real_escape_string($con, $_POST['person']);

        $sql = "INSERT INTO `csc412`.`testQuotes` (`Quote`, `Quotee`)
                VALUES ('$quote', '$person')";

        if (!mysqli_query($con, $sql)) {
            die('Error: ' . mysqli_error($con));
        } else {
            echo "Thanks entering the quote: '$quote'\n";
            echo "From: '$person'\n";
        }
        echo "List of previous quotes:\n";

        $result = mysqli_query($con, "SELECT * FROM testQuotes");
        
        //Sequential List
//        while ($row = mysqli_fetch_array($result)) {
//            echo $row['Quote'] . " " . $row['Quotee'];
//            echo "<br>";
//        }
        
        //Table List
        echo "<table border='1'>
                <tr>
                <th>Quote</th>
                <th>Quotee</th>
                </tr>";

        while ($row = mysqli_fetch_array($result)) {
            echo "<tr>";
            echo "<td>" . $row['Quote'] . "</td>";
            echo "<td>" . $row['Quotee'] . "</td>";
            echo "</tr>";
        }
        echo "</table>";

        mysqli_close($con);
        ?>
    </body>
</html>