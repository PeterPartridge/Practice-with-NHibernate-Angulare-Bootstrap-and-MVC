using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVOM
{
    class Program
    {
       

        static void Main(string[] args)
        {
            BusinessLayer.InitaliseDatabase _intz = new BusinessLayer.InitaliseDatabase();

         _intz.CallDBFactory();




            Console.WriteLine("Please press any key to exit ...");
            Console.ReadLine();
        }
    }
}
