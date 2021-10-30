using System;
using CsharpProject.Helper;

namespace CsharpProject.Models
{
    partial class Pharmacy
    {
        public bool AddDrug(Drug name)
        {
            if (_drugs.Count>MaxDrugBase)
            {
                return false;
            } 
            _drugs.Add(name);
            return true;
        }
        public bool InfoDrug(string name)
        {
            if (_drugs.Count == 0)
            {
                Extensions.Print($"There is not any drug in {Name} pharmacy", ConsoleColor.DarkRed);
                return false;
            }
            var drugs = _drugs.FindAll(x => x.Name.ToLower().Contains(name.ToLower()));
            if (_drugs.Count == 0)
            {
                Extensions.Print("Is not Found Any drug", ConsoleColor.DarkRed);
                return false;
            }
            Extensions.Print($"Information about {name} drug", ConsoleColor.DarkYellow);
            foreach (var item in drugs)
            {
                Extensions.Print(item.Name +" " + "Found", ConsoleColor.DarkGreen);
                Extensions.Print("Drug's Name: " + item.Name + " " + "Drug's Count: " + item.Count + " " + "Drug's Price: " + item.Price, ConsoleColor.Green);
            }
            return true;
        }
        public bool InfoDrugByID(int id)
        {
            if (_drugs.Count == 0)
            {
                Extensions.Print($"There is not any drug in {Name} pharmacy", ConsoleColor.DarkRed);
                return false;
            }
            var drugs1 = _drugs.FindAll(type => type.ID == id);
            if (_drugs.Count == 0)
            {
                Extensions.Print("Is not Found Any drug", ConsoleColor.DarkRed);
                return false;
            }
            foreach (var item in drugs1)
            {
                Extensions.Print(item.ID + " 's Medicine Found",ConsoleColor.DarkGreen);
                Extensions.Print("Drug's Name: " + item.Name + " " + "Drug's Count: " + item.Count + " " + "Drug's Price: " + item.Price, ConsoleColor.Green);
            }
            return true;
        }
        public bool ShowDrugItems()
        {
            if (_drugs.Count==0)
            {
                Extensions.Print($"There is not any drug in {Name} pharmacy", ConsoleColor.DarkRed);
                return false;
            }
            foreach (var item in _drugs)
            {
                Extensions.Print(item.ToString(), ConsoleColor.Yellow);
            }
            return true;
        }
        public bool SaleDrug(string name, int count, int price)
        {
            if (_drugs.Count == 0)
            {
                Extensions.Print($"There is not any drug in {Name} pharmacy", ConsoleColor.DarkRed);
                return false;
            }
            var drugs3 = _drugs.Find(item=>item.Name.ToLower().Contains(name.ToLower()));
            if (drugs3.Count >= count && drugs3.Price * count <= price)
            {
                Extensions.Print($"{drugs3.Name} - saled Succesfully", ConsoleColor.Green);
                drugs3.Count -= count;
                return true;
            }
            if (drugs3.Count==0)
            {
                Extensions.Print($"There is not this type of drug in {Name} pharmacy", ConsoleColor.DarkRed);
                return false;
            }
            Extensions.Print($"Cant sale the {drugs3.Name} drug because its Price is {drugs3.Price*count} for {count} piece, Count is {drugs3.Count} " ,ConsoleColor.DarkYellow);
            return false;
        }
        public override string ToString()
        {
            return $"{ID} - {Name}";
        }
        
    }
}
