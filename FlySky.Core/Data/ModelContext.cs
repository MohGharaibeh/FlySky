using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FlySky.Core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<About> Abouts { get; set; } = null!;
        public virtual DbSet<Airport> Airports { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Flight> Flights { get; set; } = null!;
        public virtual DbSet<Page> Pages { get; set; } = null!;
        public virtual DbSet<Reservedflight> Reservedflights { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Testimonial> Testimonials { get; set; } = null!;
        public virtual DbSet<Useracount> Useracounts { get; set; } = null!;
        public virtual DbSet<Virtualbank> Virtualbanks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=C##final;PASSWORD=123;DATA SOURCE=DESKTOP-V7VKI3K:1521/xe");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##FINAL")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<About>(entity =>
            {
                entity.ToTable("ABOUT");

                entity.Property(e => e.Aboutid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ABOUTID");

                entity.Property(e => e.Descriptions)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTIONS");

                entity.Property(e => e.Image)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Text1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TEXT1");

                entity.Property(e => e.Text2)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TEXT2");

                entity.Property(e => e.Text3)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TEXT3");

                entity.Property(e => e.Text4)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TEXT4");

                entity.Property(e => e.Text5)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TEXT5");
            });

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.ToTable("AIRPORT");

                entity.Property(e => e.Airportid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AIRPORTID");

                entity.Property(e => e.Location)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("CONTACT");

                entity.Property(e => e.Contactid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONTACTID");

                entity.Property(e => e.Email)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Image)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Message)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Phone)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Senddate)
                    .HasColumnType("DATE")
                    .HasColumnName("SENDDATE");

                entity.Property(e => e.Subject)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("FLIGHT");

                entity.Property(e => e.Flightid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("FLIGHTID");

                entity.Property(e => e.Arrivaldate)
                    .HasColumnType("DATE")
                    .HasColumnName("ARRIVALDATE");

                entity.Property(e => e.Capacity)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CAPACITY");

                entity.Property(e => e.Departuredate)
                    .HasColumnType("DATE")
                    .HasColumnName("DEPARTUREDATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Fromcountry)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("FROMCOUNTRY");

                entity.Property(e => e.Fromid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("FROMID");

                entity.Property(e => e.Image)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Price)
                    .HasColumnType("FLOAT")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Status)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Tocountry)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TOCOUNTRY");

                entity.Property(e => e.Toid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TOID");

                entity.Property(e => e.Travelclass)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TRAVELCLASS");

                entity.HasOne(d => d.From)
                    .WithMany(p => p.FlightFroms)
                    .HasForeignKey(d => d.Fromid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("AIRFROM_FK");

                entity.HasOne(d => d.To)
                    .WithMany(p => p.FlightTos)
                    .HasForeignKey(d => d.Toid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("AIRTO_FK");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.HasKey(e => e.Pagesid)
                    .HasName("SYS_C008406");

                entity.ToTable("PAGES");

                entity.Property(e => e.Pagesid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PAGESID");

                entity.Property(e => e.Image)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Paragraph)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PARAGRAPH");

                entity.Property(e => e.Text1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TEXT1");

                entity.Property(e => e.Text2)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TEXT2");

                entity.Property(e => e.Text3)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TEXT3");

                entity.Property(e => e.Text4)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TEXT4");

                entity.Property(e => e.Text5)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TEXT5");

                entity.Property(e => e.Text6)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TEXT6");

                entity.Property(e => e.Text7)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TEXT7");
            });

            modelBuilder.Entity<Reservedflight>(entity =>
            {
                entity.ToTable("RESERVEDFLIGHT");

                entity.Property(e => e.Reservedflightid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("RESERVEDFLIGHTID");

                entity.Property(e => e.Flightid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("FLIGHTID");

                entity.Property(e => e.Numberofticket)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("NUMBEROFTICKET");

                entity.Property(e => e.Reserveddate)
                    .HasColumnType("DATE")
                    .HasColumnName("RESERVEDDATE");

                entity.Property(e => e.Useracountid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERACOUNTID");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Reservedflights)
                    .HasForeignKey(d => d.Flightid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FLIGHT_FK");

                entity.HasOne(d => d.Useracount)
                    .WithMany(p => p.Reservedflights)
                    .HasForeignKey(d => d.Useracountid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("USERACCOUNT_FK");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.ToTable("TESTIMONIAL");

                entity.Property(e => e.Testimonialid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIALID");

                entity.Property(e => e.Message)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Status)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("USER_FK");
            });

            modelBuilder.Entity<Useracount>(entity =>
            {
                entity.ToTable("USERACOUNT");

                entity.Property(e => e.Useracountid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERACOUNTID");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("DATE")
                    .HasColumnName("BIRTHDATE");

                entity.Property(e => e.Email)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fname)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("FNAME");

                entity.Property(e => e.Image)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Lname)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("LNAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLEID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Useracounts)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ROLE_FK");
            });

            modelBuilder.Entity<Virtualbank>(entity =>
            {
                entity.ToTable("VIRTUALBANK");

                entity.Property(e => e.Virtualbankid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("VIRTUALBANKID");

                entity.Property(e => e.Balance)
                    .HasColumnType("FLOAT")
                    .HasColumnName("BALANCE");

                entity.Property(e => e.Cvv)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CVV");

                entity.Property(e => e.Exdate)
                    .HasColumnType("DATE")
                    .HasColumnName("EXDATE");

                entity.Property(e => e.Iban)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IBAN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
