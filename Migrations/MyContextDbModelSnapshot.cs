﻿// <auto-generated />
using Many_to_many_Relation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Many_to_many_Relation.Migrations
{
    [DbContext(typeof(MyContextDb))]
    partial class MyContextDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.Property<int>("CoursesCourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsStudnetId")
                        .HasColumnType("int");

                    b.HasKey("CoursesCourseId", "StudentsStudnetId");

                    b.HasIndex("StudentsStudnetId");

                    b.ToTable("CourseStudent", (string)null);
                });

            modelBuilder.Entity("Many_to_many_Relation.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Many_to_many_Relation.Student", b =>
                {
                    b.Property<int>("StudnetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudnetId"));

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudnetId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.HasOne("Many_to_many_Relation.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Many_to_many_Relation.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsStudnetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
