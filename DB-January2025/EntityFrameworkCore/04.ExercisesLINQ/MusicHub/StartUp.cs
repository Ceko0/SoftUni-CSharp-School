using System.Text;

namespace MusicHub
{
    using System;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            const int producerId = 9;
            string albumsInfo = ExportAlbumsInfo(context, producerId);
            Console.WriteLine(albumsInfo);

            const int minDuration = 4;
            string songsInfo = ExportSongsAboveDuration(context, minDuration);
            Console.WriteLine(songsInfo);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albums = context
                .Albums
                .Where(a => a.ProducerId.HasValue &&
                            a.ProducerId.Value == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer!.Name,
                    Songs = a
                        .Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            SongPrice = s.Price.ToString("F2"),
                            SongWriter = s.Writer.Name,
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.SongWriter)
                        .ToArray(),
                    AlbumPrice = a.Price,
                })
                .ToArray();

            albums = albums
                .OrderByDescending(a => a.AlbumPrice)
                .ToArray();

            foreach (var album in albums)
            {
                sb
                    .AppendLine($"-AlbumName: {album.AlbumName}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine($"-Songs:");

                int index = 1;
                foreach (var song in album.Songs)
                {
                    sb
                        .AppendLine($"---#{index++}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.SongPrice}")
                        .AppendLine($"---Writer: {song.SongWriter}");
                }

                sb
                    .AppendLine($"-AlbumPrice: {album.AlbumPrice.ToString("F2")}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();
            TimeSpan durationSpan = TimeSpan.FromSeconds(duration);

            var songs = context
                .Songs
                .Where(s => s.Duration > durationSpan)
                .Select(s => new
                {
                    SongName = s.Name,
                    WriterName = s.Writer.Name,
                    AlbumProducer = (s.Album != null)
                        ? (s.Album.Producer != null ? s.Album.Producer.Name : null)
                        : (null),
                    SongDuration = s.Duration.ToString("c"),
                    SongPerformers = s
                        .SongPerformers
                        .Select(sp => new
                        {
                            PerformerFirstName = sp.Performer.FirstName,
                            PerformerLastName = sp.Performer.LastName,
                        })
                        .OrderBy(p => p.PerformerFirstName)
                        .ThenBy(p => p.PerformerLastName)
                        .ToArray()
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ToArray();

            int index = 1;
            foreach (var song in songs)
            {
                sb
                    .AppendLine($"-Song #{index++}")
                    .AppendLine($"---SongName: {song.SongName}")
                    .AppendLine($"---Writer: {song.WriterName}");

                foreach (var performer in song.SongPerformers)
                {
                    sb
                        .AppendLine($"---Performer: {performer.PerformerFirstName} {performer.PerformerLastName}");
                }

                sb
                    .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.SongDuration}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
