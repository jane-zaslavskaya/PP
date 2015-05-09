using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP.BL.Implementation;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var cist = new CistBl();
            var json = cist.GetTimetableForGroup("4307140", DateTime.Now, DateTime.Now.AddDays(7));

            Console.WriteLine(json);
        }
    }
}