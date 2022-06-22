﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkApp.DataAccess.SqlServer;

namespace WorkApp.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190910112109_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
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

                    b.Property<string>("Discriminator")
                        .IsRequired();

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

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
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

            modelBuilder.Entity("WorkApp.DataAccess.Entities.DesktopMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsVisible");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.HasKey("Id");

                    b.ToTable("DesktopMenu");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddedDate = new DateTime(2019, 9, 10, 14, 21, 9, 124, DateTimeKind.Local).AddTicks(8319),
                            IsDeleted = false,
                            IsVisible = true,
                            ModifiedDate = new DateTime(2019, 9, 10, 14, 21, 9, 124, DateTimeKind.Local).AddTicks(8319),
                            Name = "Dashboard",
                            Order = 0
                        },
                        new
                        {
                            Id = 2,
                            AddedDate = new DateTime(2019, 9, 10, 14, 21, 9, 124, DateTimeKind.Local).AddTicks(8319),
                            IsDeleted = false,
                            IsVisible = true,
                            ModifiedDate = new DateTime(2019, 9, 10, 14, 21, 9, 124, DateTimeKind.Local).AddTicks(8319),
                            Name = "Kanban",
                            Order = 0
                        },
                        new
                        {
                            Id = 3,
                            AddedDate = new DateTime(2019, 9, 10, 14, 21, 9, 124, DateTimeKind.Local).AddTicks(8319),
                            IsDeleted = false,
                            IsVisible = true,
                            ModifiedDate = new DateTime(2019, 9, 10, 14, 21, 9, 124, DateTimeKind.Local).AddTicks(8319),
                            Name = "Notes",
                            Order = 0
                        },
                        new
                        {
                            Id = 4,
                            AddedDate = new DateTime(2019, 9, 10, 14, 21, 9, 124, DateTimeKind.Local).AddTicks(8319),
                            IsDeleted = false,
                            IsVisible = true,
                            ModifiedDate = new DateTime(2019, 9, 10, 14, 21, 9, 124, DateTimeKind.Local).AddTicks(8319),
                            Name = "ToDoes",
                            Order = 0
                        },
                        new
                        {
                            Id = 5,
                            AddedDate = new DateTime(2019, 9, 10, 14, 21, 9, 124, DateTimeKind.Local).AddTicks(8319),
                            IsDeleted = false,
                            IsVisible = true,
                            ModifiedDate = new DateTime(2019, 9, 10, 14, 21, 9, 124, DateTimeKind.Local).AddTicks(8319),
                            Name = "Settings",
                            Order = 0
                        });
                });

            modelBuilder.Entity("WorkApp.DataAccess.Entities.KanbanBoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("KanbanBoard");
                });

            modelBuilder.Entity("WorkApp.DataAccess.Entities.KanbanBoardCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Content");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("KanbanBoardColumnId");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<int>("Order");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("KanbanBoardColumnId");

                    b.ToTable("KanbanBoardCard");
                });

            modelBuilder.Entity("WorkApp.DataAccess.Entities.KanbanBoardCardTag", b =>
                {
                    b.Property<int>("TagId");

                    b.Property<int>("CardId");

                    b.Property<DateTime>("AddedDate");

                    b.Property<int>("Id");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedDate");

                    b.HasKey("TagId", "CardId");

                    b.HasIndex("CardId");

                    b.ToTable("KanbanBoardCardTag");
                });

            modelBuilder.Entity("WorkApp.DataAccess.Entities.KanbanBoardColumn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("KanbanBoardId");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<int>("Order");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("KanbanBoardId");

                    b.ToTable("KanbanBoardColumn");
                });

            modelBuilder.Entity("WorkApp.DataAccess.Entities.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Content");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Title");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("WorkApp.DataAccess.Entities.NoteTag", b =>
                {
                    b.Property<int>("TagId");

                    b.Property<int>("NoteId");

                    b.Property<DateTime>("AddedDate");

                    b.Property<int>("Id");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedDate");

                    b.HasKey("TagId", "NoteId");

                    b.HasIndex("NoteId");

                    b.ToTable("NoteTag");
                });

            modelBuilder.Entity("WorkApp.DataAccess.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("WorkApp.DataAccess.Entities.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("IsCompleted");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Text");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ToDo");
                });

            modelBuilder.Entity("WorkApp.DataAccess.Entities.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
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

            modelBuilder.Entity("WorkApp.DataAccess.Entities.KanbanBoard", b =>
                {
                    b.HasOne("WorkApp.DataAccess.Entities.ApplicationUser", "User")
                        .WithMany("KanbanBoards")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WorkApp.DataAccess.Entities.KanbanBoardCard", b =>
                {
                    b.HasOne("WorkApp.DataAccess.Entities.KanbanBoardColumn")
                        .WithMany("Cards")
                        .HasForeignKey("KanbanBoardColumnId");
                });

            modelBuilder.Entity("WorkApp.DataAccess.Entities.KanbanBoardCardTag", b =>
                {
                    b.HasOne("WorkApp.DataAccess.Entities.KanbanBoardCard", "Card")
                        .WithMany("Tags")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WorkApp.DataAccess.Entities.Tag", "Tag")
                        .WithMany("KanbanBoardCards")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorkApp.DataAccess.Entities.KanbanBoardColumn", b =>
                {
                    b.HasOne("WorkApp.DataAccess.Entities.KanbanBoard")
                        .WithMany("Columns")
                        .HasForeignKey("KanbanBoardId");
                });

            modelBuilder.Entity("WorkApp.DataAccess.Entities.Note", b =>
                {
                    b.HasOne("WorkApp.DataAccess.Entities.ApplicationUser", "User")
                        .WithMany("Notes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WorkApp.DataAccess.Entities.NoteTag", b =>
                {
                    b.HasOne("WorkApp.DataAccess.Entities.Note", "Note")
                        .WithMany("Tags")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WorkApp.DataAccess.Entities.Tag", "Tag")
                        .WithMany("Notes")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorkApp.DataAccess.Entities.ToDo", b =>
                {
                    b.HasOne("WorkApp.DataAccess.Entities.ApplicationUser", "User")
                        .WithMany("ToDoes")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}