namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a30bd7ce-e1f7-4c3a-9410-c71710cf5a8d', N'sanjeev@gmail.com', 0, N'AByhbSuhxE4F44JYQm27IANO3CmnZNkyYA111QgE3IuZ9rlfX1/bFWmGqoRBQqFehw==', N'0d9810f7-3660-4b6a-bc25-e1f6bf03f6c6', NULL, 0, 0, NULL, 1, 0, N'sanjeev@gmail.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'acf34bbe-890c-4474-b083-0c9b0299b8e1', N'rohit@gmail.com', 0, N'ANkrrcE8bY6tZWMH6ixLHXOosYtcgGwifq444X8it8POmCiUrqQnKaQTAXcbSs1rwA==', N'7eccd360-a170-4211-80af-84224aade7ed', NULL, 0, 0, NULL, 1, 0, N'rohit@gmail.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e36575e0-64fc-4cce-bb99-f1ba56800a89', N'raj@gmail.com', 0, N'APMQ/n1cUZe1xVYX0DhQykvQMEWOp1WH+Eg86SZplEr7z/iJ7ATHRFbtZ9NTRH+EZg==', N'22f52607-9390-4624-8d78-86613e1f0c4f', NULL, 0, 0, NULL, 1, 0, N'raj@gmail.com')

                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'52218186-fddb-4979-b1e7-6f21c1c95bb9', N'CanManageMovie')
                    
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e36575e0-64fc-4cce-bb99-f1ba56800a89', N'52218186-fddb-4979-b1e7-6f21c1c95bb9')

             ");
        }
        
        public override void Down()
        {
        }
    }
}
