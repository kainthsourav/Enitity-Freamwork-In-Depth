using System.Linq;
namespace Queries
{
    class Program
    {   
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            //Linq syntax
            var query = from c in context.Courses
                        where c.Name.Contains("C#")
                        orderby c.Name
                        select c;
            //foreach (var item in query)
            //{
            //    System.Console.WriteLine(item.Name);
            //}

            //Extention menthod
            var courses = context.Courses.Where(c => c.Name.Contains("C#")).OrderBy(c => c.Name);
            foreach (var item in courses)
            {
                System.Console.WriteLine(item.Name);
            }
            {

            }

        }
    }
}
