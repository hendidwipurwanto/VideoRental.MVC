namespace VideoRental.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_Details_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CreatedTime = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedTime = c.DateTime(),
                        ModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        FristName = c.String(),
                        LastName = c.String(),
                        BirthOfDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        GenderId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.GenderId)
                .Index(t => t.GenderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserDetails", "GenderId", "dbo.Genders");
            DropIndex("dbo.UserDetails", new[] { "GenderId" });
            DropTable("dbo.UserDetails");
        }
    }
}
