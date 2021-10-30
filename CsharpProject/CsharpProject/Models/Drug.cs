using System;
namespace CsharpProject.Models
{
    public class Drug
    {
        public string Name { get; }
        public int Price { get; }
        public int Count { get; set; }
        //public DrugType type;
        public GetTypeDrug TypeName { get; }
        static private int _id;
        public int ID { get; }
        public Drug(string name, int price, int count,GetTypeDrug type)
        {
            TypeName = type;
            Name = name;
            _id++;
            ID = _id;
            Price = price;
            Count = count;
        }
        public override string ToString()
        {
            return $"{ID} - Drugname: {Name} - Drugprice: {Price} - Drugcount: {Count} piece medicines";
        }
    }
}
