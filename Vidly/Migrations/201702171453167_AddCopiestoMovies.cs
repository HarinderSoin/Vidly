namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCopiestoMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberOfCopies", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberOfCopies");
        }
    }
}
