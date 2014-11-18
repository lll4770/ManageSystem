<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuTree.aspx.cs" Inherits="Mi_gangUI.SystemManage.MenuTree" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" />
        <f:TextBox runat="server" ID="txt_roleID" Hidden="true">
        </f:TextBox>
        <f:Tree ID="Tree1" Width="580px" ShowHeader="false" Title="修改菜单权限"  EnableCollapse="true"
            runat="server" OnNodeCheck="Tree1_NodeCheck">
        </f:Tree>
       
       
        <f:Button ID="btn_save" runat="server"  Text="保存" OnClick="btn_save_Click"></f:Button>
        <f:Button ID="btn_cancel" runat="server"  Text="取消" OnClick="btn_cancel_Click"></f:Button>
           
    </form>
</body>
</html>
