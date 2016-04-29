namespace CurrencyExchange.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class separateLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BankDepartments", "LocationLat", c => c.Double(nullable: false));
            AddColumn("dbo.BankDepartments", "LocationLng", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BankDepartments", "LocationLng");
            DropColumn("dbo.BankDepartments", "LocationLat");
        }
    }
}
