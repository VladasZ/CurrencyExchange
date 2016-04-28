namespace CurrencyExchange.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BankDepartments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GoogleId = c.String(),
                        Name = c.String(),
                        Address = c.Int(nullable: false),
                        OpenTime = c.Time(nullable: false, precision: 7),
                        CloseTime = c.Time(nullable: false, precision: 7),
                        Bank_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.Bank_Id)
                .Index(t => t.Bank_Id);
            
            CreateTable(
                "dbo.ExchangeRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        USD_Sell = c.Double(nullable: false),
                        USD_Buy = c.Double(nullable: false),
                        EUR_Sell = c.Double(nullable: false),
                        EUR_Buy = c.Double(nullable: false),
                        RUR_Sell = c.Double(nullable: false),
                        RUR_Buy = c.Double(nullable: false),
                        Bank_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.Bank_Id)
                .Index(t => t.Bank_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExchangeRecords", "Bank_Id", "dbo.Banks");
            DropForeignKey("dbo.BankDepartments", "Bank_Id", "dbo.Banks");
            DropIndex("dbo.ExchangeRecords", new[] { "Bank_Id" });
            DropIndex("dbo.BankDepartments", new[] { "Bank_Id" });
            DropTable("dbo.ExchangeRecords");
            DropTable("dbo.BankDepartments");
            DropTable("dbo.Banks");
        }
    }
}
