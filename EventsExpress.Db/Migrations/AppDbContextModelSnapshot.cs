﻿// <auto-generated />
using EventsExpress.Db.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace EventsExpress.Db.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventsExpress.Db.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.ChatRoom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("ChatRoom");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CountryId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.Comments", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CommentsId");

                    b.Property<DateTime>("Date");

                    b.Property<Guid>("EventId");

                    b.Property<string>("Text");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CommentsId");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CityId");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("date");

                    b.Property<string>("Description");

                    b.Property<bool>("IsBlocked");

                    b.Property<Guid>("OwnerId");

                    b.Property<Guid?>("PhotoId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PhotoId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.EventCategory", b =>
                {
                    b.Property<Guid>("EventId");

                    b.Property<Guid>("CategoryId");

                    b.HasKey("EventId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("EventCategory");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.EventStatusHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid>("EventId");

                    b.Property<int>("EventStatus");

                    b.Property<string>("Reason");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("EventStatusHistory");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ChatRoomId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<bool>("Edited");

                    b.Property<Guid?>("ParentId");

                    b.Property<bool>("Seen");

                    b.Property<Guid>("SenderId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("ChatRoomId");

                    b.HasIndex("ParentId");

                    b.HasIndex("SenderId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Img");

                    b.Property<Guid?>("ReportId");

                    b.Property<byte[]>("Thumb");

                    b.HasKey("Id");

                    b.HasIndex("ReportId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.Rate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EventId");

                    b.Property<byte>("Score");

                    b.Property<Guid>("UserFromId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserFromId");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedByIp");

                    b.Property<DateTime>("Expires");

                    b.Property<string>("ReplacedByToken");

                    b.Property<DateTime?>("Revoked");

                    b.Property<string>("RevokedByIp");

                    b.Property<string>("Token");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.Relationship", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Attitude");

                    b.Property<Guid>("UserFromId");

                    b.Property<Guid>("UserToId");

                    b.HasKey("Id");

                    b.HasIndex("UserFromId");

                    b.HasIndex("UserToId");

                    b.ToTable("Relationships");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid>("EventId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<byte>("Gender");

                    b.Property<bool>("IsBlocked");

                    b.Property<string>("Name");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Phone");

                    b.Property<Guid?>("PhotoId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.UserCategory", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("CategoryId");

                    b.HasKey("UserId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("UserCategory");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.UserChat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ChatId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("UserId");

                    b.ToTable("UserChat");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.UserEvent", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("EventId");

                    b.Property<int>("Status");

                    b.HasKey("UserId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("UserEvent");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.City", b =>
                {
                    b.HasOne("EventsExpress.Db.Entities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.Comments", b =>
                {
                    b.HasOne("EventsExpress.Db.Entities.Comments", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("CommentsId");

                    b.HasOne("EventsExpress.Db.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventsExpress.Db.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.Event", b =>
                {
                    b.HasOne("EventsExpress.Db.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventsExpress.Db.Entities.User", "Owner")
                        .WithMany("Events")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EventsExpress.Db.Entities.Photo", "Photo")
                        .WithMany()
                        .HasForeignKey("PhotoId");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.EventCategory", b =>
                {
                    b.HasOne("EventsExpress.Db.Entities.Category", "Category")
                        .WithMany("Events")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventsExpress.Db.Entities.Event", "Event")
                        .WithMany("Categories")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.EventStatusHistory", b =>
                {
                    b.HasOne("EventsExpress.Db.Entities.Event", "Event")
                        .WithMany("StatusHistory")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventsExpress.Db.Entities.User", "User")
                        .WithMany("ChangedStatusEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.Message", b =>
                {
                    b.HasOne("EventsExpress.Db.Entities.ChatRoom")
                        .WithMany("Messages")
                        .HasForeignKey("ChatRoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventsExpress.Db.Entities.Message", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("EventsExpress.Db.Entities.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.Photo", b =>
                {
                    b.HasOne("EventsExpress.Db.Entities.Report")
                        .WithMany("Photos")
                        .HasForeignKey("ReportId");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.Rate", b =>
                {
                    b.HasOne("EventsExpress.Db.Entities.Event", "Event")
                        .WithMany("Rates")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EventsExpress.Db.Entities.User", "UserFrom")
                        .WithMany("Rates")
                        .HasForeignKey("UserFromId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.RefreshToken", b =>
                {
                    b.HasOne("EventsExpress.Db.Entities.User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.Relationship", b =>
                {
                    b.HasOne("EventsExpress.Db.Entities.User", "UserFrom")
                        .WithMany("Relationships")
                        .HasForeignKey("UserFromId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EventsExpress.Db.Entities.User", "UserTo")
                        .WithMany()
                        .HasForeignKey("UserToId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.Report", b =>
                {
                    b.HasOne("EventsExpress.Db.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.User", b =>
                {
                    b.HasOne("EventsExpress.Db.Entities.Photo", "Photo")
                        .WithMany()
                        .HasForeignKey("PhotoId");

                    b.HasOne("EventsExpress.Db.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.UserCategory", b =>
                {
                    b.HasOne("EventsExpress.Db.Entities.Category", "Category")
                        .WithMany("Users")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventsExpress.Db.Entities.User", "User")
                        .WithMany("Categories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.UserChat", b =>
                {
                    b.HasOne("EventsExpress.Db.Entities.ChatRoom", "Chat")
                        .WithMany("Users")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventsExpress.Db.Entities.User", "User")
                        .WithMany("Chats")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventsExpress.Db.Entities.UserEvent", b =>
                {
                    b.HasOne("EventsExpress.Db.Entities.Event", "Event")
                        .WithMany("Visitors")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventsExpress.Db.Entities.User", "User")
                        .WithMany("EventsToVisit")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
