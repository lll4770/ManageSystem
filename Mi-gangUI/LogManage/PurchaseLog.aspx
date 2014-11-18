<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseLog.aspx.cs" Inherits="ProjectDemo.LogManage.PurchaseLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" />
    <f:Grid ID="Grid1" Title="消费日志"  EnableCollapse="true" PageSize="15" ShowBorder="true" ShowHeader="true"
        AllowPaging="true" runat="server" 
        DataKeyNames="Id,Name" IsDatabasePaging="true" OnPageIndexChange="Grid1_PageIndexChange">
        <Columns>
            <f:RowNumberField />
            <f:BoundField Width="100px" SortField="UserName" DataField="UserName" HeaderText="用户名称" />
            <f:BoundField Width="100px" DataField="CommodifyID" SortField="CommodifyID" DataFormatString="{0}"
                HeaderText="CommodifyID" />
            <f:BoundField Width="100px" SortField="Quantity" DataField="Quantity" HeaderText="数量" />
            <f:BoundField Width="100px" SortField="CreateDate" DataField="CreateDate" HeaderText="创建时间" />
            <f:BoundField Width="100px" SortField="IsCreditsDone" DataField="IsCreditsDone" HeaderText="是否使用" />
        </Columns>
    </f:Grid>
    </form>
</body>
</html>
