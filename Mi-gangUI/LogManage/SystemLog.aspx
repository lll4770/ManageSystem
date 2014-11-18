<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemLog.aspx.cs" Inherits="ProjectDemo.LogManage.SystemLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" />
    <f:Grid ID="Grid1" Title="系统日志"  EnableCollapse="true" PageSize="15" ShowBorder="true" ShowHeader="true"
        AllowPaging="true" runat="server" 
        DataKeyNames="Id,Name" IsDatabasePaging="true" OnPageIndexChange="Grid1_PageIndexChange">
        <Columns>
            <f:RowNumberField />
            <f:BoundField Width="200px" DataField="tablename" SortField="Table" DataFormatString="{0}"
                HeaderText="表名" />
            <f:BoundField Width="100px" SortField="field" DataField="Field" HeaderText="字段" />
            <f:BoundField Width="100px" SortField="PreValue" DataField="PreValue" HeaderText="先前值" />
            <f:BoundField Width="100px" SortField="CurrentValue" DataField="CurrentValue" HeaderText="当前值" />
            <f:BoundField Width="100px" SortField="ModifyUserID" DataField="ModifyUserID" HeaderText="修改人" />
            <f:BoundField Width="100px" SortField="ModifyDateTime" DataField="ModifyDateTime" HeaderText="修改时间" />
        </Columns>
    </f:Grid>
    </form>
</body>
</html>
