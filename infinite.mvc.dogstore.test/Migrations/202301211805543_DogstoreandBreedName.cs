namespace infinite.mvc.dogstore.test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DogstoreandBreedName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DogStores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PetName = c.String(),
                        Description = c.String(),
                        Height = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        Age = c.Int(nullable: false),
                        BreedId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Breeds", t => t.BreedId, cascadeDelete: true)
                .Index(t => t.BreedId);
            
            CreateTable(
                "dbo.Breeds",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        BreedName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DogStores", "BreedId", "dbo.Breeds");
            DropIndex("dbo.DogStores", new[] { "BreedId" });
            DropTable("dbo.Breeds");
            DropTable("dbo.DogStores");
        }
    }
}
