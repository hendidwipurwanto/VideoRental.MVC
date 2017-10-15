namespace VideoRental.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed_Gender : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO[dbo].[Genders] ([Id],[CreatedTime],[CreatedBy],[ModifiedTime],[ModifiedBy],[IsDeleted],[Name])
                VALUES('FFB68750-395D-4646-AFE7-DD338F9F8E21','2017-10-15','System', NULL, NULL,0,'Male')

                INSERT INTO[dbo].[Genders] ([Id],[CreatedTime],[CreatedBy],[ModifiedTime],[ModifiedBy],[IsDeleted],[Name])
                VALUES('A5F07A1C-AD3F-438D-80F7-B9130F4FB0E5','2017-10-15','System', NULL, NULL,0,'Female')
            ");
        }

    public override void Down()
        {
        }
    }
}
