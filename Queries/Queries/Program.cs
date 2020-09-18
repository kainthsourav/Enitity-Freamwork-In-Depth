using System.Linq;
namespace Queries
{
    class Program
    {   
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            //Linq syntax
            System.Console.WriteLine("LINQ Syntax");
            var query = from c in context.Courses
                        where (c.Name.Contains("C#"))
                        orderby (c.Name)
                        select (c);
            foreach (var item in query)
            {
                System.Console.WriteLine(item.Name);
            }
            System.Console.ReadLine();

            System.Console.WriteLine("Extention Method");
            //Extention method
            var CourseData = context.Courses.Where(c => c.Name.Contains("C#")).OrderBy(c => c.Name);
            foreach (var item in CourseData)
            {
                System.Console.WriteLine(item.Name);
            }
            System.Console.ReadLine();

            //Restrication
            var queryRes = from c in context.Courses
                           where (c.Level == 1 && c.AuthorId==1)
                           select (c);
            //Ordering
            var queryOrder = from c in context.Courses
                             where c.Level == 1
                             orderby c.Level, c.Name descending
                             select c;

            //groupby
            var queryGroup = from c in context.Courses
                             group c by c.Level
                           into g
                             select g;
            foreach (var item in queryGroup)
            {
                System.Console.WriteLine(item.Key);
                foreach (var i in item)
                {
                    System.Console.WriteLine("\t{0}", i.Name);
                }
            }

            //joins
            var queryJoin = from c in context.Courses
                            join a in context.Authors on c.AuthorId equals a.Id
                            select new { CourseName = c.Name, AuthorName = a.Name };

            foreach (var item in queryJoin)
            {
                System.Console.WriteLine(item.AuthorName);
                System.Console.WriteLine(item.CourseName);
            }

            //Group Join -left join
            var queryGroupJoin=from a in context.Authors
                               join c in context.Courses on a.Id equals c.AuthorId into g
                               select new {AuhtorName=a.Name,CourseCout=g.Count()};
                                
                        foreach (var item in queryGroupJoin)
            {
                System.Console.WriteLine("{0} ({1})", item.AuhtorName, item.CourseCout);
            }

            //Cross Join
            var queryCrossJoin = from a in context.Authors
                                 from c in context.Courses
                                 select new { AuthorName = a.Name, CourseName = c.Name };
            foreach (var item in queryCrossJoin)
            {
                System.Console.WriteLine("{0} - {1}", item.AuthorName, item.CourseName); 
            }



            System.Console.ReadLine();
        }
    }
}
