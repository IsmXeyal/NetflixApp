﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetflixAppDataAccessLayer.Contexts;

#nullable disable

namespace NetflixAppDataAccessLayer.Migrations
{
    [DbContext(typeof(NetflixDbContext))]
    [Migration("20240210192632_Mig11")]
    partial class Mig11
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CommentEditorChoice", b =>
                {
                    b.Property<int>("CommentsId")
                        .HasColumnType("int");

                    b.Property<int>("EditorChoicesId")
                        .HasColumnType("int");

                    b.HasKey("CommentsId", "EditorChoicesId");

                    b.HasIndex("EditorChoicesId");

                    b.ToTable("CommentEditorChoice");
                });

            modelBuilder.Entity("CommentMostPopularMovie", b =>
                {
                    b.Property<int>("CommentsId")
                        .HasColumnType("int");

                    b.Property<int>("MostPopularMoviesId")
                        .HasColumnType("int");

                    b.HasKey("CommentsId", "MostPopularMoviesId");

                    b.HasIndex("MostPopularMoviesId");

                    b.ToTable("CommentMostPopularMovie");
                });

            modelBuilder.Entity("CommentMostPopularTvShow", b =>
                {
                    b.Property<int>("CommentsId")
                        .HasColumnType("int");

                    b.Property<int>("MostPopularTvShowsId")
                        .HasColumnType("int");

                    b.HasKey("CommentsId", "MostPopularTvShowsId");

                    b.HasIndex("MostPopularTvShowsId");

                    b.ToTable("CommentMostPopularTvShow");
                });

            modelBuilder.Entity("CommentTop250Movie", b =>
                {
                    b.Property<int>("CommentsId")
                        .HasColumnType("int");

                    b.Property<int>("Top250MoviesId")
                        .HasColumnType("int");

                    b.HasKey("CommentsId", "Top250MoviesId");

                    b.HasIndex("Top250MoviesId");

                    b.ToTable("CommentTop250Movie");
                });

            modelBuilder.Entity("CommentTop250TvShow", b =>
                {
                    b.Property<int>("CommentsId")
                        .HasColumnType("int");

                    b.Property<int>("Top250TvShowsId")
                        .HasColumnType("int");

                    b.HasKey("CommentsId", "Top250TvShowsId");

                    b.HasIndex("Top250TvShowsId");

                    b.ToTable("CommentTop250TvShow");
                });

            modelBuilder.Entity("EditorChoiceGenre", b =>
                {
                    b.Property<int>("EditorChoicesId")
                        .HasColumnType("int");

                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.HasKey("EditorChoicesId", "GenresId");

                    b.HasIndex("GenresId");

                    b.ToTable("EditorChoiceGenre");
                });

            modelBuilder.Entity("EditorChoiceLanguage", b =>
                {
                    b.Property<int>("EditorChoicesId")
                        .HasColumnType("int");

                    b.Property<int>("LanguagesId")
                        .HasColumnType("int");

                    b.HasKey("EditorChoicesId", "LanguagesId");

                    b.HasIndex("LanguagesId");

                    b.ToTable("EditorChoiceLanguage");
                });

            modelBuilder.Entity("GenreMostPopularMovie", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<int>("MostPopularMoviesId")
                        .HasColumnType("int");

                    b.HasKey("GenresId", "MostPopularMoviesId");

                    b.HasIndex("MostPopularMoviesId");

                    b.ToTable("GenreMostPopularMovie");
                });

            modelBuilder.Entity("GenreMostPopularTvShow", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<int>("MostPopularTvShowsId")
                        .HasColumnType("int");

                    b.HasKey("GenresId", "MostPopularTvShowsId");

                    b.HasIndex("MostPopularTvShowsId");

                    b.ToTable("GenreMostPopularTvShow");
                });

            modelBuilder.Entity("GenreTop250Movie", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<int>("Top250MoviesId")
                        .HasColumnType("int");

                    b.HasKey("GenresId", "Top250MoviesId");

                    b.HasIndex("Top250MoviesId");

                    b.ToTable("GenreTop250Movie");
                });

            modelBuilder.Entity("GenreTop250TvShow", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<int>("Top250TvShowsId")
                        .HasColumnType("int");

                    b.HasKey("GenresId", "Top250TvShowsId");

                    b.HasIndex("Top250TvShowsId");

                    b.ToTable("GenreTop250TvShow");
                });

            modelBuilder.Entity("LanguageMostPopularMovie", b =>
                {
                    b.Property<int>("LanguagesId")
                        .HasColumnType("int");

                    b.Property<int>("MostPopularMoviesId")
                        .HasColumnType("int");

                    b.HasKey("LanguagesId", "MostPopularMoviesId");

                    b.HasIndex("MostPopularMoviesId");

                    b.ToTable("LanguageMostPopularMovie");
                });

            modelBuilder.Entity("LanguageMostPopularTvShow", b =>
                {
                    b.Property<int>("LanguagesId")
                        .HasColumnType("int");

                    b.Property<int>("MostPopularTvShowsId")
                        .HasColumnType("int");

                    b.HasKey("LanguagesId", "MostPopularTvShowsId");

                    b.HasIndex("MostPopularTvShowsId");

                    b.ToTable("LanguageMostPopularTvShow");
                });

            modelBuilder.Entity("LanguageTop250Movie", b =>
                {
                    b.Property<int>("LanguagesId")
                        .HasColumnType("int");

                    b.Property<int>("Top250MoviesId")
                        .HasColumnType("int");

                    b.HasKey("LanguagesId", "Top250MoviesId");

                    b.HasIndex("Top250MoviesId");

                    b.ToTable("LanguageTop250Movie");
                });

            modelBuilder.Entity("LanguageTop250TvShow", b =>
                {
                    b.Property<int>("LanguagesId")
                        .HasColumnType("int");

                    b.Property<int>("Top250TvShowsId")
                        .HasColumnType("int");

                    b.HasKey("LanguagesId", "Top250TvShowsId");

                    b.HasIndex("Top250TvShowsId");

                    b.ToTable("LanguageTop250TvShow");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.AddListEC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Id_ECMovie")
                        .HasColumnType("int");

                    b.Property<int>("Id_Person")
                        .HasColumnType("int");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Id_ECMovie");

                    b.HasIndex("Id_Person");

                    b.ToTable("AddListECs");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.AddListMPM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Id_MPM")
                        .HasColumnType("int");

                    b.Property<int>("Id_Person")
                        .HasColumnType("int");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Id_MPM");

                    b.HasIndex("Id_Person");

                    b.ToTable("AddListMPMs");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.AddListMpT", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Id_MpT")
                        .HasColumnType("int");

                    b.Property<int>("Id_Person")
                        .HasColumnType("int");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Id_MpT");

                    b.HasIndex("Id_Person");

                    b.ToTable("AddListMpTs");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.AddListTM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Id_Person")
                        .HasColumnType("int");

                    b.Property<int>("Id_TM")
                        .HasColumnType("int");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Id_Person");

                    b.HasIndex("Id_TM");

                    b.ToTable("AddListTMs");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.AddListTT", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Id_Person")
                        .HasColumnType("int");

                    b.Property<int>("Id_TT")
                        .HasColumnType("int");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Id_Person");

                    b.HasIndex("Id_TT");

                    b.ToTable("AddListTTs");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.EditorChoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Image_link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imdb_link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Imdb_rating")
                        .HasColumnType("decimal(3,1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Plot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<string>("Video_link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("EditorChoices");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.MostPopularMovie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image_link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imdb_link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Imdb_rating")
                        .HasColumnType("decimal(3,1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Plot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("MostPopularMovies");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.MostPopularTvShow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image_link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imdb_link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Imdb_rating")
                        .HasColumnType("decimal(3,1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MostPopularTvShows");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("People");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.Top250Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image_link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imdb_link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Imdb_rating")
                        .HasColumnType("decimal(3,1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Plot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Top250Movies");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.Top250TvShow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image_link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imdb_link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Imdb_rating")
                        .HasColumnType("decimal(3,1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plot")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Top250TvShows");
                });

            modelBuilder.Entity("CommentEditorChoice", b =>
                {
                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Comment", null)
                        .WithMany()
                        .HasForeignKey("CommentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.EditorChoice", null)
                        .WithMany()
                        .HasForeignKey("EditorChoicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CommentMostPopularMovie", b =>
                {
                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Comment", null)
                        .WithMany()
                        .HasForeignKey("CommentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.MostPopularMovie", null)
                        .WithMany()
                        .HasForeignKey("MostPopularMoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CommentMostPopularTvShow", b =>
                {
                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Comment", null)
                        .WithMany()
                        .HasForeignKey("CommentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.MostPopularTvShow", null)
                        .WithMany()
                        .HasForeignKey("MostPopularTvShowsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CommentTop250Movie", b =>
                {
                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Comment", null)
                        .WithMany()
                        .HasForeignKey("CommentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Top250Movie", null)
                        .WithMany()
                        .HasForeignKey("Top250MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CommentTop250TvShow", b =>
                {
                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Comment", null)
                        .WithMany()
                        .HasForeignKey("CommentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Top250TvShow", null)
                        .WithMany()
                        .HasForeignKey("Top250TvShowsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EditorChoiceGenre", b =>
                {
                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.EditorChoice", null)
                        .WithMany()
                        .HasForeignKey("EditorChoicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EditorChoiceLanguage", b =>
                {
                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.EditorChoice", null)
                        .WithMany()
                        .HasForeignKey("EditorChoicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreMostPopularMovie", b =>
                {
                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.MostPopularMovie", null)
                        .WithMany()
                        .HasForeignKey("MostPopularMoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreMostPopularTvShow", b =>
                {
                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.MostPopularTvShow", null)
                        .WithMany()
                        .HasForeignKey("MostPopularTvShowsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreTop250Movie", b =>
                {
                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Top250Movie", null)
                        .WithMany()
                        .HasForeignKey("Top250MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreTop250TvShow", b =>
                {
                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Top250TvShow", null)
                        .WithMany()
                        .HasForeignKey("Top250TvShowsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LanguageMostPopularMovie", b =>
                {
                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.MostPopularMovie", null)
                        .WithMany()
                        .HasForeignKey("MostPopularMoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LanguageMostPopularTvShow", b =>
                {
                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.MostPopularTvShow", null)
                        .WithMany()
                        .HasForeignKey("MostPopularTvShowsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LanguageTop250Movie", b =>
                {
                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Top250Movie", null)
                        .WithMany()
                        .HasForeignKey("Top250MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LanguageTop250TvShow", b =>
                {
                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Top250TvShow", null)
                        .WithMany()
                        .HasForeignKey("Top250TvShowsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.AddListEC", b =>
                {
                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.EditorChoice", "EditorChoice")
                        .WithMany("AddListECs")
                        .HasForeignKey("Id_ECMovie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Person", "Person")
                        .WithMany("AddListECs")
                        .HasForeignKey("Id_Person")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EditorChoice");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.AddListMPM", b =>
                {
                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.MostPopularMovie", "MostPopularMovie")
                        .WithMany("AddListMPMs")
                        .HasForeignKey("Id_MPM")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Person", "Person")
                        .WithMany("AddListMPMs")
                        .HasForeignKey("Id_Person")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MostPopularMovie");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.AddListMpT", b =>
                {
                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.MostPopularTvShow", "MostPopularTvShow")
                        .WithMany("AddListMpTs")
                        .HasForeignKey("Id_MpT")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Person", "Person")
                        .WithMany("AddListMpTs")
                        .HasForeignKey("Id_Person")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MostPopularTvShow");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.AddListTM", b =>
                {
                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Person", "Person")
                        .WithMany("AddListTMs")
                        .HasForeignKey("Id_Person")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Top250Movie", "Top250Movie")
                        .WithMany("AddListTMs")
                        .HasForeignKey("Id_TM")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Top250Movie");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.AddListTT", b =>
                {
                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Person", "Person")
                        .WithMany("AddListTTs")
                        .HasForeignKey("Id_Person")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetflixAppDomainLayer.Entities.Concretes.Top250TvShow", "Top250TvShow")
                        .WithMany("AddListTTs")
                        .HasForeignKey("Id_TT")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Top250TvShow");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.EditorChoice", b =>
                {
                    b.Navigation("AddListECs");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.MostPopularMovie", b =>
                {
                    b.Navigation("AddListMPMs");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.MostPopularTvShow", b =>
                {
                    b.Navigation("AddListMpTs");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.Person", b =>
                {
                    b.Navigation("AddListECs");

                    b.Navigation("AddListMPMs");

                    b.Navigation("AddListMpTs");

                    b.Navigation("AddListTMs");

                    b.Navigation("AddListTTs");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.Top250Movie", b =>
                {
                    b.Navigation("AddListTMs");
                });

            modelBuilder.Entity("NetflixAppDomainLayer.Entities.Concretes.Top250TvShow", b =>
                {
                    b.Navigation("AddListTTs");
                });
#pragma warning restore 612, 618
        }
    }
}
