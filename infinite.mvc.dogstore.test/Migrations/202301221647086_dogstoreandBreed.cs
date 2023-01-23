namespace infinite.mvc.dogstore.test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dogstoreandBreed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DogStores", "Height", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DogStores", "Height", c => c.Int(nullable: false));
        }
    }
}
