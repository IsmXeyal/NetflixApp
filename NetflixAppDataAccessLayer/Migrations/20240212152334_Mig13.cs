using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetflixAppDataAccessLayer.Migrations
{
    public partial class Mig13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Comments");

            migrationBuilder.CreateTable(
                name: "CommentEcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_EditorChoice = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentEcs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentEcs_EditorChoices_Id_EditorChoice",
                        column: x => x.Id_EditorChoice,
                        principalTable: "EditorChoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentMPMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_MostPopularMovie = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentMPMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentMPMs_MostPopularMovies_Id_MostPopularMovie",
                        column: x => x.Id_MostPopularMovie,
                        principalTable: "MostPopularMovies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentMPTs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_MostPopularTvShow = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentMPTs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentMPTs_MostPopularTvShows_Id_MostPopularTvShow",
                        column: x => x.Id_MostPopularTvShow,
                        principalTable: "MostPopularTvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentTMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Top250Movie = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentTMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentTMs_Top250Movies_Id_Top250Movie",
                        column: x => x.Id_Top250Movie,
                        principalTable: "Top250Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentTTs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Top250TvShow = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentTTs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentTTs_Top250TvShows_Id_Top250TvShow",
                        column: x => x.Id_Top250TvShow,
                        principalTable: "Top250TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentEcs_Id_EditorChoice",
                table: "CommentEcs",
                column: "Id_EditorChoice");

            migrationBuilder.CreateIndex(
                name: "IX_CommentMPMs_Id_MostPopularMovie",
                table: "CommentMPMs",
                column: "Id_MostPopularMovie");

            migrationBuilder.CreateIndex(
                name: "IX_CommentMPTs_Id_MostPopularTvShow",
                table: "CommentMPTs",
                column: "Id_MostPopularTvShow");

            migrationBuilder.CreateIndex(
                name: "IX_CommentTMs_Id_Top250Movie",
                table: "CommentTMs",
                column: "Id_Top250Movie");

            migrationBuilder.CreateIndex(
                name: "IX_CommentTTs_Id_Top250TvShow",
                table: "CommentTTs",
                column: "Id_Top250TvShow");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentEcs");

            migrationBuilder.DropTable(
                name: "CommentMPMs");

            migrationBuilder.DropTable(
                name: "CommentMPTs");

            migrationBuilder.DropTable(
                name: "CommentTMs");

            migrationBuilder.DropTable(
                name: "CommentTTs");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
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
        }
    }
}
