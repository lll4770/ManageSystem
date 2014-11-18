<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberAddress.aspx.cs" Inherits="Mi_gangUI.BusinessManage.MemberAddress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" />
    <f:Grid ID="Grid1" Title="会员地址"  EnableCollapse="true" PageSize="15" ShowBorder="true" ShowHeader="false"
        AllowPaging="true" runat="server" 
        DataKeyNames="Id" IsDatabasePaging="true">
        <Columns>
            <f:RowNumberField />
            <f:BoundField Width="10px" SortField="id" DataField="id" HeaderText="id" Hidden="true" />
            <f:BoundField Width="100px" DataField="membername" SortField="memberid" DataFormatString="{0}"
                HeaderText="会员名称" />
            <f:BoundField Width="200px" SortField="address" DataField="address" HeaderText="地址" />
            <f:BoundField Width="200px" SortField="mobile" DataField="mobile" HeaderText="电话号码" />
            <f:BoundField Width="200px" SortField="phone" DataField="phone" HeaderText="手机号" />
            <f:BoundField Width="180px" SortField="contact" DataField="contact" HeaderText="联系方式" />
            <f:BoundField Width="90px" SortField="isdefault" DataField="isdefault" HeaderText="是否默认" />
        </Columns>
    </f:Grid>
    </form>
</body>
</html>
