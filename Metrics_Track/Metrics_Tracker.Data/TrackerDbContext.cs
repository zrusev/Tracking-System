namespace Metrics_Track.Data.Models
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    
    public class TrackerDbContext : IdentityDbContext<User>            
    {
        public TrackerDbContext(DbContextOptions<TrackerDbContext> options)
            :base(options)
        {
        }

        public DbSet<tbl_HolidayTable> HolidayTable { get; set; }
        public DbSet<tbl_Activity> TblActivity { get; set; }
        public DbSet<tbl_Country> TblCountry { get; set; }
        public DbSet<tbl_Division> TblDivision { get; set; }
        public DbSet<tbl_InternalErrorsLog> TblInternalErrorsLog { get; set; }
        public DbSet<tbl_L2Id> TblL2Id { get; set; }
        public DbSet<tbl_Lob> TblLob { get; set; }
        public DbSet<tbl_Login> TblLogin { get; set; }
        public DbSet<tbl_Mining> TblMining { get; set; }
        public DbSet<tbl_Objects> TblObjects { get; set; }
        public DbSet<tbl_Process> TblProcess { get; set; }
        public DbSet<tbl_ReportingUsers> TblReportingUsers { get; set; }
        public DbSet<tbl_Specific> TblSpecific { get; set; }
        public DbSet<tbl_Status> TblStatus { get; set; }
        public DbSet<tbl_Tower> TblTower { get; set; }
        public DbSet<tbl_TowerCategory> TblTowerCategory { get; set; }
        public DbSet<tbl_TrackerVer> TblTrackerVer { get; set; }
        public DbSet<tbl_UserActivity> TblUserActivity { get; set; }
        public DbSet<tbl_VolumeMain> TblVolumeMain { get; set; }
        public DbSet<trel_CountryProcess> TrelCountryProcess { get; set; }
        public DbSet<trel_ProcessActivity> TrelProcessActivity { get; set; }
        public DbSet<trel_ProcessDivision> TrelProcessDivision { get; set; }
        public DbSet<trel_ProcessLob> TrelProcessLob { get; set; }
        public DbSet<trel_ProcessStatus> TrelProcessStatus { get; set; }
        public DbSet<trel_ProcessTower> TrelProcessTower { get; set; }
        public DbSet<trel_ProcessTowerCategory> TrelProcessTowerCategory { get; set; }
        public DbSet<trel_UserCountry> TrelUserCountry { get; set; }
        public DbSet<trel_UserMining> TrelUserMining { get; set; }
        public DbSet<tbl_QualityIntegration> TblQualityIntegration { get; set; }
        public DbSet<trel_AgentCountry> TrelAgentCountry { get; set; }
        public DbSet<trel_CountryMining> TrelCountryMining { get; set; }
        public DbSet<SSC_View_MyTransactions> SSCViewMyTransactions { get; set; }
        public DbSet<tbl_TeamLead> TblTeamLead { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("CPS");

            builder.Entity<tbl_HolidayTable>(entity =>
            {
                entity.ToTable("Holiday Table", "CPS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Country).HasMaxLength(255);

                entity.Property(e => e.FunctionName)
                    .HasColumnName("Function_Name")
                    .HasMaxLength(255);

                entity.Property(e => e.HolidayDate)
                    .HasColumnName("Holiday Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TeamLead).HasMaxLength(255);
            });

            builder.Entity<tbl_Activity>(entity =>
            {
                entity.HasKey(e => e.IdActivity);

                entity.ToTable("tbl_Activity", "CPS");

                entity.Property(e => e.IdActivity).HasColumnName("ID_Activity");

                entity.Property(e => e.Activity).HasMaxLength(255);
            });

            builder.Entity<tbl_Country>(entity =>
            {
                entity.HasKey(e => e.IdCountry);

                entity.ToTable("tbl_Country", "CPS");

                entity.Property(e => e.IdCountry).HasColumnName("ID_Country");

                entity.Property(e => e.Country).HasMaxLength(255);

                entity.Property(e => e.RefSite)
                    .HasColumnName("Ref Site")
                    .HasMaxLength(255);

                entity.Property(e => e.SpphIdCountry).HasColumnName("SPPH_ID_Country");
            });

            builder.Entity<tbl_Division>(entity =>
            {
                entity.HasKey(e => e.IdDivision);

                entity.ToTable("tbl_Division", "CPS");

                entity.Property(e => e.IdDivision).HasColumnName("ID_Division");

                entity.Property(e => e.Division).HasMaxLength(255);
            });

            builder.Entity<tbl_InternalErrorsLog>(entity =>
            {
                entity.ToTable("tbl_Internal_Errors_Log", "CPS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TimeStamp)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            builder.Entity<tbl_L2Id>(entity =>
            {
                entity.HasKey(e => e.IdProcess);

                entity.ToTable("tbl_L2_ID", "CPS");

                entity.Property(e => e.IdProcess).HasColumnName("ID_Process");

                entity.Property(e => e.L2).HasMaxLength(255);

                entity.Property(e => e.L2Id)
                    .HasColumnName("L2_ID")
                    .HasMaxLength(255);
            });

            builder.Entity<tbl_Lob>(entity =>
            {
                entity.HasKey(e => e.IdLob);

                entity.ToTable("tbl_LOB", "CPS");

                entity.Property(e => e.IdLob).HasColumnName("ID_LOB");

                entity.Property(e => e.Lob)
                    .HasColumnName("LOB")
                    .HasMaxLength(255);

                entity.Property(e => e.MmcpLob)
                    .HasColumnName("MMCP LOB")
                    .HasMaxLength(50);

                entity.Property(e => e.MmcpSegment)
                    .HasColumnName("MMCP SEGMENT")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductLine1)
                    .HasColumnName("Product Line 1")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductLine2)
                    .HasColumnName("Product Line 2")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductLine3)
                    .HasColumnName("Product Line 3")
                    .HasMaxLength(50);

                entity.Property(e => e.SpphIdProduct).HasColumnName("SPPH_ID_PRODUCT");
            });

            builder.Entity<tbl_Login>(entity =>
            {
                entity.HasKey(e => e.IdLogin);

                entity.ToTable("tbl_Login", "CPS");

                entity.Property(e => e.IdLogin).HasColumnName("ID_Login");

                entity.Property(e => e.DisplayName)
                    .HasColumnName("Display Name")
                    .HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.ServerName).HasMaxLength(255);

                entity.Property(e => e.Site).HasMaxLength(10);

                entity.Property(e => e.SsphIdUser).HasColumnName("SSPH_ID_USER");

                entity.Property(e => e.TeamLead).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(255);
            });

            builder.Entity<tbl_Mining>(entity =>
            {
                entity.HasKey(e => e.IdMining);

                entity.ToTable("tbl_Mining", "CPS");

                entity.Property(e => e.IdMining).HasColumnName("ID_Mining");

                entity.Property(e => e.State).HasMaxLength(255);
            });

            builder.Entity<tbl_Objects>(entity =>
            {
                entity.HasKey(e => e.IdObject);

                entity.ToTable("tbl_Objects", "CPS");

                entity.Property(e => e.IdObject).HasColumnName("ID_Object");

                entity.Property(e => e.CaptureText).HasMaxLength(255);

                entity.Property(e => e.FieldName).HasMaxLength(50);

                entity.Property(e => e.IdCountry).HasColumnName("ID_Country");

                entity.Property(e => e.IsVisible).HasMaxLength(255);

                entity.Property(e => e.Location).HasMaxLength(255);

                entity.Property(e => e.ObjectName).HasMaxLength(255);

                entity.Property(e => e.ObjectType).HasMaxLength(255);
            });

            builder.Entity<tbl_Process>(entity =>
            {
                entity.HasKey(e => e.IdProcess);

                entity.ToTable("tbl_Process", "CPS");

                entity.Property(e => e.IdProcess).HasColumnName("ID_Process");

                entity.Property(e => e.FunctionName)
                    .HasColumnName("Function_Name")
                    .HasMaxLength(255);

                entity.Property(e => e.Group).HasMaxLength(255);

                entity.Property(e => e.Level2Taxonomy)
                    .HasColumnName("Level 2 Taxonomy")
                    .HasMaxLength(255);

                entity.Property(e => e.Level3Taxonomy)
                    .HasColumnName("Level 3 Taxonomy")
                    .HasMaxLength(255);

                entity.Property(e => e.Mnc)
                    .IsRequired()
                    .HasColumnName("MNC")
                    .HasMaxLength(50);

                entity.Property(e => e.NiceQueue)
                    .HasColumnName("Nice Queue")
                    .HasMaxLength(50);

                entity.Property(e => e.Pid)
                    .HasColumnName("PID")
                    .HasMaxLength(50);

                entity.Property(e => e.Process).HasMaxLength(255);

                entity.Property(e => e.ProcessMap)
                    .HasColumnName("Process Map")
                    .HasMaxLength(255);

                entity.Property(e => e.SlaTarget)
                    .HasColumnName("SLA Target")
                    .HasMaxLength(50);

                entity.Property(e => e.SlaType)
                    .HasColumnName("SLA Type")
                    .HasMaxLength(50);

                entity.Property(e => e.SpphIdProcess).HasColumnName("SPPH_ID_PROCESS");
            });

            builder.Entity<tbl_QualityIntegration>(entity =>
            {
                entity.ToTable("tbl_Quality_Integration", "CPS");

                entity.HasIndex(e => e.TransactionId)
                    .HasName("C_Unique_Transaction_ID")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.QualityPtsScored).HasColumnName("Quality_Pts_Scored");

                entity.Property(e => e.QualityPtsTotal).HasColumnName("Quality_Pts_Total");

                entity.Property(e => e.TransactionId).HasColumnName("Transaction_ID");
            });

            builder.Entity<tbl_ReportingUsers>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("tbl_Reporting_Users", "CPS");

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.Ntuser)
                    .HasColumnName("NTUser")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            builder.Entity<tbl_Specific>(entity =>
            {
                entity.HasKey(e => e.IdSpec);

                entity.ToTable("tbl_Specific", "CPS");

                entity.Property(e => e.IdSpec).HasColumnName("ID_Spec");

                entity.Property(e => e.IdMain).HasColumnName("ID_Main");

                entity.Property(e => e.IdNumber)
                    .HasColumnName("ID_Number")
                    .HasMaxLength(255);
            });

            builder.Entity<tbl_Status>(entity =>
            {
                entity.HasKey(e => e.IdStatus);

                entity.ToTable("tbl_Status", "CPS");

                entity.Property(e => e.IdStatus).HasColumnName("ID_Status");

                entity.Property(e => e.Status).HasMaxLength(255);
            });

            builder.Entity<tbl_Tower>(entity =>
            {
                entity.HasKey(e => e.IdTower);

                entity.ToTable("tbl_Tower", "CPS");

                entity.Property(e => e.IdTower).HasColumnName("ID_Tower");

                entity.Property(e => e.Tower).HasMaxLength(255);
            });

            builder.Entity<tbl_TowerCategory>(entity =>
            {
                entity.HasKey(e => e.IdTowerCategory);

                entity.ToTable("tbl_TowerCategory", "CPS");

                entity.Property(e => e.IdTowerCategory).HasColumnName("ID_TowerCategory");

                entity.Property(e => e.TowerCategory).HasMaxLength(255);
            });

            builder.Entity<tbl_TrackerVer>(entity =>
            {
                entity.ToTable("tbl_Tracker_Ver", "CPS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Change).HasMaxLength(500);

                entity.Property(e => e.ChangeStamp)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(hour,(3),getutcdate()))");

                entity.Property(e => e.Request).HasMaxLength(500);

                entity.Property(e => e.Version).HasColumnType("nchar(10)");
            });

            builder.Entity<tbl_UserActivity>(entity =>
            {
                entity.HasKey(e => e.IdUserActivity);

                entity.ToTable("tbl_UserActivity", "CPS");

                entity.Property(e => e.IdUserActivity).HasColumnName("ID_UserActivity");

                entity.Property(e => e.ChangeStamp).HasColumnType("datetime");

                entity.Property(e => e.Comment).HasColumnType("ntext");

                entity.Property(e => e.IdLogin).HasColumnName("ID_Login");

                entity.Property(e => e.MetricsTrackVer)
                    .HasColumnName("Metrics_Track_Ver")
                    .HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(255);

                entity.HasOne(d => d.IdLoginNavigation)
                    .WithMany(p => p.TblUserActivity)
                    .HasForeignKey(d => d.IdLogin)
                    .HasConstraintName("FK_tbl_UserActivity_tbl_Login");
            });

            builder.Entity<tbl_VolumeMain>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.ToTable("tbl_Volume_Main", "CPS");

                entity.HasIndex(e => new { e.TransactionId, e.StartDate, e.OriginalId, e.CompleteDate, e.StatusCode })
                    .HasName("NonClusteredIndex-20180216-113906");

                entity.Property(e => e.TransactionId).HasColumnName("Transaction_ID");

                entity.Property(e => e.Attachments).HasMaxLength(150);

                entity.Property(e => e.Comment).HasColumnType("ntext");

                entity.Property(e => e.CompleteDate).HasColumnType("datetime");

                entity.Property(e => e.CurrencyCode)
                    .HasColumnName("Currency_Code")
                    .HasMaxLength(50);

                entity.Property(e => e.DateReceivedInAig)
                    .HasColumnName("Date_Received_in_AIG")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdActivity).HasColumnName("ID_Activity");

                entity.Property(e => e.IdContract)
                    .HasColumnName("ID_Contract")
                    .HasMaxLength(50);

                entity.Property(e => e.IdCountry).HasColumnName("ID_Country");

                entity.Property(e => e.IdDivision).HasColumnName("ID_Division");

                entity.Property(e => e.IdLob).HasColumnName("ID_LOB");

                entity.Property(e => e.IdLogin).HasColumnName("ID_Login");

                entity.Property(e => e.IdNumber)
                    .HasColumnName("ID_Number")
                    .HasMaxLength(500);

                entity.Property(e => e.IdPartner)
                    .HasColumnName("ID_Partner")
                    .HasMaxLength(50);

                entity.Property(e => e.IdProcess).HasColumnName("ID_Process");

                entity.Property(e => e.IdStatus).HasColumnName("ID_Status");

                entity.Property(e => e.IdTower).HasColumnName("ID_Tower");

                entity.Property(e => e.IdTowerCategory).HasColumnName("ID_TowerCategory");

                entity.Property(e => e.IdleHours)
                    .HasColumnName("Idle_Hours")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InceptionDate)
                    .HasColumnName("Inception_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.InsuredName)
                    .HasColumnName("Insured_Name")
                    .HasMaxLength(150);

                entity.Property(e => e.OriginalId).HasColumnName("Original_ID");

                entity.Property(e => e.PrecalcHt).HasColumnName("Precalc HT");

                entity.Property(e => e.PrecalcSlaHours).HasColumnName("Precalc SLA Hours");

                entity.Property(e => e.QualityInspectionDate)
                    .HasColumnName("Quality_Inspection_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.QualityPtsScored).HasColumnName("Quality_Pts_Scored");

                entity.Property(e => e.QualityPtsTotal).HasColumnName("Quality_Pts_Total");

                entity.Property(e => e.QualityReviewer)
                    .HasColumnName("Quality_Reviewer")
                    .HasMaxLength(150);

                entity.Property(e => e.ReceivedDate).HasColumnType("datetime");

                entity.Property(e => e.Sandbox).HasDefaultValueSql("((0))");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StatusCode).HasColumnName("Status_Code");

                entity.Property(e => e.TransactionRequestor)
                    .HasColumnName("Transaction_Requestor")
                    .HasMaxLength(150);

                entity.Property(e => e.WorkCode)
                    .HasColumnName("Work_Code")
                    .HasMaxLength(150);

                entity.HasOne(d => d.IdActivityNavigation)
                    .WithMany(p => p.TblVolumeMain)
                    .HasForeignKey(d => d.IdActivity)
                    .HasConstraintName("FK_tbl_Volume_Main_tbl_Activity");

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.TblVolumeMain)
                    .HasForeignKey(d => d.IdCountry)
                    .HasConstraintName("FK_tbl_Volume_Main_tbl_Country");

                entity.HasOne(d => d.IdDivisionNavigation)
                    .WithMany(p => p.TblVolumeMain)
                    .HasForeignKey(d => d.IdDivision)
                    .HasConstraintName("FK_tbl_Volume_Main_tbl_Division");

                entity.HasOne(d => d.IdLobNavigation)
                    .WithMany(p => p.TblVolumeMain)
                    .HasForeignKey(d => d.IdLob)
                    .HasConstraintName("FK_tbl_Volume_Main_tbl_LOB");

                entity.HasOne(d => d.IdLoginNavigation)
                    .WithMany(p => p.TblVolumeMain)
                    .HasForeignKey(d => d.IdLogin)
                    .HasConstraintName("FK_tbl_Volume_Main_tbl_Login");

                entity.HasOne(d => d.IdProcessNavigation)
                    .WithMany(p => p.TblVolumeMain)
                    .HasForeignKey(d => d.IdProcess)
                    .HasConstraintName("FK_tbl_Volume_Main_tbl_Process");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.TblVolumeMain)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK_tbl_Volume_Main_tbl_Status");

                entity.HasOne(d => d.IdTowerNavigation)
                    .WithMany(p => p.TblVolumeMain)
                    .HasForeignKey(d => d.IdTower)
                    .HasConstraintName("FK_tbl_Volume_Main_tbl_Tower");

                entity.HasOne(d => d.IdTowerCategoryNavigation)
                    .WithMany(p => p.TblVolumeMain)
                    .HasForeignKey(d => d.IdTowerCategory)
                    .HasConstraintName("FK_tbl_Volume_Main_tbl_TowerCategory");
            });

            builder.Entity<trel_CountryProcess>(entity =>
            {
                entity.HasKey(e => e.IdCp);

                entity.ToTable("trel_CountryProcess", "CPS");

                entity.Property(e => e.IdCp).HasColumnName("ID_CP");

                entity.Property(e => e.IdCountry).HasColumnName("ID_Country");

                entity.Property(e => e.IdProcess).HasColumnName("ID_Process");

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.TrelCountryProcess)
                    .HasForeignKey(d => d.IdCountry)
                    .HasConstraintName("FK_trel_CountryProcess_tbl_Country");

                entity.HasOne(d => d.IdProcessNavigation)
                    .WithMany(p => p.TrelCountryProcess)
                    .HasForeignKey(d => d.IdProcess)
                    .HasConstraintName("FK_trel_CountryProcess_tbl_Process");
            });

            builder.Entity<trel_ProcessActivity>(entity =>
            {
                entity.HasKey(e => e.IdPa);

                entity.ToTable("trel_ProcessActivity", "CPS");

                entity.Property(e => e.IdPa).HasColumnName("ID_PA");

                entity.Property(e => e.IdActivity).HasColumnName("ID_Activity");

                entity.Property(e => e.IdProcess).HasColumnName("ID_Process");

                entity.HasOne(d => d.IdActivityNavigation)
                    .WithMany(p => p.TrelProcessActivity)
                    .HasForeignKey(d => d.IdActivity)
                    .HasConstraintName("FK_trel_ProcessActivity_tbl_Activity");

                entity.HasOne(d => d.IdProcessNavigation)
                    .WithMany(p => p.TrelProcessActivity)
                    .HasForeignKey(d => d.IdProcess)
                    .HasConstraintName("FK_trel_ProcessActivity_tbl_Process");
            });

            builder.Entity<trel_ProcessDivision>(entity =>
            {
                entity.HasKey(e => e.IdPd);

                entity.ToTable("trel_ProcessDivision", "CPS");

                entity.Property(e => e.IdPd).HasColumnName("ID_PD");

                entity.Property(e => e.IdDivision).HasColumnName("ID_Division");

                entity.Property(e => e.IdProcess).HasColumnName("ID_Process");

                entity.HasOne(d => d.IdDivisionNavigation)
                    .WithMany(p => p.TrelProcessDivision)
                    .HasForeignKey(d => d.IdDivision)
                    .HasConstraintName("FK_trel_ProcessDivision_tbl_Division");

                entity.HasOne(d => d.IdProcessNavigation)
                    .WithMany(p => p.TrelProcessDivision)
                    .HasForeignKey(d => d.IdProcess)
                    .HasConstraintName("FK_trel_ProcessDivision_tbl_Process");
            });

            builder.Entity<trel_ProcessLob>(entity =>
            {
                entity.HasKey(e => e.IdPl);

                entity.ToTable("trel_ProcessLOB", "CPS");

                entity.Property(e => e.IdPl).HasColumnName("ID_PL");

                entity.Property(e => e.IdLob).HasColumnName("ID_LOB");

                entity.Property(e => e.IdProcess).HasColumnName("ID_Process");

                entity.HasOne(d => d.IdLobNavigation)
                    .WithMany(p => p.TrelProcessLob)
                    .HasForeignKey(d => d.IdLob)
                    .HasConstraintName("FK_trel_ProcessLOB_tbl_LOB");

                entity.HasOne(d => d.IdProcessNavigation)
                    .WithMany(p => p.TrelProcessLob)
                    .HasForeignKey(d => d.IdProcess)
                    .HasConstraintName("FK_trel_ProcessLOB_tbl_Process");
            });

            builder.Entity<trel_ProcessStatus>(entity =>
            {
                entity.HasKey(e => e.IdSp);

                entity.ToTable("trel_ProcessStatus", "CPS");

                entity.Property(e => e.IdSp).HasColumnName("ID_SP");

                entity.Property(e => e.IdProcess).HasColumnName("ID_Process");

                entity.Property(e => e.IdStatus).HasColumnName("ID_Status");

                entity.HasOne(d => d.IdProcessNavigation)
                    .WithMany(p => p.TrelProcessStatus)
                    .HasForeignKey(d => d.IdProcess)
                    .HasConstraintName("FK_trel_ProcessStatus_tbl_Process");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.TrelProcessStatus)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK_trel_ProcessStatus_tbl_Status");
            });

            builder.Entity<trel_ProcessTower>(entity =>
            {
                entity.HasKey(e => e.IdPt);

                entity.ToTable("trel_ProcessTower", "CPS");

                entity.Property(e => e.IdPt).HasColumnName("ID_PT");

                entity.Property(e => e.IdProcess).HasColumnName("ID_Process");

                entity.Property(e => e.IdTower).HasColumnName("ID_Tower");

                entity.HasOne(d => d.IdProcessNavigation)
                    .WithMany(p => p.TrelProcessTower)
                    .HasForeignKey(d => d.IdProcess)
                    .HasConstraintName("FK_trel_ProcessTower_tbl_Process");

                entity.HasOne(d => d.IdTowerNavigation)
                    .WithMany(p => p.TrelProcessTower)
                    .HasForeignKey(d => d.IdTower)
                    .HasConstraintName("FK_trel_ProcessTower_tbl_Tower");
            });

            builder.Entity<trel_ProcessTowerCategory>(entity =>
            {
                entity.HasKey(e => e.IdPtg);

                entity.ToTable("trel_ProcessTowerCategory", "CPS");

                entity.Property(e => e.IdPtg).HasColumnName("ID_PTG");

                entity.Property(e => e.IdProcess).HasColumnName("ID_Process");

                entity.Property(e => e.IdTowerCategory).HasColumnName("ID_TowerCategory");

                entity.HasOne(d => d.IdProcessNavigation)
                    .WithMany(p => p.TrelProcessTowerCategory)
                    .HasForeignKey(d => d.IdProcess)
                    .HasConstraintName("FK_trel_ProcessTowerCategory_tbl_Process");

                entity.HasOne(d => d.IdTowerCategoryNavigation)
                    .WithMany(p => p.TrelProcessTowerCategory)
                    .HasForeignKey(d => d.IdTowerCategory)
                    .HasConstraintName("FK_trel_ProcessTowerCategory_tbl_TowerCategory");
            });

            builder.Entity<trel_UserCountry>(entity =>
            {
                entity.HasKey(e => e.IdUc);

                entity.ToTable("trel_UserCountry", "CPS");

                entity.Property(e => e.IdUc).HasColumnName("ID_UC");

                entity.Property(e => e.IdCountry).HasColumnName("ID_Country");

                entity.Property(e => e.IdLogin).HasColumnName("ID_Login");

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.TrelUserCountry)
                    .HasForeignKey(d => d.IdCountry)
                    .HasConstraintName("FK_trel_UserCountry_tbl_Country");

                entity.HasOne(d => d.IdLoginNavigation)
                    .WithMany(p => p.TrelUserCountry)
                    .HasForeignKey(d => d.IdLogin)
                    .HasConstraintName("FK_trel_UserCountry_tbl_Login");
            });

            builder.Entity<trel_UserMining>(entity =>
            {
                entity.HasKey(e => e.IdUm);

                entity.ToTable("trel_UserMining", "CPS");

                entity.Property(e => e.IdUm).HasColumnName("ID_UM");

                entity.Property(e => e.IdLogin).HasColumnName("ID_Login");

                entity.Property(e => e.IdMining).HasColumnName("ID_Mining");

                entity.HasOne(d => d.IdLoginNavigation)
                    .WithMany(p => p.TrelUserMining)
                    .HasForeignKey(d => d.IdLogin)
                    .HasConstraintName("FK_trel_UserMining_tbl_Login");

                entity.HasOne(d => d.IdMiningNavigation)
                    .WithMany(p => p.TrelUserMining)
                    .HasForeignKey(d => d.IdMining)
                    .HasConstraintName("FK_trel_UserMining_tbl_Mining");
            });

            builder.Entity<trel_AgentCountry>(entity =>
            {
                entity.HasKey(i => new { i.IdAgent, i.IdCountry });

                entity.ToTable("trel_AgentCountry", "CPS");

                entity.HasOne(a => a.Country)
                    .WithMany(c => c.Agents)
                    .HasForeignKey(a => a.IdCountry);

                entity.HasOne(c => c.Agent)
                    .WithMany(a => a.Countries)
                    .HasForeignKey(c => c.IdAgent);
            });

            builder.Entity<trel_CountryMining>(entity =>
            {
                entity.HasKey(i => new { i.IdCountry, i.IdMining });

                entity.ToTable("trel_CountryMining", "CPS");

                entity.HasOne(m => m.Country)
                    .WithMany(c => c.Minings)
                    .HasForeignKey(m => m.IdCountry);

                entity.HasOne(c => c.Mining)
                    .WithMany(m => m.Countries)
                    .HasForeignKey(a => a.IdMining);
            });

            builder.HasSequence<int>("SequenceIds", schema: "CPS")
                .StartsAt(1000)
                .IncrementsBy(1);

            builder.Entity<User>(entity =>
            {
                entity.Property(e => e.IdLogin).HasColumnName("ID_Login");

                entity.Property(e => e.IdTeamLead).HasColumnName("ID_TeamLead");

                entity.Property(i => i.IdLogin).HasDefaultValueSql("NEXT VALUE FOR CPS.SequenceIds");
            });

            builder.Entity<SSC_View_MyTransactions>(entity =>
            {
                entity.HasKey(i => i.TransactionId);
                entity.Property(e => e.TransactionId).HasColumnName("Transaction_ID");

                entity.Property(e => e.CurrencyCode).HasColumnName("Currency_Code");

                entity.Property(e => e.FunctionName).HasColumnName("Function Name");

                entity.Property(e => e.IdLogin).HasColumnName("ID_Login");

                entity.Property(e => e.IdNumber).HasColumnName("ID_Number");

                entity.Property(e => e.ProcessMap).HasColumnName("Process Map");

                entity.Property(e => e.TeamLeader).HasColumnName("Team Leader");

                entity.Property(e => e.UserName).HasColumnName("User Name");

                entity.Property(e => e.SLAHrs).HasColumnName("SLA Hrs");

                entity.Property(e => e.SLATarget).HasColumnName("SLA Target");

                entity.Property(e => e.SLAType).HasColumnName("SLA Type");

                entity.Property(e => e.SLATransaction).HasColumnName("SLA Transaction");

                entity.Property(e => e.SLAAchievment).HasColumnName("SLA Achievment");

                entity.Property(e => e.HandlingTime).HasColumnName("Handling Time");

                entity.Property(e => e.MultiStepTransaction).HasColumnName("Multi-Step Transaction");

                entity.Property(e => e.AspIDLogin).HasColumnName("AspID_Login");
            });

            builder.Entity<tbl_TeamLead>(entity =>
           {
               entity.ToTable("tbl_TeamLead", "CPS");

               entity.HasKey(i => i.IdTeamLead);

               entity.Property(e => e.IdTeamLead).HasColumnName("Id_TeamLead");

               entity.Property(e => e.TeamLead).HasMaxLength(255);

               entity.HasOne(u => u.User).WithOne(t => t.TeamLead).HasForeignKey<User>(k => k.IdTeamLead);
           });

            base.OnModelCreating(builder);
        }
    }
}
