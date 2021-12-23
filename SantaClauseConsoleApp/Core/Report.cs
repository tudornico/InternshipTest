using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SantaClauseConsoleApp
{   //todo argument better the singelton use
    //We can implement a Singelton pattern in this class because the reporting of the toys requires only an intance that will be updated
    // from the files of each Child created as Letter + increment
    public sealed class Report
    {
        public List<ToyReport> reports { get; set; } = new List<ToyReport>();

        private static Report _instance { get; set; }= null;

       
        //setting up the reports from the files we already have
        private Report()
        {   
            int counter = 1;
            String line="";
            while (counter!=0)
            {
                String Filename = "Letter" + counter+".txt";
                FileInfo fileInfo = new FileInfo(Filename);
                if (fileInfo.Exists)
                {
                    StreamReader reader = new StreamReader(Filename);
                    line = "";
                 
                    int flag = 0; // flag to know when the presents start
                    while (!string.IsNullOrEmpty(line = reader.ReadLine())) 
                    {
                        if (line.Contains(':'))
                        {
                            flag = 1;
                        }

                        if (flag == 1)
                        {
                            line = reader.ReadLine();
                            List<String> presents = new List<string>(line.Split(','));
                            foreach (String present in presents)
                            {  
                               String newpresent = present.Replace(" ", "");
                               if(!String.IsNullOrEmpty(newpresent))
                                this.addToy(new Item(newpresent));
                            }
                        }
                        
                    }
                    reader.Close();

                }
                else
                {
                    break;
                }

                counter++;
            }
        }

        public static Report Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Report();
                }

                return _instance;
            }
        }
        private bool addToy(Item toy)
        {
            foreach (ToyReport toyreport in this.reports)
            {
                if (toyreport.toy.name.Equals(toy.name))
                {
                    toyreport.increment();
                    this.reports =this.reports.OrderByDescending(o=>o.counter).ToList();
                    return true;
                }
            }

            ToyReport newReport = new ToyReport(toy);
            this.reports.Add(newReport);
            this.reports= this.reports.OrderByDescending(o=>o.counter).ToList();
            return true;
        }

        public void writer()
        {
            foreach (ToyReport toyReport in _instance.reports)
            {
                Console.WriteLine("Toy is : "+toyReport.toy.name + " Amount is : " + toyReport.counter);
                
            }
        }

       
        
    }
}