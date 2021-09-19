namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_is_subscribed_to_news_letter_to_customer_class : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscribedToNewsLetter");
        }
    }
}
