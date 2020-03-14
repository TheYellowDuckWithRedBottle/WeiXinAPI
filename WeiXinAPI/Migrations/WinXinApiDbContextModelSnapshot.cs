﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeiXinAPI.Data;

namespace WeiXinAPI.Migrations
{
    [DbContext(typeof(WinXinApiDbContext))]
    partial class WinXinApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("WeiXinAPI.Enitities.Area", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CityId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ConfirmedPopulation")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurdPopulation")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeadPopulation")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(20);

                    b.Property<int>("TotalPopulation")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("WeiXinAPI.Enitities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("ConfirmedPopulation")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurdPopulation")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeadPopulation")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(20);

                    b.Property<Guid>("ProvinceId")
                        .HasColumnType("TEXT");

                    b.Property<int>("TotalPopulation")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("cities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("52e9ee28-dae3-4977-b491-c1ee88014e56"),
                            ConfirmedPopulation = 513,
                            CurdPopulation = 16,
                            DeadPopulation = 0,
                            Name = "哈尔滨市",
                            ProvinceId = new Guid("db0185a5-48af-415f-b73f-46abc3fdc6ae"),
                            TotalPopulation = 10000
                        },
                        new
                        {
                            Id = new Guid("52e9ee88-dae3-4977-b491-c2ee88054e56"),
                            ConfirmedPopulation = 513,
                            CurdPopulation = 16,
                            DeadPopulation = 0,
                            Name = "上海市",
                            ProvinceId = new Guid("db0185a5-48af-415f-b73f-46abc3fdc6af"),
                            TotalPopulation = 10000
                        },
                        new
                        {
                            Id = new Guid("52e9ee88-dae3-5977-b491-c2ee88044e56"),
                            ConfirmedPopulation = 83,
                            CurdPopulation = 25,
                            DeadPopulation = 0,
                            Name = "南京市",
                            ProvinceId = new Guid("52e9ee88-dae3-4977-b491-c2ee88044e46"),
                            TotalPopulation = 10000
                        },
                        new
                        {
                            Id = new Guid("52e9ee88-dae3-4917-b491-c2ee88144e56"),
                            ConfirmedPopulation = 73,
                            CurdPopulation = 26,
                            DeadPopulation = 0,
                            Name = "苏州市",
                            ProvinceId = new Guid("52e9ee88-dae3-4977-b491-c2ee88044e46"),
                            TotalPopulation = 20000
                        },
                        new
                        {
                            Id = new Guid("52e9ea88-dae3-4977-b491-c2ee78144e56"),
                            ConfirmedPopulation = 53,
                            CurdPopulation = 46,
                            DeadPopulation = 0,
                            Name = "镇江市",
                            ProvinceId = new Guid("52e9ee88-dae3-4977-b491-c2ee88044e46"),
                            TotalPopulation = 30000
                        });
                });

            modelBuilder.Entity("WeiXinAPI.Enitities.Province", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("ConfirmedPopulation")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurdPopulation")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeadPopulation")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(20);

                    b.Property<string>("ProvCapital")
                        .HasColumnType("TEXT");

                    b.Property<int>("TotalPopulation")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Province");

                    b.HasData(
                        new
                        {
                            Id = new Guid("52e9ee88-dae3-4977-b491-c2ee88044e46"),
                            ConfirmedPopulation = 632,
                            CurdPopulation = 365,
                            DeadPopulation = 0,
                            Name = "江苏省",
                            ProvCapital = "南京市",
                            TotalPopulation = 10000000
                        },
                        new
                        {
                            Id = new Guid("db0185a5-48af-415f-b73f-46abc3fdc6af"),
                            ConfirmedPopulation = 536,
                            CurdPopulation = 265,
                            DeadPopulation = 2,
                            Name = "上海市",
                            ProvCapital = "上海市",
                            TotalPopulation = 20000000
                        },
                        new
                        {
                            Id = new Guid("db0185a5-41af-415f-b73f-46abc3fdc6af"),
                            ConfirmedPopulation = 536,
                            CurdPopulation = 265,
                            DeadPopulation = 2,
                            Name = "北京市",
                            ProvCapital = "北京市",
                            TotalPopulation = 20000000
                        },
                        new
                        {
                            Id = new Guid("db0185a5-424f-415f-b73f-46abc3fdc6af"),
                            ConfirmedPopulation = 536,
                            CurdPopulation = 265,
                            DeadPopulation = 2,
                            Name = "辽宁市",
                            ProvCapital = "沈阳",
                            TotalPopulation = 20000000
                        },
                        new
                        {
                            Id = new Guid("db0185a5-48af-415f-b73f-46abc3fdc6ae"),
                            ConfirmedPopulation = 536,
                            CurdPopulation = 265,
                            DeadPopulation = 2,
                            Name = "黑龙江省",
                            ProvCapital = "哈尔滨市",
                            TotalPopulation = 20000000
                        },
                        new
                        {
                            Id = new Guid("d14b43dc-60b0-454f-a2f1-13e3575cc130"),
                            ConfirmedPopulation = 536,
                            CurdPopulation = 265,
                            DeadPopulation = 2,
                            Name = "吉林省",
                            ProvCapital = "长春市",
                            TotalPopulation = 20000000
                        },
                        new
                        {
                            Id = new Guid("b452ed51-935e-4558-9780-e5c70b305f5b"),
                            ConfirmedPopulation = 536,
                            CurdPopulation = 265,
                            DeadPopulation = 2,
                            Name = "江西省",
                            ProvCapital = "南昌市",
                            TotalPopulation = 20000000
                        },
                        new
                        {
                            Id = new Guid("306d2712-d177-4fd7-9144-567e45790bbb"),
                            ConfirmedPopulation = 536,
                            CurdPopulation = 265,
                            DeadPopulation = 2,
                            Name = "湖北省",
                            ProvCapital = "武汉市",
                            TotalPopulation = 20000000
                        },
                        new
                        {
                            Id = new Guid("9775cb29-a41c-4352-9abc-700c8029b892"),
                            ConfirmedPopulation = 536,
                            CurdPopulation = 265,
                            DeadPopulation = 2,
                            Name = "湖南省",
                            ProvCapital = "长沙市",
                            TotalPopulation = 20000000
                        },
                        new
                        {
                            Id = new Guid("480e74a5-e6a0-46c8-91cf-169983d792f8"),
                            ConfirmedPopulation = 536,
                            CurdPopulation = 265,
                            DeadPopulation = 2,
                            Name = "内蒙古自治区",
                            ProvCapital = "呼和浩特",
                            TotalPopulation = 20000000
                        },
                        new
                        {
                            Id = new Guid("86ef5962-1dbf-4532-8521-90744f358736"),
                            ConfirmedPopulation = 536,
                            CurdPopulation = 265,
                            DeadPopulation = 2,
                            Name = "浙江省",
                            ProvCapital = "杭州市",
                            TotalPopulation = 20000000
                        },
                        new
                        {
                            Id = new Guid("53764d2a-88a5-466f-9da0-3e06de021c92"),
                            ConfirmedPopulation = 536,
                            CurdPopulation = 265,
                            DeadPopulation = 2,
                            Name = "福建省",
                            ProvCapital = "福州市",
                            TotalPopulation = 20000000
                        },
                        new
                        {
                            Id = new Guid("5e564e63-53c6-49db-906f-b5b9b80513a3"),
                            ConfirmedPopulation = 536,
                            CurdPopulation = 265,
                            DeadPopulation = 2,
                            Name = "河北省",
                            ProvCapital = "石家庄市",
                            TotalPopulation = 20000000
                        },
                        new
                        {
                            Id = new Guid("32f83f2b-8e43-447d-842f-eda95a158ea1"),
                            ConfirmedPopulation = 536,
                            CurdPopulation = 265,
                            DeadPopulation = 2,
                            Name = "云南省",
                            ProvCapital = "昆明市",
                            TotalPopulation = 20000000
                        });
                });

            modelBuilder.Entity("WeiXinAPI.Enitities.Area", b =>
                {
                    b.HasOne("WeiXinAPI.Enitities.City", null)
                        .WithMany("Areas")
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("WeiXinAPI.Enitities.City", b =>
                {
                    b.HasOne("WeiXinAPI.Enitities.Province", "province")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
