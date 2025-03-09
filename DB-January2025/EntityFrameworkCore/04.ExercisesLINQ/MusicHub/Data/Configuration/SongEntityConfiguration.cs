namespace MusicHub.Data.Configuration
{
   using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
   using static EntityValidationConstants.Song;

    public class SongEntityConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .Property(s => s.Name)
                .HasMaxLength(SongNameMaxLength)
                .IsUnicode()
                .IsRequired();

            builder
                .Property(s => s.Duration)
                .IsRequired();

            builder 
                .Property(s => s.CreatedOn)
                .IsRequired();

            builder
                .Property(s => s.Genre)
                .IsRequired();

            builder
                .Property(s => s.Price)
                .IsRequired();

            builder
                .Property(s => s.AlbumId)
                .IsRequired(false);

            builder
                .HasOne(s => s.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(s => s.WriterId)
                .IsRequired();

            builder
                .HasOne(s => s.Writer)
                .WithMany(w => w.Songs)
                .HasForeignKey(s => s.WriterId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
