namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateOfBirthData : DbMigration
    {
        public override void Up()
        {
            Sql("Update Customers set dateofbirth = '12-24-1967' where customername = 'John Smith'"); 
        }
        
        public override void Down()
        {
        }
    }
}
