namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TextEditor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TextEditorViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TextEditorViewModels");
        }
    }
}
