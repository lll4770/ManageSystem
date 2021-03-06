﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleManage.aspx.cs" Inherits="ProjectDemo.SystemManage.RoleManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" />
    <f:Panel ID="Panel1" runat="server" BodyPadding="5px" EnableCollapse="true"
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
                <f:Form ID="Form5" ShowBorder="False" BodyPadding="5px" AnchorValue="100%"
                    ShowHeader="False" runat="server">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:TextBox ID="txt_roleName" Label="角色名称" runat="server" EmptyText="请输入角色名称">
                                </f:TextBox>
                                <f:Button ID="btn_Search" Icon="SystemSearch" OnClick="btn_Search_Click" Text="搜索" runat="server">
                                </f:Button>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Panel ID="Panel8" ShowBorder="True" ShowHeader="false" AnchorValue="100% -68"
                    Layout="Fit" runat="server">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server">
                            <Items>
                                <f:Button ID="btn_add" runat="server" Icon="Add" Text="新增" OnClick="btn_add_Click"></f:Button>
                                <f:Button ID="btn_modify" runat="server" Icon="ApplicationEdit" Text="修改" OnClick="btn_modify_Click"></f:Button>
                                <f:Button ID="btn_del" runat="server" Icon="Delete" Text="删除"  ConfirmText="确认删除吗？" OnClick="btn_del_Click"></f:Button>
                                <%--<f:Button ID="btn_modifyStatus" runat="server" Icon="LockEdit" Text="修改状态" OnClick="btn_modifyStatus_Click"></f:Button>--%>
                                <f:Button ID="btn_ModifyMenu" runat="server" Icon="ApplicationEdit" Text="修改菜单权限" OnClick="btn_ModifyMenu_Click"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Items>
                        <f:Grid ID="Grid1" Title="角色管理"  EnableCollapse="true" PageSize="15" ShowBorder="true" ShowHeader="false"
                            AllowPaging="true" runat="server" 
                            DataKeyNames="roleID,Name,statusID" IsDatabasePaging="true"  OnPageIndexChange="Grid1_PageIndexChange">
                            <Columns>
                                <f:RowNumberField />
                                <f:BoundField Width="10px" DataField="roleID" SortField="roleID" DataFormatString="{0}"
                                    HeaderText="角色id" Hidden="true" />
                                <f:BoundField Width="300px" DataField="Name" SortField="Name" DataFormatString="{0}"
                                    HeaderText="角色名称" />
                                <f:BoundField Width="300px" SortField="remark" DataField="remark" HeaderText="备注" />
                                <f:BoundField Width="200px" SortField="statusID" DataField="statusremark" HeaderText="状态" />
                            </Columns>
                        </f:Grid>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <f:Window ID="Window1" IconUrl="~/res/images/16/10.png" runat="server" Hidden="true"
            WindowPosition="Center" IsModal="true" Title="角色修改" EnableMaximize="true"
            EnableResize="true" Target="Self" EnableIFrame="true"
            Height="500px" Width="650px" OnClose="Window1_Close">
        </f:Window>
    </form>
</body>
</html>
