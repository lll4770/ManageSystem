<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreditsExchangeLog.aspx.cs" Inherits="ProjectDemo.LogManage.CreditsExchangeLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" />
    <f:Grid ID="Grid1" Title="提现日志"  EnableCollapse="true" PageSize="15" ShowBorder="true" ShowHeader="true"
        AllowPaging="true" runat="server" 
        DataKeyNames="Id,Name" IsDatabasePaging="true" OnPageIndexChange="Grid1_PageIndexChange">
        <Columns>
            <f:RowNumberField />
            <f:BoundField Width="100px" SortField="UserName" DataField="memberid" HeaderText="用户名称" />
            <f:BoundField Width="100px" DataField="Year" SortField="Year" DataFormatString="{0}"
                HeaderText="年份" />
            <f:BoundField Width="100px" SortField="Month" DataField="Month" HeaderText="月份" />
            <f:BoundField Width="100px" SortField="Credits" DataField="Credits" HeaderText="米币" />
            <f:BoundField Width="100px" SortField="IsComplete" DataField="IsComplete" HeaderText="是否完成" />
            <f:BoundField Width="100px" SortField="CompleteDateTime" DataField="CompleteDateTime" HeaderText="完成时间" />
        </Columns>
    </f:Grid>
    </form>
</body>
</html>
