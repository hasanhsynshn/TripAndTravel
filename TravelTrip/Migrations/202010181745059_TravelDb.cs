namespace TravelTrip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TravelDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Addresses = c.String(),
                        Mail = c.String(),
                        Phone = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        User = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        BlogImage = c.String(),
                    })
                .PrimaryKey(t => t.BlogId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Mail = c.String(),
                        Comments = c.String(),
                        Blog_BlogId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Blogs", t => t.Blog_BlogId)
                .Index(t => t.Blog_BlogId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        Mail = c.String(),
                        Subject = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Blog_BlogId", "dbo.Blogs");
            DropIndex("dbo.Comments", new[] { "Blog_BlogId" });
            DropTable("dbo.Contacts");
            DropTable("dbo.Comments");
            DropTable("dbo.Blogs");
            DropTable("dbo.Admins");
            DropTable("dbo.Addresses");
            DropTable("dbo.Abouts");
        }
    }
}
