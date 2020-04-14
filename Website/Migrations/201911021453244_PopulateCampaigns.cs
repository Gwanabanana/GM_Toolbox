namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCampaigns : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Campaigns ON");

            Sql("INSERT INTO CAMPAIGNS (Id, Name) VALUES (1, 'Campaign1')");
            Sql("INSERT INTO CAMPAIGNS (Id, Name) VALUES (2, 'Campaign2')");
            Sql("INSERT INTO CAMPAIGNS (Id, Name) VALUES (3, 'Campaign3')");
            Sql("INSERT INTO CAMPAIGNS (Id, Name) VALUES (4, 'Campaign4')");

            Sql("SET IDENTITY_INSERT Campaigns OFF");
        }

        public override void Down()
        {
            Sql("DELETE * FROM Campaigns WHERE Id > 0 AND Id < 5");
        }
    }
}
