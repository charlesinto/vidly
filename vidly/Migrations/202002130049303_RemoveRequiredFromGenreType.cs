namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredFromGenreType : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Movies", "genreTypeId");
            AddForeignKey("dbo.Movies", "genreTypeId", "dbo.genreTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
        }
    }
}
