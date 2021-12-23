using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SantaClauseConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {


            //Question1(); // works
            //Question2(); // works
            //Question3(); //works
            //Question4(); //works
            //Question5(); //works
            //Question6(); //works
            UI myUI = new UI();
            myUI.Innit();
        }

        static void Question1()
        {
            //creating the children
            DateTime date1 = new DateTime(2001, 11, 06);

            Child child1 = new Child("Tudor", date1, BehaviorEnum.Good, "Crisan 16", "Baia Mare");

        

        DateTime date2 = new DateTime(2001, 8, 05);
            Child child2 = new Child("Calin Pop", date2, BehaviorEnum.Bad, "Decembrie 21","Cluj Napoca");

            DateTime date3 = new DateTime(1997, 03, 30);
            Child child3 = new Child("Andrei Nicolaescu", date3, BehaviorEnum.Good, "Qualle","Vienna");

            //setting up presents
            Item present1 = new Item("Car");
            Item present2 = new Item("Sword");
            Item present3 = new Item("Doll");
            List<Item> presents1 = new List<Item>();
            presents1.Add(present1);
            presents1.Add(present2);
            //first Letter
            Letter letter1 = new Letter(child1, DateTime.Now, presents1);
            child1.Writer();
            letter1.Writer();
            Console.WriteLine();
            Console.WriteLine();
            //setting up presents
            List<Item> presents2 = new List<Item>();
            presents2.Add(present2);
            presents2.Add(present3);
            //second letter 
            Letter letter2 = new Letter(child2, DateTime.Now, presents2);
            child2.Writer();
            letter2.Writer();
            Console.WriteLine();
            Console.WriteLine();

            //setting up presents
            List<Item> presents3 = new List<Item>();
            presents3.Add(present1);
            presents3.Add(present2);
            //third letter
            Letter letter3 = new Letter(child3, DateTime.Now, presents3);
            child3.Writer();
            letter3.Writer();
        }

        static void Question2()
        { 
            DateTime date1 = new DateTime(2010, 12, 11);
            Child child1 = new Child("Tudorel Pop", date1, BehaviorEnum.Good, "Scantei 25","Baia Mare");

            DateTime date2 = new DateTime(2013, 8, 05);
            Child child2 = new Child("Dorel Paul", date2, BehaviorEnum.Bad, "Mihai Eminescu 25","Baia Mare");

            DateTime date3 = new DateTime(1997, 03, 30);
            Child child3 = new Child("Andrei Nicolaescu", date3, BehaviorEnum.Good, "Qualle","Vienna");

            //setting up presents
            Item present1 = new Item("Car");
            Item present2 = new Item("Sword");
            Item present3 = new Item("Doll");
            List<Item> presents1 = new List<Item>();
            presents1.Add(present1);
            presents1.Add(present2);
            //first Letter
            DateTime letterDate1 = new DateTime(2021, 12, 23);
            Letter letter1 = new Letter(child1, letterDate1, presents1);
            child1.Writer();
            letter1.createFileLetter("Letter1.txt");
            Console.WriteLine();
            Console.WriteLine();
            //setting up presents
            List<Item> presents2 = new List<Item>();
            presents2.Add(present2);
            presents2.Add(present3);
            //second letter 
            DateTime dateLetter2 = new DateTime(2021, 12, 24);
            Letter letter2 = new Letter(child2, dateLetter2, presents2);
            child2.Writer();
            letter2.createFileLetter("Letter2.txt");
            Console.WriteLine();
            Console.WriteLine();

            //setting up presents
            List<Item> presents3 = new List<Item>();
            
            presents3.Add(present1);
            presents3.Add(present2);
            //third letter
            DateTime dateLetter3 = new DateTime(2021, 12, 21);
            Letter letter3 = new Letter(child3, dateLetter3, presents3);
            child3.Writer();
            letter3.createFileLetter("Letter3.txt");
        }

        static void Question3()
        {
            
            //creating the children
            DateTime date1 = new DateTime(2001, 11, 06);
            Child child1 = new Child("Tudor", date1, BehaviorEnum.Good, "Crisan 16","Baia Mare");

            DateTime date2 = new DateTime(2001, 8, 05);
            Child child2 = new Child("Calin Pop", date2, BehaviorEnum.Bad, "Decembrie 21","Cluj Napoca");

            DateTime date3 = new DateTime(1997, 03, 30);
            Child child3 = new Child("Andrei Nicolaescu", date3, BehaviorEnum.Good, "Qualle","Vienna");

            //setting up presents
            Item present1 = new Item("Car");
            Item present2 = new Item("Sword");
            Item present3 = new Item("Doll");
            List<Item> presents1 = new List<Item>();
            presents1.Add(present1);
            presents1.Add(present2);
            //first Letter
            Letter letter1 = new Letter(child1, DateTime.Now, presents1);
            child1.Writer();
            letter1.createFileLetter("Letter1.txt");
            Console.WriteLine();
            Console.WriteLine();
            //setting up presents
            List<Item> presents2 = new List<Item>();
            presents2.Add(present2);
            presents2.Add(present3);
            //second letter 
            Letter letter2 = new Letter(child2, DateTime.Now, presents2);
            child2.Writer();
            letter2.createFileLetter("Letter2.txt");
            Console.WriteLine();
            Console.WriteLine();

            //setting up presents
            List<Item> presents3 = new List<Item>();
            presents3.Add(present1);
            presents3.Add(present2); //different from 2 we want to show the difference in amount so that the sorting works
            //third letter
            Letter letter3 = new Letter(child3, DateTime.Now, presents3);
            child3.Writer();
            letter3.createFileLetter("Letter3.txt");
        }

        static void Question4()
        {
            Report report= Report.Instance; 
            report.writer();
            
        }

        static void Question5()
        {
            //Singelton design pattern can be implemented in the report class (view implementation of report)
            // the core idea is that we don t want multiple reports and with this we can be sure that the information
            //stocked in report is global and can be used from anywhere
            
            //Sigelton can also be used for Question 6 as we want all children ever created to be added to the repository
            //so we make a singleton design pattern for the repository and we call the instance in the child constructor
        }

        static void Question6()
        {
            DateTime date1 = new DateTime(2001, 11, 06);
            Child child1 = new Child("Tudor", date1, BehaviorEnum.Good, "Crisan 16","Baia Mare");

            DateTime date2 = new DateTime(2001, 8, 05);
            Child child2 = new Child("Calin Pop", date2, BehaviorEnum.Bad, "Decembrie 21","Cluj Napoca");

            DateTime date3 = new DateTime(1997, 03, 30);
            Child child3 = new Child("Andrei Nicolaescu", date3, BehaviorEnum.Good, "Qualle","Baia Mare");
            
            ChildRepository repoInstance = ChildRepository.Instace;
            List<Child> childList =   repoInstance.groupByTown();
            
            

            foreach (Child child in childList)
            {
                child.Writer();
            }
            
            
        }
    }
}
