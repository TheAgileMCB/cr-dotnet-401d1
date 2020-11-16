﻿// <auto-generated />
using IdentityDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IdentityDemo.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20200610163050_AddPostCreatedBy")]
    partial class AddPostCreatedBy
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IdentityDemo.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contents")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedByUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Contents = "Hello, World was created by Brian Kernighan. This term also refers to a simple introductory program for beginners. ",
                            Title = "Hello World"
                        },
                        new
                        {
                            Id = 2,
                            Contents = "C# is a programming language created by Microsoft in 2000. It is widely used for many different applications. we love C#",
                            Title = "Intro to C#"
                        },
                        new
                        {
                            Id = 3,
                            Contents = "How much wood could a woodchuck chuck, if a woodchuck could chuck wood?",
                            Title = "A simple riddle"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
