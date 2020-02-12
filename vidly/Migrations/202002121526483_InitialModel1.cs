namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        _movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t._movie_Id)
                .Index(t => t._movie_Id);
            
            AddColumn("dbo.Customers", "Rental_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Rental_Id");
            AddForeignKey("dbo.Customers", "Rental_Id", "dbo.Rentals", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Rental_Id", "dbo.Rentals");
            DropForeignKey("dbo.Rentals", "_movie_Id", "dbo.Movies");
            DropIndex("dbo.Rentals", new[] { "_movie_Id" });
            DropIndex("dbo.Customers", new[] { "Rental_Id" });
            DropColumn("dbo.Customers", "Rental_Id");
            DropTable("dbo.Rentals");
            DropTable("dbo.Movies");
        }
    }
}
