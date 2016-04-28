namespace CurrencyExchange.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addObmennikId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banks", "ObmennikById", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Banks", "ObmennikById");
        }
    }
}
