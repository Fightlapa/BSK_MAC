namespace BSK_MAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Uzytkowniks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Imie = c.String(maxLength: 4000),
                        Nazwisko = c.String(maxLength: 4000),
                        Clearance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Uzytkowniks");
        }
    }
}
