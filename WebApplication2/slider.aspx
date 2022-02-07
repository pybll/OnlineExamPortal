<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="slider.aspx.cs" Inherits="WebApplication2.slider" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta http-equiv="content-type" content="text/html;charset=utf-8"/>
    <title>Amazing Slider</title>
    
   </head> -->
    <script src="sliderengine/jquery.js"></script>
    <script src="sliderengine/amazingslider.js"></script>
    <script src="sliderengine/initslider-1.js"></script>

</head>
<body>
    <form id="form1" runat="server">
<div style="margin:30px auto;max-width:600px;">
    
       <div id="amazingslider-1" style="display:block;position:relative;margin:16px auto 60px;">
        <ul class="amazingslider-slides" style="display:none;">
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </ul>
        <ul class="amazingslider-thumbnails" style="display:none;">
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>

        </ul>
        <div class="amazingslider-engine" style="display:none;"><a href="http://amazingslider.com">jQuery Slider</a></div>
    </div>
    <!-- End of body section HTML codes -->

    
</div>

    </form>
</body>
</html>
