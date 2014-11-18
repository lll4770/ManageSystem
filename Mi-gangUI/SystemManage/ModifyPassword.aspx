<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyPassword.aspx.cs" Inherits="Mi_gangUI.SystemManage.ModifyPassword" %>

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
                        <f:TextBox runat="server" ID="txt_userid" Hidden="true">
                        </f:TextBox>
                        <f:TextBox runat="server" ID="txt_baseFlag" Hidden="true">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" Label="新密码" ID="txt_Password" TextMode="Password" Required="true">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" Label="确认密码" ID="txt_RePassword" TextMode="Password" Required="true">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                
            </Rows>
            <Toolbars>
                 <f:Toolbar ID="ToolbarCommon" runat="server" Position="Bottom">
                    <Items>
                        <f:Button ID="btn_save" runat="server" Icon="SystemSave" Text="保存" OnClick="btn_save_Click"></f:Button>
                        <f:Button ID="btn_cancel" runat="server" Icon="SystemClose" Text="取消" OnClick="btn_cancel_Click"></f:Button>
                    </Items>
                     </f:Toolbar>
                </Toolbars>
        </f:Form>
    </form>
</body>
</html>
