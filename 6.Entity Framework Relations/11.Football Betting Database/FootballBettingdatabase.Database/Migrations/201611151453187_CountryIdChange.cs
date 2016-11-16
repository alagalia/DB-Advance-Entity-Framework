namespace FootballBettingdatabase.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CountryIdChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CountryContinents", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Towns", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Towns", new[] { "Country_Id" });
            DropIndex("dbo.CountryContinents", new[] { "Country_Id" });
            DropPrimaryKey("dbo.Countries");
            DropPrimaryKey("dbo.CountryContinents");
            DropColumn("dbo.Countries", "Id");
            AddColumn("dbo.Countries", "Id", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.Towns", "Country_Id", c => c.String(maxLength: 3));
            AlterColumn("dbo.CountryContinents", "Country_Id", c => c.String(nullable: false, maxLength: 3));
            AddPrimaryKey("dbo.Countries", "Id");
            AddPrimaryKey("dbo.CountryContinents", new[] { "Country_Id", "Continent_Id" });
            CreateIndex("dbo.Towns", "Country_Id");
            CreateIndex("dbo.CountryContinents", "Country_Id");
            AddForeignKey("dbo.CountryContinents", "Country_Id", "dbo.Countries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Towns", "Country_Id", "dbo.Countries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Towns", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.CountryContinents", "Country_Id", "dbo.Countries");
            DropIndex("dbo.CountryContinents", new[] { "Country_Id" });
            DropIndex("dbo.Towns", new[] { "Country_Id" });
            DropPrimaryKey("dbo.CountryContinents");
            DropPrimaryKey("dbo.Countries");
            AlterColumn("dbo.CountryContinents", "Country_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Towns", "Country_Id", c => c.Int());
            AlterColumn("dbo.Countries", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CountryContinents", new[] { "Country_Id", "Continent_Id" });
            AddPrimaryKey("dbo.Countries", "Id");
            CreateIndex("dbo.CountryContinents", "Country_Id");
            CreateIndex("dbo.Towns", "Country_Id");
            AddForeignKey("dbo.Towns", "Country_Id", "dbo.Countries", "Id");
            AddForeignKey("dbo.CountryContinents", "Country_Id", "dbo.Countries", "Id", cascadeDelete: true);
        }
    }
}
