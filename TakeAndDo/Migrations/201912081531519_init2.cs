namespace TakeAndDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("sheldoncooper.AspNetUsers", "PersonName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("sheldoncooper.AspNetUsers", "PersonName");
        }
    }
}
