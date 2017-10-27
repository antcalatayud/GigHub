namespace GigHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulalteGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Jazz')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Pop')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Rock')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id in (1, 2, 3)");
        }
    }
}
