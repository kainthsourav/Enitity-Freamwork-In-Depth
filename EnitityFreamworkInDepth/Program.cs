using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnitityFreamworkInDepth
{
 
   
    class Program
    {
        static void Main(string[] args)
        {
            var context = new dbEFEntities();
            var post = new dbo_Posts()
            {
                Body = "Body",
                DatePublished = DateTime.Now,
                Title = "Title",
                Postid = 1
            };
            context.dbo_Posts.Add(post);
            
            //DifferentDatabse

            var DiffContext = new KainthsouravEntities();
            var Data = DiffContext.getMovieData();
            foreach (var item in Data)
            {
                Console.WriteLine(item.move_name);
                Console.WriteLine(item.movie_category);
            }

            //using enum to give value
            var UserType = new UserProfile()
            {
                UserProfileId = 551,
                UserName = "Sourav",
                UserMemberShipType = User_memeberShipType.Plantium //using enum here
            };
            DiffContext.UserProfiles.Add(UserType);
            //DiffContext.SaveChanges();

            //Video game Excercise
            var videoContext = new VidzyEntities1();

            videoContext.AddVideo("Call of Duty", DateTime.Now, "Action", (byte?)classification.Platnium);
        }
    }
}
