namespace Metrics_Track.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;
    using System.IO;
    using System.Text;

    public partial class SeedDataToDatabase : Migration
    {
        private const string MIGRATION_SQL_SCRIPT_FILE_NAME = @"..\Metrics_Track.Scripts\SeedDatabase.Script.sql";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (File.Exists(MIGRATION_SQL_SCRIPT_FILE_NAME))
            {
                var script = File.ReadAllLines(MIGRATION_SQL_SCRIPT_FILE_NAME);

                StringBuilder scalarScripts = new StringBuilder();

                foreach (var line in script)
                {
                    scalarScripts.AppendLine(line);
                }

                migrationBuilder.Sql(scalarScripts.ToString());
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
