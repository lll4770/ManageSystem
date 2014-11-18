<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuDetail.aspx.cs" Inherits="Mi_gangUI.SystemManage.MenuDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
        <f:Form ID="SimpleForm1" ShowBorder="false" ShowHeader="false"
            AutoScroll="true" BodyPadding="10px" runat="server">
            <Rows>
                <f:FormRow>
                    <Items>
                        <f:DropDownList runat="server" Label="父菜单" ID="ddl_parentName">
                        </f:DropDownList>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" ID="txt_MenuId" Hidden="true">
                        </f:TextBox>
                        <f:TextBox runat="server" Label="菜单名称" ID="txt_MenuName" Required="true">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" Label="菜单Url" ID="txt_MenuUrl" Required="true">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:NumberBox Label="菜单排序" ID="txt_MenuSort" runat="server" MinValue="0"
                        NoDecimal="true" NoNegative="True" Required="True" ShowRedStar="True" />
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:CheckBox ID="ck_menuValid" ShowLabel="false" runat="server" Text="菜单有效性" Checked="True">
                        </f:CheckBox>
                    </Items>
                </f:FormRow>
                
            </Rows>
            <Toolbars>
                <f:Toolbar ID="ToolbarCommon" runat="server" Position="Bottom">
                    <Items>
                        <f:Button ID="btn_save" runat="server"  Text="保存" Icon="SystemSave" OnClick="btn_save_Click"></f:Button>
                        <f:Button ID="btn_cancel" runat="server"  Text="取消" Icon="SystemClose" OnClick="btn_cancel_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Form>
    </form>
</body>
</html>
