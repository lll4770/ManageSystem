<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnnounceManage.aspx.cs" Inherits="Mi_gangUI.BusinessManage.AnnounceManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager2" runat="server" />
    <f:Panel ID="Panel1" runat="server" BodyPadding="5px" EnableCollapse="true"
            ShowBorder="True" ShowHeader="false" Layout="Anchor">
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
                                <f:TextBox ID="txt_Name" runat="server" EmptyText="请输入会员名称">
                                </f:TextBox>
                                <f:DropDownList runat="server" Label="公告类型" ID="ddl_AnnounceType" >
                                </f:DropDownList>
                                <f:DatePicker ID="txt_StartDate" runat="server" Label="开始时间" Required="true"></f:DatePicker>
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
                                <f:Button ID="btn_Add" runat="server" Icon="Add" Text="新增"></f:Button>
                                <f:Button ID="btn_modify" runat="server" Icon="ApplicationEdit" Text="修改" OnClick="btn_modify_Click"></f:Button>
                                <f:Button ID="btn_del" runat="server" Icon="Delete" Text="删除"  ConfirmText="确认删除吗？" OnClick="btn_del_Click"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Items>
                        <f:Grid ID="Grid2" Title="用户信息"  EnableCollapse="true" PageSize="15" ShowBorder="true" ShowHeader="true"
                            AllowPaging="true" runat="server" 
                            DataKeyNames="ID" IsDatabasePaging="true"  OnPageIndexChange="Grid2_PageIndexChange">
                            <Columns>
                                <f:RowNumberField />
                                <f:BoundField Width="10px" DataField="ID" SortField="ID" DataFormatString="{0}"
                                    HeaderText="ID" Hidden="true" />
                                <f:BoundField Width="100px" DataField="Value" SortField="Value" DataFormatString="{0}"
                                    HeaderText="公告类型" />
                                <f:BoundField Width="100px" DataField="Name" SortField="Name" DataFormatString="{0}"
                                    HeaderText="会员名称" />
                                <f:BoundField Width="500px" DataField="Content" SortField="Content" DataFormatString="{0}"
                                    HeaderText="公告内容" />
                                <f:BoundField Width="300px" DataField="ValidDateFrom" SortField="ValidDateFrom" DataFormatString="{0}"
                                    HeaderText="开始时间" />
                                <f:BoundField Width="300px" DataField="ValidDateTo" SortField="ValidDateTo" DataFormatString="{0}"
                                    HeaderText="结束时间" />
                            </Columns>
                        </f:Grid>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <f:Window ID="Window1" IconUrl="~/res/images/16/10.png" runat="server" Hidden="true"
            WindowPosition="Center" IsModal="true" Title="用户信息" EnableMaximize="true"
            EnableResize="true" Target="Self" EnableIFrame="true"
            Height="500px" Width="650px" OnClose="Window1_Close">
        </f:Window>
    </form>
</body>
</html>
