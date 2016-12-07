namespace DWD278_FinalProject_VH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ToWatchLists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Year = c.Int(nullable: false),
                        GenreID = c.Int(nullable: false),
                        RatingID = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Genres", t => t.GenreID, cascadeDelete: true)
                .ForeignKey("dbo.Ratings", t => t.RatingID, cascadeDelete: true)
                .Index(t => t.GenreID)
                .Index(t => t.RatingID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToWatchLists", "RatingID", "dbo.Ratings");
            DropForeignKey("dbo.ToWatchLists", "GenreID", "dbo.Genres");
            DropIndex("dbo.ToWatchLists", new[] { "RatingID" });
            DropIndex("dbo.ToWatchLists", new[] { "GenreID" });
            DropTable("dbo.ToWatchLists");
            DropTable("dbo.Ratings");
            DropTable("dbo.Genres");
        }
    }
}
