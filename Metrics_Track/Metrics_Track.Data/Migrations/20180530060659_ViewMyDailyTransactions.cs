namespace Metrics_Track.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;
    using System;
    using System.Text;

    public partial class ViewMyDailyTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "SSCViewMyTransactions",
            //    schema: "CPS",
            //    columns: table => new
            //    {
            //        Transaction_ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Activity = table.Column<string>(nullable: true),
            //        AspID_Login = table.Column<int>(nullable: true),
            //        Audit = table.Column<int>(nullable: false),
            //        Comment = table.Column<string>(nullable: true),
            //        CompleteDate = table.Column<DateTime>(nullable: true),
            //        Country = table.Column<string>(nullable: true),
            //        Currency_Code = table.Column<string>(nullable: true),
            //        FunctionName = table.Column<string>(name: "Function Name", nullable: true),
            //        HandlingTime = table.Column<double>(name: "Handling Time", nullable: true),
            //        ID_Login = table.Column<int>(nullable: true),
            //        ID_Number = table.Column<string>(nullable: true),
            //        Lob = table.Column<string>(nullable: true),
            //        Mnc = table.Column<string>(nullable: true),
            //        MultiStepTransaction = table.Column<int>(name: "Multi-Step Transaction", nullable: false),
            //        Premium = table.Column<double>(nullable: true),
            //        Priority = table.Column<short>(nullable: true),
            //        Process = table.Column<string>(nullable: true),
            //        ProcessMap = table.Column<string>(name: "Process Map", nullable: true),
            //        ReceivedDate = table.Column<DateTime>(nullable: true),
            //        SLAAchievment = table.Column<int>(name: "SLA Achievment", nullable: false),
            //        SLAHrs = table.Column<double>(name: "SLA Hrs", nullable: true),
            //        SLATarget = table.Column<int>(name: "SLA Target", nullable: true),
            //        SLATransaction = table.Column<int>(name: "SLA Transaction", nullable: false),
            //        SLAType = table.Column<string>(name: "SLA Type", nullable: true),
            //        StartDate = table.Column<DateTime>(nullable: true),
            //        Status = table.Column<string>(nullable: true),
            //        TeamLeader = table.Column<string>(name: "Team Leader", nullable: true),
            //        UserName = table.Column<string>(name: "User Name", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SSCViewMyTransactions", x => x.Transaction_ID);
            //    });

            StringBuilder dailyTransactionsView = new StringBuilder();

            dailyTransactionsView.Append("CREATE VIEW [CPS].[SSC_View_MyTransactions]" + Environment.NewLine);
            dailyTransactionsView.Append("AS" + Environment.NewLine);
            dailyTransactionsView.Append("SELECT TOP (100) PERCENT CPS.tbl_Volume_Main.Transaction_ID, CPS.tbl_Process.Function_Name AS [Function Name], tbl_Country_1.Country," + Environment.NewLine);
            dailyTransactionsView.Append("CPS.tbl_TeamLead.TeamLead AS [Team Leader], CASE WHEN [Display Name] IS NULL THEN ASPNETUSERS.USERNAME ELSE [Display Name] END AS [User Name], " + Environment.NewLine);
            dailyTransactionsView.Append("CPS.tbl_Process.Process, CPS.tbl_Process.[Process Map], CPS.tbl_Activity.Activity, CPS.tbl_LOB.LOB, CPS.tbl_Volume_Main.ReceivedDate, " + Environment.NewLine);
            dailyTransactionsView.Append("CPS.tbl_Volume_Main.StartDate, CPS.tbl_Volume_Main.CompleteDate, CPS.tbl_Volume_Main.Comment, CPS.tbl_Volume_Main.ID_Number, CPS.tbl_Status.Status, " + Environment.NewLine);
            dailyTransactionsView.Append("CPS.tbl_Volume_Main.Premium, CPS.tbl_Volume_Main.Currency_Code, CPS.tbl_Process.MNC, CPS.tbl_Volume_Main.Priority, " + Environment.NewLine);
            dailyTransactionsView.Append("CASE WHEN [Precalc SLA Hours] IS NULL THEN CPS.SSC_GetSLAHrs(CPS.tbl_Volume_Main.Original_ID, CPS.tbl_Volume_Main.ReceivedDate, " + Environment.NewLine);
            dailyTransactionsView.Append("CPS.tbl_Volume_Main.CompleteDate, CPS.tbl_TeamLead.TeamLead, CPS.tbl_Process.[SLA Type], CPS.tbl_Volume_Main.Priority, CPS.tbl_Country.Country) " + Environment.NewLine);
            dailyTransactionsView.Append("ELSE [Precalc SLA Hours] END AS [SLA Hrs], CASE WHEN CPS.tbl_Volume_Main.Priority = 0 THEN CPS.tbl_Process.[SLA Target] ELSE 4 END AS [SLA Target], " + Environment.NewLine);
            dailyTransactionsView.Append("CPS.tbl_Process.[SLA Type], 1 AS [SLA Transaction], CASE WHEN CASE WHEN [Precalc SLA Hours] IS NULL " + Environment.NewLine);
            dailyTransactionsView.Append("THEN CPS.SSC_GetSLAHrs(CPS.tbl_Volume_Main.Original_ID, CPS.tbl_Volume_Main.ReceivedDate, CPS.tbl_Volume_Main.CompleteDate, CPS.tbl_TeamLead.TeamLead, " + Environment.NewLine);
            dailyTransactionsView.Append("CPS.tbl_Process.[SLA Type], CPS.tbl_Volume_Main.Priority, CPS.tbl_Country.Country) " + Environment.NewLine);
            dailyTransactionsView.Append("ELSE [Precalc SLA Hours] END <= CASE WHEN CPS.tbl_Volume_Main.Priority = 0 THEN CPS.tbl_Process.[SLA Target] ELSE 4 END THEN 1 ELSE 0 END AS [SLA Achievment], " + Environment.NewLine);
            dailyTransactionsView.Append("CASE WHEN [Precalc HT] IS NULL THEN CPS.SSC_GetWorkingMin(CPS.tbl_Volume_Main.Original_ID, CPS.tbl_Volume_Main.StartDate, " + Environment.NewLine);
            dailyTransactionsView.Append("CPS.tbl_Volume_Main.CompleteDate) ELSE [Precalc HT] END AS [Handling Time], CASE WHEN CPS.tbl_Volume_Main.Original_ID IS NULL " + Environment.NewLine);
            dailyTransactionsView.Append("THEN 0 ELSE 1 END AS [Multi-Step Transaction], CASE WHEN CPS.tbl_Volume_Main.Attachments IS NULL THEN 0 ELSE 1 END AS Audit, CPS.tbl_Login.ID_Login, " + Environment.NewLine);
            dailyTransactionsView.Append("CPS.AspNetUsers.ID_Login AS AspID_Login " + Environment.NewLine);
            dailyTransactionsView.Append("FROM CPS.tbl_Status RIGHT OUTER JOIN " + Environment.NewLine);
            dailyTransactionsView.Append("CPS.tbl_Volume_Main ON CPS.tbl_Status.ID_Status = CPS.tbl_Volume_Main.ID_Status LEFT OUTER JOIN " + Environment.NewLine);
            dailyTransactionsView.Append("CPS.tbl_TowerCategory ON CPS.tbl_Volume_Main.ID_TowerCategory = CPS.tbl_TowerCategory.ID_TowerCategory LEFT OUTER JOIN " + Environment.NewLine);
            dailyTransactionsView.Append("CPS.tbl_Division ON CPS.tbl_Volume_Main.ID_Division = CPS.tbl_Division.ID_Division LEFT OUTER JOIN " + Environment.NewLine);
            dailyTransactionsView.Append("CPS.tbl_Process ON CPS.tbl_Volume_Main.ID_Process = CPS.tbl_Process.ID_Process LEFT OUTER JOIN " + Environment.NewLine);
            dailyTransactionsView.Append("CPS.tbl_Tower ON CPS.tbl_Volume_Main.ID_Tower = CPS.tbl_Tower.ID_Tower LEFT OUTER JOIN " + Environment.NewLine);
            dailyTransactionsView.Append("CPS.tbl_Country ON CPS.tbl_Volume_Main.ID_Country = CPS.tbl_Country.ID_Country LEFT OUTER JOIN " + Environment.NewLine);
            dailyTransactionsView.Append("CPS.tbl_Activity ON CPS.tbl_Volume_Main.ID_Activity = CPS.tbl_Activity.ID_Activity LEFT OUTER JOIN " + Environment.NewLine);
            dailyTransactionsView.Append("CPS.tbl_Country AS tbl_Country_1 ON CPS.tbl_Volume_Main.ID_Country = tbl_Country_1.ID_Country LEFT OUTER JOIN " + Environment.NewLine);
            dailyTransactionsView.Append("CPS.tbl_Login ON CPS.tbl_Volume_Main.ID_Login = CPS.tbl_Login.ID_Login LEFT OUTER JOIN " + Environment.NewLine);
            dailyTransactionsView.Append("CPS.tbl_LOB ON CPS.tbl_Volume_Main.ID_LOB = CPS.tbl_LOB.ID_LOB LEFT OUTER JOIN " + Environment.NewLine);
            dailyTransactionsView.Append("CPS.AspNetUsers ON CPS.tbl_Volume_Main.ID_Login = CPS.AspNetUsers.ID_Login LEFT OUTER JOIN" + Environment.NewLine);
            dailyTransactionsView.Append("CPS.tbl_TeamLead ON CPS.tbl_TeamLead.Id_TeamLead = CPS.AspNetUsers.ID_TeamLead " + Environment.NewLine);
            dailyTransactionsView.Append("WHERE (CPS.tbl_Volume_Main.Status_Code = 1) " + Environment.NewLine);
            dailyTransactionsView.Append("AND (CPS.tbl_Volume_Main.CompleteDate > DATEADD(d, DATEDIFF(d, 0, CPS.tbl_Volume_Main.CompleteDate), 0)) OR (CPS.tbl_Volume_Main.Status_Code = 2)" + Environment.NewLine);            

            migrationBuilder.Sql(dailyTransactionsView.ToString());
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "SSCViewMyTransactions",
            //    schema: "CPS");

            migrationBuilder.Sql("DROP VIEW [CPS].[SSC_View_MyTransactions]");

        }
    }
}
