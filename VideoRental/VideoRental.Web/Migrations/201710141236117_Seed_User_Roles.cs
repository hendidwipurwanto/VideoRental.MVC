namespace VideoRental.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed_User_Roles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7d361700-fb5d-4548-a9bb-5e30f26901f0', N'Admin')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1594130d-6c27-4d98-b282-16ba25f04b5a', N'Staff')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'40f0fcb8-afac-4e78-98b6-1e9dc2cbb169', N'Guest')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
