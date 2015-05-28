<html>
    <body>


        <?php
        $con = mysqli_connect("setapproject.org", "csc412", "csc412", "csc412");
// Check connection
        if (mysqli_connect_errno()) {
            echo "Failed to connect to MySQL: " . mysqli_connect_error();
        }

// escape variables for security
        $quote = mysqli_real_escape_string($con, $_POST['quote']);
        $person = mysqli_real_escape_string($con, $_POST['person']);

        $result = mysqli_query($con, "SELECT * FROM testQuotes
                    WHERE Quote='" . $quote . "'");

       // echo  "$result1";
        while ($row = mysqli_fetch_array($result)) {
            echo $row['$quote'] . " " . $row['$person'];
            echo "<br>";
        }
        $result2 = mysqli_query($con, "SELECT * FROM testQuotes
                    WHERE Quotee='" . $person . "'");

        while ($row = mysqli_fetch_array($result2)) {
            echo $row['$quote'] . " " . $row['$person'];
            echo "<br>";
        }
        mysqli_close($con);
        ?>
    </body>
</html>