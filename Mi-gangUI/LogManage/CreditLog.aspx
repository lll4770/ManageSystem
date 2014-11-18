<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreditLog.aspx.cs" Inherits="ProjectDemo.LogManage.CreditLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" />
    <f:Grid ID="Grid1" Title="米币日志"  EnableCollapse="true" PageSize="15" ShowBorder="true" ShowHeader="true"
        AllowPaging="true" runat="server" 
        DataKeyNames="Id,Name" IsDatabasePaging="true" OnPageIndexChange="Grid1_PageIndexChange">
        <Columns>
            <f:RowNumberField />
            <f:BoundField Width="100px" SortField="log_purchaseid" DataField="log_purchaseid" HeaderText="log_purchaseid" />
            <f:BoundField Width="200px" DataField="effectmemberid" SortField="effectmemberid" DataFormatString="{0}"
                HeaderText="影响会员id" />
            <f:BoundField Width="100px" SortField="credites" DataField="credites" HeaderText="米币" />
            <f:BoundField Width="100px" SortField="createDate" DataField="createDate" HeaderText="创建时间" />
        </Columns>
    </f:Grid>
    </form>
</body>
</html>
