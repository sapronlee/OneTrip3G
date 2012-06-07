namespace OneTrip3G.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Places",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        EnglishName = c.String(nullable: false, maxLength: 40),
                        Keywords = c.String(maxLength: 40),
                        Description = c.String(maxLength: 100),
                        VideoFile = c.String(maxLength: 200),
                        VideoSize = c.String(),
                        MapFile = c.String(maxLength: 200),
                        MapSize = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        DisplayName = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Settings");
            DropTable("Users");
            DropTable("Places");
        }
    }
}
