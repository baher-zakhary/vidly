namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seed_users : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'abf2a4e6-f313-43d1-a204-6f485c3ef601', N'guest@vidly.com', 0, N'AHbnAbVGf0nMKTKhKsTk+qhoMHRP6PzYDNZJzOqANNyiZK8UYkjJDM0J+j4o3qjnpQ==', N'98b99b32-cea4-4f62-a4f2-bdab03a3d581', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fafd1247-7350-4954-97ac-3e439d095b60', N'admin@vidly.com', 0, N'AMcTW5r68X2mJ1wjuhOu2F0rt6AhAw6/5nc3pTI7mcVRxTVJDyl4eRQXauxnEKPEhQ==', N'd5e9aa86-9909-40b2-baec-0f9be21974b1', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ec9e1bf1-b03c-43ec-95de-b111f78571a5', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fafd1247-7350-4954-97ac-3e439d095b60', N'ec9e1bf1-b03c-43ec-95de-b111f78571a5')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
