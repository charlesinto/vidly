namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreToMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenreTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "genreType_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Movies", "genreType_Id");
            AddForeignKey("dbo.Movies", "genreType_Id", "dbo.GenreTypes", "Id", cascadeDelete: true);
            Sql("Insert Into GenreTypes( Name) VALUES ('Comdey')");
            Sql("Insert Into GenreTypes(Name) VALUES ('Romance')");
            Sql("Insert Into GenreTypes( Name) VALUES ('Action')");
            Sql("Insert Into GenreTypes( Name) VALUES ('Family')");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "genreType_Id", "dbo.GenreTypes");
            DropIndex("dbo.Movies", new[] { "genreType_Id" });
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "genreType_Id");
            DropColumn("dbo.Movies", "GenreId");
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropTable("dbo.GenreTypes");
        }
    }
}
