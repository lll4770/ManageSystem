<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuManage.aspx.cs" Inherits="ProjectDemo.SystemManage.AuthorizationManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" />
    <f:Panel ID="Panel7" runat="server" BodyPadding="5px" EnableCollapse="true"
            ShowBorder="True" ShowHeader="false"
            Layout="Anchor">
            <%--<Toolbars>
                <f:Toolbar ID="ToolbarCommon" runat="server">
                    <Items>
                        <f:Button ID="btn_modifyPassword" runat="server" CssStyle="margin-left:800px;" Icon="ApplicationEdit" Text="修改密码"></f:Button>
                        <f:Button ID="btn_modifyStyle" runat="server" Icon="ApplicationEdit" Text="主题修改"></f:Button>
                        <f:Button ID="btn_refresh" runat="server" Icon="PageRefresh" Text="页面刷新"></f:Button>
                        <f:Button ID="btn_exit" runat="server" Text="安全退出"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>--%>
            <Items>
                <%--<f:Form ID="Form5" ShowBorder="False" BodyPadding="5px" AnchorValue="100%"
                    ShowHeader="False" runat="server">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:TextBox ID="TextBox5" Label="用户名" runat="server">
                                </f:TextBox>
                                <f:TextBox ID="TextBox8" Label="所在班级" runat="server">
                                </f:TextBox>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:TextBox ID="TextBox6" Label="所在年级" runat="server">
                                </f:TextBox>
                                <f:Button ID="Button11" Text="搜索" runat="server">
                                </f:Button>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>--%>
                <f:Panel ID="Panel8" ShowBorder="True" ShowHeader="false" AnchorValue="100% -68"
                    Layout="Fit" runat="server">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server">
                            <Items>
                                <f:Button ID="btn_add" runat="server" Icon="Add" Text="新增"></f:Button>
                                <f:Button ID="btn_modify" runat="server" Icon="ApplicationEdit" Text="修改" OnClick="btn_modify_Click"></f:Button>
                                <f:Button ID="btn_del" runat="server" Icon="Delete" Text="删除"  ConfirmText="确认删除吗？" OnClick="btn_del_Click"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Items>
                        <f:Grid ID="Grid1" Title="菜单管理"  EnableCollapse="true" PageSize="15" ShowBorder="true" ShowHeader="false"
                            AllowPaging="true" runat="server" 
                            DataKeyNames="MenuId,Name" IsDatabasePaging="true"
                            AllowSorting="true" SortField="Name" SortDirection="ASC" OnPageIndexChange="Grid1_PageIndexChange">
                            <Columns>
                                <f:RowNumberField />
                                <f:BoundField Width="10px" SortField="MenuId" DataField="MenuId" DataFormatString="{0}" HeaderText="菜单ID" Hidden="true"/>
                                <f:BoundField Width="300px" DataField="Name" SortField="MenuName" DataFormatString="{0}"
                                    HeaderText="菜单名称" />
                                <f:BoundField Width="500px" SortField="URL" DataField="URL" HeaderText="菜单Url" />
                                <f:BoundField Width="100px" SortField="OrderId" DataField="OrderId" HeaderText="菜单排序" />
                                <f:BoundField Width="100px" SortField="partentName" DataField="partentName" HeaderText="父菜单" /> 
                                <f:BoundField Width="300px" SortField="valid" DataField="valid" HeaderText="状态" />
                            </Columns>
                        </f:Grid>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <f:Window ID="Window1" IconUrl="~/res/images/16/10.png" runat="server" Hidden="true"
            WindowPosition="Center" IsModal="true" Title="菜单修改" EnableMaximize="true"
            EnableResize="true" Target="Self" EnableIFrame="true"
            Height="500px" Width="650px" OnClose="Window1_Close">
        </f:Window>
    </form>
</body>
</html>
