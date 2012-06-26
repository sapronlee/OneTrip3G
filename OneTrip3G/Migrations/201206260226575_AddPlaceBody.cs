namespace OneTrip3G.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddPlaceBody : DbMigration
    {
        public override void Up()
        {
            AddColumn("Places", "Body", b => b.String(maxLength: 2000));
        }
        
        public override void Down()
        {
            DropColumn("Places", "Body");
        }
    }
}
