﻿// <auto-generated />
using GirişSimilasyonu.BusinessLayer.DataBağlantısı;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GirişSimilasyonu.Migrations
{
    [DbContext(typeof(ProjeContext))]
    partial class ProjeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("EC_Sequence_calısan")
                .StartsAt(100L);

            modelBuilder.HasSequence("EC_Sequence_kullanıcı")
                .StartsAt(1000L);

            modelBuilder.HasSequence("KişiSequence");

            modelBuilder.Entity("GirişSimilasyonu.BusinessLayer.Entityler.Kişi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [KişiSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyisim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("İsim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Şifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kişiler");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("GirişSimilasyonu.BusinessLayer.Entityler.NormalKullanıcılar", b =>
                {
                    b.HasBaseType("GirişSimilasyonu.BusinessLayer.Entityler.Kişi");

                    b.Property<int>("KullanıcıNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR EC_Sequence_kullanıcı");

                    b.ToTable("NormalKullanıcılars");

                    b.HasData(
                        new
                        {
                            Id = 99997,
                            Email = "taha.aslan@gmail.com",
                            Soyisim = "aslan",
                            İsim = "taha",
                            Şifre = "test1",
                            KullanıcıNo = 1
                        },
                        new
                        {
                            Id = 99996,
                            Email = "yasin.susurcu@gmail.com",
                            Soyisim = "susurcu",
                            İsim = "yasin",
                            Şifre = "test4",
                            KullanıcıNo = 2
                        });
                });

            modelBuilder.Entity("GirişSimilasyonu.BusinessLayer.Entityler.Çalışan", b =>
                {
                    b.HasBaseType("GirişSimilasyonu.BusinessLayer.Entityler.Kişi");

                    b.Property<string>("ÇalışanKonumu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ÇalışanNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR EC_Sequence_calısan");

                    b.ToTable("Çalışanlar");

                    b.HasData(
                        new
                        {
                            Id = 99999,
                            Email = "ahmet.kılıç@gmail.com",
                            Soyisim = "kılıç",
                            İsim = "ahmet",
                            Şifre = "test2",
                            ÇalışanKonumu = "Normal çalışan",
                            ÇalışanNo = 1
                        },
                        new
                        {
                            Id = 99998,
                            Email = "osman.yılmaz@gmail.com",
                            Soyisim = "yılmaz",
                            İsim = "osman",
                            Şifre = "test3",
                            ÇalışanKonumu = "Yönetici",
                            ÇalışanNo = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
