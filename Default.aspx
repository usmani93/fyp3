<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Civic</title>
    <style>
        html, body 
        {
            background: linear-gradient(blue,midnightblue,navy);
            background-repeat:no-repeat;
            text-align:center;
            height:100%;
            width:100%;
        }
        .button 
        {
            text-align:center;
            background-color:white;
            font-family:'Trebuchet MS';
            font-size:30px;
            color:red;
            border:2px solid #000000;
        }
        .button:hover
        {
            color:black;
        }
        .image 
        {
            height:auto;
            width:auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:FileUpload class="button" ID="FileUpload1" runat="server" /><br />
        <asp:Image class="image" ID="Image1" runat="server" /><br />
        <asp:Button class= "button" ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload to Server" /><br />
        <asp:Button class= "button" ID="Button2" runat="server" OnClick="Button2_Click" Text="Detect" />
    
    </div>
        
    </form>
</body>
</html>
