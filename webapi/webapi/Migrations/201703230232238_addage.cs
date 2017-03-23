namespace webapi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "age", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "age");
        }
    }
}
