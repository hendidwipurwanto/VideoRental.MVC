namespace VideoRental.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_UserDetailId_in_ASPNetUser_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserDetailId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserDetailId");
        }
    }
}
