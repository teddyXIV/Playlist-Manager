﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlaylistManager.Models;

#nullable disable

namespace PlaylistManager.Migrations
{
    [DbContext(typeof(PlaylistManagerContext))]
    partial class PlaylistManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PlaylistManager.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("PlaylistManager.Models.Playlist", b =>
                {
                    b.Property<int>("PlaylistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PlaylistId");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("PlaylistManager.Models.PlaylistSong", b =>
                {
                    b.Property<int>("PlaylistSongId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<int>("SongId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistSongId");

                    b.HasIndex("PlaylistId");

                    b.HasIndex("SongId");

                    b.ToTable("PlaylistSongs");
                });

            modelBuilder.Entity("PlaylistManager.Models.Song", b =>
                {
                    b.Property<int>("SongId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("SongId");

                    b.HasIndex("GenreId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("PlaylistManager.Models.PlaylistSong", b =>
                {
                    b.HasOne("PlaylistManager.Models.Playlist", "Playlist")
                        .WithMany("JoinEntities")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlaylistManager.Models.Song", "Song")
                        .WithMany("JoinEntities")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Playlist");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("PlaylistManager.Models.Song", b =>
                {
                    b.HasOne("PlaylistManager.Models.Genre", "Genre")
                        .WithMany("Songs")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("PlaylistManager.Models.Genre", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("PlaylistManager.Models.Playlist", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("PlaylistManager.Models.Song", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
