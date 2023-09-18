﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjekatNaVezbama.DB;

#nullable disable

namespace ProjekatNaVezbama.Migrations
{
    [DbContext(typeof(DBPostItContext))]
    [Migration("20230918121756_active-inactive-option")]
    partial class activeinactiveoption
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PostUser", b =>
                {
                    b.Property<int>("LikedByID")
                        .HasColumnType("int");

                    b.Property<int>("LikedPostsID")
                        .HasColumnType("int");

                    b.HasKey("LikedByID", "LikedPostsID");

                    b.HasIndex("LikedPostsID");

                    b.ToTable("PostUser");
                });

            modelBuilder.Entity("ProjekatNaVezbama.Model.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CreatorID")
                        .HasColumnType("int");

                    b.Property<int>("LikeCount")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OriginPostID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("CreatorID");

                    b.HasIndex("OriginPostID");

                    b.HasIndex("UserID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ProjekatNaVezbama.Model.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatorID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("LikeCount")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("CreatorID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("ProjekatNaVezbama.Model.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PostUser", b =>
                {
                    b.HasOne("ProjekatNaVezbama.Model.User", null)
                        .WithMany()
                        .HasForeignKey("LikedByID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjekatNaVezbama.Model.Post", null)
                        .WithMany()
                        .HasForeignKey("LikedPostsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjekatNaVezbama.Model.Comment", b =>
                {
                    b.HasOne("ProjekatNaVezbama.Model.User", "Creator")
                        .WithMany("Comments")
                        .HasForeignKey("CreatorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjekatNaVezbama.Model.Post", "OriginPost")
                        .WithMany("Comments")
                        .HasForeignKey("OriginPostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjekatNaVezbama.Model.User", null)
                        .WithMany("LikedComments")
                        .HasForeignKey("UserID");

                    b.Navigation("Creator");

                    b.Navigation("OriginPost");
                });

            modelBuilder.Entity("ProjekatNaVezbama.Model.Post", b =>
                {
                    b.HasOne("ProjekatNaVezbama.Model.User", "Creator")
                        .WithMany("Posts")
                        .HasForeignKey("CreatorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("ProjekatNaVezbama.Model.User", b =>
                {
                    b.HasOne("ProjekatNaVezbama.Model.User", null)
                        .WithMany("Followers")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("ProjekatNaVezbama.Model.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("ProjekatNaVezbama.Model.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Followers");

                    b.Navigation("LikedComments");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
