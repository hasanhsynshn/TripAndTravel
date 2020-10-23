namespace TravelTrip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Blog_BlogId", "dbo.Blogs");
            DropIndex("dbo.Comments", new[] { "Blog_BlogId" });
            RenameColumn(table: "dbo.Comments", name: "Blog_BlogId", newName: "BlogId");
            AddColumn("dbo.Blogs", "CommentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "BlogId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "BlogId");
            AddForeignKey("dbo.Comments", "BlogId", "dbo.Blogs", "BlogId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "BlogId", "dbo.Blogs");
            DropIndex("dbo.Comments", new[] { "BlogId" });
            AlterColumn("dbo.Comments", "BlogId", c => c.Int());
            DropColumn("dbo.Blogs", "CommentId");
            RenameColumn(table: "dbo.Comments", name: "BlogId", newName: "Blog_BlogId");
            CreateIndex("dbo.Comments", "Blog_BlogId");
            AddForeignKey("dbo.Comments", "Blog_BlogId", "dbo.Blogs", "BlogId");
        }
    }
}
