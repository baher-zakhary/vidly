namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populate_membership_type : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (1, 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (2, 30, 1, 10)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (3, 90, 3, 15)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (4, 300, 12, 20)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM MembershipTypes WHERE Id = 1");
            Sql("DELETE FROM MembershipTypes WHERE Id = 2");
            Sql("DELETE FROM MembershipTypes WHERE Id = 3");
            Sql("DELETE FROM MembershipTypes WHERE Id = 4");
        }
    }
}
