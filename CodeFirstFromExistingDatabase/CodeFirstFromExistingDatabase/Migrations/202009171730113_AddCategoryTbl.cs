namespace CodeFirstFromExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("Insert into Categories values('Web Developement')");
            Sql("Insert into Categories values('ASP.NET')");

        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
