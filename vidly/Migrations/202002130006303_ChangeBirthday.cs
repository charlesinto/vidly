namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBirthday : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE CUSTOMERS SET birthdate = '12/07/1995' where Id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
