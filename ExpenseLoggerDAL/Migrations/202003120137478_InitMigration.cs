namespace ExpenseLoggerDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 255),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpenseOnDate = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserID)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        EmailAddress = c.String(nullable: false, maxLength: 255),
                        Gender = c.Boolean(nullable: false),
                        DateOfBirth = c.DateTime(storeType: "date"),
                        Password = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                        Value = c.String(maxLength: 10),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Settings", "UserID", "dbo.Users");
            DropForeignKey("dbo.Expenses", "UserID", "dbo.Users");
            DropForeignKey("dbo.Categories", "UserID", "dbo.Users");
            DropIndex("dbo.Settings", new[] { "UserID" });
            DropIndex("dbo.Expenses", new[] { "UserID" });
            DropIndex("dbo.Expenses", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "UserID" });
            DropTable("dbo.Settings");
            DropTable("dbo.Users");
            DropTable("dbo.Expenses");
            DropTable("dbo.Categories");
        }
    }
}
