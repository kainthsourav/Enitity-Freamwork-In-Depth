using System.Linq;
using System.Data.Entity;
using System;

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


            //Add Update Delete Objects
            AddVideos(new Video
            {
                Name = "Terminator 1",
                GenreId = 2,
                ReleaseDate = new DateTime(1984, 10, 26),
                Classification = Classification.Silver
            });

            AddTags("classics", "drama");

            AddTagsToVideo(1, "classics", "drama", "comedy");

            RemoveTagsFromVideo(1, "comedy");

            RemoveVideo(1);
            RemoveGenre(2, enforceDeletingVideos: true);
        }

        private static void RemoveGenre(int v, bool enforceDeletingVideos)
        {
            using (var context = new VidzyContext())
            {
                var genre = context.Genres.Include(g => g.Videos).SingleOrDefault(g => g.Id == v);
                if (genre == null) return;

                if (enforceDeletingVideos)
                    context.Videos.RemoveRange(genre.Videos);

                context.Genres.Remove(genre);
                context.SaveChanges();
            }
        }

        public static void AddVideos(Video video)
        {
            using (var context = new VidzyContext())
            {
                context.Videos.Add(video);
                context.SaveChanges();
            }
            
        }

        public static void AddTagsToVideo(int videoid,params string[] tags)
        {
            using (var context = new VidzyContext())
            {
                var videoTags = context.Tags.Where(t => tags.Contains(t.Name)).ToList();
                foreach (var item in tags)
                {
                   if(!videoTags.Any(t=>t.Name.Equals(item,StringComparison.CurrentCultureIgnoreCase)))
                    {
                        videoTags.Add(new Tag
                        {
                            Name = item
                        });
                    } 
                }
                var video = context.Videos.Single(v => v.Id == videoid);
                videoTags.ForEach(t => video.AddTag(t));
                context.SaveChanges();
            }

        }
        public static void RemoveVideo(int id)
        {
            using (var context = new VidzyContext())
            {
                var vid = context.Videos.SingleOrDefault(v => v.Id == id);
                if (vid != null)
                {
                    context.Videos.Remove(vid);
                    context.SaveChanges();
                }
               
            }
        }

        public static void AddTags(params string[] tags)
        {
            using (var context = new VidzyContext())
            {
                var tag = context.Tags.Where(t => tags.Contains(t.Name)).ToList();
                foreach (var item in tags)
                {
                    if(!tag.Any(t=>t.Name.Equals(item,StringComparison.CurrentCultureIgnoreCase)))
                    {
                        context.Tags.Add(new Tag
                        {
                            Name = item
                        });
                    }
                }
                context.SaveChanges();

            }
        }
        public static void RemoveTagsFromVideo(int videoId, params string[] tagNames)
        {
           
            using (var context = new VidzyContext())
            {
                context.Tags.Where(t => tagNames.Contains(t.Name)).Load();
                var video = context.Videos.Single(v => v.Id == videoId);
                foreach (var tag in tagNames)
                {
                    video.RemoveTag(tag);
                }
               
            }
        }
}
}

