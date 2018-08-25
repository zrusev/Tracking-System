namespace Metrics_Track.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;
    using System;
    using System.Text;

    public partial class SCCViewReporting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            StringBuilder allTransactionsView = new StringBuilder();

            allTransactionsView.Append("CREATE VIEW [CPS].[SSC_View_Reporting]" + Environment.NewLine);
            allTransactionsView.Append("AS" + Environment.NewLine);
            allTransactionsView.Append("SELECT CPS.tbl_Volume_Main.Transaction_ID as [Transaction ID], CPS.tbl_Process.Function_Name AS [Function Name], tbl_Country_1.Country, CPS.tbl_TeamLead.TeamLead AS [Team Leader], " + Environment.NewLine);
            allTransactionsView.Append("CPS.AspNetUsers.FirstName + ' ' + CPS.AspNetUsers.LastName AS [User Name], CPS.tbl_Process.Process, CPS.tbl_Process.[Process Map], CPS.tbl_Activity.Activity, CPS.tbl_LOB.LOB, " + Environment.NewLine);
            allTransactionsView.Append("CPS.tbl_Volume_Main.ReceivedDate as [Received Date], CPS.tbl_Volume_Main.StartDate as [Start Date], CPS.tbl_Volume_Main.CompleteDate as [Complete Date], CPS.tbl_Volume_Main.Comment, " + Environment.NewLine);
            allTransactionsView.Append("CPS.tbl_Volume_Main.ID_Number as [ID Number], CASE WHEN CPS.tbl_Volume_Main.priority = 0 OR CPS.tbl_Volume_Main.Status_Code = 2 THEN CPS.tbl_Status.Status ELSE 'Priority' END AS Status, " + Environment.NewLine);
            allTransactionsView.Append("CPS.tbl_Volume_Main.Premium, CPS.tbl_Volume_Main.Currency_Code as [Currency Code], CPS.tbl_Volume_Main.Priority, CPS.tbl_Volume_Main.Inception_Date as [Inception Date], " + Environment.NewLine);
            allTransactionsView.Append("CPS.tbl_Volume_Main.Date_Received_in_AIG as [Date Received In Company], CASE WHEN [Precalc SLA Hours] IS NULL THEN CPS.SSC_GetSLAHrs(CPS.tbl_Volume_Main.Original_ID, CPS.tbl_Volume_Main.ReceivedDate, " + Environment.NewLine);
            allTransactionsView.Append("CPS.tbl_Volume_Main.CompleteDate, CPS.tbl_TeamLead.TeamLead, CPS.tbl_Process.[SLA Type], CPS.tbl_Volume_Main.Priority, CPS.tbl_Country.Country) " + Environment.NewLine);
            allTransactionsView.Append("ELSE [Precalc SLA Hours] END AS [SLA Hrs], CASE WHEN CPS.tbl_Volume_Main.Priority = 0 THEN CPS.tbl_Process.[SLA Target] ELSE 4 END AS [SLA Target], " + Environment.NewLine);
            allTransactionsView.Append("CASE WHEN CPS.tbl_Volume_Main.Priority = 1 THEN 'Short' ELSE CPS.tbl_Process.[SLA Type] END AS [SLA Type], " + Environment.NewLine);
            allTransactionsView.Append("CASE WHEN CASE WHEN [Precalc SLA Hours] IS NULL THEN CPS.SSC_GetSLAHrs(CPS.tbl_Volume_Main.Original_ID, CPS.tbl_Volume_Main.ReceivedDate, " + Environment.NewLine);
            allTransactionsView.Append("CPS.tbl_Volume_Main.CompleteDate, CPS.tbl_TeamLead.TeamLead, CPS.tbl_Process.[SLA Type], CPS.tbl_Volume_Main.Priority, CPS.tbl_Country.Country) " + Environment.NewLine);
            allTransactionsView.Append("ELSE [Precalc SLA Hours] END <= CASE WHEN CPS.tbl_Volume_Main.Priority = 0 THEN CPS.tbl_Process.[SLA Target] ELSE 4 END THEN 1 ELSE 0 END AS [SLA Achievement], " + Environment.NewLine);
            allTransactionsView.Append("CASE WHEN [Precalc HT] IS NULL THEN CPS.SSC_GetWorkingMin(CPS.tbl_Volume_Main.Original_ID, CPS.tbl_Volume_Main.StartDate, " + Environment.NewLine);
            allTransactionsView.Append("CPS.tbl_Volume_Main.CompleteDate) ELSE [Precalc HT] END AS [Handling Time], 'WK' + RIGHT('0' + CAST(DATEPART(wk, CPS.tbl_Volume_Main.CompleteDate) AS varchar(10)), 2) " + Environment.NewLine);
            allTransactionsView.Append("+ '_' + CAST(DATEPART(yyyy, CPS.tbl_Volume_Main.CompleteDate) AS Varchar(10)) AS Week, LEFT(DATENAME(month, CPS.tbl_Volume_Main.CompleteDate), 3) " + Environment.NewLine);
            allTransactionsView.Append("+ '_' + CAST(DATEPART(yyyy, CPS.tbl_Volume_Main.CompleteDate) AS Varchar(10)) AS Month, CPS.tbl_Volume_Main.Sandbox " + Environment.NewLine);
            allTransactionsView.Append("FROM CPS.tbl_Volume_Main  RIGHT OUTER JOIN" + Environment.NewLine);
            allTransactionsView.Append("CPS.tbl_Status ON CPS.tbl_Volume_Main.ID_Status = CPS.tbl_Status.ID_Status LEFT OUTER JOIN " + Environment.NewLine);
            allTransactionsView.Append("CPS.tbl_TowerCategory ON CPS.tbl_Volume_Main.ID_TowerCategory = CPS.tbl_TowerCategory.ID_TowerCategory LEFT OUTER JOIN " + Environment.NewLine);
            allTransactionsView.Append("CPS.tbl_Division ON CPS.tbl_Volume_Main.ID_Division = CPS.tbl_Division.ID_Division LEFT OUTER JOIN " + Environment.NewLine);
            allTransactionsView.Append("CPS.tbl_Process ON CPS.tbl_Volume_Main.ID_Process = CPS.tbl_Process.ID_Process LEFT OUTER JOIN " + Environment.NewLine);
            allTransactionsView.Append("CPS.tbl_Tower ON CPS.tbl_Volume_Main.ID_Tower = CPS.tbl_Tower.ID_Tower LEFT OUTER JOIN " + Environment.NewLine);
            allTransactionsView.Append("CPS.tbl_Country ON CPS.tbl_Volume_Main.ID_Country = CPS.tbl_Country.ID_Country LEFT OUTER JOIN " + Environment.NewLine);
            allTransactionsView.Append("CPS.tbl_Activity ON CPS.tbl_Volume_Main.ID_Activity = CPS.tbl_Activity.ID_Activity LEFT OUTER JOIN " + Environment.NewLine);
            allTransactionsView.Append("CPS.tbl_LOB ON CPS.tbl_Volume_Main.ID_LOB = CPS.tbl_LOB.ID_LOB LEFT OUTER JOIN " + Environment.NewLine);
            allTransactionsView.Append("CPS.tbl_Country AS tbl_Country_1 ON CPS.tbl_Volume_Main.ID_Country = tbl_Country_1.ID_Country LEFT OUTER JOIN " + Environment.NewLine);
            allTransactionsView.Append("CPS.AspNetUsers ON CPS.tbl_Volume_Main.ID_Login = CPS.AspNetUsers.ID_Login LEFT OUTER JOIN " + Environment.NewLine);
            allTransactionsView.Append("CPS.tbl_TeamLead ON CPS.tbl_TeamLead.Id_TeamLead = CPS.AspNetUsers.ID_TeamLead " + Environment.NewLine);
            allTransactionsView.Append("WHERE (CPS.tbl_Volume_Main.Status_Code = 1) OR (CPS.tbl_Volume_Main.Status_Code = 2) " + Environment.NewLine);

            migrationBuilder.Sql(allTransactionsView.ToString());
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW [CPS].[SSC_View_Reporting]");
        }
    }
}
