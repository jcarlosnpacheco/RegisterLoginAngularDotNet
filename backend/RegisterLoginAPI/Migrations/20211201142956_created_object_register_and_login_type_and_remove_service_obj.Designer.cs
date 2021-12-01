﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RegisterLoginAPI.Infra.Data.Context;

namespace RegisterLoginAPI.Migrations
{
    [DbContext(typeof(DBRegisterLoginContext))]
    [Migration("20211201142956_created_object_register_and_login_type_and_remove_service_obj")]
    partial class created_object_register_and_login_type_and_remove_service_obj
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("RegisterLoginAPI.Business.Entity.LoginType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PK_Login_Type");

                    b.ToTable("login_type");
                });

            modelBuilder.Entity("RegisterLoginAPI.Business.Entity.RegisterLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("login_name");

                    b.Property<string>("Observation")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("observation");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.HasKey("Id")
                        .HasName("PK_Register_Login");

                    b.ToTable("register_login");
                });

            modelBuilder.Entity("RegisterLoginAPI.Business.Entity.LoginType", b =>
                {
                    b.HasOne("RegisterLoginAPI.Business.Entity.RegisterLogin", null)
                        .WithOne("LoginType")
                        .HasForeignKey("RegisterLoginAPI.Business.Entity.LoginType", "Id")
                        .HasConstraintName("FK_Login_Type")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RegisterLoginAPI.Business.Entity.RegisterLogin", b =>
                {
                    b.Navigation("LoginType");
                });
#pragma warning restore 612, 618
        }
    }
}
