using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SantaClauseConsoleApp
{
    public class UI
    {
        public void Innit()
        {  
            
            ChildRepository repo = ChildRepository.Instace;
            LetterRepository letterRepository = LetterRepository.Instace;
            Report report = Report.Instance;
            if(repo.Children.Count == 0)
            {
                this.SetUpInnit();
            }
            Console.WriteLine("Please select from one of these options");
            Console.WriteLine("1 : See All Children");
            Console.WriteLine("2 : See All Children grouped by town");
            Console.WriteLine("3 : create a new Child");
            Console.WriteLine("4 : get the Letter From A Child");
            Console.WriteLine("5 : get the full report");
            Console.WriteLine("0 : Exit and Happy Holidays");
            Console.WriteLine("Your choice is : ");
            String choice = Console.ReadLine();
            
                switch (choice)
                {
                    case "1":
                        this.SeeAllChildren(repo.Children);
                        break;

                    case "2":
                        
                        this.SeeAllChildren(repo.groupByTown());
                        break;

                    case "3":
                        this.setUpChild();
                        break;

                    case "4" :
                        foreach (Child child in repo.Children)
                        {
                            child.Writer();   
                        }
                        Console.WriteLine("Pick the Id of the child you want the letter from : ");
                        int currentId = int.Parse(Console.ReadLine());
                        letterRepository.printLetterByChildID(currentId);
                        break;
                    
                    case "5":
                        report.writer();
                        break;
                    default:
                        Console.WriteLine("Thanks for A Good Christmas Santa");
                        break;
                }
            if(!(choice.Equals("0") || choice.Equals(null)))
            this.Innit();
        }

        private void setUpChild()
        {
            String Name, Town, Address;
            DateTime birthdate;
            BehaviorEnum isGood;
            Console.WriteLine("The Name is : ");
            Name = Console.ReadLine();
            Console.WriteLine("The Town is : ");
            Town = Console.ReadLine();
            Console.WriteLine("The Address is : ");
            Address = Console.ReadLine();
            
                    
            Console.WriteLine("BirthDate is (YYYY-MM-DD) : ");
            birthdate = Convert.ToDateTime(Console.ReadLine());
                    
            Console.WriteLine("Behaviour this Year was (Good or Bad) : ");
            isGood = (BehaviorEnum) Enum.Parse(typeof(BehaviorEnum), Console.ReadLine());
            try
            {
                this.NewChild(Name, Town, Address, birthdate, isGood);
            }
            catch(InvalidDataException e)
            {
                Console.WriteLine(e.Message);
                this.setUpChild();
            }
        }
        private void NewChild(String name,String town,String andress,DateTime birthDate,BehaviorEnum isGood)
        {
            Child child = new Child(name, birthDate, isGood, andress, town);
        }

        private void SeeAllChildren(List<Child> childList)
        {
            foreach (Child child in childList)
            {
                child.Writer();
            }
           
        }

        private void SortedChildren()
        {
            ChildRepository repo = ChildRepository.Instace;
            SeeAllChildren(repo.Children);
        }

        private void SetUpInnit()
        {
            DateTime date1 = new DateTime(2010, 12, 11);
            Child child1 = new Child("Tudorel Pop", date1, BehaviorEnum.Good, "Scantei 25","Baia Mare");

            DateTime date2 = new DateTime(2013, 8, 05);
            Child child2 = new Child("Dorel Paul", date2, BehaviorEnum.Bad, "Mihai Eminescu 25","Baia Mare");

            DateTime date3 = new DateTime(1997, 03, 30);
            Child child3 = new Child("Andrei Nicolaescu", date3, BehaviorEnum.Good, "Qualle","Vienna");
            Item present1 = new Item("Car");
            Item present2 = new Item("Sword");
            Item present3 = new Item("Doll");
            List<Item> presents1 = new List<Item>();
            presents1.Add(present1);
            presents1.Add(present2);
            //first Letter
            DateTime letterDate1 = new DateTime(2021, 12, 23);
            Letter letter1 = new Letter(child1, letterDate1, presents1);
            letter1.createFileLetter("Letter1.txt");
            
            //setting up presents
            List<Item> presents2 = new List<Item>();
            presents2.Add(present2);
            presents2.Add(present3);
            //second letter 
            DateTime dateLetter2 = new DateTime(2021, 12, 24);
            Letter letter2 = new Letter(child2, dateLetter2, presents2);
            letter2.createFileLetter("Letter2.txt");

            //setting up presents
            List<Item> presents3 = new List<Item>();
            
            presents3.Add(present1);
            presents3.Add(present2);
            //third letter
            DateTime dateLetter3 = new DateTime(2021, 12, 21);
            Letter letter3 = new Letter(child3, dateLetter3, presents3);
            letter3.createFileLetter("Letter3.txt");
        }
        
        
        
        
    }
}
