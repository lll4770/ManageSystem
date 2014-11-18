<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberDetail.aspx.cs" Inherits="Mi_gangUI.BusinessManage.MemberDetail" %>

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
                        <f:TextBox runat="server" ID="txt_memberID" Hidden="true">
                        </f:TextBox>
                        <f:TextBox runat="server" ID="txt_InviterID" Hidden="true">
                        </f:TextBox>
                        <f:TextBox runat="server" ID="txt_leftID" Hidden="true">
                        </f:TextBox>
                        <f:TextBox runat="server" ID="txt_TopID" Hidden="true">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" Label="会员名称" ID="txt_Name" Required="true" ShowRedStar="true">
                        </f:TextBox>
                        <f:TextBox runat="server" Label="真实姓名" ID="txt_RealName" Required="true" ShowRedStar="true">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" Label="会员代码" ID="txt_Code" Required="true" ShowRedStar="true">
                        </f:TextBox>
                        <f:TextBox runat="server" Label="会员密码" ID="txt_Password" Required="true" ShowRedStar="true">
                        </f:TextBox>
                        
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" Label="邮箱" ID="txt_Mail" Required="true" ShowRedStar="true">
                        </f:TextBox>
                        <f:TextBox runat="server" Label="微信" ID="txt_WeChat" Required="true" ShowRedStar="true">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" Label="购买商品" ID="txt_BuyCommodity">
                        </f:TextBox>
                        <f:TextBox runat="server" Label="购买商品月份" ID="txt_BuyCommodityMonth">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:NumberBox runat="server" Label="大米数" ID="txt_Points"></f:NumberBox>
                        <f:NumberBox runat="server" Label="米币数" ID="txt_Credits"></f:NumberBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:DropDownList runat="server" Label="会员状态" ID="ddl_Status" ShowRedStar="true">
                        </f:DropDownList>
                        <f:DropDownList runat="server" Label="会员类型" ID="ddl_MemberType" ShowRedStar="true">
                        </f:DropDownList>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" Label="银行" ID="txt_Bank" Required="true" ShowRedStar="true">
                        </f:TextBox>
                        <f:TextBox runat="server" Label="账户" ID="txt_BankAccount" Required="true" ShowRedStar="true">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" Label="帐号" ID="txt_BankNumber" Required="true" ShowRedStar="true">
                        </f:TextBox>
                        <f:TextBox runat="server" Label="身份证号" ID="txt_IdentityNumber" >
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" EnableBlurEvent="true" ID="txt_InviterName" Label="邀请会员" OnBlur="txt_InviterName_Blur">
                        </f:TextBox>
                        <f:TextBox runat="server" EnableBlurEvent="true" ID="txt_leftMember" Label="左边会员" OnBlur="txt_leftMember_Blur">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" Label="手机号码" ID="txt_CellPhone" >
                        </f:TextBox>
                        <f:TextBox runat="server" EnableBlurEvent="true" ID="txt_TopMember" Label="上级会员" OnBlur="txt_TopMember_Blur">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:FileUpload runat="server" ID="txt_IdentityPic" EmptyText="请选择一张照片" Label="个人头像">
                        </f:FileUpload>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:FileUpload runat="server" ID="txt_AgreementPic" EmptyText="请选择一张照片" Label="扫描件">
                        </f:FileUpload>
                        
                    </Items>
                </f:FormRow>
            </Rows>
            <Toolbars>
                <f:Toolbar ID="ToolbarCommon" runat="server" Position="Bottom">
                    <Items>
                        <f:Button ID="btn_save" runat="server" ValidateForms="SimpleForm1" Text="保存" OnClick="btn_save_Click"></f:Button>
                        <f:Button ID="btn_cancel" runat="server"  Text="取消" OnClick="btn_cancel_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Form>
    </form>
</body>
</html>
