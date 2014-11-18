using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_gangDataService
{
    public static class MGSqlList
    {
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        public const string Sql_GetMenuList = @"  select * from(
                        select main.MenuID,main.Name,main.OrderID,main.ParentID,parent.Name as partentName,main.URL,
                        (case main.Valid when 1 then '有效' else '无效' end) as Valid,main.Icon,
                        ROW_NUMBER() over (order by main.menuid) as rownumber
                        from [Migang-ZX].[dbo].[Au_Menus] main
                        left join [Migang-ZX].[dbo].[Au_Menus] parent
                        on main.ParentID=parent.MenuID) t
                        where t.rownumber between {0} and {1}";

        /// <summary>
        /// 获取菜单总条数
        /// </summary>
        public const string Sql_GetMenuCount = @"select COUNT(1) from [Migang-ZX].[dbo].[Au_Menus] ";

        /// <summary>
        /// 获取父菜单
        /// </summary>
        public const string Sql_GetParentInfo = @"select MenuID,Name from [Migang-ZX].[dbo].[Au_Menus] 
                            where ParentID is null";

        /// <summary>
        /// 根据菜单id获取详细信息
        /// </summary>
        public const string Sql_GetMenuInfoByMenuId = @"select main.MenuID,main.Name,main.ParentID,main.Valid,main.URL,main.orderID
                            from [Migang-ZX].[dbo].[Au_Menus] main where main.MenuID={0}";

        /// <summary>
        /// 菜单新增
        /// </summary>
        public const string Sql_InsertMenu = @"insert [Migang-ZX].dbo.Au_Menus
                            (Name,OrderID,ParentID,URL,Valid)
                            values('{0}',{1},{2},'{3}',{4})";
        public const string Sql_InsertMenuEx = @"insert [Migang-ZX].dbo.Au_Menus
                            (Name,OrderID,URL,Valid)
                            values('{0}',{1},'{2}','{3}')";

        /// <summary>
        /// 根据菜单id修改菜单信息
        /// </summary>
        public const string Sql_UpdateMenuByID = @"update [Migang-ZX].dbo.Au_Menus
                            set Name='{0}',OrderID={1},ParentID={2},URL='{3}',Valid={4}
                            where MenuID={5}";
        public const string Sql_UpdateMenuByIDEx = @"update [Migang-ZX].dbo.Au_Menus
                            set Name='{0}',OrderID={1},URL='{2}',Valid={3}
                            where MenuID={4}";

        /// <summary>
        /// 删除菜单
        /// </summary>
        public const string Sql_DelMenuByID = @"delete from [Migang-ZX].dbo.Au_Menus
                            where MenuID={0}";

        public const string Sql_DelButtonByMenuID = @"delete from [Migang-ZX].dbo.Au_Buttons
                            where MenuID={0}";

        /// <summary>
        /// 按钮列表
        /// </summary>
        public const string Sql_GetButtonList = @"select * from (
                            SELECT [ButtonID],menu.Name as menuName,button.[Name] as buttonName
                            ,(case [IsAuthority] when 0 then '否' else '是' end) as IsAuthority,
                            ROW_NUMBER() over (order by buttonid) as rownumber
                            FROM [Migang-ZX].[dbo].[Au_Buttons] button
                            inner join [Migang-ZX].dbo.Au_Menus menu
                            on button.MenuID=menu.MenuID where 1=1 {2})t
                            where t.rownumber between {0} and {1}";

        /// <summary>
        /// 获取菜单总条数
        /// </summary>
        public const string Sql_GetButtonCount = @"select COUNT(1) from [Migang-ZX].[dbo].[Au_Buttons] 
                            where 1=1 {0}";

        /// <summary>
        /// 按钮新增
        /// </summary>
        public const string Sql_InsertButton = @" insert into [Migang-ZX].[dbo].[Au_Buttons]
                          (MenuID,Name,IsAuthority)
                          values({0},'{1}',{2})";

        /// <summary>
        /// 按钮更新
        /// </summary>
        public const string Sql_UpdateButtonByID = @"update [Migang-ZX].[dbo].[Au_Buttons]
                          set MenuID={0},Name='{1}',IsAuthority={2}
                          where ButtonID={3}";

        /// <summary>
        /// 按钮删除
        /// </summary>
        public const string Sql_DelButtonByID = @"delete from [Migang-ZX].[dbo].[Au_Buttons]
                            where ButtonID={0}";

        public const string Sql_DelButtonRoleByButtonID = @"delete from [Migang-ZX].dbo.Au_Buttons_Au_Roles
                            where ButtonID={0}";

        /// <summary>
        /// 根据角色id获取角色名称
        /// </summary>
        public const string Sql_GetRoleNameByID = @"select name from [Migang-ZX].[dbo].[Au_Roles]
                            where RoleID={0}";

        /// <summary>
        /// 获取所有菜单信息
        /// </summary>
        public const string Sql_GetMenuInfo = @"select MenuID,Name,ParentID from [Migang-ZX].[dbo].Au_Menus
                            where Valid=1";

        /// <summary>
        /// 根据按钮id获取按钮信息
        /// </summary>
        public const string Sql_GetButtonInfoByID = @"select MenuID,Name,IsAuthority from  [Migang-ZX].[dbo].[Au_Buttons]
                            where ButtonID={0}";

        /// <summary>
        /// 获取角色信息列表
        /// </summary>
        public const string Sql_GetRoleList = @"select * from (
                            SELECT roles.[RoleID],roles.[Name],roles.[Remark],
                            roles.[StatusID],sstatus.Remark as statusremark,
                            ROW_NUMBER() over (order by roleid) as rownumber
                            FROM [Migang-ZX].[dbo].[Au_Roles] roles
                            inner join [Migang-ZX].dbo.Sys_StatusType sstatus 
                            on roles.StatusID=sstatus.StatusID where 1=1 {2})t
                              where t.rownumber between {0} and {1}";

        /// <summary>
        /// 获取角色总条数
        /// </summary>
        public const string Sql_GetRoleCount = @"select COUNT(1) from [Migang-ZX].[dbo].[Au_Roles] 
                            where 1=1 {0}";

        /// <summary>
        /// 根据id删除角色信息
        /// </summary>
        public const string Sql_DeleteRoleByID = @"delete from [Migang-ZX].[dbo].[Au_Roles]
                            where RoleID={0}";

        /// <summary>
        /// 根据角色id获取角色
        /// </summary>
        public const string Sql_GetRoleInfoByID = @"
                            SELECT [RoleID],[Name],[Remark],[StatusID]
                            from [Migang-ZX].[dbo].[Au_Roles]
                            where RoleID={0}";

        /// <summary>
        /// 角色新增
        /// </summary>
        public const string Sql_InsertRole = @"insert into [Migang-ZX].[dbo].[Au_Roles]
                            (Name,Remark,StatusID)
                            values('{0}','{1}',{2})";

        /// <summary>
        /// 根据id更形角色信息
        /// </summary>
        public const string Sql_UpdateRoleByID = @"update [Migang-ZX].[dbo].[Au_Roles]
                            set Name='{0}',Remark='{1}',StatusID='{3}'
                            where RoleID={2}";

        /// <summary>
        /// 更新角色的状态
        /// </summary>
        public const string Sql_UpdateRoleStatus = @"UPDATE [Migang-ZX].[dbo].[Au_Roles]
                            set StatusID='{0}'
                            where RoleID={1}";

        /// <summary>
        /// 根据角色id获取菜单信息
        /// </summary>
        public const string Sql_GetMenuByRoleID = @"SELECT menu.[MenuID] ,menu.[Name] ,menu.[ParentID]
                              FROM [Migang-ZX].[dbo].[Au_Menus] menu
                              inner join [Migang-ZX].dbo.Au_Menus_Au_Roles menu2role
                              on menu.MenuID=menu2role.MenuID
                              where Valid=1  and RoleID={0}";

        /// <summary>
        /// 根据角色id获取菜单信息
        /// </summary>
        public const string Sql_GetMenuByRoleIDs = @"SELECT distinct menu.[MenuID] ,menu.[Name] ,menu.[ParentID],menu.URL
                              FROM [Migang-ZX].[dbo].[Au_Menus] menu
                              inner join [Migang-ZX].dbo.Au_Menus_Au_Roles menu2role
                              on menu.MenuID=menu2role.MenuID
                              where Valid=1  and RoleID in ({0})";

        /// <summary>
        /// 根据角色id获取所有的菜单
        /// </summary>
        public const string Sql_GetMenuIDByRoleID = @"select * from [Migang-ZX].dbo.Au_Menus_Au_Roles
                            where RoleID={0};";

        /// <summary>
        /// 角色菜单表新增
        /// </summary>
        public const string Sql_InsertMenu2Role = @" insert [Migang-ZX].dbo.Au_Menus_Au_Roles
                            (MenuID,RoleID) values({0},{1})";

        /// <summary>
        /// 角色菜单表删除
        /// </summary>
        public const string Sql_DelMenu2Role = @"delete from [Migang-ZX].dbo.Au_Menus_Au_Roles
                            where RoleID={0} and MenuID={1}";

        /// <summary>
        /// 获取公共数据列表
        /// </summary>
        public const string Sql_GetCommonSettingsList = @"select * from (
                          select ID,Name,Value,ROW_NUMBER() over (order by id) as rownumber from 
                          [Migang-ZX].dbo.Sys_CommonSettings where 1=1 {2})t
                          where t.rownumber between {0} and {1}";

        /// <summary>
        /// 获取公共数据的总条数
        /// </summary>
        public const string Sql_GetCommonSettingsCount = @"select COUNT(1) from [Migang-ZX].dbo.Sys_CommonSettings 
                            where 1=1 {0}";

        /// <summary>
        /// 根据id删除
        /// </summary>
        public const string Sql_DeleteCommSettingsByID = @"delete from [Migang-ZX].dbo.Sys_CommonSettings 
                            where ID={0}";

        /// <summary>
        /// 根据id获取公共数据值
        /// </summary>
        public const string Sql_GetCommonSettingsByID = @"
                          select ID,Name,Value from 
                          [Migang-ZX].dbo.Sys_CommonSettings
                          where ID={0}";

        /// <summary>
        /// 公共数据新增
        /// </summary>
        public const string Sql_InsertCommonSetting = @"insert into [Migang-ZX].dbo.Sys_CommonSettings
                            (Name,Value) values('{0}','{1}')";

        /// <summary>
        /// 公共数据更新
        /// </summary>
        public const string Sql_UpdateCommonSettingByID = @"update [Migang-ZX].dbo.Sys_CommonSettings
                            set Name='{0}',Value='{1}' where ID={2}";

        /// <summary>
        /// 获取角色信息
        /// </summary>
        public const string Sql_GetAllRoleInfo = @"select StatusID,Remark,value from Sys_StatusType";

        /// <summary>
        /// 获取用户列表
        /// </summary>
        public const string Sql_GetUserList = @"select * from (
                            SELECT users.[UserID],[UserNumber],users.[Name] 
		                            ,[Password],[Code],[NickName],[CreateDate],statustype.Remark as statusremark
                                  ,users.[StatusID],users.[Remark],
                                  ROW_NUMBER() over (order by users.userid) as rownumber
                              FROM [Migang-ZX].[dbo].[Sys_Users] users
                              inner join [Migang-ZX].dbo.Sys_StatusType statustype
                              on users.StatusID=statustype.StatusID 
                              where 1=1 {2})t
                              where t.rownumber between {0} and {1}";

        /// <summary>
        /// 获取用户总数
        /// </summary>
        public const string Sql_GetUserCount = @"select COUNT(1) from [Migang-ZX].dbo.Sys_Users 
                            where 1=1 {0}";

        /// <summary>
        /// 根据id获取用户信息
        /// </summary>
        public const string Sql_GetUserInfoByID = @"SELECT [UserID],[UserNumber],[Name]
                              ,[Password],[Code],[NickName],[CreateDate]
                              ,[StatusID],[Remark]
                          FROM [Migang-ZX].[dbo].[Sys_Users]
                          where UserID={0}";

        /// <summary>
        /// 用户新增
        /// </summary>
        public const string Sql_InsertUser = @"insert into [Migang-ZX].[dbo].[Sys_Users]
                          (UserNumber,Name,Code,NickName,CreateDate,StatusID,Remark)
                          values('{0}','{1}','{2}','{3}','{4}',{5},'{6}')";

        /// <summary>
        /// 用户更新
        /// </summary>
        public const string Sql_UpdateUserByID = @"update [Migang-ZX].[dbo].[Sys_Users]
                          set UserNumber='{1}',Name='{2}',Code='{3}',NickName='{4}',
                          CreateDate='{5}',StatusID={6},Remark='{7}'
                          where UserID={0}";

        /// <summary>
        /// 获取激活的角色列表
        /// </summary>
        public const string Sql_GetRoleListActive = @" select RoleID,Name from [Migang-ZX].dbo.Au_Roles
                        where StatusID=1";

        /// <summary>
        /// 新增用户角色
        /// </summary>
        public const string Sql_InsertRoleUser = @"insert into [Migang-ZX].dbo.Sys_Users_Au_Roles
                        (UserID,RoleID)values({0},{1})";

        /// <summary>
        /// 删除用户角色
        /// </summary>
        public const string Sql_DelRoleUser = @"delete from [Migang-ZX].dbo.Sys_Users_Au_Roles
                        where UserID={0}";

        /// <summary>
        /// 新增按钮角色
        /// </summary>
        public const string Sql_InsertRoleButton = @"insert into [Migang-ZX].dbo.Au_Buttons_Au_Roles
                        (ButtonID,RoleID)
                        values({0},{1})";

        /// <summary>
        /// 删除按钮权限
        /// </summary>
        public const string Sql_DelRoleButton = @"delete from [Migang-ZX].dbo.Au_Buttons_Au_Roles
                        where ButtonID={0}";

        /// <summary>
        /// 根据按钮id获取角色
        /// </summary>
        public const string Sql_GetRoleButtonByButtonID = @"select ButtonID,RoleID from [Migang-ZX].dbo.Au_Buttons_Au_Roles
                        where ButtonID={0}";

        /// <summary>
        /// 根据用户id获取角色
        /// </summary>
        public const string SqlGetRoleUserByUserID = @"select UserID,RoleID from [Migang-ZX].dbo.Sys_Users_Au_Roles
                        where UserID={0}";

        /// <summary>
        /// 根据按钮id获取对应的角色
        /// </summary>
        public const string Sql_GetRoleInfoByButtonID = @"select roles.Name from [Migang-ZX].dbo.Au_Buttons_Au_Roles button2role
                        inner join [Migang-zx].dbo.Au_Roles roles
                        on button2role.RoleID=roles.RoleID and roles.StatusID=1
                        where button2role.ButtonID={0}";

        /// <summary>
        /// 根据用户id获取对应的角色
        /// </summary>
        public const string Sql_GetRoleInfoByUserID = @"select roles.RoleID,roles.Name from [Migang-ZX].dbo.Sys_Users_Au_Roles user2role
                        inner join [Migang-zx].dbo.Au_Roles roles
                        on user2role.RoleID=roles.RoleID and roles.StatusID=1
                        where user2role.UserID={0}";

        /// <summary>
        /// 更新用户密码
        /// </summary>
        public const string Sql_UpdatePassword = @"UPDATE [Migang-ZX].dbo.Sys_Users
                        set Password='{0}'
                        where UserID={1}";

        /// <summary>
        /// 获取系统日志
        /// </summary>
        public const string Sql_GetSystemLogList = @"select * from(
                        select id,tablename,field,prevalue,currentvalue,modifyuserid,modifydatetime,
                        ROW_NUMBER() over (order by id desc) as rownumber
                        from [migang-zx].dbo.log_systemChange)t
                        where t.rownumber between {0} and {1}";

        public const string Sql_GetSystemLogCount = @"select COUNT(1) from [migang-zx].dbo.log_systemChange";

        public const string Sql_GetErrorLogList = @"select * from(
                            select id,loginfo,CreateDate,ROW_NUMBER() over (order by id desc) as rownumber
                            from [migang-zx].dbo.log_systemerror)t
                            where t.rownumber between {0} and {1}";
        public const string Sql_GetErrorLogCount = @"select COUNT(1) from [migang-zx].dbo.log_systemerror";

        public const string Sql_GetCreditsExChangeLogList = @"select * from
                            (
                            select ID,memberid,[year],[month],
                            credits,iscomplete,completeDatetime,ROW_NUMBER() over (order by ID desc) as rownumber
                                from [migang-zx].dbo.log_CreditsExChange
                            )t where t.rownumber between {0} and {1}";
        public const string Sql_GetGetCreditsExChangeLogCount = @"select COUNT(1) from [migang-zx].dbo.log_CreditsExChange";

        public const string Sql_GetCreditsChangeList = @"select * from(
                            select id,log_purchaseid,effectmemberid,credites,
                            createDate,ROW_NUMBER() over (order by id desc) as rownumber
                            from [migang-zx].dbo.log_CreditsChange
                            )t where t.rownumber between {0} and {1}";
        public const string Sql_GetCreditsChangeCount = @"select COUNT(1) from [migang-zx].dbo.log_CreditsChange";

        public const string Sql_GetPointsChangeList = @"select * from (
                            select id,memberid,cause,result,
                            ROW_NUMBER() over (order by id desc) as rownumber
                            from [migang-zx].dbo.log_pointsChange
                            )t where t.rownumber between {0} and {1}";
        public const string Sql_GetPointsChangeCount = @"select COUNT(1) from [migang-zx].dbo.log_pointsChange";

        public const string Sql_GetPurchaseLogList = @"select * from (
                            select log_purchaseid,memberid,commodityid,quantity,
                            createDate,iscreditsDone,ROW_NUMBER() over (order by log_purchaseid desc) as rownumber
                            from [migang-zx].dbo.log_purchase
                            )t where t.rownumber between {0} and {1}";
        public const string Sql_GetPurchaseLogCount = @"select COUNT(1) from [migang-zx].dbo.log_purchase";

        /// <summary>
        /// 根据用户id删除用户
        /// </summary>
        public const string Sql_DeleteUserByID = @"delete from [Migang-ZX].dbo.Sys_Users
                            where UserID={0}";

        /// <summary>
        /// 根据用户id删除用户角色表中的信息
        /// </summary>
        public const string Sql_DelUserRoleByUserId=@"
                            delete from [Migang-ZX].dbo.Sys_Users_Au_Roles
                            where UserID={0}";

        /// <summary>
        /// 获取会员列表
        /// </summary>
        public const string Sql_GetMemberList = @"select * from (
                        SELECT [MemberID],[InviterID],[LeftMemberID]
                              ,[TopMemberID],member.[MemberTypeID],membertype.Value as membertypeValue,[Name],[Code]
                              ,[Password],[CellPhone],[RealName],[Mail],[Weichat]
                              ,[BuyCommodity],[BuyCommodityCurrMonth],[CreateDate]
                              ,[Points],[Credits],[Bank],[BankAccount],[BankNumber]
                              ,[IdentityNumber],[IdentityPic],[AgreementSignedPic],member.[StatusID],statustype.Remark as statusremark,
                              ROW_NUMBER() over(order by [MemberID]) as rownumber
                          FROM [Migang-ZX].[dbo].[Bz_Member] member
                          inner join [Migang-ZX].dbo.Bz_MemberType membertype
                          on member.MemberTypeID=membertype.MemberTypeID
                          inner join [Migang-ZX].dbo.Sys_StatusType statustype
                          on member.StatusID=statustype.StatusID where 1=1 {2})t
                          where t.rownumber between {0} and {1}";

        /// <summary>
        /// 获取会员总条数
        /// </summary>
        public const string Sql_GetMemberCount = @"select COUNT(1) from [Migang-ZX].[dbo].[Bz_Member] member where 1=1 {0}";

        /// <summary>
        /// 获取会员类型
        /// </summary>
        public const string Sql_GetMemberType = @"SELECT [MemberTypeID],[Value],[Remark]
                            FROM [Migang-ZX].[dbo].[Bz_MemberType]";

        /// <summary>
        /// 根据id获取会员详情
        /// </summary>
        public const string Sql_GetMemberByMemberID = @" SELECT [MemberID],[InviterID],[LeftMemberID]
                              ,[TopMemberID],member.[MemberTypeID],[Name],[Code]
                              ,[Password],[CellPhone],[RealName],[Mail],[Weichat]
                              ,[BuyCommodity],[BuyCommodityCurrMonth],[CreateDate]
                              ,[Points],[Credits],[Bank],[BankAccount],[BankNumber]
                              ,[IdentityNumber],[IdentityPic],[AgreementSignedPic],member.[StatusID]
                          FROM [Migang-ZX].[dbo].[Bz_Member] member
                          where member.MemberID={0}";

        /// <summary>
        /// 根据会员id更新会员信息
        /// </summary>
        public const string Sql_UpdateMemberByMemberID = @"update [Migang-ZX].[dbo].[Bz_Member]
                          set [Name]='{0}',[Code]='{1}',[CellPhone]='{2}',[RealName]='{3}',
                          [Mail]='{4}',[Weichat]='{5}',[Points]={6},[Credits]={7},[Bank]='{8}',
                          [BankAccount]='{9}',[BankNumber]='{10}',[StatusID]={12},[MemberTypeID]={13},
                           BuyCommodity='{14}',BuyCommodityCurrMonth='{15}',IdentityNumber='{16}',IdentityPic='{17}',
                            AgreementSignedPic='{18}',Password='{19}'{20}
                          where MemberID={11}";

        /// <summary>
        /// 会员新增
        /// </summary>
        public const string Sql_InsertMember = @" insert into [Migang-ZX].[dbo].[Bz_Member]
                          ([Name],[Code],[CellPhone],[RealName],[Mail],[Weichat],
                          [Points],[Credits],[Bank],[BankAccount],[BankNumber],StatusID,MemberTypeID,Password,CreateDate,
                            BuyCommodity,BuyCommodityCurrMonth,IdentityNumber,IdentityPic
                            ,AgreementSignedPic{19})
                          values('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},'{8}','{9}','{10}',{11},{12},'{13}',GetDate(),
                            '{14}','{15}','{16}','{17}','{18}'{20})";

        /// <summary>
        /// 根据会员名称查询会员id
        /// </summary>
        public const string Sql_GetmemberIDByMemberName = @"select MemberID from [Migang-ZX].[dbo].[Bz_Member] where name='{0}'";

        /// <summary>
        /// 删除会员
        /// </summary>
        public const string Sql_DeleteMemberByID = @"delete from [Migang-ZX].[dbo].[Bz_Member]
                            where MemberID={0}";

        /// <summary>
        /// 获取会员等级
        /// </summary>
        public const string Sql_GetMemberGradeList = @"select * from (
                          select ID,Grade,Points,OrderID,ROW_NUMBER() over (order by id) as rownumber
                           from [Migang-ZX].dbo.Bz_MemberGrade)t
                           where t.rownumber between {0} and {1}";

        /// <summary>
        /// 获取会员等级条数
        /// </summary>
        public const string Sql_GetMemberGradeCount = @"select COUNT(1) from [Migang-ZX].dbo.Bz_MemberGrade";

        /// <summary>
        /// 根据id获取等级信息
        /// </summary>
        public const string Sql_DelMemberGradeByID = @"delete from [Migang-ZX].dbo.Bz_MemberGrade
                            where ID={0}";

        /// <summary>
        /// 根据id获取等级信息
        /// </summary>
        public const string Sql_GetMemberGradeID = @"select ID,Grade,Points,OrderID from [Migang-ZX].dbo.Bz_MemberGrade
                            where ID={0}";

        /// <summary>
        /// 会员等级新增
        /// </summary>
        public const string Sql_InsertMemberGrade = @"insert into [Migang-ZX].dbo.Bz_MemberGrade
                            (Grade,Points,OrderID)
                            values('{0}',{1},{2})";

        /// <summary>
        /// 根据id更新等级信息
        /// </summary>
        public const string Sql_UpdateMemberByID = @"update [Migang-ZX].dbo.Bz_MemberGrade
                            set Grade='{0}',Points={1},OrderID={2}
                            where id={3}";

        /// <summary>
        /// 会员登录验证
        /// </summary>
        public const string Sql_UserLogIn = @"select UserID,UserNumber,Password,Name,Code,NickName,StatusID from [Migang-ZX].dbo.Sys_Users
                            where UserNumber='{0}' and Password='{1}'";

        /// <summary>
        /// 获取公告列表
        /// </summary>
        public const string Sql_GetAnnoncementList = @"select * from(
                            SELECT [ID],announcement.[AnnouncementTypeID],atype.Value,announcement.[MemberID],
                                  member.Name,[Content],[ValidDateFrom],[ValidDateTo],ROW_NUMBER() over (order by announcement.id) as rownumber
                              FROM [Migang-ZX].[dbo].[Bz_Announcement] announcement
                              inner join [Migang-ZX].dbo.Bz_AnnouncementType atype
                              on announcement.AnnouncementTypeID=atype.AnnouncementTypeID
                              inner join [Migang-ZX].dbo.Bz_Member member
                              on announcement.MemberID=member.MemberID where 1=1 {2})t
                              where t.rownumber between {0} and {1}";

        /// <summary>
        /// 公告总条数
        /// </summary>
        public const string Sql_GetAnnoncementCount = @"select COUNT(1) from [Migang-ZX].[dbo].[Bz_Announcement] announcement
                                inner join [Migang-ZX].dbo.Bz_Member member
                              on announcement.MemberID=member.MemberID 
                                where 1=1 {0}";

        /// <summary>
        /// 根据id删除公告
        /// </summary>
        public const string Sql_DelAnnoucementByID = @"delete from [Migang-ZX].[dbo].[Bz_Announcement]
                                where ID={0}";

        /// <summary>
        /// 根据id获取公告信息
        /// </summary>
        public const string Sql_GetAnnoucementByID = @"select ID,AnnouncementTypeID,MemberID,ValidDateFrom,ValidDateTo,Content
                                   from [Migang-ZX].[dbo].[Bz_Announcement]
                                  where ID={0}";

        /// <summary>
        /// 获取公告类型信息
        /// </summary>
        public const string Sql_GetAnnoucementType = @"select AnnouncementTypeID,Value from [Migang-ZX].dbo.Bz_AnnouncementType";

        /// <summary>
        /// 公告新增
        /// </summary>
        public const string Sql_InsertAnnouncement = @"insert into [Migang-ZX].[dbo].[Bz_Announcement]
                                (AnnouncementTypeID,MemberID,ValidDateFrom,ValidDateTo,Content)
                                values({0},{1},'{2}','{3}','{4}')";

        /// <summary>
        /// 更新公告信息
        /// </summary>
        public const string Sql_UpdateAnnouncementByID = @"update  [Migang-ZX].[dbo].[Bz_Announcement]
                                set AnnouncementTypeID={0},MemberID={1},ValidDateFrom='{2}',
                                ValidDateTo='{3}',Content='{4}'
                                where ID={5}";

        /// <summary>
        /// 根据会员id获取会员地址
        /// </summary>
        public const string Sql_GetMemberLocationByMemberid = @"select id,location.memberid,[address],mobile,
                            phone,zipcode,contact,isdefault,member.name
                             from [Migang-ZX].[dbo].Bz_MemberLocation location
                             inner join [Migang-ZX].dbo.Bz_Member member
                             on location.memberid=member.memberid
                             where location.memberid={0}";

        public const string Sql_GetMemberLocationCount = @"select count(1) from [Migang-ZX].[dbo].Bz_MemberLocation where memberid={0}";
    }
}
