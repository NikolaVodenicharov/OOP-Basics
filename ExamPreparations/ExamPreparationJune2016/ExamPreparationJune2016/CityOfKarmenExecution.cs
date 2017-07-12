namespace ExamPreparationJune2016
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ExamPreparationJune2016.PeopleInKarmen;

    public class CityOfKarmenExecution
    {
        public static void Main()
        {
            var households = new List<Household>();
            
            // with each 3rd input is day to pay salaries and pensions
            int inputCounter = 0;
 
            while (true)
            {
                var input = Console.ReadLine();
                inputCounter++;

                // is day to pay slaries and pensions
                bool isPayday = (inputCounter % 3 == 0);
                PayMoney(households, isPayday);

                if (input.Equals("EVN", StringComparison.OrdinalIgnoreCase))
                {
                    PrintTotalConsumption(households);
                }
                else if (input.Equals("EVN bill", StringComparison.OrdinalIgnoreCase))
                {
                    PayBillsOrEmigrate(households);
                }
                else if (input.Equals("Democracy", StringComparison.OrdinalIgnoreCase))
                {
                    PrintTotalPopulation(households);
                    break;
                }
                else
                {
                    try
                    {
                        AddHousehold(households, input);
                        PayMoneyToLastAdded(households, isPayday);
                    }
                    catch (Exception)
                    {
                        // put exception ?
                    }
                }
            }
        }

        private static void PrintTotalPopulation(List<Household> households)
        {
            int popuation = households.Sum(x => x.MemberCounter());
            Console.WriteLine("Total population: {0}", popuation);
        }

        private static void PayBillsOrEmigrate(List<Household> households)
        {
            for (int i = 0; i < households.Count; i++)
            {
                if (households[i].CanPayBills())
                {
                    households[i].PayBills();
                }
                else
                {
                    households.RemoveAt(i);
                    i--;
                }
            }
        }

        private static void PayMoneyToLastAdded(List<Household> households, bool isPayday)
        {
            if (isPayday)
            {
                households.Last().AddMoney();
            }
        }

        private static void PayMoney(List<Household> households, bool isPayday)
        {
            if (isPayday)
            {
                foreach (var household in households)
                {
                    household.AddMoney();
                }
            }
        }

        private static void PrintTotalConsumption(List<Household> households)
        {
            Console.WriteLine("Total consumption: {0}",
                              households.Sum(x => x.CalculateConsumption()));
        }

        private static void AddHousehold(List<Household> households, string input)
        {
            var info = input.Split(new char[] { ',', '(', ')', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            bool isCouple = info.Length > 4;
            var type = info[0];
            double income = AddIncome(info, isCouple);
            double television = AddTelevision(info, isCouple);
            double fridge = AddFridge(info, isCouple);
            double laptopOrStove = AddLaptopOrStove(info, isCouple);

            if (type.Equals("AloneOld", StringComparison.OrdinalIgnoreCase))
            {
                households.Add(new OldSingle(income));
            }
            else if (type.Equals("AloneYoung", StringComparison.OrdinalIgnoreCase))
            {
                households.Add(new YoungSingle
                              (income,
                              double.Parse(info[3])));
            }
            else if (type.Equals("OldCouple", StringComparison.OrdinalIgnoreCase))
            {
                households.Add(new OldCouple(
                               income,
                               fridge,
                               television,
                               laptopOrStove));
            }
            else if (type.Equals("YoungCouple", StringComparison.OrdinalIgnoreCase))
            {
                households.Add(new YoungCoupleWithoutChildren
                              (income,
                               fridge,
                               television,
                               laptopOrStove));
            }
            else if (type.Equals("YoungCoupleWithChildren", StringComparison.OrdinalIgnoreCase))
            {
                List<Child> children = MakeChildList(info);

                households.Add(new YoungCoupleWithChilden(
                               income,
                               fridge,
                               television,
                               laptopOrStove,
                               children));
            }
        }

        private static double AddLaptopOrStove(string[] info, bool isCouple)
        {
            double laptopOrStove = 0;

            if (isCouple)
            {
                laptopOrStove += double.Parse(info[8]);
            }

            return laptopOrStove;
        }

        private static double AddFridge(string[] info, bool isCouple)
        {
            double fridge = 0;

            if (isCouple)
            {
                fridge += double.Parse(info[6]);
            }

            return fridge;
        }

        private static double AddTelevision(string[] info, bool isCouple)
        {
            double television = 0;

            if (isCouple)
            {
                television += double.Parse(info[4]);
            }

            return television;
        }

        private static double AddIncome(string[] info, bool isCouple)
        {
            double income = double.Parse(info[1]);

            if (isCouple)
            {
                income += double.Parse(info[2]);
            }

            return income;
        }

        // YoungCouple 22 25 TV 1.5 Fridge 1.2 Laptop 1     Child(10, 5, 6, 7, 8) Child(10, 5, 5) Child(10, 5)
        // 0            1  2  3  4    5     6     7   8       9   10  11 12 13 14  15   16  17 18  19   20  21

        private static List<Child> MakeChildList(string[] info)
        {
            var children = new List<Child>();

            var index = 9;

            bool indexInRange = true;
            while (indexInRange)
            {
                List<double> childCosts = AddChildCosts(info, index);

                double food = childCosts[0];
                List<double> toys = AddToys(childCosts);

                children.Add(new Child
                            (food,
                             toys));

                index += childCosts.Count + 1;
                indexInRange = index < info.Length;
            }

            return children;
        }

        private static List<double> AddChildCosts(string[] info, int index)
        {
            var childCosts = new List<double>();
            var i = index;

            while (true)
            {
                i++;

                bool indexOutOfRange = (i >= info.Length);
                if (indexOutOfRange)
                {
                    break;
                }

                bool isChild = info[i].Equals("Child", StringComparison.OrdinalIgnoreCase);
                if (isChild)
                {
                    break;
                }

                childCosts.Add(double.Parse(info[i]));
            }

            return childCosts;
        }

        private static List<double> AddToys(List<double> numbers)
        {
            var toys = new List<double>();
            for (int i = 1; i < numbers.Count; i++)
            {
                toys.Add(numbers[i]);
            }

            return toys;
        }
    }
}
