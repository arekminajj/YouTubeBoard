﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using YouTubeBoardCore.Data;

namespace YouTubeBoardCore.Migrations
{
    [DbContext(typeof(VideoDbContext))]
    partial class VideoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("YouTubeBoardCore.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(30);

                    b.Property<int?>("VideoModelId");

                    b.HasKey("Id");

                    b.HasIndex("VideoModelId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("YouTubeBoardCore.Models.VideoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Url");

                    b.Property<string>("UserEmail");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("YouTubeBoardCore.Models.Tag", b =>
                {
                    b.HasOne("YouTubeBoardCore.Models.VideoModel")
                        .WithMany("Tags")
                        .HasForeignKey("VideoModelId");
                });
#pragma warning restore 612, 618
        }
    }
}
