namespace TakeAndDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "sheldoncooper.Agents",
                c => new
                    {
                        AgentId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.AgentId);
            
            CreateTable(
                "sheldoncooper.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        AgentId = c.Int(nullable: false),
                        TenderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("sheldoncooper.Agents", t => t.AgentId, cascadeDelete: true)
                .ForeignKey("sheldoncooper.Tenders", t => t.TenderId, cascadeDelete: true)
                .Index(t => t.AgentId)
                .Index(t => t.TenderId);
            
            CreateTable(
                "sheldoncooper.Tenders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Credits = c.String(maxLength: 255),
                        Link = c.String(maxLength: 255),
                        TenderTypeId = c.Int(nullable: false),
                        StockId = c.Int(),
                        RegionId = c.Int(),
                        TenderCategoryId = c.Int(),
                        ExpirationDate = c.DateTime(),
                        ParticipationDate = c.DateTime(),
                        CompletionDate = c.DateTime(),
                        InitMaxContractPrice = c.Decimal(precision: 18, scale: 2),
                        MinEstimatedPrice = c.Decimal(precision: 18, scale: 2),
                        VatIncludePrice = c.Decimal(precision: 18, scale: 2),
                        DeliveryPrice = c.Decimal(precision: 18, scale: 2),
                        ExtraCharge = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("sheldoncooper.Regions", t => t.RegionId)
                .ForeignKey("sheldoncooper.Stocks", t => t.StockId)
                .ForeignKey("sheldoncooper.TenderCategories", t => t.TenderCategoryId)
                .ForeignKey("sheldoncooper.TenderTypes", t => t.TenderTypeId, cascadeDelete: true)
                .Index(t => t.TenderTypeId)
                .Index(t => t.StockId)
                .Index(t => t.RegionId)
                .Index(t => t.TenderCategoryId);
            
            CreateTable(
                "sheldoncooper.Regions",
                c => new
                    {
                        RegionId = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RegionId);
            
            CreateTable(
                "sheldoncooper.Stocks",
                c => new
                    {
                        StockId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.StockId);
            
            CreateTable(
                "sheldoncooper.TenderCategories",
                c => new
                    {
                        TenderCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TenderCategoryId);
            
            CreateTable(
                "sheldoncooper.TenderTypes",
                c => new
                    {
                        TenderTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.TenderTypeId);
            
            CreateTable(
                "sheldoncooper.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.Int(nullable: false),
                        AgentId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("sheldoncooper.Agents", t => t.AgentId, cascadeDelete: true)
                .ForeignKey("sheldoncooper.AspNetUsers", t => t.User_Id)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.AgentId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("sheldoncooper.Teams", "User_Id", "sheldoncooper.AspNetUsers");
            DropForeignKey("sheldoncooper.Teams", "AgentId", "sheldoncooper.Agents");
            DropForeignKey("sheldoncooper.Tenders", "TenderTypeId", "sheldoncooper.TenderTypes");
            DropForeignKey("sheldoncooper.Tenders", "TenderCategoryId", "sheldoncooper.TenderCategories");
            DropForeignKey("sheldoncooper.Tenders", "StockId", "sheldoncooper.Stocks");
            DropForeignKey("sheldoncooper.Tenders", "RegionId", "sheldoncooper.Regions");
            DropForeignKey("sheldoncooper.Orders", "TenderId", "sheldoncooper.Tenders");
            DropForeignKey("sheldoncooper.Orders", "AgentId", "sheldoncooper.Agents");
            DropIndex("sheldoncooper.Teams", new[] { "User_Id" });
            DropIndex("sheldoncooper.Teams", new[] { "AgentId" });
            DropIndex("sheldoncooper.Teams", new[] { "ApplicationUserId" });
            DropIndex("sheldoncooper.Tenders", new[] { "TenderCategoryId" });
            DropIndex("sheldoncooper.Tenders", new[] { "RegionId" });
            DropIndex("sheldoncooper.Tenders", new[] { "StockId" });
            DropIndex("sheldoncooper.Tenders", new[] { "TenderTypeId" });
            DropIndex("sheldoncooper.Orders", new[] { "TenderId" });
            DropIndex("sheldoncooper.Orders", new[] { "AgentId" });
            DropTable("sheldoncooper.Teams");
            DropTable("sheldoncooper.TenderTypes");
            DropTable("sheldoncooper.TenderCategories");
            DropTable("sheldoncooper.Stocks");
            DropTable("sheldoncooper.Regions");
            DropTable("sheldoncooper.Tenders");
            DropTable("sheldoncooper.Orders");
            DropTable("sheldoncooper.Agents");
        }
    }
}
