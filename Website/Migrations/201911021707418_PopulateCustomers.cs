namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Customers ON");

            Sql("INSERT INTO Customers (Id, Name, Birthdate) VALUES (1, 'Jan Nowak', 13/10/1990)");
            Sql("INSERT INTO Customers (Id, Name, Birthdate) VALUES (2, 'Kamil Kowalski', 01/01/1997)");
            Sql("INSERT INTO Customers (Id, Name, Birthdate) VALUES (3, 'Ania Kania', 27/12/2001)");
            
            Sql("SET IDENTITY_INSERT Customers OFF");
        }
        
        public override void Down()
        {
            Sql("DELETE * FROM Customers WHERE Id > 0 AND Id < 5");
        }
    }
}
