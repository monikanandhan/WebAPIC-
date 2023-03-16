﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBook.Model;

namespace MyBook.Migrations
{
    [DbContext(typeof(BooksDbContext))]
    partial class BooksDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MyBook.Model.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("author");
                });

            modelBuilder.Entity("MyBook.Model.Book_Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("book_Author");
                });

            modelBuilder.Entity("MyBook.Model.Books", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CoverUrl")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateRead")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Genere")
                        .HasColumnType("text");

                    b.Property<bool>("IsRead")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<int?>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("bookSample");
                });

            modelBuilder.Entity("MyBook.Model.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("publisher");
                });

            modelBuilder.Entity("MyBook.Model.Book_Author", b =>
                {
                    b.HasOne("MyBook.Model.Author", "author")
                        .WithMany("Book_Author")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBook.Model.Books", "books")
                        .WithMany("Book_Author")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("author");

                    b.Navigation("books");
                });

            modelBuilder.Entity("MyBook.Model.Books", b =>
                {
                    b.HasOne("MyBook.Model.Publisher", "publisher")
                        .WithMany("booksDemo")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("publisher");
                });

            modelBuilder.Entity("MyBook.Model.Author", b =>
                {
                    b.Navigation("Book_Author");
                });

            modelBuilder.Entity("MyBook.Model.Books", b =>
                {
                    b.Navigation("Book_Author");
                });

            modelBuilder.Entity("MyBook.Model.Publisher", b =>
                {
                    b.Navigation("booksDemo");
                });
#pragma warning restore 612, 618
        }
    }
}
