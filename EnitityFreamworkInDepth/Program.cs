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
            context.SaveChanges();
        }
    }
}
