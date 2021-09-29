namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_phone_to_Register_and_external_login : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Phone");
        }
    }
}
