using System.Linq;
using System.Data.Entity;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {

            //Lazy loading
            var context = new VidzyContext();
            var videos = context.Videos.ToList();

            foreach (var item in videos)
            {
                System.Console.WriteLine("{0}{1}", item.Genre, item.Name);
              
            }

            //Eager Loading
            var vid = context.Videos.Include(v => v.Genre).ToList();
            foreach (var item in vid)
            {
                System.Console.WriteLine("{0}{1}", item.Name, item.Genre.Name);
            }

            //Explicit
            var vidd = context.Videos.ToList();
            context.Genres.Load();
            foreach (var item in vidd)
            {
                System.Console.WriteLine("{0}{1}", item.Name, item.Genre.Name);
            }
        }
    }
}
