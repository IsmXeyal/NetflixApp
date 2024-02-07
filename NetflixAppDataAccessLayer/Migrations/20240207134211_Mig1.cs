using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetflixAppDataAccessLayer.Migrations
{
    public partial class Mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EditorChoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    Video_link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Imdb_link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Imdb_rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image_link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plot = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditorChoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MostPopularMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Imdb_link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Imdb_rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image_link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MostPopularMovies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MostPopularTvShows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Imdb_link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Imdb_rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image_link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MostPopularTvShows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Top250Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Imdb_link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Imdb_rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image_link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Top250Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Top250TvShows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Imdb_link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Imdb_rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image_link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Top250TvShows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommentEditorChoice",
                columns: table => new
                {
                    CommentsId = table.Column<int>(type: "int", nullable: false),
                    EditorChoicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentEditorChoice", x => new { x.CommentsId, x.EditorChoicesId });
                    table.ForeignKey(
                        name: "FK_CommentEditorChoice_Comments_CommentsId",
                        column: x => x.CommentsId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentEditorChoice_EditorChoices_EditorChoicesId",
                        column: x => x.EditorChoicesId,
                        principalTable: "EditorChoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EditorChoiceGenre",
                columns: table => new
                {
                    EditorChoicesId = table.Column<int>(type: "int", nullable: false),
                    GenresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditorChoiceGenre", x => new { x.EditorChoicesId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_EditorChoiceGenre_EditorChoices_EditorChoicesId",
                        column: x => x.EditorChoicesId,
                        principalTable: "EditorChoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EditorChoiceGenre_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EditorChoiceLanguage",
                columns: table => new
                {
                    EditorChoicesId = table.Column<int>(type: "int", nullable: false),
                    LanguagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditorChoiceLanguage", x => new { x.EditorChoicesId, x.LanguagesId });
                    table.ForeignKey(
                        name: "FK_EditorChoiceLanguage_EditorChoices_EditorChoicesId",
                        column: x => x.EditorChoicesId,
                        principalTable: "EditorChoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EditorChoiceLanguage_Languages_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentMostPopularMovie",
                columns: table => new
                {
                    CommentsId = table.Column<int>(type: "int", nullable: false),
                    MostPopularMoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentMostPopularMovie", x => new { x.CommentsId, x.MostPopularMoviesId });
                    table.ForeignKey(
                        name: "FK_CommentMostPopularMovie_Comments_CommentsId",
                        column: x => x.CommentsId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentMostPopularMovie_MostPopularMovies_MostPopularMoviesId",
                        column: x => x.MostPopularMoviesId,
                        principalTable: "MostPopularMovies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMostPopularMovie",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    MostPopularMoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMostPopularMovie", x => new { x.GenresId, x.MostPopularMoviesId });
                    table.ForeignKey(
                        name: "FK_GenreMostPopularMovie_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMostPopularMovie_MostPopularMovies_MostPopularMoviesId",
                        column: x => x.MostPopularMoviesId,
                        principalTable: "MostPopularMovies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageMostPopularMovie",
                columns: table => new
                {
                    LanguagesId = table.Column<int>(type: "int", nullable: false),
                    MostPopularMoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageMostPopularMovie", x => new { x.LanguagesId, x.MostPopularMoviesId });
                    table.ForeignKey(
                        name: "FK_LanguageMostPopularMovie_Languages_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageMostPopularMovie_MostPopularMovies_MostPopularMoviesId",
                        column: x => x.MostPopularMoviesId,
                        principalTable: "MostPopularMovies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentMostPopularTvShow",
                columns: table => new
                {
                    CommentsId = table.Column<int>(type: "int", nullable: false),
                    MostPopularTvShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentMostPopularTvShow", x => new { x.CommentsId, x.MostPopularTvShowsId });
                    table.ForeignKey(
                        name: "FK_CommentMostPopularTvShow_Comments_CommentsId",
                        column: x => x.CommentsId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentMostPopularTvShow_MostPopularTvShows_MostPopularTvShowsId",
                        column: x => x.MostPopularTvShowsId,
                        principalTable: "MostPopularTvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMostPopularTvShow",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    MostPopularTvShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMostPopularTvShow", x => new { x.GenresId, x.MostPopularTvShowsId });
                    table.ForeignKey(
                        name: "FK_GenreMostPopularTvShow_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMostPopularTvShow_MostPopularTvShows_MostPopularTvShowsId",
                        column: x => x.MostPopularTvShowsId,
                        principalTable: "MostPopularTvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageMostPopularTvShow",
                columns: table => new
                {
                    LanguagesId = table.Column<int>(type: "int", nullable: false),
                    MostPopularTvShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageMostPopularTvShow", x => new { x.LanguagesId, x.MostPopularTvShowsId });
                    table.ForeignKey(
                        name: "FK_LanguageMostPopularTvShow_Languages_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageMostPopularTvShow_MostPopularTvShows_MostPopularTvShowsId",
                        column: x => x.MostPopularTvShowsId,
                        principalTable: "MostPopularTvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddListECs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Person = table.Column<int>(type: "int", nullable: false),
                    Id_ECMovie = table.Column<int>(type: "int", nullable: false),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddListECs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddListECs_EditorChoices_Id_ECMovie",
                        column: x => x.Id_ECMovie,
                        principalTable: "EditorChoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddListECs_People_Id_Person",
                        column: x => x.Id_Person,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddListMPMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Person = table.Column<int>(type: "int", nullable: false),
                    Id_MPM = table.Column<int>(type: "int", nullable: false),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddListMPMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddListMPMs_MostPopularMovies_Id_MPM",
                        column: x => x.Id_MPM,
                        principalTable: "MostPopularMovies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddListMPMs_People_Id_Person",
                        column: x => x.Id_Person,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddListMpTs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Person = table.Column<int>(type: "int", nullable: false),
                    Id_MpT = table.Column<int>(type: "int", nullable: false),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddListMpTs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddListMpTs_MostPopularTvShows_Id_MpT",
                        column: x => x.Id_MpT,
                        principalTable: "MostPopularTvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddListMpTs_People_Id_Person",
                        column: x => x.Id_Person,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddListTMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Person = table.Column<int>(type: "int", nullable: false),
                    Id_TM = table.Column<int>(type: "int", nullable: false),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddListTMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddListTMs_People_Id_Person",
                        column: x => x.Id_Person,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddListTMs_Top250Movies_Id_TM",
                        column: x => x.Id_TM,
                        principalTable: "Top250Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentTop250Movie",
                columns: table => new
                {
                    CommentsId = table.Column<int>(type: "int", nullable: false),
                    Top250MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentTop250Movie", x => new { x.CommentsId, x.Top250MoviesId });
                    table.ForeignKey(
                        name: "FK_CommentTop250Movie_Comments_CommentsId",
                        column: x => x.CommentsId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentTop250Movie_Top250Movies_Top250MoviesId",
                        column: x => x.Top250MoviesId,
                        principalTable: "Top250Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreTop250Movie",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    Top250MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreTop250Movie", x => new { x.GenresId, x.Top250MoviesId });
                    table.ForeignKey(
                        name: "FK_GenreTop250Movie_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreTop250Movie_Top250Movies_Top250MoviesId",
                        column: x => x.Top250MoviesId,
                        principalTable: "Top250Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageTop250Movie",
                columns: table => new
                {
                    LanguagesId = table.Column<int>(type: "int", nullable: false),
                    Top250MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageTop250Movie", x => new { x.LanguagesId, x.Top250MoviesId });
                    table.ForeignKey(
                        name: "FK_LanguageTop250Movie_Languages_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageTop250Movie_Top250Movies_Top250MoviesId",
                        column: x => x.Top250MoviesId,
                        principalTable: "Top250Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddListTTs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Person = table.Column<int>(type: "int", nullable: false),
                    Id_TT = table.Column<int>(type: "int", nullable: false),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddListTTs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddListTTs_People_Id_Person",
                        column: x => x.Id_Person,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddListTTs_Top250TvShows_Id_TT",
                        column: x => x.Id_TT,
                        principalTable: "Top250TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentTop250TvShow",
                columns: table => new
                {
                    CommentsId = table.Column<int>(type: "int", nullable: false),
                    Top250TvShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentTop250TvShow", x => new { x.CommentsId, x.Top250TvShowsId });
                    table.ForeignKey(
                        name: "FK_CommentTop250TvShow_Comments_CommentsId",
                        column: x => x.CommentsId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentTop250TvShow_Top250TvShows_Top250TvShowsId",
                        column: x => x.Top250TvShowsId,
                        principalTable: "Top250TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreTop250TvShow",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    Top250TvShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreTop250TvShow", x => new { x.GenresId, x.Top250TvShowsId });
                    table.ForeignKey(
                        name: "FK_GenreTop250TvShow_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreTop250TvShow_Top250TvShows_Top250TvShowsId",
                        column: x => x.Top250TvShowsId,
                        principalTable: "Top250TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageTop250TvShow",
                columns: table => new
                {
                    LanguagesId = table.Column<int>(type: "int", nullable: false),
                    Top250TvShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageTop250TvShow", x => new { x.LanguagesId, x.Top250TvShowsId });
                    table.ForeignKey(
                        name: "FK_LanguageTop250TvShow_Languages_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageTop250TvShow_Top250TvShows_Top250TvShowsId",
                        column: x => x.Top250TvShowsId,
                        principalTable: "Top250TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddListECs_Id_ECMovie",
                table: "AddListECs",
                column: "Id_ECMovie");

            migrationBuilder.CreateIndex(
                name: "IX_AddListECs_Id_Person",
                table: "AddListECs",
                column: "Id_Person");

            migrationBuilder.CreateIndex(
                name: "IX_AddListMPMs_Id_MPM",
                table: "AddListMPMs",
                column: "Id_MPM");

            migrationBuilder.CreateIndex(
                name: "IX_AddListMPMs_Id_Person",
                table: "AddListMPMs",
                column: "Id_Person");

            migrationBuilder.CreateIndex(
                name: "IX_AddListMpTs_Id_MpT",
                table: "AddListMpTs",
                column: "Id_MpT");

            migrationBuilder.CreateIndex(
                name: "IX_AddListMpTs_Id_Person",
                table: "AddListMpTs",
                column: "Id_Person");

            migrationBuilder.CreateIndex(
                name: "IX_AddListTMs_Id_Person",
                table: "AddListTMs",
                column: "Id_Person");

            migrationBuilder.CreateIndex(
                name: "IX_AddListTMs_Id_TM",
                table: "AddListTMs",
                column: "Id_TM");

            migrationBuilder.CreateIndex(
                name: "IX_AddListTTs_Id_Person",
                table: "AddListTTs",
                column: "Id_Person");

            migrationBuilder.CreateIndex(
                name: "IX_AddListTTs_Id_TT",
                table: "AddListTTs",
                column: "Id_TT");

            migrationBuilder.CreateIndex(
                name: "IX_CommentEditorChoice_EditorChoicesId",
                table: "CommentEditorChoice",
                column: "EditorChoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentMostPopularMovie_MostPopularMoviesId",
                table: "CommentMostPopularMovie",
                column: "MostPopularMoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentMostPopularTvShow_MostPopularTvShowsId",
                table: "CommentMostPopularTvShow",
                column: "MostPopularTvShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentTop250Movie_Top250MoviesId",
                table: "CommentTop250Movie",
                column: "Top250MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentTop250TvShow_Top250TvShowsId",
                table: "CommentTop250TvShow",
                column: "Top250TvShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_EditorChoiceGenre_GenresId",
                table: "EditorChoiceGenre",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_EditorChoiceLanguage_LanguagesId",
                table: "EditorChoiceLanguage",
                column: "LanguagesId");

            migrationBuilder.CreateIndex(
                name: "IX_EditorChoices_Name",
                table: "EditorChoices",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GenreMostPopularMovie_MostPopularMoviesId",
                table: "GenreMostPopularMovie",
                column: "MostPopularMoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMostPopularTvShow_MostPopularTvShowsId",
                table: "GenreMostPopularTvShow",
                column: "MostPopularTvShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GenreTop250Movie_Top250MoviesId",
                table: "GenreTop250Movie",
                column: "Top250MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreTop250TvShow_Top250TvShowsId",
                table: "GenreTop250TvShow",
                column: "Top250TvShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageMostPopularMovie_MostPopularMoviesId",
                table: "LanguageMostPopularMovie",
                column: "MostPopularMoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageMostPopularTvShow_MostPopularTvShowsId",
                table: "LanguageMostPopularTvShow",
                column: "MostPopularTvShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Name",
                table: "Languages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LanguageTop250Movie_Top250MoviesId",
                table: "LanguageTop250Movie",
                column: "Top250MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageTop250TvShow_Top250TvShowsId",
                table: "LanguageTop250TvShow",
                column: "Top250TvShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_MostPopularMovies_Name",
                table: "MostPopularMovies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MostPopularTvShows_Name",
                table: "MostPopularTvShows",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_Username",
                table: "People",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Top250Movies_Name",
                table: "Top250Movies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Top250TvShows_Name",
                table: "Top250TvShows",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddListECs");

            migrationBuilder.DropTable(
                name: "AddListMPMs");

            migrationBuilder.DropTable(
                name: "AddListMpTs");

            migrationBuilder.DropTable(
                name: "AddListTMs");

            migrationBuilder.DropTable(
                name: "AddListTTs");

            migrationBuilder.DropTable(
                name: "CommentEditorChoice");

            migrationBuilder.DropTable(
                name: "CommentMostPopularMovie");

            migrationBuilder.DropTable(
                name: "CommentMostPopularTvShow");

            migrationBuilder.DropTable(
                name: "CommentTop250Movie");

            migrationBuilder.DropTable(
                name: "CommentTop250TvShow");

            migrationBuilder.DropTable(
                name: "EditorChoiceGenre");

            migrationBuilder.DropTable(
                name: "EditorChoiceLanguage");

            migrationBuilder.DropTable(
                name: "GenreMostPopularMovie");

            migrationBuilder.DropTable(
                name: "GenreMostPopularTvShow");

            migrationBuilder.DropTable(
                name: "GenreTop250Movie");

            migrationBuilder.DropTable(
                name: "GenreTop250TvShow");

            migrationBuilder.DropTable(
                name: "LanguageMostPopularMovie");

            migrationBuilder.DropTable(
                name: "LanguageMostPopularTvShow");

            migrationBuilder.DropTable(
                name: "LanguageTop250Movie");

            migrationBuilder.DropTable(
                name: "LanguageTop250TvShow");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "EditorChoices");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "MostPopularMovies");

            migrationBuilder.DropTable(
                name: "MostPopularTvShows");

            migrationBuilder.DropTable(
                name: "Top250Movies");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Top250TvShows");
        }
    }
}
