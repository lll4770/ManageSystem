<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LevelDetail.aspx.cs" Inherits="Mi_gangUI.BusinessManage.LevelDetail" %>

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
                        <f:TextBox runat="server" ID="txt_ID" Hidden="true">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" Label="等级" ID="txt_Grade" Required="true">
                        </f:TextBox>
                        
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:NumberBox runat="server" Label="大米数" ID="txt_Points" Required="true"></f:NumberBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                         <f:NumberBox runat="server" Label="排序" ID="txt_orderID" Required="true"></f:NumberBox>
                    </Items>
                </f:FormRow>
            </Rows>
            <Toolbars>
                <f:Toolbar ID="ToolbarCommon" runat="server" Position="Bottom">
                    <Items>
                        <f:Button ID="btn_save" runat="server" Icon="SystemSave" ValidateForms="SimpleForm1" Text="保存" OnClick="btn_save_Click"></f:Button>
                        <f:Button ID="btn_cancel" runat="server" Icon="SystemClose" Text="取消" OnClick="btn_cancel_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Form>
    </form>
</body>
</html>
