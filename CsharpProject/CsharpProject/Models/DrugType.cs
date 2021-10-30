using System;
using System.Collections.Generic;
using CsharpProject.Helper;

namespace CsharpProject.Models
{
     class DrugType
    {
        private List<Drug> _Type;
        public int Max;
        public int Count;
        public GetTypeDrug TypeName { get; }
        public int ID { get; }
        public DrugType(GetTypeDrug type, int max)
        {
            Max = max;
            TypeName = type;
        }
        public bool AddDrug(Drug name, int count)
        {
            _Type = new List<Drug>();
            Count = count;
            if (_Type.Count == Max)
            {
                return false;
            }
            Extensions.Print("Type added: ", ConsoleColor.Green);
            _Type.Add(name);
            return true;
        }
        public Drug ShowTypes()
        {
            //var type1 = _Type.FindAll(predicate);
            if (_Type.Count == 0)
            {
                Extensions.Print("There is not this type of drug", ConsoleColor.DarkRed);
            }
            else
            {
                Extensions.Print("Liquid Drug list: ", ConsoleColor.Blue);
                foreach (var item in _Type)
                {
                    if (item.TypeName == GetTypeDrug.Liquid)
                    {
                        Extensions.Print(item.ToString(), ConsoleColor.DarkYellow);
                    }
                }
                Extensions.Print("Tablet Drug list: ", ConsoleColor.Blue);
                foreach (var item in _Type)
                {
                    if (item.TypeName == GetTypeDrug.Tablet)
                    {
                        Extensions.Print(item.ToString(), ConsoleColor.DarkYellow);
                    }
                }
                Extensions.Print("Capsule Drug list: ", ConsoleColor.Blue);
                foreach (var item in _Type)
                {
                    if (item.TypeName == GetTypeDrug.Capsules)
                    {
                        Extensions.Print(item.ToString(), ConsoleColor.DarkYellow);
                    }
                }
            }
            return null;
        }
        public override string ToString()
        {
            return TypeName.ToString();
        }

    }
    public enum GetTypeDrug
    {
        Liquid,
        Tablet,
        Capsules
    }
}
