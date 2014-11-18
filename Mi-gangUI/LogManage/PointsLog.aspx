<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PointsLog.aspx.cs" Inherits="ProjectDemo.LogManage.PointsLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" />
    <f:Grid ID="Grid1" Title="大米日志"  EnableCollapse="true" PageSize="15" ShowBorder="true" ShowHeader="true"
        AllowPaging="true" runat="server" 
        DataKeyNames="Id,Name" IsDatabasePaging="true" OnPageIndexChange="Grid1_PageIndexChange">
        <Columns>
            <f:RowNumberField />
            <f:BoundField Width="100px" SortField="UserName" DataField="memberid" HeaderText="用户名称" />
            <f:BoundField Width="200px" DataField="Cause" SortField="Cause" DataFormatString="{0}"
                HeaderText="使用原因" />
            <f:BoundField Width="200px" SortField="result" DataField="result" HeaderText="结果" />
        </Columns>
    </f:Grid>
    </form>
</body>
</html>
