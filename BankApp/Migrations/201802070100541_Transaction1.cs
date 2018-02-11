namespace BankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transaction1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Transactions", "TractionId", "TransactionId");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Transactions", "TransactionId", "TractionId");
        }
    }
}
