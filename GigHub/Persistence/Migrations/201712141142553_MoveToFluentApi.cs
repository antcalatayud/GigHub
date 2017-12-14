namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoveToFluentApi : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notifications", "Gig_Id", "dbo.Gigs");
            DropIndex("dbo.Notifications", new[] { "Gig_Id" });
            AlterColumn("dbo.Notifications", "Gig_Id", c => c.Int());
            CreateIndex("dbo.Notifications", "Gig_Id");
            AddForeignKey("dbo.Notifications", "Gig_Id", "dbo.Gigs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "Gig_Id", "dbo.Gigs");
            DropIndex("dbo.Notifications", new[] { "Gig_Id" });
            AlterColumn("dbo.Notifications", "Gig_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Notifications", "Gig_Id");
            AddForeignKey("dbo.Notifications", "Gig_Id", "dbo.Gigs", "Id", cascadeDelete: true);
        }
    }
}
