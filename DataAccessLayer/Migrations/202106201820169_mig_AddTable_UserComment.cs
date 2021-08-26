namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_AddTable_UserComment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserComments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        CommentContent = c.String(),
                        CommentDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CommentStatus = c.Boolean(nullable: false),
                        PostID = c.Int(nullable: false),
                        WriterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .ForeignKey("dbo.Writers", t => t.WriterID, cascadeDelete: true)
                .Index(t => t.PostID)
                .Index(t => t.WriterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserComments", "WriterID", "dbo.Writers");
            DropForeignKey("dbo.UserComments", "PostID", "dbo.Posts");
            DropIndex("dbo.UserComments", new[] { "WriterID" });
            DropIndex("dbo.UserComments", new[] { "PostID" });
            DropTable("dbo.UserComments");
        }
    }
}
