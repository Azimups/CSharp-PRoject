using System;
using System.Collections.Generic;
using CsharpProject.Helper;

namespace CsharpProject.Models
{
    partial class Pharmacy
    {
        public string Name { get; }
        private static int _counter;
        public int ID { get; }
        public int MaxDrugBase { get; }
        private List<Drug> _drugs;
        public Pharmacy(string name, int MaxDrugbase)
        {
            Name = name;
            _counter++;
            ID = _counter;
            _drugs = new List<Drug>();
        }
    }
    
}
