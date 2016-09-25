namespace ORM.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version_11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        CardID = c.Int(nullable: false, identity: true),
                        CardNo = c.String(nullable: false, maxLength: 19),
                        EmployeeID = c.Int(nullable: false),
                        ValidThrough = c.DateTime(nullable: false),
                        CardHolder = c.String(nullable: false, maxLength: 31),
                    })
                .PrimaryKey(t => t.CardID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID)
                .Index(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditCards", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.CreditCards", new[] { "EmployeeID" });
            DropTable("dbo.CreditCards");
        }
    }
}
