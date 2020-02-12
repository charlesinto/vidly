namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMemebershipType1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DurationInMonth, DiscountRate) VALUES(6, 1000, 30, 40)");

        }
        public override void Down()
        {
        }
    }
        
        
}

