namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyGenreTypeInMovie : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Movies", name: "genreType_Id", newName: "genreTypeId");
            RenameIndex(table: "dbo.Movies", name: "IX_genreType_Id", newName: "IX_genreTypeId");
            DropColumn("dbo.Movies", "GenreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Movies", name: "IX_genreTypeId", newName: "IX_genreType_Id");
            RenameColumn(table: "dbo.Movies", name: "genreTypeId", newName: "genreType_Id");
        }
    }
}
