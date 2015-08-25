<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GetNextTask2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="1">
                <tr>
                    <td colspan="7">Procedure Name : <b>LwkfproGetNextTask</b> 
                    </td>
                </tr>
                <tr>
                    <td><b>Column Name</b></td>
                    <td>Entity Type</td>
                    <td>Entity ID</td>
                    <td>Function Type</td>
                    <td>Lock ID</td>
                    <td>Lock Acquired</td>
                    <td>Lock Expired</td>
                </tr>
                <tr>
                    <td><b>Result</b></td>
                    <td><asp:Label ID="lblentityType" runat="server"></asp:Label></td>
                    <td><asp:Label ID="lblentityId" runat="server"></asp:Label></td>
                    <td><asp:Label ID="lblfunctionType" runat="server"></asp:Label></td>
                    <td><asp:Label ID="lbllockId" runat="server"></asp:Label></td>
                    <td><asp:Label ID="lbllockAcquired" runat="server"></asp:Label></td>
                    <td><asp:Label ID="lbllockExpired" runat="server"></asp:Label></td>
                </tr>                
            </table>
        </div>
        <p></p>
        <div>
            <table border="1">
                <tr>
                    <td colspan="2">Procedure Name : <b>wkfconItemIDFromMIN</b></td>
                </tr>
                <tr>
                    <td><b>Column Name</b></td>
                    <td>Item ID </td>                    
                </tr>
                <tr>
                    <td><b>Result</b></td>
                    <td><asp:Label ID="lblitemId" runat="server"></asp:Label></td>                   
                </tr>
            </table>
        </div>
        <p></p>
        <div>
            <table border="1">
                <tr>
                    <td colspan="2">Procedure Name : <b>wkfconPublicationIDFromMIN</b></td>
                </tr>
                <tr>
                    <td><b>Column Name</b></td>
                    <td>Entity ID For Min</td>                    
                </tr>
                <tr>
                    <td><b>Result</b></td>
                    <td><asp:Label ID="lblentityIdForMin" runat="server"></asp:Label></td>                   
                </tr>
            </table>
        </div>
        <p></p>
        <div>
            <table border="1">
                <tr>
                    <td colspan="2">Procedure Name : <b>wkfconFunctionTypeNameFromID</b></td>
                </tr>
                <tr>
                    <td><b>Column Name</b></td>
                    <td>Function Type</td>                    
                </tr>
                <tr>
                    <td><b>Result</b></td>
                    <td><asp:Label ID="lblRefFunctionType" runat="server"></asp:Label></td>                   
                </tr>
            </table>
        </div>
        <p></p>
        <div>
            <table border="1">
                <tr>
                    <td colspan="4">Procedure Name : <b>fralokLockSteal</b></td>
                </tr>
                <tr>
                    <td><b>Column Name</b></td>
                    <td>stealLockId</td>                    
                    <td>stealLockAcquired</td>                    
                    <td>StealLockTimeout</td>                    
                </tr>
                <tr>
                    <td><b>Result</b></td>
                    <td><asp:Label ID="lblstealLockId" runat="server"></asp:Label></td>
                    <td><asp:Label ID="lblstealLockAcquired" runat="server"></asp:Label></td>
                    <td><asp:Label ID="lblStealLockTimeout" runat="server"></asp:Label></td>                   
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
