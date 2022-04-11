﻿// <auto-generated />
using GameLibraryApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameLibraryApi.Migrations
{
    [DbContext(typeof(GameLibraryContext))]
    [Migration("20220411185326_UpdateGameModel")]
    partial class UpdateGameModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GameLibraryApi.Models.Game", b =>
                {
                    b.Property<string>("Identifier")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Identifier");

                    b.ToTable("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
