namespace BSK_MAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Garazs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PojemnoscOsobowych = c.Int(nullable: false),
                        PojemnoscCiezarowych = c.Int(nullable: false),
                        Classification = c.Int(nullable: false),
                        NazwaMiasta_Nazwa = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Miastoes", t => t.NazwaMiasta_Nazwa)
                .Index(t => t.NazwaMiasta_Nazwa);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Garazs", "NazwaMiasta_Nazwa", "dbo.Miastoes");
            DropIndex("dbo.Garazs", new[] { "NazwaMiasta_Nazwa" });
            DropTable("dbo.Garazs");
        }
    }
}
