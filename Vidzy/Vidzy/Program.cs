using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyContext();
            var moviesSortedByName = context.Videos.Where(c=>c.Genre.Name.Equals("Action")).OrderBy(c => c.Name);

            var dramamovie = context.Videos.Where(c => c.Genre.Name.Equals("drama") && c.Classification==Classification.Gold).OrderByDescending(c => c.ReleaseDate);

            var p = context.Videos.Select(v => new { MoviesName = v.Name, Genre = v.Genre.Name });

            var grp = context.Videos.GroupBy(c => c.Classification)
                .Select(g => new
                {
                    Classification = g.Key.ToString(),
                    Videos=g.OrderBy(c=>c.Name)
                });

            var sortedbyclassfication = context.Videos.GroupBy(c => c.Classification)
                .Select(g => new
                {
                    Classification = g.Key.ToString(),
                    Video = g.Count()
                });

            var gen = context.Genres.GroupJoin(context.Videos, g => g.Id, v => v.GenreId, (genre, videos) =>
                     new
                     {
                         Name = genre.Name,
                         Vcount = videos.Count()
                     }).OrderByDescending(g => g.Vcount); ;
        }
    }
}
