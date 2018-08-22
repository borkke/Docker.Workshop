﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Users.Data;

namespace Users.Migrations
{
    [DbContext(typeof(UsersContext))]
    partial class UsersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Users.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Conuntry");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Number");

                    b.Property<string>("Street");

                    b.HasKey("Id");

                    b.ToTable("Notes");

                    b.HasData(
                        new { Id = 1, City = "Novi Sad", Conuntry = "Serbia", FirstName = "Aleksandar", LastName = "Borkovac", Number = "yyy", Street = "xxx" },
                        new { Id = 2, City = "London", Conuntry = "United Kingdom", FirstName = "Marko", LastName = "Markovic", Number = "yyy", Street = "xxx" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}