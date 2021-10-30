using System;
using System.Collections.Generic;
using CsharpProject.Helper;
using CsharpProject.Models;
namespace CsharpProject
{
    class Program
    {
        static void Main(string[] args)
        {
            InputPharmacyName:
            Extensions.Print("Enter Pharmacy name", ConsoleColor.DarkYellow);
            string PharmacyName = Console.ReadLine();
            if (PharmacyName == "" || PharmacyName==null)
            {
                Extensions.Print("Enter Pharmacy name Correctly", ConsoleColor.DarkRed);
                goto InputPharmacyName;
            }
            InputMaxCapacity:
            Extensions.Print("Enter Pharmacy's max drug capacity", ConsoleColor.DarkYellow);
            string PharmacyMaxDrugCapacity = Console.ReadLine();
            bool Capacity = int.TryParse(PharmacyMaxDrugCapacity, out int maxcapacity);
            if (!Capacity)
            {
                 Extensions.Print("Enter max capacity Correctly!", ConsoleColor.DarkRed);
                 goto InputMaxCapacity;
            }
                Pharmacy pharmacy = new Pharmacy(PharmacyName, maxcapacity);
            Extensions.Print($"Welcome to the {PharmacyName} pharmacy", ConsoleColor.DarkRed);
            Extensions.Print($"What do you want to do in the {PharmacyName}",ConsoleColor.Gray);
            while (true)
            {
                Extensions.Print("1 - Add drug to the pharmacy, 2 - Get Info about drug, 3 - Show drugs in Pharmacy, 4 - Sale drug, 5 - Exit", ConsoleColor.Blue);
                string FirstStep = Console.ReadLine();
                bool result = int.TryParse(FirstStep, out int Entry);
                if (result &&(Entry>=1 && Entry<=5))
                {
                    if (Entry==5)
                    {
                        Extensions.Print("See you Soon, Bye...", ConsoleColor.DarkGreen);
                        break;
                    }
                    switch (Entry)
                    {
                        case 1:
                            Extensions.Print("Enter drug's name", ConsoleColor.DarkYellow);
                            string DrugName = Console.ReadLine();
                            if (DrugName == "" || DrugName== null)
                            {
                                Extensions.Print("Enter Drug name Correctly", ConsoleColor.DarkRed);
                                goto case 1;
                            }
                        InputDrugPrice:
                            Extensions.Print("Enter drug's price",ConsoleColor.DarkYellow);
                            string Price = Console.ReadLine();
                            result = int.TryParse(Price, out int DrugPrice);
                            if (!result)
                            {
                                Extensions.Print("Enter Price Correctly!", ConsoleColor.Red);
                                goto InputDrugPrice;
                            }
                            EnterMaxCount:
                            Extensions.Print("Enter drug's count", ConsoleColor.DarkYellow);
                            string Count = Console.ReadLine();
                            result = int.TryParse(Count, out int DrugCount);
                            if (DrugCount>maxcapacity)
                            {
                                Extensions.Print($"There is not space for {Count} piece, max capacity is {maxcapacity}", ConsoleColor.DarkRed);
                                goto EnterMaxCount;
                            }
                            if (!result)
                            {
                                Extensions.Print("Enter Right Count!", ConsoleColor.DarkRed);
                                goto EnterMaxCount;
                            }
                            InputType:
                            Extensions.Print("Enter drug's type, 1-for Liquid,2-for Tablet,3-for Capsules,4-for Painkiller",ConsoleColor.DarkYellow);
                            string Type = Console.ReadLine();
                            result = int.TryParse(Type, out int DrugType);
                            if (result && (DrugType >= 1 && DrugType <= 4))
                            {
                                switch (DrugType)
                                {
                                    case 1:
                                        DrugType drugtype1 = new DrugType(GetTypeDrug.Liquid, maxcapacity);
                                        Drug drug4 = new Drug(DrugName, DrugPrice, DrugCount, GetTypeDrug.Liquid);
                                        if (!drugtype1.AddDrug(drug4, DrugCount))
                                        {
                                            Extensions.Print("There is not Space", ConsoleColor.DarkRed);
                                        }
                                        drugtype1.ShowTypes();
                                        break;
                                    case 2:
                                        DrugType drugType2 = new DrugType(GetTypeDrug.Tablet, maxcapacity);
                                        Drug drug1 = new Drug(DrugName, DrugPrice, DrugCount, GetTypeDrug.Tablet);

                                        if (!drugType2.AddDrug(drug1, DrugCount))
                                        {
                                            Extensions.Print("There is not Space", ConsoleColor.DarkRed);
                                        }
                                        drugType2.ShowTypes();
                                        break;
                                    case 3:
                                        DrugType drugType3 = new DrugType(GetTypeDrug.Capsules, maxcapacity);
                                        Drug drug3 = new Drug(DrugName, DrugPrice, DrugCount, GetTypeDrug.Capsules);
                                        if (!drugType3.AddDrug(drug3, DrugCount))
                                        {
                                            Extensions.Print("There is not Space", ConsoleColor.DarkRed);
                                        }
                                        drugType3.ShowTypes();
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                Extensions.Print("Choose the numbers which is seen", ConsoleColor.DarkRed);
                                goto InputType;
                            }
                            Drug drug = new Drug(DrugName, DrugPrice, DrugCount, GetTypeDrug.Liquid);
                            if (!pharmacy.AddDrug(drug))
                            {
                                Extensions.Print($"There is not Space for {drug} in the {PharmacyName} Pharmacy, max capacity is {maxcapacity}", ConsoleColor.DarkRed);
                                goto InputMaxCapacity;
                            }
                            Extensions.Print("General drug List: ", ConsoleColor.Blue);
                            Extensions.Print($"{drug} - Added to Pharmacy", ConsoleColor.Green);
                            break;
                        case 2:
                            Extensions.Print("Show Info as Name input Name, ad ID Input ID,", ConsoleColor.Yellow);
                            string Decision = Console.ReadLine();
                            if (Decision=="Name")
                            {
                                Extensions.Print("Enter drug's Name", ConsoleColor.DarkYellow);
                                DrugName = Console.ReadLine();
                                pharmacy.InfoDrug(DrugName);
                            }
                            else if (Decision=="ID")
                            {
                                Extensions.Print("Enter drug's ID, Not drug's type ID", ConsoleColor.DarkYellow);
                                string ID = Console.ReadLine();
                                bool DrgID = int.TryParse(ID, out int DrugID);
                                if (DrgID)
                                {
                                    pharmacy.InfoDrugByID(DrugID);
                                }
                            }
                            break;
                        case 3:
                            pharmacy.ShowDrugItems();
                            break;
                            
                        case 4:
                            Extensions.Print("Enter Drug's Name That You want to Buy", ConsoleColor.DarkYellow);
                            string SaleDrugName = Console.ReadLine();
                            if (SaleDrugName == null || SaleDrugName== "")
                            {
                                Extensions.Print("Enter drug name correctly", ConsoleColor.DarkRed);
                                goto case 4;
                            }
                            InputDrugCount:
                            Extensions.Print("Enter Drug's Count That You want to Buy", ConsoleColor.DarkYellow);
                            string count = Console.ReadLine();
                            result = int.TryParse(count, out int SaleDrugCount);
                            if (!result)
                            {
                                Extensions.Print("Enter Drug's Count Correctly", ConsoleColor.DarkRed);
                                goto InputDrugCount;
                            }
                            InputDrugPrice1:
                            Extensions.Print("Enter Drug's Price That You want to Pay", ConsoleColor.DarkYellow);
                            string price = Console.ReadLine();
                            result = int.TryParse(price, out int SalePrice);
                            if (!result)
                            {
                                Extensions.Print("Enter Drug's Price Correctly", ConsoleColor.DarkRed);
                                goto InputDrugPrice1;
                            }
                            if (!pharmacy.SaleDrug(SaleDrugName, SaleDrugCount,SalePrice))
                            {
                                Extensions.Print("Do you want to continue to buy / yes or No ", ConsoleColor.DarkYellow);
                                Decision = Console.ReadLine();
                                if (Decision == "Yes")
                                {
                                    goto case 4;
                                }
                                else
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Extensions.Print("Choose the numbers which is seen", ConsoleColor.DarkRed);
                }
            }
        }
    }
}
