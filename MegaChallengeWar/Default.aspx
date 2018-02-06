<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MegaChallengeWar.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>War Card Game</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <h3>Play War!</h3>
            </div>
            <div>
                <asp:Button ID="playButton" Text="Play" OnClick="PlayButtonClick" runat="server" />
            </div>
            <br />
            <div>
                <asp:Label ID="battleSummaryLabel" Text="" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
