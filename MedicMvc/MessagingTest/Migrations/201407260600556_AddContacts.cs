namespace MessagingTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContacts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUserApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserApplicationUsers", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserApplicationUsers", new[] { "ApplicationUser_Id1" });
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        InitiatorId = c.String(nullable: false, maxLength: 128),
                        RecieverId = c.String(nullable: false, maxLength: 128),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.InitiatorId, t.RecieverId })
                .ForeignKey("dbo.AspNetUsers", t => t.RecieverId)
                .ForeignKey("dbo.AspNetUsers", t => t.InitiatorId, cascadeDelete: true)
                .Index(t => t.InitiatorId)
                .Index(t => t.RecieverId);
            
            CreateTable(
                "dbo.Ignores",
                c => new
                    {
                        InitiatorId = c.String(nullable: false, maxLength: 128),
                        RecieverId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.InitiatorId, t.RecieverId })
                .ForeignKey("dbo.AspNetUsers", t => t.RecieverId)
                .ForeignKey("dbo.AspNetUsers", t => t.InitiatorId, cascadeDelete: true)
                .Index(t => t.InitiatorId)
                .Index(t => t.RecieverId);
            
            //DropTable("dbo.ApplicationUserApplicationUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUserApplicationUsers",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id1 = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.ApplicationUser_Id1 });
            
            DropForeignKey("dbo.Ignores", "InitiatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ignores", "RecieverId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contacts", "InitiatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contacts", "RecieverId", "dbo.AspNetUsers");
            DropIndex("dbo.Ignores", new[] { "RecieverId" });
            DropIndex("dbo.Ignores", new[] { "InitiatorId" });
            DropIndex("dbo.Contacts", new[] { "RecieverId" });
            DropIndex("dbo.Contacts", new[] { "InitiatorId" });
            DropTable("dbo.Ignores");
            DropTable("dbo.Contacts");
            CreateIndex("dbo.ApplicationUserApplicationUsers", "ApplicationUser_Id1");
            CreateIndex("dbo.ApplicationUserApplicationUsers", "ApplicationUser_Id");
            AddForeignKey("dbo.ApplicationUserApplicationUsers", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ApplicationUserApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
