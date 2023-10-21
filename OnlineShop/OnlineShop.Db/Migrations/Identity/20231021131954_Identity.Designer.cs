﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Db;

namespace OnlineShop.Db.Migrations.Identity
{
    [DbContext(typeof(IdentityContext))]
    [Migration("20231021131954_Identity")]
    partial class Identity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CompareProduct", b =>
                {
                    b.Property<Guid>("ComparesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ComparesId", "ItemsId");

                    b.HasIndex("ItemsId");

                    b.ToTable("CompareProduct");
                });

            modelBuilder.Entity("FavoritesProduct", b =>
                {
                    b.Property<Guid>("FavoritesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FavoritesId", "ItemsId");

                    b.HasIndex("ItemsId");

                    b.ToTable("FavoritesProduct");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserContactId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserContactId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Compare", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Compares");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Favorites", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Image");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bf516feb-ee36-4359-8fb8-5a2d614c1e4c"),
                            ProductId = new Guid("a3f432a9-17a0-4307-984b-290611a248f5"),
                            Url = "/img/Products/1.jpg"
                        },
                        new
                        {
                            Id = new Guid("dcf4871e-5f45-4337-b648-3accbbe160b3"),
                            ProductId = new Guid("c9f07f92-c9d5-4e8f-8093-5c242997ba82"),
                            Url = "/img/Products/2.jpg"
                        },
                        new
                        {
                            Id = new Guid("ff6a3d51-de4f-42dc-94d7-fd20c8ba56ed"),
                            ProductId = new Guid("fe7524c9-a431-4b5b-83b2-9568c7f37bfa"),
                            Url = "/img/Products/3.jpg"
                        },
                        new
                        {
                            Id = new Guid("4f6ed34b-6b41-4300-a572-8f42bfd49f00"),
                            ProductId = new Guid("fce4ebfe-1ae7-4e47-b29f-1d34916fc298"),
                            Url = "/img/Products/3.jpg"
                        },
                        new
                        {
                            Id = new Guid("764a2356-2299-4ba5-9773-bd920bdd0c83"),
                            ProductId = new Guid("6e406ea4-2656-4c1f-a0d3-8acbc9265dd7"),
                            Url = "/img/Products/5.jpg"
                        },
                        new
                        {
                            Id = new Guid("8c22393e-33de-457c-b6ca-3e8e6fe683af"),
                            ProductId = new Guid("56db2983-947f-45d5-ba51-5d5cef5cf7a5"),
                            Url = "/img/Products/6.jpg"
                        },
                        new
                        {
                            Id = new Guid("25b815c8-66b1-45a9-a135-25b5f1bbf732"),
                            ProductId = new Guid("8002540c-9944-4b42-ac8c-01ad787e81e6"),
                            Url = "/img/Products/6.jpg"
                        },
                        new
                        {
                            Id = new Guid("a3c5aa32-bb9f-4a5b-8940-f376ed800665"),
                            ProductId = new Guid("7a2227e4-4603-444f-ae2d-099079474ea0"),
                            Url = "/img/Products/5.jpg"
                        },
                        new
                        {
                            Id = new Guid("7276209a-42f3-4f33-a3ea-3830ffacc02c"),
                            ProductId = new Guid("a76d1ebe-cc7d-4618-ac9f-3d1f4935fe57"),
                            Url = "/img/Products/4.jpg"
                        },
                        new
                        {
                            Id = new Guid("270dde04-91f0-4904-a9f8-7d549da361c7"),
                            ProductId = new Guid("e54fae4f-7d6c-4e34-aa1b-820cdc772653"),
                            Url = "/img/Products/3.jpg"
                        },
                        new
                        {
                            Id = new Guid("f873006b-bb3f-466e-94d1-d86fca504a3d"),
                            ProductId = new Guid("615496eb-0537-4657-8237-f033266a3a57"),
                            Url = "/img/Products/2.jpg"
                        },
                        new
                        {
                            Id = new Guid("27455371-a22c-47d0-b25b-b497f075cbf4"),
                            ProductId = new Guid("0cb8d9f0-c806-462c-a1b6-3f095b324761"),
                            Url = "/img/Products/1.jpg"
                        },
                        new
                        {
                            Id = new Guid("483ef989-cf7d-4819-8232-4e56251daced"),
                            ProductId = new Guid("27baabe2-d81b-4c46-86e0-23b97d7637c8"),
                            Url = "/img/Products/2.jpg"
                        },
                        new
                        {
                            Id = new Guid("f9781ad5-ab5c-4422-b4ab-33301e835ed9"),
                            ProductId = new Guid("fbb6b537-d539-47ee-95c6-386b5ac0679a"),
                            Url = "/img/Products/3.jpg"
                        },
                        new
                        {
                            Id = new Guid("3a94dd81-fb96-40c6-9f3c-97850b7b1b8f"),
                            ProductId = new Guid("a1ffa88c-1316-42a8-8601-95d70a65d150"),
                            Url = "/img/Products/4.jpg"
                        },
                        new
                        {
                            Id = new Guid("f9e4198c-1d98-4178-bde5-a2936cae7643"),
                            ProductId = new Guid("0794a187-dfea-4807-9259-a7ff279455f2"),
                            Url = "/img/Products/5.jpg"
                        },
                        new
                        {
                            Id = new Guid("c2f50f69-0abc-4c2c-8c65-e0b6188600bd"),
                            ProductId = new Guid("bb71353d-1a58-45a2-84da-9b4137bec6f6"),
                            Url = "/img/Products/6.jpg"
                        },
                        new
                        {
                            Id = new Guid("f2ebc5c0-0288-4b0b-a7cf-cd3977ca72df"),
                            ProductId = new Guid("755221a6-0f45-4e86-9948-6e9f85872734"),
                            Url = "/img/Products/4.jpg"
                        },
                        new
                        {
                            Id = new Guid("f206660f-69d6-47d5-aed9-4aa753fb2e69"),
                            ProductId = new Guid("133788f9-139f-453e-b543-98b5876c4cb7"),
                            Url = "/img/Products/3.jpg"
                        },
                        new
                        {
                            Id = new Guid("d2343390-9c56-4db8-a14f-0b305f6c25bc"),
                            ProductId = new Guid("beb1332d-fbe9-4d6e-88f1-c2603bc7a80f"),
                            Url = "/img/Products/1.jpg"
                        });
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("InfoStatus")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a3f432a9-17a0-4307-984b-290611a248f5"),
                            Cost = 11426m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                            Name = "Пистолетик"
                        },
                        new
                        {
                            Id = new Guid("c9f07f92-c9d5-4e8f-8093-5c242997ba82"),
                            Cost = 11426m,
                            Description = "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim",
                            Name = "Шапка"
                        },
                        new
                        {
                            Id = new Guid("fe7524c9-a431-4b5b-83b2-9568c7f37bfa"),
                            Cost = 10398m,
                            Description = "Ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ",
                            Name = "Конструктор"
                        },
                        new
                        {
                            Id = new Guid("fce4ebfe-1ae7-4e47-b29f-1d34916fc298"),
                            Cost = 94608m,
                            Description = "Ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate",
                            Name = "Пистолетик"
                        },
                        new
                        {
                            Id = new Guid("6e406ea4-2656-4c1f-a0d3-8acbc9265dd7"),
                            Cost = 83000m,
                            Description = "Velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat",
                            Name = "Мишка"
                        },
                        new
                        {
                            Id = new Guid("56db2983-947f-45d5-ba51-5d5cef5cf7a5"),
                            Cost = 38020m,
                            Description = "cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
                            Name = "Пирамидка"
                        },
                        new
                        {
                            Id = new Guid("8002540c-9944-4b42-ac8c-01ad787e81e6"),
                            Cost = 59657m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing",
                            Name = "Трусы"
                        },
                        new
                        {
                            Id = new Guid("7a2227e4-4603-444f-ae2d-099079474ea0"),
                            Cost = 73815m,
                            Description = "Ex ea commodo consequat.Duis aute irure dolor",
                            Name = "Пистолетик"
                        },
                        new
                        {
                            Id = new Guid("a76d1ebe-cc7d-4618-ac9f-3d1f4935fe57"),
                            Cost = 66068m,
                            Description = "Sed do eiusmod tempor incididunt ut labore et dolore magna ",
                            Name = "Пистолетик"
                        },
                        new
                        {
                            Id = new Guid("e54fae4f-7d6c-4e34-aa1b-820cdc772653"),
                            Cost = 51625m,
                            Description = "Velit esse cillum dolore eu fugiat nulla pariatur.E",
                            Name = "Ложка"
                        },
                        new
                        {
                            Id = new Guid("615496eb-0537-4657-8237-f033266a3a57"),
                            Cost = 76311m,
                            Description = "Velit esse cillum dolore eu fugiat nulla pariatur.",
                            Name = "Пистолетик"
                        },
                        new
                        {
                            Id = new Guid("0cb8d9f0-c806-462c-a1b6-3f095b324761"),
                            Cost = 12248m,
                            Description = "Ex ea commodo consequat.Duis aute irure dolor in reprehenderit in v",
                            Name = "Соска"
                        },
                        new
                        {
                            Id = new Guid("27baabe2-d81b-4c46-86e0-23b97d7637c8"),
                            Cost = 4225m,
                            Description = "Ex ea commodo consequat.Duis aute i ",
                            Name = "Ложка"
                        },
                        new
                        {
                            Id = new Guid("fbb6b537-d539-47ee-95c6-386b5ac0679a"),
                            Cost = 54643m,
                            Description = "Minim veniam, quis nostrud exercitation ullamco laboris ",
                            Name = "Конструктор"
                        },
                        new
                        {
                            Id = new Guid("a1ffa88c-1316-42a8-8601-95d70a65d150"),
                            Cost = 18346m,
                            Description = "Velit esse cillum dolore eu fugiat nulla pariatur.",
                            Name = "Шапка"
                        },
                        new
                        {
                            Id = new Guid("0794a187-dfea-4807-9259-a7ff279455f2"),
                            Cost = 94741m,
                            Description = "Ex ea commodo consequat.Duis aute irure dolor in r",
                            Name = "Кукла"
                        },
                        new
                        {
                            Id = new Guid("bb71353d-1a58-45a2-84da-9b4137bec6f6"),
                            Cost = 6957m,
                            Description = "Velit esse cillum dolore eu fugiat nulla pariatur.",
                            Name = "Кукла"
                        },
                        new
                        {
                            Id = new Guid("755221a6-0f45-4e86-9948-6e9f85872734"),
                            Cost = 82167m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                            Name = "Ложка"
                        },
                        new
                        {
                            Id = new Guid("133788f9-139f-453e-b543-98b5876c4cb7"),
                            Cost = 82167m,
                            Description = "Velit esse cillum dolore eu fugiat nulla pariatur",
                            Name = "Чашка"
                        },
                        new
                        {
                            Id = new Guid("beb1332d-fbe9-4d6e-88f1-c2603bc7a80f"),
                            Cost = 88268m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                            Name = "Ползунки"
                        });
                });

            modelBuilder.Entity("OnlineShop.Db.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactsName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.UserContact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("UserContacts");
                });

            modelBuilder.Entity("CompareProduct", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Compare", null)
                        .WithMany()
                        .HasForeignKey("ComparesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Db.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FavoritesProduct", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Favorites", null)
                        .WithMany()
                        .HasForeignKey("FavoritesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Db.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Db.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineShop.Db.Models.CartItem", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Cart", "Cart")
                        .WithMany("Items")
                        .HasForeignKey("CartId");

                    b.HasOne("OnlineShop.Db.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId");

                    b.HasOne("OnlineShop.Db.Models.UserContact", "UserContact")
                        .WithMany()
                        .HasForeignKey("UserContactId");

                    b.Navigation("Cart");

                    b.Navigation("Order");

                    b.Navigation("Product");

                    b.Navigation("UserContact");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Image", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Product", null)
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Product", null)
                        .WithMany("Orders")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.UserContact", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Order", "Order")
                        .WithOne("UserContacts")
                        .HasForeignKey("OnlineShop.Db.Models.UserContact", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Cart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("UserContacts");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("Images");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}