namespace Metrics_Track.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;
    using System;
    using System.Text;

    public partial class SSCViewCurrentStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            StringBuilder currentStatusView = new StringBuilder();

            currentStatusView.Append("CREATE VIEW [CPS].[SSC_View_UserCurrent]" + Environment.NewLine);
            currentStatusView.Append("AS" + Environment.NewLine);
            currentStatusView.Append("SELECT R.[ID_Login],R.[Display Name],R.[TeamLead] AS [Team Leader],R.[Type],R.[ChangeStamp] AS [Last Update],R.[Comment],R.[Sandbox] " + Environment.NewLine);
            currentStatusView.Append("FROM (SELECT [CPS].[tbl_UserActivity].[ID_Login],[FirstName] + ' ' + [LastName] as [Display Name],[TeamLead],[Type],[ChangeStamp],[Comment],[CPS].[tbl_UserActivity].[Sandbox] " + Environment.NewLine);
            currentStatusView.Append(",RANK() OVER (PARTITION BY [CPS].[tbl_UserActivity].[ID_Login] ORDER BY [ChangeStamp] DESC) time_rank " + Environment.NewLine);
            currentStatusView.Append("FROM CPS.AspNetUsers RIGHT OUTER JOIN CPS.tbl_UserActivity ON CPS.AspNetUsers.ID_Login = CPS.tbl_UserActivity.ID_Login " + Environment.NewLine);
            currentStatusView.Append("RIGHT OUTER JOIN [CPS].[tbl_TeamLead] ON [CPS].[tbl_TeamLead].Id_TeamLead = CPS.AspNetUsers.ID_TeamLead " + Environment.NewLine);
            currentStatusView.Append("WHERE[ChangeStamp] >= DATEADD(mm, - 3, Getdate())) R WHERE r.time_rank = 1" + Environment.NewLine);

            migrationBuilder.Sql(currentStatusView.ToString());
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW [CPS].[SSC_View_UserCurrent]");
        }
    }
}
