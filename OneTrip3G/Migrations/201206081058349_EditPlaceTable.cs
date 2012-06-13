namespace OneTrip3G.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class EditPlaceTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Places", "VideoSize", c => c.Int());
            AlterColumn("Places", "MapSize", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("Places", "MapSize", c => c.String());
            AlterColumn("Places", "VideoSize", c => c.String());
        }
    }
}
