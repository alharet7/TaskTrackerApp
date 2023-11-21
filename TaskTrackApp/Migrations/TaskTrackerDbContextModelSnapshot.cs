﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskTracker.Data;

#nullable disable

namespace TaskTrackerApp.Migrations
{
    [DbContext(typeof(TaskTrackerDbContext))]
    partial class TaskTrackerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskTrackerApp.Models.Todo", b =>
                {
                    b.Property<int>("TaskTodoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskTodoId"));

                    b.Property<DateTime>("TaskTodoDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaskTodoDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskTodoName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskTodoId");

                    b.ToTable("Todos");

                    b.HasData(
                        new
                        {
                            TaskTodoId = 1,
                            TaskTodoDate = new DateTime(2023, 11, 22, 11, 41, 53, 751, DateTimeKind.Local).AddTicks(6805),
                            TaskTodoDescription = "Finish the web application project",
                            TaskTodoName = "Complete Project"
                        },
                        new
                        {
                            TaskTodoId = 2,
                            TaskTodoDate = new DateTime(2023, 11, 23, 11, 41, 53, 751, DateTimeKind.Local).AddTicks(6819),
                            TaskTodoDescription = "Read a new book on software development",
                            TaskTodoName = "Read Book"
                        },
                        new
                        {
                            TaskTodoId = 3,
                            TaskTodoDate = new DateTime(2023, 11, 24, 11, 41, 53, 751, DateTimeKind.Local).AddTicks(6820),
                            TaskTodoDescription = "Go for a run or hit the gym",
                            TaskTodoName = "Exercise"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
