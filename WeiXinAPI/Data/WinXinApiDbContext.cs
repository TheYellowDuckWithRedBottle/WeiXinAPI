using Microsoft.EntityFrameworkCore;
using System;
using WeiXinAPI.Enitities;

namespace WeiXinAPI.Data
{
    public class WinXinApiDbContext:DbContext
    {
        public WinXinApiDbContext(DbContextOptions<WinXinApiDbContext> options):base(options)
        {
        }
        public DbSet<Province> Province { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Area> Areas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Province>()
                .Property(x => x.Name).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<City>()
                .Property(x => x.Name).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Area>()
                .Property(x => x.Name).IsRequired().HasMaxLength(20);

            modelBuilder.Entity<City>().HasOne(navigationExpression: x => x.province)
                .WithMany(navigationExpression: x => x.Cities)
                .HasForeignKey(x => x.ProvinceId).OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Province>().HasData(
                new Province
                {
                    Id = Guid.Parse("52e9ee88-dae3-4977-b491-c2ee88044e46"),
                    ProvCapital = "南京市",
                    TotalPopulation = 10000000,
                    ConfirmedPopulation = 632,
                    CurdPopulation = 365,
                    DeadPopulation = 0,
                    Name = "江苏省"

                },
                new Province
                {
                    Id = Guid.Parse("db0185a5-48af-415f-b73f-46abc3fdc6af"),
                    Name = "上海市",
                    TotalPopulation = 20000000,
                    ConfirmedPopulation = 536,
                    CurdPopulation = 265,
                    DeadPopulation = 2,
                    ProvCapital = "上海市"
                }, 
                new Province
                {
                    Id = Guid.Parse("db0185a5-41af-415f-b73f-46abc3fdc6af"),
                    Name = "北京市",
                    TotalPopulation = 20000000,
                    ConfirmedPopulation = 536,
                    CurdPopulation = 265,
                    DeadPopulation = 2,
                    ProvCapital = "北京市"
                },
                new Province
                {
                    Id = Guid.Parse("db0185a5-424f-415f-b73f-46abc3fdc6af"),
                    Name = "辽宁市",
                    ProvCapital = "沈阳",
                    TotalPopulation = 20000000,
                    ConfirmedPopulation = 536,
                    CurdPopulation = 265,
                    DeadPopulation = 2,
                },
                new Province
                {
                    Id = Guid.Parse("DB0185A5-48AF-415F-B73F-46ABC3FDC6AE"),
                    Name = "黑龙江省",
                    ProvCapital = "哈尔滨市",
                    TotalPopulation = 20000000,
                    ConfirmedPopulation = 536,
                    CurdPopulation = 265,
                    DeadPopulation = 2,
                },
                 new Province
                 {
                     Id = Guid.NewGuid(),
                     Name = "吉林省",
                     ProvCapital = "长春市",
                     TotalPopulation = 20000000,
                     ConfirmedPopulation = 536,
                     CurdPopulation = 265,
                     DeadPopulation = 2,
                 },
                  new Province
                  {
                      Id = Guid.NewGuid(),
                      Name = "江西省",
                      ProvCapital = "南昌市",
                      TotalPopulation = 20000000,
                      ConfirmedPopulation = 536,
                      CurdPopulation = 265,
                      DeadPopulation = 2,
                  },
                   new Province
                   {
                       Id = Guid.NewGuid(),
                       Name = "湖北省",
                       ProvCapital = "武汉市",
                       TotalPopulation = 20000000,
                       ConfirmedPopulation = 536,
                       CurdPopulation = 265,
                       DeadPopulation = 2,
                   },
                    new Province
                    {
                        Id = Guid.NewGuid(),
                        Name = "湖南省",
                        ProvCapital = "长沙市",
                        TotalPopulation = 20000000,
                        ConfirmedPopulation = 536,
                        CurdPopulation = 265,
                        DeadPopulation = 2,
                    },
                     new Province
                     {
                         Id = Guid.NewGuid(),
                         Name = "内蒙古自治区",
                         ProvCapital = "呼和浩特",
                         TotalPopulation = 20000000,
                         ConfirmedPopulation = 536,
                         CurdPopulation = 265,
                         DeadPopulation = 2,
                     },
                      new Province
                      {
                          Id = Guid.NewGuid(),
                          Name = "浙江省",
                          ProvCapital = "杭州市",
                          TotalPopulation = 20000000,
                          ConfirmedPopulation = 536,
                          CurdPopulation = 265,
                          DeadPopulation = 2,
                      },
                       new Province
                       {
                           Id = Guid.NewGuid(),
                           Name = "福建省",
                           ProvCapital = "福州市",
                           TotalPopulation = 20000000,
                           ConfirmedPopulation = 536,
                           CurdPopulation = 265,
                           DeadPopulation = 2,
                       },
                        new Province
                        {
                            Id = Guid.NewGuid(),
                            Name = "河北省",
                            ProvCapital = "石家庄市",
                            TotalPopulation = 20000000,
                            ConfirmedPopulation = 536,
                            CurdPopulation = 265,
                            DeadPopulation = 2,
                        },
                      
                              new Province
                              {
                                  Id = Guid.NewGuid(),
                                  Name = "云南省",
                                  ProvCapital = "昆明市",
                                  TotalPopulation = 20000000,
                                  ConfirmedPopulation = 536,
                                  CurdPopulation = 265,
                                  DeadPopulation = 2,
                              });
            modelBuilder.Entity<City>().HasData(
                new City
                {
                    Id = Guid.Parse("52e9ee28-dae3-4977-b491-c1ee88014e56"),
                    ProvinceId = Guid.Parse("db0185a5-48af-415f-b73f-46abc3fdc6ae"),
                    TotalPopulation = 10000,
                    ConfirmedPopulation = 513,
                    CurdPopulation = 16,
                    DeadPopulation = 0,
                    Name = "哈尔滨市"
                },
                 new City
                 {
                     Id = Guid.Parse("52e9ee88-dae3-4977-b491-c2ee88054e56"),
                     ProvinceId = Guid.Parse("db0185a5-48af-415f-b73f-46abc3fdc6af"),
                     TotalPopulation = 10000,
                     ConfirmedPopulation = 513,
                     CurdPopulation = 16,
                     DeadPopulation = 0,
                     Name = "上海市"

                 },
               new City
               {
                   Id = Guid.Parse("52e9ee88-dae3-5977-b491-c2ee88044e56"),
                   ProvinceId= Guid.Parse("52e9ee88-dae3-4977-b491-c2ee88044e46"),
                   TotalPopulation = 10000,
                   ConfirmedPopulation = 83,
                   CurdPopulation = 25,
                   DeadPopulation = 0,
                   Name = "南京市"

               },
               new City
               {
                   Id = Guid.Parse("52e9ee88-dae3-4917-b491-c2ee88144e56"),
                   ProvinceId = Guid.Parse("52e9ee88-dae3-4977-b491-c2ee88044e46"),
                   TotalPopulation = 20000,
                   ConfirmedPopulation = 73,
                   CurdPopulation = 26,
                   DeadPopulation = 0,
                   Name = "苏州市"

               },
               new City
               {
                   Id = Guid.Parse("52e9ea88-dae3-4977-b491-c2ee78144e56"),
                   ProvinceId = Guid.Parse("52e9ee88-dae3-4977-b491-c2ee88044e46"),
                   TotalPopulation = 30000,
                   ConfirmedPopulation = 53,
                   CurdPopulation = 46,
                   DeadPopulation = 0,
                   Name = "镇江市"

               });


        }

    }
}
