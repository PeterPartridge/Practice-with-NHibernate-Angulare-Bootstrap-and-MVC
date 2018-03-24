﻿using CoreDataLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CoreSVOM
{
    class Program
    {


        static void Main(string[] args)
        {
            CoreBusinessLayer.InitaliseDatabase _intz = new CoreBusinessLayer.InitaliseDatabase();
            CoreBusinessLayer.GenericDBCalls.GetSingleObject GSO = new CoreBusinessLayer.GenericDBCalls.GetSingleObject();

            Console.WriteLine("What would you like to do today?");
            var answer = Console.ReadLine();
            Console.WriteLine("What word shall we searh for?");
            string query = Console.ReadLine();
            Company record = new Company();

            if (answer == "Make DB")
            {
                _intz.CallDBFactory();
                Console.WriteLine("Please press any key to exit ...");
                Console.ReadLine();
            }
            else if (answer == "GC")
            {
                record = GSO.GetSingleRecord<Company>("Name", query);
                Console.WriteLine(record);
            }
            else if (answer == "GCS")
            {
                var recordExtra = GSO.GetSingleRecordAndFetchExtraRecord<Company>("Name", "Imagination", " Employees");
                User CRecord = recordExtra. Employees.Where(x => x.Title == "Mr").FirstOrDefault();
                Console.WriteLine(CRecord.FirstName);
            }
            else if (answer == "GUS")
            {
                var recordExtra = GSO.GetSingleRecordAndFetchExtraRecord<User>("FirstName", "Bob", "Vehicles");
                Vehicle CRecord = recordExtra.Vehicles.Where(x => x.Id == Guid.Parse("B06FCF03-8CBF-4FDE-889F-A82900E52356")).FirstOrDefault();
                Console.WriteLine(CRecord.Model);
            }
            else if (answer == "GV")
            {
                var recordExtra = GSO.GetSingleRecord<Vehicle>("Model", "Big");
                Console.WriteLine(recordExtra.Make);
            }




            Console.ReadLine();
        }
    }
}