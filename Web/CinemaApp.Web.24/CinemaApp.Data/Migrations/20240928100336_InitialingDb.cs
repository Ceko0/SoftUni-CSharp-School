using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialingDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("13940f18-31d4-45ad-a316-9cf00184d0ff"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("daf38241-0f9f-4710-be53-88dabc903d49"));

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "Release", "Title" },
                values: new object[,]
                {
                    { new Guid("78898422-157b-4dfc-86d8-c42a1038468e"), "Among motion pictures of Middle-earth in various formats, The Lord of the Rings is a trilogy of epic fantasy adventure films directed by Peter Jackson, based on the novel The Lord of the Rings by British author J. R. R. Tolkien. The films are subtitled The Fellowship of the Ring (2001), The Two Towers (2002), and The Return of the King (2003)", "Peter Jackson", 178, "Fantasy", new DateTime(2001, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lord of the Rings" },
                    { new Guid("96f769d4-84b5-4714-9ff9-328c559324e6"), "Harry Potter and the Goblet of Fire is a 2005 fantasy film directed by Mike Newell from a screenplay by Steve Kloves. It is based on the 2000 novel Harry Potter and the Goblet of Fire by J. K. Rowling. It is the sequel to Harry Potter and the Prisoner of Azkaban (2004) and the fourth instalment in the Harry Potter film series. ", "Mike Newel", 157, "Fantasy", new DateTime(2005, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Goblet of fire" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("78898422-157b-4dfc-86d8-c42a1038468e"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("96f769d4-84b5-4714-9ff9-328c559324e6"));

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "Release", "Title" },
                values: new object[,]
                {
                    { new Guid("13940f18-31d4-45ad-a316-9cf00184d0ff"), "Among motion pictures of Middle-earth in various formats, The Lord of the Rings is a trilogy of epic fantasy adventure films directed by Peter Jackson, based on the novel The Lord of the Rings by British author J. R. R. Tolkien. The films are subtitled The Fellowship of the Ring (2001), The Two Towers (2002), and The Return of the King (2003)", "Peter Jackson", 178, "Fantasy", new DateTime(2001, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lord of the Rings" },
                    { new Guid("daf38241-0f9f-4710-be53-88dabc903d49"), "Harry Potter and the Goblet of Fire is a 2005 fantasy film directed by Mike Newell from a screenplay by Steve Kloves. It is based on the 2000 novel Harry Potter and the Goblet of Fire by J. K. Rowling. It is the sequel to Harry Potter and the Prisoner of Azkaban (2004) and the fourth instalment in the Harry Potter film series. ", "Mike Newel", 157, "Fantasy", new DateTime(2005, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Goblet of fire" }
                });
        }
    }
}
