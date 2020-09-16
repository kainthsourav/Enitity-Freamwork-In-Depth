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
            var Data= DiffContext.GetData();
            foreach (var item in Data)
            {
                Console.WriteLine(item.move_name);
                Console.WriteLine(item.movie_category);
            }
           
        }
    }
}
