<!--<!DOCTYPE html>-->
<html lang="en">
    <head>
        <meta http-equiv="content-type" content="text/html; charset=UTF-8"> 
        <title>Elbert Dang's CSC 412 Website</title>
        <meta name="generator" content="Bootply" />
        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
        <link href="assets/bootstrap.min.css" rel="stylesheet">
        <link href="assets/style.css" rel="stylesheet">
        <!--[if lt IE 9]>
          <script src="//html5shim.googlecode.com/svn/trunk/html5.js"></script>
        <![endif]-->


        <!-- CSS code from Bootply.com editor -->
        <style type="text/css">

            @media screen and (min-width: 768px) {
                #masthead h1 {
                    font-size: 50px;
                }
            }

            @media (min-width: 979px) {
                #sidebar.affix-top {
                    position: static;
                    margin-top:30px;
                    width:228px;
                }

                #sidebar.affix {
                    position: fixed;
                    top:70px;
                    width:228px;
                }
            }
        </style>
    </head>

    <!-- HTML code from Bootply.com editor -->

    <body  >


        <header class="navbar navbar-default navbar-fixed-top" role="banner">
            <div class="container">
                <div class="navbar-header">
                    <button class="navbar-toggle" type="button" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a href="/~edang" class="navbar-brand active"><strong>Home</strong></a>
                </div>
                <nav class="collapse navbar-collapse" role="navigation">
                    <ul class="nav navbar-nav">
                        <li>
                            <a href="employment.html">Employment</a>
                        </li>

                        <!--<li>
                        <a href="visitorLog.html">Visitors</a>
                        </li>
                        <li>
                            <a href="visitorQuotes.html">Quotes</a>
                        </li>
                        <li>
                            <a href="old/old_index.html">Old site</a>
                        </li>-->
                    </ul>
                </nav>
            </div>
        </header>

        <div id="masthead">  
            <div class="container">
                <div class="row">

                    <div class="col-md-12">
                        <div class="well well-lg"> 
                            <div class="row">
                                <div class="col-sm-2">
                                    <img src="imgs/avatar2.png" class="img-responsive" width="500" height="500">
                                </div>
                                <div class="col-sm-6">
                                    <h1>Elbert Dang's
                                        <p class="lead">CSC 412 Website</p>
                                    </h1>
                                </div>
                            </div>
                        </div>
                    </div>

                </div> 
            </div><!-- /cont -->
        </div>

        <!-- Begin Body -->
        <div class="container">
            <div class="row">
                <div class="col-md-3" id="leftCol">

                    <ul class="nav nav-stacked" id="sidebar">
                        <li><a href="#sec0">About Me</a></li>
                        <li><a href="#sec2">School Projects</a></li>
                        <li><a href="#sec3">Other links</a></li>
                    </ul>

                </div>  
                <div class="col-md-9">
                    <h2 id="sec0">About Me</h2>

                    <hr class="col-md-12">
                    <p>I am recent graduate of San Francisco State University, majoring in Computer Science and Minoring in Mathematics. </p>
                    <p>I received my Bachelor's Degree of Science in Computer Science in the Spring of 2015.</p>
                    <p>I received my Associate's Degree of Arts in Mathematics from Skyline College in the Spring of 2012.</p>
                    <p>I received a Certificate in Computerized Accounting from the ROP Adult School in the Fall of 2008.</p>

                    <hr>
                    <h2 id="sec2">School Projects</h2>
                    <li><a href="http://sfsuswe.com/~s15g10/" target="_blank">PetFriend - CSC648 Software Engineering Final Project</a></li>
                    <li><a href="http://smurf.sfsu.edu/~wob/" target="_blank">Cards of the Wild - CSC631 Multiplayer Game Development Project</a></li>
                    <li><a href="http://mirix5.github.io/processingvideoeditor/" target="_blank"><img src="imgs/PVE.PNG" alt="PVEDefault" width="200" height="150">   Processing Video Editor  </a></li>
                    <li><a href="tankgame.html" target="_blank">Splitscreen Tank Game</a></li>
                    <li><a href="wingman.html" target="_blank">Wingman Game</a></li>

                    <hr class="col-md-12">


                    <h2 id="sec3">Other Links</h2>
                    <div style="float:left; display:inline-block;">
                        <div style="float:left; margin-right: 10px;">
                            <a href="https://github.com/NetNGames" target="_blank">
                                <img src="imgs/logo_GitHub.png" alt="Git" width="64" height="64">
                                <div class="caption">
                                    My Github
                                </div>
                            </a>

                        </div>
                        <div style="float:left;">
                            <a href="https://www.linkedin.com/pub/elbert-dang/91/34b/873" target="_blank">
                                <img src="imgs/logo_In.png" alt="Linked" width="64" height="64">
                                <div class="caption">
                                    My LinkedIn
                                </div>
                            </a>
                        </div>
                    </div>
                </div> 
            </div>
        </div>








        <!-- JavaScript jQuery code from Bootply.com editor -->
        <script type='text/javascript' src="//ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js"></script>
        <script type='text/javascript' src="assets/bootstrap.min.js"></script>
        <script type='text/javascript'>

            $(document).ready(function() {

                $('#sidebar').affix({
                    offset: {
                        top: 235
                    }
                });

                var $body = $(document.body);
                var navHeight = $('.navbar').outerHeight(true) + 10;

                $body.scrollspy({
                    target: '#leftCol',
                    offset: navHeight
                });

                /* smooth scrolling sections */
                $('a[href*=#]:not([href=#])').click(function() {
                    if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
                        var target = $(this.hash);
                        target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
                        if (target.length) {
                            $('html,body').animate({
                                scrollTop: target.offset().top - 50
                            }, 1000);
                            return false;
                        }
                    }
                });

            });

        </script>

        <div id="footer">
            <ul>
                <li><a href="http://bootply.com/100983">Created with Bootstrap Sidebar with Affix and Scrollspy</a></li>
                <!--<li><a href="assets/bootply.html">Download template here</a></li>-->
            </ul>
        </div>
        <?php //include 'assets/footer.php'; ?>
    </body>
</html>