using System;
class Car
{
    public Car(string model, double price)
    {
        Model = model;
        RentalPrice = price;
        TotalCars++;
    }
    public static int TotalCars;
    private string model;
    private double rentalPrice;
    

    public string Model
    {
        set { model = value; }
    }

    public double RentalPrice
    {
        set { rentalPrice = value; }
    }

    public void Display()
    {
        Console.WriteLine("Model: " + model);
        Console.WriteLine("Rental Price: " + rentalPrice);
    }
    
}
class Car_Rental
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();

        void ShowCars(List<Car> list)
        {
            if (cars.Count == 0)
            {
                Console.WriteLine("No cars available");
                return;
            }

            foreach (Car c in cars)
            {
                c.Display();
                Console.WriteLine("----");
            }

            Console.WriteLine("Total cars : " + Car.TotalCars);
        }

        void AddCar(List<Car> cars)
        {
            Console.WriteLine("Enter the car model: ");
            string model = Console.ReadLine();

            Console.WriteLine("Enter the car :rental price ");
            double rentalPrice = double.Parse(Console.ReadLine());

            cars.Add(new Car(model, rentalPrice));
            Console.WriteLine("Car added successfully ");
        }
        
        while (true)
        {
            Console.WriteLine("\n===== Car Rental System =====");
            Console.WriteLine("1. Add a new car");
            Console.WriteLine("2. Show all cars");
            Console.WriteLine("3. Exit");

            Console.Write("Choose option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddCar(cars);
                    break;

                case 2:
                    ShowCars(cars);
                    break;

                case 3:
                    Console.WriteLine("Goodbye!");
                    return; 

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
