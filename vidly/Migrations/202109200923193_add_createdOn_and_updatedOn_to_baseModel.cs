namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_createdOn_and_updatedOn_to_baseModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "UpdatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.MembershipTypes", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.MembershipTypes", "UpdatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "numberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "UpdatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Genres", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Genres", "UpdatedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Genres", "UpdatedOn");
            DropColumn("dbo.Genres", "CreatedOn");
            DropColumn("dbo.Movies", "UpdatedOn");
            DropColumn("dbo.Movies", "CreatedOn");
            DropColumn("dbo.Movies", "numberInStock");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.MembershipTypes", "UpdatedOn");
            DropColumn("dbo.MembershipTypes", "CreatedOn");
            DropColumn("dbo.Customers", "UpdatedOn");
            DropColumn("dbo.Customers", "CreatedOn");
        }
    }
}
