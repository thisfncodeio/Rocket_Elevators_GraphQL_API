using System;
using GraphQL_API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GraphQL_API.Entities
{
    public partial class  RailsApp_developmentContext : DbContext
    {
        public  RailsApp_developmentContext()
        {
        }

        public  RailsApp_developmentContext(DbContextOptions< dbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Battery> Batteries { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<BuildingsDetail> BuildingsDetails { get; set; }
        public virtual DbSet<Column> Columns { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Elevator> Elevators { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Lead> Leads { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<SchemaMigration> SchemaMigrations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=warehouse_development; uid=codeboxx;password=Codeboxx1!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("addresses");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Address1)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("address")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.city)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("city")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.country)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("country")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.entity)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("entity")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.number_and_street)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("number_and_street")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.lat).HasColumnName("lat");

                entity.Property(e => e.lng).HasColumnName("lng");

                entity.Property(e => e.notes)
                    .HasColumnType("text")
                    .HasColumnName("notes")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.postal_code)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("postal_code")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.status)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("status")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.type_of_address)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("type_address")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

         
            modelBuilder.Entity<Battery>(entity =>
            {
                entity.ToTable("batteries");

                entity.HasIndex(e => e.building_id, "index_batteries_on_building_id");

                entity.HasIndex(e => e.employee_id, "index_batteries_on_employee_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.building_id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("building_id");

                entity.Property(e => e.certificate_of_operations)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("cert_ope")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.date_of_commissioning)
                    .HasColumnType("date")
                    .HasColumnName("date_commissioning");

                entity.Property(e => e.date_of_last_inspection)
                    .HasColumnType("date")
                    .HasColumnName("date_last_inspection");

                entity.Property(e => e.employee_id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("employee_id");

                entity.Property(e => e.information)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("information")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.notes)
                    .HasColumnType("text")
                    .HasColumnName("notes")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.status)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("status")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.building_type)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("type_building")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.building_id)
                    .HasConstraintName("fk_rails_fc40470545");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.employee_id)
                    .HasConstraintName("fk_rails_ceeeaf55f7");
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.ToTable("buildings");

                entity.HasIndex(e => e.address_id, "index_buildings_on_address_id");

                entity.HasIndex(e => e.customer_id, "index_buildings_on_customer_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.address_id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("address_id");

                entity.Property(e => e.email_of_the_administrator_of_the_building)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("adm_contact_mail")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.full_name_of_the_building_administrator)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("adm_contact_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.phone_number_of_the_building_administrator)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("adm_contact_phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.customer_id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("customer_id");

                entity.Property(e => e.technical_contact_email_for_the_building)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("tect_contact_email")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.full_name_of_the_technical_contact_for_the_building)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("tect_contact_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.technical_contact_phone_for_the_building)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("tect_contact_phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.address_id)
                    .HasConstraintName("fk_rails_6dc7a885ab");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.customer_id)
                    .HasConstraintName("fk_rails_c29cbe7fb8");
            });

            modelBuilder.Entity<BuildingsDetail>(entity =>
            {
                entity.ToTable("buildings_details");

                entity.HasIndex(e => e.building_id, "index_buildings_details_on_building_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.building_id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("building_id");

                entity.Property(e => e.information_key)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("information_key")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.value)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("value")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.BuildingsDetails)
                    .HasForeignKey(d => d.building_id)
                    .HasConstraintName("fk_rails_2f1b3cc9c4");
            });

            modelBuilder.Entity<Column>(entity =>
            {
                entity.ToTable("columns");

                entity.HasIndex(e => e.battery_id, "index_columns_on_battery_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.number_of_floors_served)
                    .HasColumnType("int(11)")
                    .HasColumnName("amount_floors_served");

                entity.Property(e => e.battery_id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("battery_id");

                entity.Property(e => e.information)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("information")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.notes)
                    .HasColumnType("text")
                    .HasColumnName("notes")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.status)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("status")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.building_type)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("type_building")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Battery)
                    .WithMany(p => p.Columns)
                    .HasForeignKey(d => d.battery_id)
                    .HasConstraintName("fk_rails_021eb14ac4");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.address_id, "index_customers_on_address_id");

                entity.HasIndex(e => e.user_id, "index_customers_on_user_role");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.address_id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("address_id");

                entity.Property(e => e.company_name)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("company_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.email_of_company_contact)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("cpy_contact_email")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.full_name_of_company_contact)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("cpy_contact_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.company_contact_phone)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("cpy_contact_phone")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.company_description)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("cpy_description")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.customers_creation_date)
                    .HasColumnType("date")
                    .HasColumnName("date_create");

                entity.Property(e => e.user_id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_role");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.address_id)
                    .HasConstraintName("fk_rails_3f9404ba26");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.user_id)
                    .HasConstraintName("fk_rails_9917eeaf5d");
            });

            modelBuilder.Entity<Elevator>(entity =>
            {
                entity.ToTable("elevators");

                entity.HasIndex(e => e.column_id, "index_elevators_on_column_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.certificate_of_inspection)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("cert_ope")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.column_id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("column_id");

                entity.Property(e => e.date_of_commissioning)
                    .HasColumnType("date")
                    .HasColumnName("date_commissioning");

                entity.Property(e => e.date_of_last_inspection)
                    .HasColumnType("date")
                    .HasColumnName("date_last_inspection");

                entity.Property(e => e.information)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("information")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.model)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("model")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.notes)
                    .HasColumnType("text")
                    .HasColumnName("notes")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.serial_number)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("serial_number")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.status)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("status")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.building_type)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("type_building")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Column)
                    .WithMany(p => p.Elevators)
                    .HasForeignKey(d => d.column_id)
                    .HasConstraintName("fk_rails_69442d7bc2");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.HasIndex(e => e.user_id, "index_employees_on_user_role");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.first_name)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("first_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.last_name)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("last_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.title)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("title")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.user_id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_id");

            });

            modelBuilder.Entity<Lead>(entity =>
            {
                entity.ToTable("leads");

                entity.HasIndex(e => e.customer_id, "index_leads_on_customer_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.attachment)
                    .HasColumnType("mediumblob")
                    .HasColumnName("attached_file");

                entity.Property(e => e.company_name)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("company_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.created_at)
                    .HasColumnType("date")
                    .HasColumnName("create_at");

                entity.Property(e => e.customer_id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("customer_id");

                entity.Property(e => e.department_in_charge_of_elevators)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("department_in_charge_of_elevators")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.email)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("email")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.full_name_of_contact)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("full_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.message)
                    .HasColumnType("text")
                    .HasColumnName("message")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.file_name)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("name_attached_file")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.phone)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("phone_number")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.project_description)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("project_description")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.project_name)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("project_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Leads)
                    .HasForeignKey(d => d.customer_id)
                    .HasConstraintName("fk_rails_da25e077a0");
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.ToTable("quotes");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.num_of_apartments)
                    .HasColumnType("int(11)")
                    .HasColumnName("apps_qty");

                entity.Property(e => e.num_of_basements)
                    .HasColumnType("int(11)")
                    .HasColumnName("basements_qty");

                entity.Property(e => e.building_type)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("building_type")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.num_of_distinct_businesses)
                    .HasColumnType("int(11)")
                    .HasColumnName("business_qty");

                entity.Property(e => e.company_name)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("company_name")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.created_at)
                    .HasColumnType("date")
                    .HasColumnName("create_at");

                entity.Property(e => e.required_shafts)
                    .HasColumnType("int(11)")
                    .HasColumnName("elevator_needed");

                entity.Property(e => e.num_of_elevator_cages)
                    .HasColumnType("int(11)")
                    .HasColumnName("elevators_qty");

                entity.Property(e => e.email)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("email")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.num_of_floors)
                    .HasColumnType("int(11)")
                    .HasColumnName("floors_qty");

                entity.Property(e => e.num_of_activity_hours_per_day)
                    .HasColumnType("int(11)")
                    .HasColumnName("hours_activity");

                entity.Property(e => e.num_of_occupants_per_Floor)
                    .HasColumnType("int(11)")
                    .HasColumnName("occupants_floors_qty");

                entity.Property(e => e.num_of_parking_spots)
                    .HasColumnType("int(11)")
                    .HasColumnName("parkings_qty");

                entity.Property(e => e.total)
                    .HasColumnType("int(11)")
                    .HasColumnName("total_price");
            });

            modelBuilder.Entity<SchemaMigration>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PRIMARY");

                entity.ToTable("schema_migrations");

                entity.Property(e => e.Version)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("version")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.created_at)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.email)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("email")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.encrypted_password)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("encrypted_password")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.remember_created_at)
                    .HasColumnType("datetime")
                    .HasColumnName("remember_created_at");

                entity.Property(e => e.reset_password_sent_at)
                    .HasColumnType("datetime")
                    .HasColumnName("reset_password_sent_at");

                entity.Property(e => e.reset_password_token)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("reset_password_token")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.updated_at)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
