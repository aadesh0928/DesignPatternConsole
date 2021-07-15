using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public enum CarBodyType
    {
        MiniHatchback,
        Hatchback,
        SUV,
        Sedan,
        MiniSedan
    }
    public class Car
    {
        public CarBodyType  CarType { get; set; }
        public string  Color { get; set; }
        public int NoOfDoors { get; set; }

        public string  Address { get; set; }
        public string  City { get; set; }

        public override string ToString()
        {
            return $"{nameof(CarType)} :" +
                $" { CarType}, {nameof(Color)} : " +
                $"{Color}, {nameof(NoOfDoors)}: " +
                $"{NoOfDoors}, {nameof(Address)}: {Address}";
        }
    }


    public class CarBuilder
    {
        public Car Car { get; set; }

        public CarBuilder()
        {
            Car = new Car();
        }

        public Car Build() => Car;

        public CarInfoBuilder Info => new CarInfoBuilder(Car);

        public CarAddressBuilder Built => new CarAddressBuilder(Car);

    }


    public class CarInfoBuilder: CarBuilder
    {
        public CarInfoBuilder(Car car)
        {
            Car = car;
        }

        public CarInfoBuilder WithType(CarBodyType type)
        {
            Car.CarType = type;
            return this;
        }

        public CarInfoBuilder WithColor(string color)
        {
            Car.Color = color;
            return this;
        }

        public CarInfoBuilder WithNoOfDoors(int numDoors)
        {
            Car.NoOfDoors = numDoors;
            return this;
        }
    }


    public class CarAddressBuilder: CarBuilder
    {
        public CarAddressBuilder(Car car)
        {
            Car = car;
        }

        public CarAddressBuilder InCity(string city)
        {
            Car.City = city;
            return this;
        }

        public CarAddressBuilder AtAddress(string address)
        {
            Car.Address = address;
            return this;
        }
    }


    public class Example
    {
        public static void Main1(string[] args)
        {
            var car = new CarBuilder().Info
                .WithType(CarBodyType.SUV)
                .WithColor("red")
                .WithNoOfDoors(5)
                .Built.InCity("Delhi").AtAddress("Rohini")
                .Build();

            Console.WriteLine(car);
            Console.ReadLine();
        }
    }


}
