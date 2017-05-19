namespace Tp3_AspNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 150, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 150, unicode: false),
                        Isbn = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.AuthorBook",
                c => new
                    {
                        AuthorId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AuthorId, t.BookId })
                .ForeignKey("dbo.Author", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuthorBook", "BookId", "dbo.Book");
            DropForeignKey("dbo.AuthorBook", "AuthorId", "dbo.Author");
            DropIndex("dbo.AuthorBook", new[] { "BookId" });
            DropIndex("dbo.AuthorBook", new[] { "AuthorId" });
            DropTable("dbo.AuthorBook");
            DropTable("dbo.Book");
            DropTable("dbo.Author");
        }
    }
}
