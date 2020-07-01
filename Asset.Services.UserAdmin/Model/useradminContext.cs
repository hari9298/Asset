using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Asset.Services.UserAdmin.Model
{
    public partial class useradminContext : DbContext
    {
        public useradminContext()
        {
        }

        public useradminContext(DbContextOptions<useradminContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAddressDetails> TAddressDetails { get; set; }
        public virtual DbSet<TCommonListMaster> TCommonListMaster { get; set; }
        public virtual DbSet<TCommunicationDetails> TCommunicationDetails { get; set; }
        public virtual DbSet<TCompanyMaster> TCompanyMaster { get; set; }
        public virtual DbSet<TEmailTemplate> TEmailTemplate { get; set; }
        public virtual DbSet<TFunctionMaster> TFunctionMaster { get; set; }
        public virtual DbSet<TGroupMaster> TGroupMaster { get; set; }
        public virtual DbSet<TProductCategoryMaster> TProductCategoryMaster { get; set; }
        public virtual DbSet<TProductMaster> TProductMaster { get; set; }
        public virtual DbSet<TRoleFunctionLink> TRoleFunctionLink { get; set; }
        public virtual DbSet<TRoleMaster> TRoleMaster { get; set; }
        public virtual DbSet<TStatusMaster> TStatusMaster { get; set; }
        public virtual DbSet<TTransporterMaster> TTransporterMaster { get; set; }
        public virtual DbSet<TTransporterTransactionDetails> TTransporterTransactionDetails { get; set; }
        public virtual DbSet<TUserMaster> TUserMaster { get; set; }
        public virtual DbSet<TUserProfile> TUserProfile { get; set; }
        public virtual DbSet<Tblbusinessentity> Tblbusinessentity { get; set; }
        public virtual DbSet<Tbldeliveryk> Tbldeliveryk { get; set; }
        public virtual DbSet<Tbldeliverylocname> Tbldeliverylocname { get; set; }
        public virtual DbSet<Tbldeliveryname> Tbldeliveryname { get; set; }
        public virtual DbSet<Tbldeliveryquantity> Tbldeliveryquantity { get; set; }
        public virtual DbSet<Tbldeliveryrank> Tbldeliveryrank { get; set; }
        public virtual DbSet<Tblnomsubcycle> Tblnomsubcycle { get; set; }
        public virtual DbSet<Tblpkgid> Tblpkgid { get; set; }
        public virtual DbSet<Tblratescheduled> Tblratescheduled { get; set; }
        public virtual DbSet<Tblreceiptlocname> Tblreceiptlocname { get; set; }
        public virtual DbSet<Tblreceiptquantity> Tblreceiptquantity { get; set; }
        public virtual DbSet<Tblreceiptrank> Tblreceiptrank { get; set; }
        public virtual DbSet<Tblsvcreqkey> Tblsvcreqkey { get; set; }
        public virtual DbSet<Tbltransactioninfo> Tbltransactioninfo { get; set; }
        public virtual DbSet<Tblupk> Tblupk { get; set; }
        public virtual DbSet<Tblupname> Tblupname { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=root;database=useradmin");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<TAddressDetails>(entity =>
            {
                entity.HasKey(e => e.AdId);

                entity.ToTable("t_address_details", "useradmin");

                entity.HasIndex(e => e.AdAddrType)
                    .HasName("T_ADDRESS_DETAILS_fk0");

                entity.Property(e => e.AdId)
                    .HasColumnName("AD_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AdAddrType)
                    .HasColumnName("AD_ADDR_TYPE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AdAddress)
                    .HasColumnName("AD_ADDRESS")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AdCity)
                    .HasColumnName("AD_CITY")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AdCountry)
                    .HasColumnName("AD_COUNTRY")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AdModifiedBy)
                    .HasColumnName("AD_MODIFIED_BY")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AdModifiedOn).HasColumnName("AD_MODIFIED_ON");

                entity.Property(e => e.AdPostalCode)
                    .HasColumnName("AD_POSTAL_CODE")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.AdRefId)
                    .HasColumnName("AD_REF_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AdRefType)
                    .HasColumnName("AD_REF_TYPE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AdState)
                    .HasColumnName("AD_STATE")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.AdAddrTypeNavigation)
                    .WithMany(p => p.TAddressDetails)
                    .HasForeignKey(d => d.AdAddrType)
                    .HasConstraintName("T_ADDRESS_DETAILS_fk0");
            });

            modelBuilder.Entity<TCommonListMaster>(entity =>
            {
                entity.HasKey(e => e.ClId);

                entity.ToTable("t_common_list_master", "useradmin");

                entity.HasIndex(e => e.ClStatus)
                    .HasName("T_COMMON_LIST_MASTER_fk0");

                entity.Property(e => e.ClId)
                    .HasColumnName("CL_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClListDescription)
                    .HasColumnName("CL_LIST_DESCRIPTION")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ClListName)
                    .HasColumnName("CL_LIST_NAME")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ClListOrder)
                    .HasColumnName("CL_LIST_ORDER")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClModifiedBy)
                    .HasColumnName("CL_MODIFIED_BY")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClModifiedOn).HasColumnName("CL_MODIFIED_ON");

                entity.Property(e => e.ClStatus)
                    .HasColumnName("CL_STATUS")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.ClStatusNavigation)
                    .WithMany(p => p.TCommonListMaster)
                    .HasForeignKey(d => d.ClStatus)
                    .HasConstraintName("T_COMMON_LIST_MASTER_fk0");
            });

            modelBuilder.Entity<TCommunicationDetails>(entity =>
            {
                entity.HasKey(e => e.CdId);

                entity.ToTable("t_communication_details", "useradmin");

                entity.HasIndex(e => e.CdCommType)
                    .HasName("T_COMMUNICATION_DETAILS_fk0");

                entity.Property(e => e.CdId)
                    .HasColumnName("CD_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CdCommIsPrimary)
                    .HasColumnName("CD_COMM_IS_PRIMARY")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CdCommType)
                    .HasColumnName("CD_COMM_TYPE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CdCommValue)
                    .HasColumnName("CD_COMM_VALUE")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CdModifiedBy)
                    .HasColumnName("CD_MODIFIED_BY")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CdModifiedOn).HasColumnName("CD_MODIFIED_ON");

                entity.Property(e => e.CdRefId)
                    .HasColumnName("CD_REF_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CdRefType)
                    .HasColumnName("CD_REF_TYPE")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CdCommTypeNavigation)
                    .WithMany(p => p.TCommunicationDetails)
                    .HasForeignKey(d => d.CdCommType)
                    .HasConstraintName("T_COMMUNICATION_DETAILS_fk0");
            });

            modelBuilder.Entity<TCompanyMaster>(entity =>
            {
                entity.HasKey(e => e.CmId);

                entity.ToTable("t_company_master", "useradmin");

                entity.HasIndex(e => e.CmBusinessType)
                    .HasName("T_COMPANY_MASTER_fk2");

                entity.HasIndex(e => e.CmParentComp)
                    .HasName("T_COMPANY_MASTER_fk0");

                entity.HasIndex(e => e.CmStatus)
                    .HasName("T_COMPANY_MASTER_fk3");

                entity.HasIndex(e => e.CmType)
                    .HasName("T_COMPANY_MASTER_fk1");

                entity.Property(e => e.CmId)
                    .HasColumnName("CM_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CmBusinessType)
                    .HasColumnName("CM_BUSINESS_TYPE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CmModifiedBy)
                    .HasColumnName("CM_MODIFIED_BY")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CmModifiedOn).HasColumnName("CM_MODIFIED_ON");

                entity.Property(e => e.CmName)
                    .HasColumnName("CM_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CmParentComp)
                    .HasColumnName("CM_PARENT_COMP")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CmPrimaryContact)
                    .HasColumnName("CM_PRIMARY_CONTACT")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CmStatus)
                    .HasColumnName("CM_STATUS")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CmType)
                    .HasColumnName("CM_TYPE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CmWebsite)
                    .HasColumnName("CM_WEBSITE")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TEmailTemplate>(entity =>
            {
                entity.HasKey(e => e.EtId);

                entity.ToTable("t_email_template", "useradmin");

                entity.HasIndex(e => e.EtStatus)
                    .HasName("T_Email_Template_fk0");

                entity.Property(e => e.EtId)
                    .HasColumnName("ET_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EtCreatedBy)
                    .HasColumnName("ET_Created_BY")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EtCreatedOn).HasColumnName("ET_Created_ON");

                entity.Property(e => e.EtDescription)
                    .HasColumnName("ET_Description")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EtModifiedBy)
                    .HasColumnName("ET_MODIFIED_BY")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EtModifiedOn).HasColumnName("ET_MODIFIED_ON");

                entity.Property(e => e.EtName)
                    .HasColumnName("ET_Name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EtStatus)
                    .HasColumnName("ET_Status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EtTemplateBody)
                    .HasColumnName("ET_TemplateBody")
                    .HasColumnType("blob");

                entity.HasOne(d => d.EtStatusNavigation)
                    .WithMany(p => p.TEmailTemplate)
                    .HasForeignKey(d => d.EtStatus)
                    .HasConstraintName("T_Email_Template_fk0");
            });

            modelBuilder.Entity<TFunctionMaster>(entity =>
            {
                entity.HasKey(e => e.FmId);

                entity.ToTable("t_function_master", "useradmin");

                entity.HasIndex(e => e.FmStatus)
                    .HasName("T_FUNCTION_MASTER_fk1");

                entity.HasIndex(e => e.FmType)
                    .HasName("T_FUNCTION_MASTER_fk0");

                entity.Property(e => e.FmId)
                    .HasColumnName("FM_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FmModifiedBy)
                    .HasColumnName("FM_MODIFIED_BY")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FmModifiedOn).HasColumnName("FM_MODIFIED_ON");

                entity.Property(e => e.FmName)
                    .HasColumnName("FM_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FmOrder)
                    .HasColumnName("FM_ORDER")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FmStatus)
                    .HasColumnName("FM_STATUS")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FmType)
                    .HasColumnName("FM_TYPE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FmUri)
                    .HasColumnName("FM_URI")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.MenuImagePath)
                    .HasColumnName("menuImagePath")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TGroupMaster>(entity =>
            {
                entity.HasKey(e => e.GmId);

                entity.ToTable("t_group_master", "useradmin");

                entity.HasIndex(e => e.GmStatus)
                    .HasName("T_GROUP_MASTER_fk0");

                entity.Property(e => e.GmId)
                    .HasColumnName("GM_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GmCreatedBy)
                    .HasColumnName("GM_CREATED_BY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GmCreatedOn).HasColumnName("GM_CREATED_ON");

                entity.Property(e => e.GmDescription)
                    .HasColumnName("GM_DESCRIPTION")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.GmModifiedBy)
                    .HasColumnName("GM_MODIFIED_BY")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GmModifiedOn).HasColumnName("GM_MODIFIED_ON");

                entity.Property(e => e.GmName)
                    .HasColumnName("GM_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GmStatus)
                    .HasColumnName("GM_STATUS")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TProductCategoryMaster>(entity =>
            {
                entity.ToTable("t_product_category_master", "useradmin");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CatId)
                    .HasColumnName("cat_id")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TProductMaster>(entity =>
            {
                entity.ToTable("t_product_master", "useradmin");

                entity.HasIndex(e => e.CatId)
                    .HasName("FK_T_PRODUCT_CATEGORY_MASTER");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CatId)
                    .HasColumnName("cat_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnName("createdOn");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModifiedOn).HasColumnName("modifiedOn");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProdId)
                    .HasColumnName("prod_id")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(2)");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.TProductMaster)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK_T_PRODUCT_CATEGORY_MASTER");
            });

            modelBuilder.Entity<TRoleFunctionLink>(entity =>
            {
                entity.HasKey(e => e.RflId);

                entity.ToTable("t_role_function_link", "useradmin");

                entity.HasIndex(e => e.RflFunction)
                    .HasName("T_ROLE_FUNCTION_LINK_fk1");

                entity.HasIndex(e => e.RflRole)
                    .HasName("T_ROLE_FUNCTION_LINK_fk0");

                entity.HasIndex(e => e.RflStatus)
                    .HasName("T_ROLE_FUNCTION_LINK_fk2");

                entity.Property(e => e.RflId)
                    .HasColumnName("RFL_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RflAccessKey)
                    .HasColumnName("RFL_ACCESS_KEY")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RflFunction)
                    .HasColumnName("RFL_FUNCTION")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RflModifiedBy)
                    .HasColumnName("RFL_MODIFIED_BY")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RflModifiedOn).HasColumnName("RFL_MODIFIED_ON");

                entity.Property(e => e.RflRole)
                    .HasColumnName("RFL_ROLE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RflStatus)
                    .HasColumnName("RFL_STATUS")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TRoleMaster>(entity =>
            {
                entity.HasKey(e => e.RmId);

                entity.ToTable("t_role_master", "useradmin");

                entity.HasIndex(e => e.RmStatus)
                    .HasName("T_ROLE_MASTER_fk0");

                entity.Property(e => e.RmId)
                    .HasColumnName("RM_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RmCreatedBy)
                    .HasColumnName("RM_CREATED_BY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RmCreatedOn).HasColumnName("RM_CREATED_ON");

                entity.Property(e => e.RmDescription)
                    .HasColumnName("RM_DESCRIPTION")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RmModifiedBy)
                    .HasColumnName("RM_MODIFIED_BY")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RmModifiedOn).HasColumnName("RM_MODIFIED_ON");

                entity.Property(e => e.RmName)
                    .HasColumnName("RM_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RmStatus)
                    .HasColumnName("RM_STATUS")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RmType)
                    .HasColumnName("RM_TYPE")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TStatusMaster>(entity =>
            {
                entity.HasKey(e => e.SmId);

                entity.ToTable("t_status_master", "useradmin");

                entity.Property(e => e.SmId)
                    .HasColumnName("SM_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SmDescription)
                    .HasColumnName("SM_DESCRIPTION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SmModifiedBy)
                    .HasColumnName("SM_MODIFIED_BY")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SmModifiedOn).HasColumnName("SM_MODIFIED_ON");
            });

            modelBuilder.Entity<TTransporterMaster>(entity =>
            {
                entity.HasKey(e => e.TransporterId);

                entity.ToTable("t_transporter_master", "useradmin");

                entity.Property(e => e.TransporterId)
                    .HasColumnName("TRANSPORTER_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BusinessEntityGroup)
                    .HasColumnName("Business_Entity_Group")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RateScheduled)
                    .HasColumnName("RATE_SCHEDULED")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SvcReqKey).HasColumnName("SVC_REQ_KEY");

                entity.Property(e => e.TimeEntry).HasColumnName("Time_Entry");

                entity.Property(e => e.TransStatus)
                    .HasColumnName("TRANS_STATUS")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TTransporterTransactionDetails>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.ToTable("t_transporter_transaction_details", "useradmin");

                entity.HasIndex(e => e.TransporterId)
                    .HasName("TRANSPORTER_ID");

                entity.Property(e => e.TransactionId)
                    .HasColumnName("TRANSACTION_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Audit)
                    .HasColumnName("AUDIT")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryK)
                    .HasColumnName("DELIVERY_K")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryLocName)
                    .HasColumnName("DELIVERY_LOC_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryName)
                    .HasColumnName("DELIVERY_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryQty)
                    .HasColumnName("DELIVERY_QTY")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryRank)
                    .HasColumnName("DELIVERY_RANK")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FuelQty)
                    .HasColumnName("FUEL_QTY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FuelRate)
                    .HasColumnName("FUEL_RATE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NominationSubCycle)
                    .HasColumnName("NOMINATION_SUB_CYCLE")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PathMiles)
                    .HasColumnName("PATH_MILES")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PkgId)
                    .HasColumnName("PKG_ID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiptLocName)
                    .HasColumnName("RECEIPT_LOC_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiptQty)
                    .HasColumnName("RECEIPT_QTY")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiptRank)
                    .HasColumnName("RECEIPT_RANK")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionInfo)
                    .HasColumnName("TRANSACTION_INFO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransporterId)
                    .HasColumnName("TRANSPORTER_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpK)
                    .HasColumnName("UP_K")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpName)
                    .HasColumnName("UP_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Transporter)
                    .WithMany(p => p.TTransporterTransactionDetails)
                    .HasForeignKey(d => d.TransporterId)
                    .HasConstraintName("TRANSPORTER_ID");
            });

            modelBuilder.Entity<TUserMaster>(entity =>
            {
                entity.HasKey(e => e.UmId);

                entity.ToTable("t_user_master", "useradmin");

                entity.HasIndex(e => e.UmCompany)
                    .HasName("T_USER_MASTER_fk0");

                entity.HasIndex(e => e.UmGroup)
                    .HasName("T_USER_MASTER_fk1");

                entity.HasIndex(e => e.UmStatus)
                    .HasName("T_USER_MASTER_fk2");

                entity.Property(e => e.UmId)
                    .HasColumnName("UM_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UmCompany)
                    .HasColumnName("UM_COMPANY")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UmFirstName)
                    .HasColumnName("UM_FIRST_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UmGroup)
                    .HasColumnName("UM_GROUP")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UmLastName)
                    .HasColumnName("UM_LAST_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UmLogin)
                    .HasColumnName("UM_LOGIN")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UmMiddleName)
                    .HasColumnName("UM_MIDDLE_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UmModifiedBy)
                    .HasColumnName("UM_MODIFIED_BY")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UmModifiedOn).HasColumnName("UM_MODIFIED_ON");

                entity.Property(e => e.UmPassRecvAnswer)
                    .HasColumnName("UM_PASS_RECV_ANSWER")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UmPassRecvQuestion)
                    .HasColumnName("UM_PASS_RECV_QUESTION")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UmPasswodExpiry).HasColumnName("UM_PASSWOD_EXPIRY");

                entity.Property(e => e.UmPassword)
                    .HasColumnName("UM_PASSWORD")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UmStatus)
                    .HasColumnName("UM_STATUS")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TUserProfile>(entity =>
            {
                entity.HasKey(e => e.UpId);

                entity.ToTable("t_user_profile", "useradmin");

                entity.HasIndex(e => e.UpRoleId)
                    .HasName("T_USER_PROFILE_fk0");

                entity.HasIndex(e => e.UpStatus)
                    .HasName("T_USER_PROFILE_fk1");

                entity.Property(e => e.UpId)
                    .HasColumnName("UP_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpCreatedBy)
                    .HasColumnName("UP_CREATED_BY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpCreatedOn).HasColumnName("UP_CREATED_ON");

                entity.Property(e => e.UpModifiedBy)
                    .HasColumnName("UP_MODIFIED_BY")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpModifiedOn).HasColumnName("UP_MODIFIED_ON");

                entity.Property(e => e.UpRefId)
                    .HasColumnName("UP_REF_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpRefType)
                    .HasColumnName("UP_REF_TYPE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpRoleId)
                    .HasColumnName("UP_ROLE_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpStatus)
                    .HasColumnName("UP_STATUS")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.UpRole)
                    .WithMany(p => p.TUserProfile)
                    .HasForeignKey(d => d.UpRoleId)
                    .HasConstraintName("T_USER_PROFILE_fk0");

                entity.HasOne(d => d.UpStatusNavigation)
                    .WithMany(p => p.TUserProfile)
                    .HasForeignKey(d => d.UpStatus)
                    .HasConstraintName("T_USER_PROFILE_fk1");
            });

            modelBuilder.Entity<Tblbusinessentity>(entity =>
            {
                entity.ToTable("tblbusinessentity", "useradmin");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BusinessEntityName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tbldeliveryk>(entity =>
            {
                entity.ToTable("tbldeliveryk", "useradmin");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DeliveryKname)
                    .IsRequired()
                    .HasColumnName("DeliveryKName")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tbldeliverylocname>(entity =>
            {
                entity.ToTable("tbldeliverylocname", "useradmin");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DeliveryLocName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tbldeliveryname>(entity =>
            {
                entity.ToTable("tbldeliveryname", "useradmin");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DeliveryName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tbldeliveryquantity>(entity =>
            {
                entity.ToTable("tbldeliveryquantity", "useradmin");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DeliveryQuantityName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tbldeliveryrank>(entity =>
            {
                entity.ToTable("tbldeliveryrank", "useradmin");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DeliveryRankName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tblnomsubcycle>(entity =>
            {
                entity.ToTable("tblnomsubcycle", "useradmin");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomSubCname)
                    .IsRequired()
                    .HasColumnName("NomSubCName")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tblpkgid>(entity =>
            {
                entity.ToTable("tblpkgid", "useradmin");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PkgId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tblratescheduled>(entity =>
            {
                entity.ToTable("tblratescheduled", "useradmin");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RateName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tblreceiptlocname>(entity =>
            {
                entity.ToTable("tblreceiptlocname", "useradmin");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReceiptLocName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tblreceiptquantity>(entity =>
            {
                entity.ToTable("tblreceiptquantity", "useradmin");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReceiptQuantityName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tblreceiptrank>(entity =>
            {
                entity.ToTable("tblreceiptrank", "useradmin");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReceiptRankName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tblsvcreqkey>(entity =>
            {
                entity.ToTable("tblsvcreqkey", "useradmin");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SvcReqKeyName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tbltransactioninfo>(entity =>
            {
                entity.ToTable("tbltransactioninfo", "useradmin");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TransactionInfoName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tblupk>(entity =>
            {
                entity.ToTable("tblupk", "useradmin");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpKname)
                    .IsRequired()
                    .HasColumnName("UpKName")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tblupname>(entity =>
            {
                entity.ToTable("tblupname", "useradmin");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
