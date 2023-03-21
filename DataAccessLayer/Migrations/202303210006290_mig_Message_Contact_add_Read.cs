namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_Message_Contact_add_Read : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactRead", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "MessageRead", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "MessageStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageStatus");
            DropColumn("dbo.Messages", "MessageRead");
            DropColumn("dbo.Contacts", "ContactRead");
        }
    }
}
