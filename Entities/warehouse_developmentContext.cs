using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class   warehouse_developmentContext : DbContext
    {
        public   warehouse_developmentContext()
        {
        }

        public   warehouse_developmentContext(DbContextOptions<  warehouseContext> options)
            : base(options)
        {
        }
        public virtual DbSet<DimCustomer> DimCustomerss { get; set; }
        public virtual DbSet<FactContact> FactContacts { get; set; }
        public virtual DbSet<FactElevator> FactElevators { get; set; }
        public virtual DbSet<FactIntervention> FactInterventions { get; set; }
        public virtual DbSet<FactQuote> FactQuotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=codeboxx-postgresql.cq6zrczewpu2.us-east-1.rds.amazonaws.com;Database=warehouse_development;Username=codeboxx;Password=Codeboxx1!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<DimCustomer>(entity =>
            {
                entity.ToTable("dim_customers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.nb_elevators).HasColumnName("amount_elevator");

                entity.Property(e => e.company_name)
                    .HasColumnType("character varying")
                    .HasColumnName("company_name");

                entity.Property(e => e.company_email)
                    .HasColumnType("character varying")
                    .HasColumnName("email_of_company_contact");

                entity.Property(e => e.company_contact)
                    .HasColumnType("character varying")
                    .HasColumnName("full_name_of_company_contact");

                entity.Property(e => e.creation_date)
                    .HasColumnType("date")
                    .HasColumnName("creation_date");

                entity.Property(e => e.customer_city)
                    .HasColumnType("character varying")
                    .HasColumnName("customer_city");
            });

            modelBuilder.Entity<FactContact>(entity =>
            {
                entity.ToTable("fact_contacts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.company_name)
                    .HasColumnType("character varying")
                    .HasColumnName("company_name");

                entity.Property(e => e.contact_id).HasColumnName("contact_id");

                entity.Property(e => e.creation_date)
                    .HasColumnType("date")
                    .HasColumnName("creation_date");

                entity.Property(e => e.email)
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.project_name)
                    .HasColumnType("character varying")
                    .HasColumnName("project_name");
            });

            modelBuilder.Entity<FactElevator>(entity =>
            {
                entity.ToTable("fact_elevators");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.building_city)
                    .HasColumnType("character varying")
                    .HasColumnName("building_city");

                entity.Property(e => e.building_id)
                    .HasColumnType("character varying")
                    .HasColumnName("building_id");

                

                entity.Property(e => e.commission_date)
                    .HasColumnType("date")
                    .HasColumnName("commissioning_date");

                entity.Property(e => e.customer_id)
                    .HasColumnType("character varying")
                    .HasColumnName("customer_id");

                entity.Property(e => e.serial_number)
                    .HasColumnType("character varying")
                    .HasColumnName("serial_number");
            });
            modelBuilder.Entity<FactIntervention>(entity =>
            {
                entity.ToTable("fact_intervention");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.battery_id).HasColumnName("battery_id");

                entity.Property(e => e.building_id).HasColumnName("building_id");

                entity.Property(e => e.column_id).HasColumnName("column_id");

                entity.Property(e => e.elevator_id).HasColumnName("elevator_id");

                entity.Property(e => e.employee_id).HasColumnName("employee_id");

                entity.Property(e => e.end_date).HasColumnName("end_date_intervention");

                entity.Property(e => e.report).HasColumnName("report");

                entity.Property(e => e.result)
                    .HasColumnType("character varying")
                    .HasColumnName("result");

                entity.Property(e => e.start_date).HasColumnName("start_date_intervention");

                entity.Property(e => e.status)
                    .HasColumnType("character varying")
                    .HasColumnName("status");

            });
            modelBuilder.Entity<FactQuote>(entity =>
            {
                entity.ToTable("fact_quotes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.num_elevators).HasColumnName("amount_elevator");

                entity.Property(e => e.company_name)
                    .HasColumnType("character varying")
                    .HasColumnName("company_name");

                entity.Property(e => e.creation_date)
                    .HasColumnType("date")
                    .HasColumnName("creation_date");

                entity.Property(e => e.email)
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.quote_id).HasColumnName("quote_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
