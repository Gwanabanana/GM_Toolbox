namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
             {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 32),
             })
             .PrimaryKey(t => t.Id);
                    }
                    
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
