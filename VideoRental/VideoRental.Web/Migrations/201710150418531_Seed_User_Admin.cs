namespace VideoRental.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed_User_Admin : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO[dbo].[AspNetUsers] ([Id],[Email],[EmailConfirmed],[PasswordHash],[SecurityStamp],[PhoneNumber],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEndDateUtc],[LockoutEnabled],[AccessFailedCount],[UserName])
                VALUES('fe016e31-5216-4ebb-9f9d-8bc2710c53ac','admin@mail.com',0,'ABnp/9mEKLk0EpTryPDLEhYlG7O9hzjFesCaqsb1zOsA2QbuLtQUn+FaVqPBGnZlvg==','3794496a-49ef-4ebb-adbf-d11e817e337f', NULL,0,0, NULL,1,0,'admin')

                INSERT INTO[dbo].[AspNetUserRoles] ([UserId],[RoleId])
                VALUES('fe016e31-5216-4ebb-9f9d-8bc2710c53ac','7d361700-fb5d-4548-a9bb-5e30f26901f0')
            ");
        }

    public override void Down()
        {
        }
    }
}
