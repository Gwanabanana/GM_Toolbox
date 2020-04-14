namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateWorlds : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Worlds ON");

            Sql("INSERT INTO Worlds (Id, Name) VALUES (1, 'Campaign1')");
            Sql("INSERT INTO Worlds (Id, Name) VALUES (2, 'Campaign2')");
            Sql("INSERT INTO Worlds (Id, Name) VALUES (3, 'Campaign3')");
            Sql("INSERT INTO Worlds (Id, Name) VALUES (4, 'Campaign4')");
            Sql("INSERT INTO Worlds (Id, Name) VALUES (5, 'Campaign5')");
            Sql("INSERT INTO Worlds (Id, Name) VALUES (6, 'Campaign6')");
            Sql("INSERT INTO Worlds (Id, Name) VALUES (7, 'Campaign7')");
            Sql("INSERT INTO Worlds (Id, Name) VALUES (8, 'Campaign8')");
            Sql("INSERT INTO Worlds (Id, Name) VALUES (9, 'Campaign9')");
            
            Sql("SET IDENTITY_INSERT Worlds OFF");
        }

        public override void Down()
        {
            Sql("DELETE * FROM Worlds WHERE Id > 0 AND Id < 10");
        }
    }
}
