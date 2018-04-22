namespace EmployeesTest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "BornDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "BornDate", c => c.DateTime(nullable: false));
        }
    }
}
