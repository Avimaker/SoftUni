namespace MusicHub
{
    using System;
    using System.Text;
    using Data;
    using Initializer;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            using MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            //const int producerId = 4;
            //string result = ExportAlbumsInfo(context, producerId);
            //Console.WriteLine(result);

            const int duration = 4;
            string result = ExportSongsAboveDuration(context, duration);
            Console.WriteLine(result);


            
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .Where(a => a.ProducerId.HasValue &&
                            a.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer!.Name,
                    Songs = a.Songs
                        .OrderByDescending(s => s.Name)
                        .ThenBy(s => s.Writer.Name)
                        .Select(s => new
                        {
                            SongName = s.Name,
                            Price = s.Price.ToString("F2"),
                            WriterName = s.Writer.Name
                        })
                        .ToList(),
                    TotalPrice = a.Songs.Sum(s => s.Price)
                })
                .OrderByDescending(a => a.TotalPrice)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");

                int counter = 1;
                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{counter}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.Price}");
                    sb.AppendLine($"---Writer: {song.WriterName}");
                    counter++;
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalPrice:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songsData = context
                .Songs
                .Where(s => s.Duration > TimeSpan.FromSeconds(duration))
                .Select(s => new
                {
                    SongName = s.Name,
                    WriterName = s.Writer.Name,
                    //AlbumProducer = s.Album.Producer.Name,
                    AlbumProducer = (s.Album != null) ?
                        (s.Album.Producer != null ?
                        s.Album.Producer.Name : null) : (null),
                    Duration = s.Duration.ToString("c"),
                    SongPerformer = s
                        .SongPerformers
                        .OrderBy(sp => sp.Performer.FirstName)
                        .ThenBy(sp => sp.Performer.LastName)
                       //.Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                       .Select(sp => new
                       {
                           PerformerFirstName = sp.Performer.FirstName,
                           PerformerLastName = sp.Performer.LastName
                       })
                       .ToList()
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ToList();

            var sb = new StringBuilder();
            int songNumber = 1;

            foreach (var song in songsData)
            {
                sb.AppendLine($"-Song #{songNumber}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.WriterName}");

                //foreach (var performer in song.SongPerformer)
                //{
                //    sb.AppendLine($"---Performer: {performer}");
                //}

                foreach (var performer in song.SongPerformer)
                {
                    sb.AppendLine($"---Performer: {performer.PerformerFirstName} {performer.PerformerLastName}");
                }


                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration}");

                songNumber++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}

/*
 
 Символът "c" в кода s.Duration.ToString("c") е стандартен форматиращ низ за типа TimeSpan в C#. Той представлява "constant format" (непроменлив формат), който гарантира, че времето ще се показва във вид, независим от културни настройки (invariant).

Какво прави "c" за TimeSpan?
Форматът "c" извежда времето в следния вид:
[-][d.]hh:mm:ss[.fffffff]
където:

d — дни (ако има такива),

hh — часове (00–23),

mm — минути (00–59),

ss — секунди (00–59),

fffffff — части от секундата (ако има такива).

Примери:
5 минути и 35 секунди → 00:05:35

1 ден, 5 часа и 30 минути → 1.05:30:00

2 часа, 10 минути и 3 милисекунди → 02:10:00.0030000

Защо се използва в задачата?
В условието на задачата се изисква Duration да се форматира като 00:05:35 (часове:минути:секунди).
Форматът "c" автоматично премахва дните и частите от секундата, ако те са нулеви, което отговаря на примера.

Допълнителни бележки:
Ако времето е по-малко от 24 часа, дните няма да се показват (например 15:30:00 вместо 0.15:30:00).

Ако искате винаги да показвате часове, минути и секунди (без дни), "c" е идеалният избор.

Пример от задачата:

Duration = s.Duration.ToString("c"); 
// Ако Duration е 5 минути и 35 секунди → "00:05:35"

Така форматът "c" е перфектен за задачата, тъй като предоставя точното и последователно форматиране, което се изисква.
 
 */