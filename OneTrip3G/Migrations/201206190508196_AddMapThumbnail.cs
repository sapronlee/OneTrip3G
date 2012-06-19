namespace OneTrip3G.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddMapThumbnail : DbMigration
    {
        public override void Up()
        {
            AddColumn("Places", "MapThumbnailFile", c => c.String());
            AddColumn("Places", "MapThumbnailSize", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Places", "MapThumbnailSize");
            DropColumn("Places", "MapThumbnailFile");
        }
    }
}
