using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Audit_Mvc_Core.Models
{
    public partial class AuditContext : DbContext
    {
        public AuditContext()
        {
        }

        public AuditContext(DbContextOptions<AuditContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<AdminTaskAssign> AdminTaskAssigns { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<CustTaskCreation> CustTaskCreations { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;user=root;password=Krishna@209;database=Audit");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.Property(e => e.AdminId).HasColumnName("admin_Id");

                entity.Property(e => e.AdminBankAccno)
                    .HasMaxLength(20)
                    .HasColumnName("admin_Bank_accno");

                entity.Property(e => e.AdminBankName)
                    .HasMaxLength(30)
                    .HasColumnName("admin_Bank_Name");

                entity.Property(e => e.AdminCity)
                    .HasMaxLength(15)
                    .HasColumnName("admin_City");

                entity.Property(e => e.AdminDob)
                    .HasColumnType("date")
                    .HasColumnName("admin_DOB");

                entity.Property(e => e.AdminEmailid)
                    .HasMaxLength(30)
                    .HasColumnName("admin_Emailid");

                entity.Property(e => e.AdminFirstname)
                    .HasMaxLength(20)
                    .HasColumnName("admin_Firstname");

                entity.Property(e => e.AdminGender)
                    .HasColumnType("enum('Male','Female','Others')")
                    .HasColumnName("admin_Gender");

                entity.Property(e => e.AdminIfscCode)
                    .HasMaxLength(20)
                    .HasColumnName("admin_IFSC_code");

                entity.Property(e => e.AdminLastname)
                    .HasMaxLength(20)
                    .HasColumnName("admin_Lastname");

                entity.Property(e => e.AdminLicenceNo)
                    .HasMaxLength(30)
                    .HasColumnName("admin_Licence_no");

                entity.Property(e => e.AdminMobileNo)
                    .HasPrecision(12)
                    .HasColumnName("admin_Mobile_no");

                entity.Property(e => e.AdminPanNo)
                    .HasMaxLength(20)
                    .HasColumnName("admin_Pan_no");

                entity.Property(e => e.AdminPassword)
                    .HasMaxLength(20)
                    .HasColumnName("admin_Password");

                entity.Property(e => e.AdminProfilepic)
                    .HasColumnType("blob")
                    .HasColumnName("admin_Profilepic");

                entity.Property(e => e.AdminState)
                    .HasMaxLength(15)
                    .HasColumnName("admin_State");

                entity.Property(e => e.AdminUsername)
                    .HasMaxLength(20)
                    .HasColumnName("admin_Username");
            });

            modelBuilder.Entity<AdminTaskAssign>(entity =>
            {
                entity.ToTable("admin_task_assign");

                entity.HasIndex(e => e.AssignedTo, "Assigned_To");

                entity.HasIndex(e => e.AssignedBy, "Assigned_by");

                entity.HasIndex(e => e.CompanyId, "Company_Id");

                entity.HasIndex(e => e.CustomerId, "Customer_Id");

                entity.HasIndex(e => e.TaskId, "Task_Id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssignedBy).HasColumnName("Assigned_by");

                entity.Property(e => e.AssignedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Assigned_Date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.AssignedTo).HasColumnName("Assigned_To");

                entity.Property(e => e.Comments).HasMaxLength(800);

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.CompletionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Completion_Date");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.Priority).HasColumnType("enum('P1','P2','P3')");

                entity.Property(e => e.Remarks).HasMaxLength(800);

                entity.Property(e => e.TaskId).HasColumnName("Task_Id");

                entity.Property(e => e.TaskStatus)
                    .HasColumnName("Task_Status")
                    .HasDefaultValueSql("'2'")
                    .HasComment("1=Completed, 0=Rejected, 2=Pending,3=Cancelled");

                entity.HasOne(d => d.AssignedByNavigation)
                    .WithMany(p => p.AdminTaskAssigns)
                    .HasForeignKey(d => d.AssignedBy)
                    .HasConstraintName("admin_task_assign_ibfk_3");

                entity.HasOne(d => d.AssignedToNavigation)
                    .WithMany(p => p.AdminTaskAssigns)
                    .HasForeignKey(d => d.AssignedTo)
                    .HasConstraintName("admin_task_assign_ibfk_4");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.AdminTaskAssigns)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("admin_task_assign_ibfk_2");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.AdminTaskAssigns)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("admin_task_assign_ibfk_5");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.AdminTaskAssigns)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("admin_task_assign_ibfk_1");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.CmpId)
                    .HasName("PRIMARY");

                entity.ToTable("company");

                entity.HasIndex(e => e.CmpRegisteredBy, "Cmp_RegisteredBy");

                entity.Property(e => e.CmpId).HasColumnName("Cmp_Id");

                entity.Property(e => e.CmpBankAccno)
                    .HasMaxLength(20)
                    .HasColumnName("Cmp_Bank_accno");

                entity.Property(e => e.CmpBankBranch)
                    .HasMaxLength(30)
                    .HasColumnName("Cmp_Bank_Branch");

                entity.Property(e => e.CmpBankChequePhoto)
                    .HasColumnType("blob")
                    .HasColumnName("Cmp_Bank_Cheque_Photo");

                entity.Property(e => e.CmpBankName)
                    .HasMaxLength(30)
                    .HasColumnName("Cmp_Bank_Name");

                entity.Property(e => e.CmpCompanyAddress)
                    .HasMaxLength(300)
                    .HasColumnName("Cmp_Company_Address");

                entity.Property(e => e.CmpCompanyCity)
                    .HasMaxLength(20)
                    .HasColumnName("Cmp_Company_City");

                entity.Property(e => e.CmpCompanyState)
                    .HasMaxLength(20)
                    .HasColumnName("Cmp_Company_State");

                entity.Property(e => e.CmpDoc)
                    .HasColumnType("blob")
                    .HasColumnName("Cmp_Doc");

                entity.Property(e => e.CmpGstAddress)
                    .HasMaxLength(300)
                    .HasColumnName("Cmp_Gst_Address");

                entity.Property(e => e.CmpGstCity)
                    .HasMaxLength(20)
                    .HasColumnName("Cmp_Gst_City");

                entity.Property(e => e.CmpGstNo)
                    .HasMaxLength(30)
                    .HasColumnName("Cmp_GST_no");

                entity.Property(e => e.CmpGstState)
                    .HasMaxLength(20)
                    .HasColumnName("Cmp_Gst_State");

                entity.Property(e => e.CmpIfscCode)
                    .HasMaxLength(20)
                    .HasColumnName("Cmp_IFSC_code");

                entity.Property(e => e.CmpLandline)
                    .HasPrecision(12)
                    .HasColumnName("Cmp_Landline");

                entity.Property(e => e.CmpLicenceNo)
                    .HasMaxLength(30)
                    .HasColumnName("Cmp_Licence_no");

                entity.Property(e => e.CmpName)
                    .HasMaxLength(50)
                    .HasColumnName("Cmp_Name");

                entity.Property(e => e.CmpPanNo)
                    .HasMaxLength(20)
                    .HasColumnName("Cmp_Pan_no");

                entity.Property(e => e.CmpPropreitorFirstName)
                    .HasMaxLength(20)
                    .HasColumnName("Cmp_Propreitor_First_Name");

                entity.Property(e => e.CmpPropreitorLastName)
                    .HasMaxLength(20)
                    .HasColumnName("Cmp_Propreitor_Last_Name");

                entity.Property(e => e.CmpRegisteredBy).HasColumnName("Cmp_RegisteredBy");

                entity.Property(e => e.CmpType)
                    .HasMaxLength(15)
                    .HasColumnName("Cmp_Type");

                entity.Property(e => e.CmpZip).HasColumnName("Cmp_Zip");

                entity.Property(e => e.CmpZipCode).HasColumnName("Cmp_ZipCode");

                entity.HasOne(d => d.CmpRegisteredByNavigation)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.CmpRegisteredBy)
                    .HasConstraintName("company_ibfk_1");
            });

            modelBuilder.Entity<CustTaskCreation>(entity =>
            {
                entity.HasKey(e => e.TaskNo)
                    .HasName("PRIMARY");

                entity.ToTable("cust_task_creation");

                entity.HasIndex(e => e.CompanyId, "Company_Id");

                entity.HasIndex(e => e.CustomerId, "Customer_ID");

                entity.Property(e => e.TaskNo).HasColumnName("Task_No");

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.Documents).HasColumnType("blob");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("End_Date");

                entity.Property(e => e.PeriodFrom)
                    .HasColumnType("date")
                    .HasColumnName("Period_From");

                entity.Property(e => e.PeriodTo)
                    .HasColumnType("date")
                    .HasColumnName("Period_To");

                entity.Property(e => e.TaskCreationDate)
                    .HasColumnType("date")
                    .HasColumnName("Task_Creation_Date");

                entity.Property(e => e.TaskType)
                    .HasColumnType("enum('GST','TAX')")
                    .HasColumnName("Task_Type");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CustTaskCreations)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("cust_task_creation_ibfk_1");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustTaskCreations)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("cust_task_creation_ibfk_2");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.CustAddress)
                    .HasMaxLength(50)
                    .HasColumnName("Cust_Address");

                entity.Property(e => e.CustCity)
                    .HasMaxLength(20)
                    .HasColumnName("Cust_City");

                entity.Property(e => e.CustCompanyName)
                    .HasMaxLength(40)
                    .HasColumnName("Cust_Company_Name");

                entity.Property(e => e.CustDeisgnation)
                    .HasMaxLength(20)
                    .HasColumnName("Cust_Deisgnation");

                entity.Property(e => e.CustDob)
                    .HasColumnType("date")
                    .HasColumnName("Cust_DOB");

                entity.Property(e => e.CustEmailid)
                    .HasMaxLength(30)
                    .HasColumnName("Cust_Emailid");

                entity.Property(e => e.CustFirstname)
                    .HasMaxLength(20)
                    .HasColumnName("Cust_Firstname");

                entity.Property(e => e.CustGender)
                    .HasColumnType("enum('Male','Female','Others')")
                    .HasColumnName("Cust_Gender")
                    .HasDefaultValueSql("'Male'");

                entity.Property(e => e.CustLastname)
                    .HasMaxLength(20)
                    .HasColumnName("Cust_Lastname");

                entity.Property(e => e.CustMobileNo).HasColumnName("Cust_Mobile_no");

                entity.Property(e => e.CustPassword)
                    .HasMaxLength(20)
                    .HasColumnName("Cust_Password");

                entity.Property(e => e.CustProfilepic)
                    .HasMaxLength(30)
                    .HasColumnName("Cust_Profilepic");

                entity.Property(e => e.CustReferenceId)
                    .HasMaxLength(20)
                    .HasColumnName("Cust_Reference_Id");

                entity.Property(e => e.CustState)
                    .HasMaxLength(15)
                    .HasColumnName("Cust_state");

                entity.Property(e => e.CustUsername)
                    .HasMaxLength(20)
                    .HasColumnName("Cust_Username");

                entity.Property(e => e.CustZipCode)
                    .HasMaxLength(10)
                    .HasColumnName("Cust_Zip_code");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PRIMARY");

                entity.ToTable("employee");

                entity.Property(e => e.EmpId).HasColumnName("Emp_Id");

                entity.Property(e => e.EmpAddress)
                    .HasMaxLength(50)
                    .HasColumnName("Emp_Address");

                entity.Property(e => e.EmpBankAccno)
                    .HasMaxLength(20)
                    .HasColumnName("Emp_Bank_accno");

                entity.Property(e => e.EmpBankBranch)
                    .HasMaxLength(30)
                    .HasColumnName("Emp_Bank_Branch");

                entity.Property(e => e.EmpBankName)
                    .HasMaxLength(30)
                    .HasColumnName("Emp_Bank_Name");

                entity.Property(e => e.EmpCity)
                    .HasMaxLength(20)
                    .HasColumnName("Emp_City");

                entity.Property(e => e.EmpDepartment)
                    .HasColumnType("enum('GST','TAX','GST/TAX')")
                    .HasColumnName("Emp_Department");

                entity.Property(e => e.EmpDesignation)
                    .HasColumnType("enum('Jr.Accountant','Sr.Accountant')")
                    .HasColumnName("Emp_Designation");

                entity.Property(e => e.EmpDob)
                    .HasColumnType("date")
                    .HasColumnName("Emp_DOB");

                entity.Property(e => e.EmpDoj)
                    .HasColumnType("date")
                    .HasColumnName("Emp_DOJ");

                entity.Property(e => e.EmpEmailid)
                    .HasMaxLength(30)
                    .HasColumnName("Emp_Emailid");

                entity.Property(e => e.EmpFirstname)
                    .HasMaxLength(20)
                    .HasColumnName("Emp_Firstname");

                entity.Property(e => e.EmpGender)
                    .HasColumnType("enum('Male','Female','Others')")
                    .HasColumnName("Emp_Gender");

                entity.Property(e => e.EmpIfscCode)
                    .HasMaxLength(20)
                    .HasColumnName("Emp_IFSC_code");

                entity.Property(e => e.EmpLastname)
                    .HasMaxLength(20)
                    .HasColumnName("Emp_Lastname");

                entity.Property(e => e.EmpMobileNo)
                    .HasPrecision(12)
                    .HasColumnName("Emp_Mobile_no");

                entity.Property(e => e.EmpPanNo)
                    .HasMaxLength(20)
                    .HasColumnName("Emp_Pan_no");

                entity.Property(e => e.EmpPassword)
                    .HasMaxLength(20)
                    .HasColumnName("Emp_Password");

                entity.Property(e => e.EmpProfilepic)
                    .HasColumnType("blob")
                    .HasColumnName("Emp_Profilepic");

                entity.Property(e => e.EmpQualificationDoc)
                    .HasColumnType("blob")
                    .HasColumnName("Emp_Qualification_Doc");

                entity.Property(e => e.EmpSalary)
                    .HasPrecision(6)
                    .HasColumnName("Emp_Salary");

                entity.Property(e => e.EmpState)
                    .HasMaxLength(15)
                    .HasColumnName("Emp_state");

                entity.Property(e => e.EmpUsername)
                    .HasMaxLength(20)
                    .HasColumnName("Emp_Username");

                entity.Property(e => e.EmpZipCode)
                    .HasMaxLength(10)
                    .HasColumnName("Emp_Zip_code");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
