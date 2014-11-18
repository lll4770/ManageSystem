<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Mi_gangUI.Index" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>米缸直销平台后台管理</title>
    <style>
        body.f-theme-neptune .header {
            background-color: #005999;
            border-bottom: 1px solid #1E95EC;
        }

            body.f-theme-neptune .header .x-panel-body {
                background-color: transparent;
            }

            body.f-theme-neptune .header .title a {
                font-weight: bold;
                font-size: 24px;
                text-decoration: none;
                line-height: 50px;
                margin-left: 10px;
            }
        .center
        {
            text-align:center;
            margin-left: auto;
            margin-right: auto;
        }
        .cssRgiht
        {
            margin-left:1000px;
            line-height: 50px;
        }

        
        #header {
            position: relative;
            border-bottom-width: 2px;
            border-bottom-style: solid;
            padding: 8px 12px 6px;
        }

            #header a.logo {
                display: inline-block;
                margin-right: 5px;
            }

            #header a.title {
                font-weight: bold;
                font-size: 24px;
                text-decoration: none;
                line-height: 30px;
                color: #fff;
            }


            #header .themeroller {
                position: absolute;
                top: 10px;
                right: 10px;
            }

                #header .themeroller a {
                    font-size: 20px;
                    text-decoration: none;
                    line-height: 30px;
                    color: #fff;
                }



        .f-theme-neptune #header {
            background-color: #005999;
            border-bottom: 1px solid #1E95EC;
        }

            .f-theme-neptune #header .title a {
                color: #fff;
            }

        .f-theme-blue #header {
            background-color: #004BA8;
            border-bottom: 1px solid #034699;
        }

            .f-theme-blue #header .title a {
                color: #fff;
            }

        .f-theme-gray #header {
            background-color: #d3d3d3;
            border-bottom: 1px solid #bab9b9;
        }

            .f-theme-gray #header .title a {
                color: #333;
            }

        .f-theme-access #header {
            background-color: #343b48;
            border-bottom: 1px solid #1f232b;
        }

            .f-theme-access #header .title a {
                color: #fff;
            }



        #logo {
            position: absolute;
            bottom: 20px;
            right: 0;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            opacity: 0.8;
            z-index: 100000;
        }


        .f-theme-access .maincontent .x-panel-body {
            background-image: none;
        }

        .isnew {
            color: red;
        }

        .bottomtable {
            width: 100%;
            font-size: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>
        <f:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
            <Regions>
                <f:Region ID="Region1" ShowBorder="false" Height="50px" ShowHeader="false"
                    Position="Top" Layout="Fit" runat="server">
                    <Items>
                        <f:ContentPanel ShowBorder="false" ShowHeader="false" ID="ContentPanel1" CssClass="header"
                            runat="server">
                            <div id="header">
                                <table>
                                    <tbody><tr>
                                        <td>
                                            <a class="title" href="./default.aspx">米缸直销后台管理系统</a>
                                        </td>
                                    </tr>
                                </tbody></table>
                                <div class="themeroller">
                                    <f:Button ID="btn_ChangePassword" runat="server" OnClick="btn_ChangePassword_Click" Text="修改密码"></f:Button>&nbsp; &nbsp;
                                    <f:Button ID="btn_Exit" runat="server" OnClick="btn_Exit_Click" Text="安全退出"></f:Button>
                                </div>
                            </div>
                        </f:ContentPanel>
                    </Items>
                </f:Region>
                <f:Region ID="Region2" Split="true" Width="200px" ShowHeader="true" Title="菜单"
                    EnableCollapse="true" Layout="Fit" Position="Left" runat="server">
                    <Items>
                        <f:Tree runat="server" ShowBorder="false" ShowHeader="false" EnableArrows="true" EnableLines="true" ID="leftMenuTree">
                            <%--<Nodes>
                                <f:TreeNode Text="系统管理" Expanded="false">
                                    <f:TreeNode Text="用户管理" NavigateUrl="~/SystemManage/UserManage.aspx"></f:TreeNode>
                                    <f:TreeNode Text="角色管理" NavigateUrl="~/SystemManage/RoleManage.aspx"></f:TreeNode>
                                    <f:TreeNode Text="菜单管理" NavigateUrl="~/SystemManage/MenuManage.aspx"></f:TreeNode>
                                    <f:TreeNode Text="按钮管理" NavigateUrl="~/SystemManage/ButtonManage.aspx"></f:TreeNode>
                                    <f:TreeNode Text="公共数据管理" NavigateUrl="~/SystemManage/CommonDataManage.aspx"></f:TreeNode>
                                </f:TreeNode>
                            </Nodes>
                            <Nodes>
                                    <f:TreeNode Text="业务管理" Expanded="false">
                                        <f:TreeNode Text="商品管理" NavigateUrl="~/BusinessManage/CommdityManage.aspx"></f:TreeNode>
                                        <f:TreeNode Text="会员管理" NavigateUrl="~/BusinessManage/MemberManage.aspx"></f:TreeNode>
                                        <f:TreeNode Text="会员等级管理" NavigateUrl="~/BusinessManage/MemberLevelManage.aspx"></f:TreeNode>
                                        <f:TreeNode Text="公告管理" NavigateUrl="~/BusinessManage/AnnounceManage.aspx"></f:TreeNode>
                                    </f:TreeNode>
                            </Nodes>
                            <Nodes>
                                <f:TreeNode Text="日志记录" Expanded="false">
                                    <f:TreeNode Text="系统记录" NavigateUrl="~/LogManage/SystemLog.aspx"></f:TreeNode>
                                    <f:TreeNode Text="错误记录" NavigateUrl="~/LogManage/ErrorLog.aspx"></f:TreeNode>
                                    <f:TreeNode Text="米币记录" NavigateUrl="~/LogManage/CreditLog.aspx"></f:TreeNode>
                                    <f:TreeNode Text="大米记录" NavigateUrl="~/LogManage/PointsLog.aspx"></f:TreeNode>
                                    <f:TreeNode Text="消费记录" NavigateUrl="~/LogManage/PurchaseLog.aspx"></f:TreeNode>
                                    <f:TreeNode Text="提现记录" NavigateUrl="~/LogManage/CreditsExchangeLog.aspx"></f:TreeNode>
                                </f:TreeNode>
                            </Nodes>--%>
                        </f:Tree>
                    </Items>
                </f:Region>
                <f:Region ID="mainRegion" ShowHeader="false" Layout="Fit" Position="Center"
                    runat="server">
                    <Items>
                        <f:TabStrip ID="mainTabStrip" EnableTabCloseMenu="true" ShowBorder="false" runat="server">
                            <Tabs>
                                <f:Tab ID="Tab1" Title="首页" Layout="Fit" Icon="House" runat="server">
                                    <Items>
                                        <f:ContentPanel ID="ContentPanel2" ShowBorder="false" BodyPadding="10px" ShowHeader="false" AutoScroll="true"
                                            runat="server">
                                            WelCome
                                        </f:ContentPanel>
                                    </Items>
                                </f:Tab>
                            </Tabs>
                        </f:TabStrip>
                    </Items>
                </f:Region>
                <f:Region ID="Region3" ShowBorder="false" Height="20px" ShowHeader="false"
                    Position="Bottom" Layout="Fit" runat="server">
                    <Items>
                        <f:ContentPanel ShowBorder="false" ShowHeader="false" ID="ContentPanel3" CssClass="f-theme-neptune"
                            runat="server">
                            <div class="center">
                                当前用户:<span style="font-weight:bold"><%=CurrentAdminUser.UserNumber%></span>
                            </div>
                        </f:ContentPanel>
                    </Items>
                </f:Region>
            </Regions>
        </f:RegionPanel>
        <f:Window ID="Window1" IconUrl="~/res/images/16/10.png" runat="server" Hidden="true"
            WindowPosition="Center" IsModal="true" Title="用户信息" EnableMaximize="true"
            EnableResize="true" Target="Self" EnableIFrame="true"
            Height="500px" Width="650px" OnClose="Window1_Close">
        </f:Window>
        
    </form>
    <script>
        var menuClientID = '<%= leftMenuTree.ClientID %>';
        var tabStripClientID = '<%= mainTabStrip.ClientID %>';

        // 页面控件初始化完毕后，会调用用户自定义的onReady函数
        F.ready(function () {

            // 初始化主框架中的树(或者Accordion+Tree)和选项卡互动，以及地址栏的更新
            // treeMenu： 主框架中的树控件实例，或者内嵌树控件的手风琴控件实例
            // mainTabStrip： 选项卡实例
            // createToolbar： 创建选项卡前的回调函数（接受tabConfig参数）
            // updateLocationHash: 切换Tab时，是否更新地址栏Hash值
            // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
            // refreshWhenTabChange: 切换选项卡时，是否刷新内部IFrame
            F.util.initTreeTabStrip(F(menuClientID), F(tabStripClientID), null, true, false, false);

        });
    </script>
</body>
</html>
