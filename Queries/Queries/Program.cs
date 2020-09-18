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


            //Extention method
            var CourseData = context.Courses.Where(c => c.Name.Contains("C#")).OrderBy(c => c.Name);
            foreach (var item in CourseData)
            {
                System.Console.WriteLine(item.Name);
            }
            System.Console.ReadLine();

            //restiction
            var res = context.Courses
                .Where(c => c.Level == 1)
                .OrderBy(c=>c.Name)
                .ThenByDescending(c=>c.Level);
            // Projection
            var proj = context.Courses
                .Where(c => c.Level == 1)
                .OrderBy(c => c.Name)
                .ThenByDescending(c => c.Level)
                .SelectMany(c => c.Tags)
                .Distinct();

            foreach (var item in proj)
            {
                System.Console.WriteLine(item.Name);
            }

            //groupinh

            var grop = context.Courses
                .GroupBy(c => c.Level);
            foreach (var item in grop)
            {
                System.Console.WriteLine("Key : "+item.Key);
                foreach ( var i in item)
                {
                    System.Console.WriteLine("\t",i.Name);
                }
                
            }
            //join
            context.Courses.Join(context.Authors,
                c => c.AuthorId, 
                a => a.Id, 
                (course, author) =>
                   new
                   {
                       CourseName = course.Name,
                       AuthorName = author.Name
                   });

            context.Authors.GroupJoin(context.Courses, a => a.Id, c => c.AuthorId, (author, cours) =>
                   new
                   {
                       AuthorName=author.Name,
                       CourseName= cours
                   });
            System.Console.ReadLine();
        }
    }
}
