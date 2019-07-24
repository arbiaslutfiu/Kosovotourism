﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Monument_Scann.Data;

namespace Monument_Scann.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190624143148_users")]
    partial class users
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Monument_Scann.Areas.Admin.Models.Lajki", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Liked");

                    b.Property<int>("MonumentsId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("MonumentsId");

                    b.ToTable("Lajkis");
                });

            modelBuilder.Entity("Monument_Scann.Areas.Admin.Models.LajkiTurS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Liked");

                    b.Property<string>("UserId");

                    b.Property<int>("touristspotsId");

                    b.HasKey("Id");

                    b.HasIndex("touristspotsId");

                    b.ToTable("LajkiTurSs");
                });

            modelBuilder.Entity("Monument_Scann.Areas.Admin.Models.Monument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Citys");

                    b.Property<int?>("ComentsId");

                    b.Property<string>("History");

                    b.Property<string>("Image");

                    b.Property<int?>("LajkiMId");

                    b.Property<int?>("MonumentId");

                    b.Property<int>("NrLike");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ComentsId");

                    b.HasIndex("LajkiMId");

                    b.HasIndex("MonumentId");

                    b.ToTable("Monument");
                });

            modelBuilder.Entity("Monument_Scann.Areas.Admin.Models.MonumentComments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comented")
                        .IsRequired();

                    b.Property<int>("MonumentId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("MonumentId");

                    b.ToTable("MonumentComments");
                });

            modelBuilder.Entity("Monument_Scann.Areas.Admin.Models.Reports", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .IsRequired();

                    b.Property<string>("email")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Monument_Scann.Areas.Admin.Models.touristspot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Citys");

                    b.Property<int?>("ComentsId");

                    b.Property<string>("History");

                    b.Property<string>("Image");

                    b.Property<int?>("LajkiTSId");

                    b.Property<int>("NrLike");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ComentsId");

                    b.HasIndex("LajkiTSId");

                    b.ToTable("touristspot");
                });

            modelBuilder.Entity("Monument_Scann.Areas.Admin.Models.TouristSpotComents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comented")
                        .IsRequired();

                    b.Property<string>("UserName");

                    b.Property<int>("touristspotId");

                    b.HasKey("Id");

                    b.HasIndex("touristspotId");

                    b.ToTable("TouristSpotComents");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monument_Scann.Areas.Admin.Models.Lajki", b =>
                {
                    b.HasOne("Monument_Scann.Areas.Admin.Models.Monument", "Monuments")
                        .WithMany()
                        .HasForeignKey("MonumentsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monument_Scann.Areas.Admin.Models.LajkiTurS", b =>
                {
                    b.HasOne("Monument_Scann.Areas.Admin.Models.touristspot", "touristspots")
                        .WithMany()
                        .HasForeignKey("touristspotsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monument_Scann.Areas.Admin.Models.Monument", b =>
                {
                    b.HasOne("Monument_Scann.Areas.Admin.Models.MonumentComments", "Coments")
                        .WithMany()
                        .HasForeignKey("ComentsId");

                    b.HasOne("Monument_Scann.Areas.Admin.Models.Lajki", "LajkiM")
                        .WithMany()
                        .HasForeignKey("LajkiMId");

                    b.HasOne("Monument_Scann.Areas.Admin.Models.Monument")
                        .WithMany("Monuments")
                        .HasForeignKey("MonumentId");
                });

            modelBuilder.Entity("Monument_Scann.Areas.Admin.Models.MonumentComments", b =>
                {
                    b.HasOne("Monument_Scann.Areas.Admin.Models.Monument", "Monumenti")
                        .WithMany()
                        .HasForeignKey("MonumentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monument_Scann.Areas.Admin.Models.touristspot", b =>
                {
                    b.HasOne("Monument_Scann.Areas.Admin.Models.TouristSpotComents", "Coments")
                        .WithMany()
                        .HasForeignKey("ComentsId");

                    b.HasOne("Monument_Scann.Areas.Admin.Models.LajkiTurS", "LajkiTS")
                        .WithMany()
                        .HasForeignKey("LajkiTSId");
                });

            modelBuilder.Entity("Monument_Scann.Areas.Admin.Models.TouristSpotComents", b =>
                {
                    b.HasOne("Monument_Scann.Areas.Admin.Models.touristspot", "Touristspoti")
                        .WithMany()
                        .HasForeignKey("touristspotId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
