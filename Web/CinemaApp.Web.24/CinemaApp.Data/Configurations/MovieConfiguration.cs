namespace CinemaApp.Data.Configurations
{
    
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    
    using static Common.EntityValidationConstants.Movie;
    using Models;

    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);

            builder
                .Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(TitleMaxLength);

            builder
                .Property(m => m.Genre)
                .IsRequired()
                .HasMaxLength(TitleMaxLength);

            builder
                .Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(DirectorNameMaxLength);

            builder
                .Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            builder.HasData(this.seedMovies());
        }

        private List<Movie> seedMovies()
        {
            List<Movie> movies = new()
            {
                new Movie()
                {
                    Id = Guid.NewGuid(),
                    Title ="Harry Potter and the Goblet of fire",
                    Genre = "Fantasy",
                    Release = new DateTime(2005,11,01),
                    Director = "Mike Newel" ,
                    Duration = 157,
                    Description = "Harry Potter and the Goblet of Fire is a 2005 fantasy film directed by Mike Newell from a screenplay by Steve Kloves. It is based on the 2000 novel Harry Potter and the Goblet of Fire by J. K. Rowling. It is the sequel to Harry Potter and the Prisoner of Azkaban (2004) and the fourth instalment in the Harry Potter film series. "
                },
                new Movie()
                {
                    Id = Guid.NewGuid(),
                    Title = "Lord of the Rings",
                    Genre = "Fantasy",
                    Release = new DateTime(2001,05,01),
                    Director = "Peter Jackson",
                    Duration = 178,
                    Description = "Among motion pictures of Middle-earth in various formats, The Lord of the Rings is a trilogy of epic fantasy adventure films directed by Peter Jackson, based on the novel The Lord of the Rings by British author J. R. R. Tolkien. The films are subtitled The Fellowship of the Ring (2001), The Two Towers (2002), and The Return of the King (2003)"
                }
            };

            return movies;

        }
    }
}
