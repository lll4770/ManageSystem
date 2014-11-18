<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommdityManage.aspx.cs" Inherits="ProjectDemo.CommdityManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" />
    <f:Grid ID="Grid1" Title="商品管理"  EnableCollapse="true" PageSize="15" ShowBorder="true" ShowHeader="true"
        AllowPaging="true" runat="server" 
        DataKeyNames="Id,Name" IsDatabasePaging="true">
        <Columns>
            <f:RowNumberField />
            <f:BoundField Width="200px" DataField="BranchNumber" SortField="BranchNumber" DataFormatString="{0}"
                HeaderText="BranchNumber" />
            <f:BoundField Width="100px" SortField="Price" DataField="Price" HeaderText="价格" />
            <f:BoundField Width="100px" SortField="SecondPrice" DataField="SecondPrice" HeaderText="SecondPrice" />
            <f:BoundField Width="100px" SortField="BuyBouns" DataField="BuyBouns" HeaderText="BuyBouns" />
            <f:BoundField Width="100px" SortField="StatusID" DataField="StatusID" HeaderText="StatusID" />
        </Columns>
    </f:Grid>
    </form>
</body>
</html>
