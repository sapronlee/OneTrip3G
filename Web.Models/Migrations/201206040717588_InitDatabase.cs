namespace Web.Models.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
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
                "Places",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        EnglishName = c.String(nullable: false, maxLength: 20),
                        VideoFile = c.String(),
                        VideoSize = c.Int(defaultValue: 0),
                        MapFile = c.String(),
                        MapSize = c.Int(defaultValue: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Places");
            DropTable("Users");
        }
    }
}
