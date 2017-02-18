namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToGeneres : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres values (1, 'Comedy')");
            Sql("Insert into Genres values (2, 'Action')");
            Sql("Insert into Genres values (3, 'Romance')");
            Sql("Insert into Genres values (4, 'Action')");
            Sql("Insert into Genres values (5, 'Family')");
        }
        
        public override void Down()
        {
        }
    }
}
