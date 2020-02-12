namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMemebershipType : DbMigration
    {
        public override void Up()
        {
            
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DurationInMonth, DiscountRate) VALUES(1, 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DurationInMonth, DiscountRate) VALUES(2, 30, 1, 10)");
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DurationInMonth, DiscountRate) VALUES(3, 90, 3, 15)");
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DurationInMonth, DiscountRate) VALUES(4, 300, 12, 20)");
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DurationInMonth, DiscountRate) VALUES(5, 500, 24, 25)");
        }
        
        public override void Down()
        {
        }
    }
}
