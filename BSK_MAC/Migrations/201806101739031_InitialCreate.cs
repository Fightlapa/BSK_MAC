namespace BSK_MAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Miastoes",
                c => new
                    {
                        Nazwa = c.String(nullable: false, maxLength: 4000),
                        Wojewodztwo = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Nazwa);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Miastoes");
        }
    }
}
