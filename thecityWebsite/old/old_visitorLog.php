<html>
    <body>
        Thanks for visiting <?php echo $_POST["fname"]; ?> <?php echo $_POST["lname"]; ?>!<br>
        Past visitors:<br>
        <?php
        class Visitor{
            public $firstname;
            public $lastname;
            public $email;
        }
        ?>
    </body>
</html>