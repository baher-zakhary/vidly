namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_membership_type_name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
