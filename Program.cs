using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Need_for_Speed3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> carDetails = new Dictionary<string, List<int>>();
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split("|").ToArray();
                carDetails.Add(data[0], new List<int>());
                carDetails[data[0]].Add(int.Parse(data[1])); //mileage
                carDetails[data[0]].Add(int.Parse(data[2])); //fuel
            }
            string[] input = Console.ReadLine().Split(" : ").ToArray();

            while (input[0]!= "Stop")
            {
                string command = input[0];
                int distance = 0;
                int fuel = 0;
                int mil = 0;
                string car = "";
                switch (command)
                {
                    case "Drive":
                        car = input[1];
                        distance = int.Parse(input[2]);
                        fuel = int.Parse(input[3]);
                        int currFuel = carDetails[car][1];
                        int currMil = carDetails[car][0];
                        if (fuel>currFuel)
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }
                        else
                        {
                            carDetails[car][0] = (currMil + distance);
                            carDetails[car][1] = (currFuel - fuel);
                            Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                            if (carDetails[car][0] >= 100000)
                            {
                                carDetails.Remove(car);
                                Console.WriteLine($"Time to sell the {car}!");
                            }
                        }
                        break;
                    case "Refuel":
                        car = input[1];
                        fuel = int.Parse(input[2]);
                        int currFuelincar = carDetails[car][1];
                        
                        if ((currFuelincar + fuel) < 75)
                        {
                            carDetails[car][1] = (currFuelincar + fuel);
                            Console.WriteLine($"{car} refueled with {fuel} liters");
                        }
                        else
                        {
                            carDetails[car][1] = 75;
                            Console.WriteLine($"{car} refueled with {75-currFuelincar} liters");
                        }
                        break;
                    case "Revert":
                        car = input[1];
                        mil = int.Parse(input[2]);
                        int currMill = carDetails[car][0];
                        if ((currMill - mil) > 10000)
                        {
                            Console.WriteLine($"{car} mileage decreased by {mil} kilometers");
                            carDetails[car][0] = (currMill - mil);
                        }
                        else
                        {
                            
                            carDetails[car][0] = 10000;
                        }
                        break;

                    default:
                        break;
                }
                input = Console.ReadLine().Split(" : ").ToArray();
            }

            foreach (var item in carDetails.OrderByDescending(x=>x.Value[0]).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key} -> Mileage: {item.Value[0]} kms, Fuel in the tank: {item.Value[1]} lt.");
            }
        }
    }
}


//•	Revert : {car} : {kilometers}
//o Decrease the mileage of the given car with the given kilometers and print the kilometers you have decreased it with in the following format:
//"{car} mileage decreased by {amount reverted} kilometers"
//o If the mileage becomes less than 10 000km after it is decreased, just set it to 10 000km and
//DO NOT print anything.
