namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MyProperty = c.Int(nullable: false),
                        Wins = c.Int(nullable: false),
                        Motiv = c.String(),
                        U1 = c.String(),
                        U2 = c.String(),
                        Time = c.Time(nullable: false, precision: 7),
                        Created = c.DateTime(nullable: false),
                        Type = c.String(),
                        Pgn = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        Send = c.String(),
                        Type = c.String(),
                        Created = c.DateTime(nullable: false),
                        Receiver_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Receiver_Id)
                .Index(t => t.Receiver_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Name = c.String(),
                        Image = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Created = c.DateTime(nullable: false),
                        Role = c.DateTime(nullable: false),
                        ConvAviertas = c.String(),
                        Array = c.String(),
                        Age = c.Int(nullable: false),
                        Sex = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Puzzles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        FeInit = c.String(),
                        Fenfinish = c.String(),
                        Nummoves = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        Corrects = c.Int(nullable: false),
                        Intents = c.Int(nullable: false),
                        CreatedBy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Puzzles", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Receiver_Id", "dbo.Users");
            DropForeignKey("dbo.Boards", "User_Id", "dbo.Users");
            DropIndex("dbo.Puzzles", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Messages", new[] { "Receiver_Id" });
            DropIndex("dbo.Boards", new[] { "User_Id" });
            DropTable("dbo.Puzzles");
            DropTable("dbo.Users");
            DropTable("dbo.Messages");
            DropTable("dbo.Boards");
        }
    }
}
