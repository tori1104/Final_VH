namespace DWD278_FinalProject_VH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypeStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypeStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.ToWatchLists", "TypeStatusID", c => c.Int(nullable: false));
            CreateIndex("dbo.ToWatchLists", "TypeStatusID");
            AddForeignKey("dbo.ToWatchLists", "TypeStatusID", "dbo.TypeStatus", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToWatchLists", "TypeStatusID", "dbo.TypeStatus");
            DropIndex("dbo.ToWatchLists", new[] { "TypeStatusID" });
            DropColumn("dbo.ToWatchLists", "TypeStatusID");
            DropTable("dbo.TypeStatus");
        }
    }
}
