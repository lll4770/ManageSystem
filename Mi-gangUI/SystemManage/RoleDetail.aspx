<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleDetail.aspx.cs" Inherits="Mi_gangUI.SystemManage.RoleDetail" %>

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
                        <f:TextBox runat="server" ID="txt_roleID" Hidden="true">
                        </f:TextBox>
                        <f:TextBox runat="server" Label="角色名称" ID="txt_RoleName" Required="true">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" Label="备注" ID="txt_Remark" >
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:DropDownList runat="server" Label="角色状态" ID="ddl_RoleName">
                        </f:DropDownList>
                    </Items>
                </f:FormRow>
            </Rows>
            <Toolbars>
                <f:Toolbar ID="ToolbarCommon" runat="server" Position="Bottom">
                    <Items>
                        <f:Button ID="btn_save" runat="server" ValidateForms="SimpleForm1" Icon="SystemSave" Text="保存" OnClick="btn_save_Click"></f:Button>
                        <f:Button ID="btn_cancel" runat="server"  Text="取消" Icon="SystemClose" OnClick="btn_cancel_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Form>
    </form>
</body>
</html>
