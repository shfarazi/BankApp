namespace BankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transaction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TractionId = c.Int(nullable: false, identity: true),
                        TransactionDate = c.DateTime(nullable: false),
                        TransactionAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        TransactionType = c.Int(nullable: false),
                        AccountNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TractionId)
                .ForeignKey("dbo.Accounts", t => t.AccountNumber, cascadeDelete: true)
                .Index(t => t.AccountNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "AccountNumber", "dbo.Accounts");
            DropIndex("dbo.Transactions", new[] { "AccountNumber" });
            DropTable("dbo.Transactions");
        }
    }
}
