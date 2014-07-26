namespace MessagingTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMessaging : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Long(nullable: false, identity: true),
                        SenderId = c.String(maxLength: 128),
                        Timestamp = c.DateTime(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId)
                .Index(t => t.SenderId);
            
            CreateTable(
                "dbo.Recipients",
                c => new
                    {
                        MessageId = c.Long(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Recieved = c.Boolean(nullable: false),
                        TimeRecieved = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.MessageId, t.UserId })
                .ForeignKey("dbo.Messages", t => t.MessageId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.MessageId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Recipients", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Recipients", "MessageId", "dbo.Messages");
            DropIndex("dbo.Recipients", new[] { "UserId" });
            DropIndex("dbo.Recipients", new[] { "MessageId" });
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropTable("dbo.Recipients");
            DropTable("dbo.Messages");
        }
    }
}
