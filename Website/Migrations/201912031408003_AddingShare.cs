namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingShare : DbMigration
    {
        public override void Up()
        {
            CreateTable(
            "dbo.Access",
            c => new
            {
                Id = c.Int(nullable: false, identity: true),
                NoteId = c.Int(),
                UserId = c.String(),
                CanEdit = c.Boolean(),
            })
            .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Access");
        }
    }
}
