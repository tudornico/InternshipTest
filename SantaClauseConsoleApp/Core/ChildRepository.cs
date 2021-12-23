using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace SantaClauseConsoleApp
{
    public sealed class ChildRepository
    {
        public  List<Child> Children { get; set; } 

        private static ChildRepository _instace { get; set; } = null;


        private ChildRepository()
        {
            this.Children = new List<Child>();
        }

        public static ChildRepository Instace
        {
            get
            {
                if (_instace == null)
                {
                    _instace = new ChildRepository();
                }

                return _instace;
            }
        }

        public void addChild(Child child)
        {
            _instace.Children.Add(child);
        }

        public List<Child> groupByTown()
        {
            List<Child> resultList = new List<Child>(); 
            resultList = _instace.Children.OrderBy(c => c.Town).ThenBy(c=>c.adress).ToList();
            return resultList;
        }

        public bool FindById(int ID)
        {
            foreach (Child variableChild in _instace.Children)
            {
                if (variableChild.ID == ID)
                    return true;
            }

            return false;
        }

    }

}
